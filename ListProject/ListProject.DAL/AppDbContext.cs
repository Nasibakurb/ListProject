using ListProject.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ListProject.DAL
{
    public class AppDbContext : DbContext // Наследуем от DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated(); // Автоматич. создание дб
        }

        public DbSet<TaskEntity> Tasks { get; set; } // Создание сущности

        //protected override void OnModelCreating(ModelBuilder modelBuilder) // Настройки модели
        //{
        //    modelBuilder.Entity<TaskEntity>(builder =>
        //    {

        //    });
        //}
    }
}
