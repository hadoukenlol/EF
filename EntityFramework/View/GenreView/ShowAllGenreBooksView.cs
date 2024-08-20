using EntityFramework.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace EntityFramework.View.GenreView
{
    public class ShowAllGenreBooksView
    {
        IGenreRepository genreRepository;
        public ShowAllGenreBooksView(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите id жанра");
                var id = int.Parse(Console.ReadLine());

                var books = genreRepository.FindAllBooks(id);
                if (books.IsNullOrEmpty())
                {
                    Console.WriteLine("В базе нет ни одной книги данного жанра");
                }
                foreach (var item in books)
                {
                    Console.WriteLine("Id: " + item.Id + ", Name: " + item.Name + ", Publish year: " + item.PublishYear);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
