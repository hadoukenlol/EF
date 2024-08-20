using EntityFramework.Models;
using EntityFramework.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace EntityFramework.View.AuthorView
{
    public class ShowCountBooksByAuthorInLibraryView
    {
        private IAuthorRepository authorRepository;

        public ShowCountBooksByAuthorInLibraryView(IAuthorRepository authorRepository)
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
                var lastName = Console.ReadLine();
                var booksCount = authorRepository.GetCountBooksByAuthorInLibrary(new Author { FirstName = firstName, LastName = lastName });

                if (booksCount == 0)
                {
                    Console.WriteLine("В базе нет ни одной книги");
                }
                else
                    Console.WriteLine($"В базе {booksCount} книг {firstName} {lastName}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
