using ListProject.Domain.Resoonse;
using ListProject.Domain.ViewModel;
using ListProject.Domain.Entity;
using NPOI.SS.Formula.Functions;

namespace ListProject.Service.Interfaces
{
    public interface ITaskService
    {
        Task<IBaseResponse<TaskEntity>> Create(CreateTaskViewModel model);
    }
}
