using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View.GenreView
{
    public class ShowCountBooksByGenreInLibraryView
    {
        private IGenreRepository genreRepository;

        public ShowCountBooksByGenreInLibraryView(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите назание жанра");
                var name = Console.ReadLine();
                var booksCount = genreRepository.GetCountBooksByGenreInLibrary(new Genre { Name = name});

                if (booksCount == 0)
                {
                    Console.WriteLine("В базе нет ни одной книги");
                }
                else
                    Console.WriteLine($"В базе {booksCount} книг в жанре {name} ");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
