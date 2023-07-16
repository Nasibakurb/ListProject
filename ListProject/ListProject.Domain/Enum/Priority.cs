using System.ComponentModel.DataAnnotations;

namespace ListProject.Domain.Enum
{
    public enum Priority
    {
        [Display (Name = "Легкая")]
        Easy = 1,
        [Display(Name = "Средняя")]
        Medium = 2,
        [Display(Name = "Тяжелая")]
        Hard = 3

    }
}
