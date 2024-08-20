using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View.GenreView
{
    public class AddGenreView
    {
        IGenreRepository genreRepository;
        public AddGenreView(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите название жанра");
                var name = Console.ReadLine();
                genreRepository.Add(new Genre { Name = name, Books = new List<Book>() });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
