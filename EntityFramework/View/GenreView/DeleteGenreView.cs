using EntityFramework.Exceptions;
using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View.GenreView
{
    public class DeleteGenreView
    {
        IGenreRepository genreRepository;
        public DeleteGenreView(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите название жанра");
                var name = Console.ReadLine();
                genreRepository.Delete(new Genre { Name = name, Books = new List<Book>() });
            }
            catch(GenreNotFoundException) 
            {
                Console.WriteLine("Ошибка! Жанр с таким названием не найден");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
