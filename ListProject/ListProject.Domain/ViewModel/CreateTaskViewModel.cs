using ListProject.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListProject.Domain.ViewModel
{
    public class CreateTaskViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }


        public void Validation()
        {
            if (string.IsNullOrWhiteSpace(Name)) // Пустая строка
            {
                throw new ArgumentNullException(Name, "Укажите название задачи, пожалуйста");
            }
            if (string.IsNullOrWhiteSpace(Description)) // Пустая строка
            {
                throw new ArgumentNullException(Description, "Укажите описание задачи, пожалуйста");
            }
        }

    }
}
