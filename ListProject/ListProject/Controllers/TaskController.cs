using ListProject.Domain.ViewModel;
using ListProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ListProject.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        // Для использование методов
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskViewModel model)
        {
            var response = await _taskService.Create(model);

            if (response.StatusCode == Domain.Enum.StatusCode.Ok) // Если объект создался
            { // Метод "ок" с объектом json c содерж. описание 
                return Ok(new {description = response.Description });
            } // В противном случаи
            return BadRequest(new {description = response.Description });
        }

    }
}