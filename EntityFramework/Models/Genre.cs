using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Genre
    {
        /// <summary>
        /// Id жанра
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название жанра
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список книг в жанре
        /// </summary>
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
