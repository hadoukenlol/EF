using EntityFramework.Exceptions;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repositories
{
    public class UserRepository : IUserRepository
    {
        IBookRepository bookRepository;

        public UserRepository(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        /// <param name="user">пользователь для добавления</param>
        public void Add(User user)
        {
            using (var db = new AppContext())
            {

                // Добавление одиночного пользователя
                db.Users.Add(user);

                db.SaveChanges();
            }

        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="user">пользователь для удаления</param>
        public void Delete(User user)
        {
            using (var db = new AppContext())
            {

                var findUser = db.Users.Where(u => u.Name == user.Name && u.Email == user.Email).ToList().FirstOrDefault();
                if (findUser != null)
                {
                    throw new UserNotFoundException();
                }
                db.Users.Remove(findUser);

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Поиск всех пользователей
        /// </summary>
        /// <returns></returns>
        public List<User> FindAll()
        {
            List<User> allUsers;
            using (var db = new AppContext())
            {

                allUsers = db.Users.ToList();

            }
            return allUsers;
        }

        /// <summary>
        /// Поиск пользователя по id
        /// </summary>
        /// <param name="id">id пользователя</param>
        /// <returns></returns>
        public User FindById(int id)
        {
            using (var db = new AppContext())
            {

                var user = db.Users.Include(u => u.Books).Where(user => user.Id == id).ToList().FirstOrDefault();
                if (user != null)
                    throw new UserNotFoundException();
                return user;
            }


        }

        /// <summary>
        /// Обновление имени пользователя по ID
        /// </summary>
        /// <param name="id">id пользователя</param>
        /// <param name="value">Новое имя</param>
        public void UpdateNameById(int id, string value)
        {
            using (var db = new AppContext())
            {

                var user = db.Users.Where(u => u.Id == id).ToList().FirstOrDefault();
                user.Name = value;

                db.SaveChanges();

            }
        }

        /// <summary>
        /// Обновление Email пользователя по ID
        /// </summary>
        /// <param name="id">id пользователя</param>
        /// <param name="value">Новый Email</param>
        public void UpdateEmailById(int id, string value)
        {
            using (var db = new AppContext())
            {

                var user = db.Users.Where(u => u.Id == id).ToList().FirstOrDefault();
                if (user != null)
                    throw new UserNotFoundException();
                user.Email = value;

                db.SaveChanges();

            }
        }

        /// <summary>
        /// Взять книгу из библиотеки
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="bookId">Id книги</param>
        public void GetBookFromLibrary(int userId, int bookId)
        {


            using (var db = new AppContext())
            {
                Book book = db.Books.Where(b => b.Id == bookId).ToList().FirstOrDefault();
                if (book == null)
                    throw new BookNotFoundException();

                if (book.CountBookInLibrary == 0)
                    throw new NoBooksInLibraryException();

                User user = db.Users.Include(u => u.Books).Where(user => user.Id == userId).ToList().FirstOrDefault();

                if(user == null)
                    throw new UserNotFoundException();

                book.CountBookInLibrary--;
                user.Books.Add(book);
                db.SaveChanges();


            }
        }

        /// <summary>
        /// Вернуть книгу в библиотеку
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="bookId">Id книги</param>
        public void ReturnBookToLibrary(int userId, int bookId)
        {

            using (var db = new AppContext())
            {
                Book book = db.Books.Include(b => b.Users).Where(book => book.Id == bookId).ToList().FirstOrDefault();
                
                if (book == null)
                    throw new BookNotFoundException();

                User user = db.Users.Include(u => u.Books).Where(user => user.Id == userId).ToList().FirstOrDefault();
                
                if (user == null)
                    throw new UserNotFoundException();

                if (!user.Books.Contains(book))
                    throw new UserHaveNotBookException();

                user.Books.Remove(book);
                book.CountBookInLibrary++;
                db.SaveChanges();

            }
        }


        /// <summary>
        /// Получить список книг, которые находятся у пользователя на руках
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Book> FindAllBooks(int userId)
        {
            User user = FindById(userId);
            if (user.Books != null)
                return user.Books.ToList();
            return new List<Book>();
        }


        public bool HasBookByNameAndAutorInUser(string name, int authorId, int userId)
        {
            using (var db = new AppContext())
            {
                var countBooks = db.Users.Include(u => u.Books).Where(u => u.Id == userId).FirstOrDefault().Books.Where(b => b.Name == name && b.AuthorId == authorId).Count();

                return countBooks > 0;
            }
        }
     }
}
