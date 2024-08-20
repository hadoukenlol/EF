using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Author
    {
        /// <summary>
        /// Id автора
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя автора
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия автора
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Список книг автора
        /// </summary>
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
