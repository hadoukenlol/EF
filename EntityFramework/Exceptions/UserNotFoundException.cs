using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Exceptions
{
    /// <summary>
    /// Исключение: пользователь с данным параметрами не найден в бд
    /// </summary>
    public class UserNotFoundException : Exception
    {
    }
}
