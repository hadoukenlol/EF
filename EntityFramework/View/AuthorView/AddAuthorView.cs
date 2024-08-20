using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View.AuthorView
{
    public class AddAuthorView
    {
        IAuthorRepository authorRepository;
        public AddAuthorView(IAuthorRepository authorRepository)
        {
                this.authorRepository = authorRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите имя автора");
                var firstName = Console.ReadLine();
                Console.WriteLine("Введите фамилию автора");
                var LastName = Console.ReadLine();
                authorRepository.Add(new Author { FirstName = firstName, LastName = LastName, Books = new List<Book>() });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
