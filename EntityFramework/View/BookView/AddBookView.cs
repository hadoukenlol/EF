using EntityFramework.Exceptions;
using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View.BookView
{
    public class AddBookView
    {
        private IBookRepository bookRepository;
        private IGenreRepository genreRepository;

        public AddBookView(IBookRepository bookRepository, IGenreRepository genreRepository)
        {
            this.bookRepository = bookRepository;
            this.genreRepository = genreRepository;

        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите название");
                var name = Console.ReadLine();
                Console.WriteLine("Введите год издания");
                var year = uint.Parse(Console.ReadLine());

                Console.WriteLine("Введите Id автора книги");
                var authorId = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите id жанра книги через запятую");

                var genreIds = Console.ReadLine().Split(",").ToList();
                var genres = new List<Genre>();

                foreach (var genreId in genreIds)
                {
                    var tempGenreId = int.Parse(genreId);
                    genres.Add(genreRepository.FindById(tempGenreId));
                }

                var book = new Book { Name = name, PublishYear = year, Users = new List<User>(), AuthorId = authorId, Genres = genres };
                bookRepository.Add(book);

            }
            catch (GenreNotFoundException)
            {
                Console.WriteLine("Ошибка! Список id жанров некорректен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




        }
    }

}
