using EntityFramework.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace EntityFramework.View.GenreView
{
    public class ShowAllGenreView
    {
        IGenreRepository genreRepository;
        public ShowAllGenreView(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }
        public void Show()
        {
            try
            {
                var genres = genreRepository.FindAll();
                if (genres.IsNullOrEmpty())
                {
                    Console.WriteLine("В базе нет ни одного жанра");
                }
                foreach (var item in genres)
                {
                    Console.WriteLine("Id: " + item.Id + ", Name: " + item.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }

}
