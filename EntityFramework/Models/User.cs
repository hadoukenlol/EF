namespace EntityFramework.Models
{
    public class User
    {
        /// <summary>
        /// Id пользователя (первичный ключ)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// E-mail пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Список книг, находящихся на руках у пользователя
        /// </summary>
        public List<Book> Books { get; set; } = new List<Book>();
    }
}