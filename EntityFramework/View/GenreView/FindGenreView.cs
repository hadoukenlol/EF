using EntityFramework.Exceptions;
using EntityFramework.Repositories;

namespace EntityFramework.View.GenreView
{
    public class FindGenreView
    {
        IGenreRepository genreRepository;
        public FindGenreView(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите Id жанра");
                var id = int.Parse(Console.ReadLine());
                genreRepository.FindById(id);
            }
            catch (GenreNotFoundException)
            {
                Console.WriteLine("Ошибка! Жанр с таким Id не найден");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
