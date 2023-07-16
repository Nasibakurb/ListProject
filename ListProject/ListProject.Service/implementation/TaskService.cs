using ListProject.DAL.Interfaces;
using ListProject.Domain.Entity;
using ListProject.Domain.Enum;
using ListProject.Domain.Resoonse;
using ListProject.Domain.ViewModel;
using ListProject.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListProject.Service.implementation
{ // Реализация интерфейса
    public class TaskService : ITaskService // Наследуемся от интерфейса
    {
        private ILogger<TaskService> _logger; // Журнал событий и состояния 
        private readonly IBaseRepository<TaskEntity> _taskRepository; // Интерфейс репозитор. методы (по умолчанию)

        public TaskService(IBaseRepository<TaskEntity> taskRepository, ILogger<TaskService> logger)
        { 
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<IBaseResponse<TaskEntity>>Create(CreateTaskViewModel model)
        { // Вернет IBaseResponse<TaskEntity> (ответ с сущностью)
            try
            {
                model.Validation(); // Валидация

                _logger.LogInformation($"Запрос на создание задачи: {model.Name}"); 

                var task = await _taskRepository.GetAll() // 1. Получить все элементы
                .Where(x => x.CreatedDate.Date == DateTime.Now) // 2. Найти элемент с определен. датой
                .FirstOrDefaultAsync(x => x.Name == model.Name); //3. Выбирается первый элемент с определ. именем

                if(task != null) // Если такая задача по дате и имене существует 
                {
                    return new BaseResponse<TaskEntity>() // Создается новый объект
                    {
                        Description = "Задача с таким названием уже есть", // Описание ошибки
                        StatusCode = StatusCode.TaskIsHasAlready // Код состоян. ошибки 
                    };
                } 
                // Если такая задача по дате и имене не существует 
                task = new TaskEntity() 
                { // Создается новый объект и заполняется свойствами 
                    Name = model.Name,
                    Description = model.Description,
                    IsDone = false,
                    Priority = model.Priority,
                    CreatedDate = DateTime.Now

                };
                await _taskRepository.Create(task); // Создание и сохранение
                
                _logger.LogInformation($"Данная задача создалась: {task.Name}"); // Журнал событий записывается

                return new BaseResponse<TaskEntity>()
                { // Возвр. объект с информацией 
                    Description = "Данная задача создалась",
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            { // Если произошла ошибка
                _logger.LogError(ex, $"[TaskService.Created]:{ex.Message}");
                return new BaseResponse<TaskEntity>()
                {
                    Description = $"Ошибка: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            
        }
    }
}
