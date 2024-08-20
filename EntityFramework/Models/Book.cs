using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models
{
    public class Book
    {
        /// <summary>
        /// Id книги (первичный ключ)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название книги
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Год выпуска книги
        /// </summary>
        public uint PublishYear { get; set; }

        /// <summary>
        /// Количество книг
        /// </summary>
        public uint CountBookInLibrary { get; set; } = 10;
        
        /// <summary>
        /// Пользователь, на руках у которого находится книга
        /// </summary>
        public List<User> Users { get; set; } = new List<User>();

        /// <summary>
        /// Навигационное свойство id автора книги
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Автор книги
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// Список жанров произведения
        /// </summary>
        public List<Genre> Genres { get; set; } = new List<Genre>();
    }
}