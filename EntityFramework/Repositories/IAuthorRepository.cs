using EntityFramework.Models;

namespace EntityFramework.Repositories
{
    public interface IAuthorRepository
    {
        Author FindById(int id);

        public List<Author> FindAll();

        void Add(Author author);

        void Delete(Author author);

        public List<Book> FindAllBooks(int userId);

        public int FindIdByData(Author author);

        public uint GetCountBooksByAuthorInLibrary(Author author);

    }

}