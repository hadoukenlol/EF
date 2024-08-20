using EntityFramework.Models;

namespace EntityFramework.Repositories
{
    public interface IUserRepository
    {
        User FindById(int id);

        public List<User> FindAll();

        void Add(User user);

        void Delete(User user);

        void UpdateNameById(int id, string value);

        public void UpdateEmailById(int id, string value);

        public void GetBookFromLibrary(int userId, int bookId);

        public void ReturnBookToLibrary(int userId, int bookId);

        public List<Book> FindAllBooks(int userId);

        bool HasBookByNameAndAutorInUser(string name, int authorId , int userId);

    }
}