using EntityFramework.Models;

namespace EntityFramework.Repositories
{
    public interface IGenreRepository
    {
        Genre FindById(int id);

        public List<Genre> FindAll();

        void Add(Genre genre);

        void Delete(Genre genre);

        public List<Book> FindAllBooks(int genreId);

        public uint GetCountBooksByGenreInLibrary(Genre genre);

    }

}