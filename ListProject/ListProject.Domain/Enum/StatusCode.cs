using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListProject.Domain.Enum
{
    public enum StatusCode
    {
        Ok = 0,
        Error = 1,
        TaskNotFount = 10,
        TaskIsHasAlready = 300,
        InternalServerError = 500
    }
}
