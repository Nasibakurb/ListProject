using ListProject.Domain.Enum;

namespace ListProject.Domain.Entity
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; } // статус выполнения
        public DateTime CreatedDate { get; set; }
        public Priority Priority { get; set; }

    }
}
