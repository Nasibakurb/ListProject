using ListProject.DAL.Interfaces;
using ListProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListProject.DAL.Repositories
{
    public class TaskRepository : IBaseRepository<TaskEntity> // Указываем точную модель 
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        { // Запросы к Дб через AppDbContext (DbContext)
            _context = context;
        }

        public async Task Create(TaskEntity entity)
        {
            await _context.Tasks.AddAsync(entity); // Tasks - созданная сущность в AppDbContext
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TaskEntity entity)
        {
            _context.Tasks.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TaskEntity> GetAll()
        {
            return _context.Tasks; // Возвращаем сущность созданную в AppDbContext
        }

        public async Task<TaskEntity> Update(TaskEntity entity)
        {
            _context.Tasks.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
