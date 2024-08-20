using EntityFramework.Models;

namespace EntityFramework.Repositories
{
    public interface IBookRepository
    {
        Book FindById(int id);

        public List<Book> FindAll(BookSortParams bookSortParams = BookSortParams.none, SortType sortType = SortType.ascending);

        public void Add(Book book);

        void Delete(Book book);

        void UpdateById(int id, string value);
        public List<Book> GetBooksByGenreAndDate(Genre genre, uint minYear, uint maxYear);

        bool HasBookByNameAndAutorInLib(string name, Author author);

        bool HasBookByNameAndAutorInLib(string name, int authorId);

        Book FindLastByYear();

    }
}