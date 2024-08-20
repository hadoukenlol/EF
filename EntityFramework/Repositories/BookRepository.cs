using EntityFramework.Exceptions;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace EntityFramework.Repositories
{
    public class BookRepository : IBookRepository
    {
        /// <summary>
        /// Добавление книги в бд
        /// </summary>
        /// <param name="book">модель книги</param>
        public void Add(Book book)
        {
            using (var db = new AppContext())
            {
                //вытаскиваем жанры отдельно
                var genres = book.Genres.ToList();
                book.Genres = new List<Genre>();

                // Добавление книги
                db.Books.Add(book);
                db.SaveChanges();

                //добавление жанров
                var findGenres = db.Books.Include(b => b.Genres).Where(b => b.Name == book.Name && b.PublishYear == book.PublishYear && b.AuthorId == book.AuthorId).ToList().FirstOrDefault().Genres;
                findGenres.AddRange(genres);

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удаление книги из бд
        /// </summary>
        /// <param name="book">модель книги</param>
        public void Delete(Book book)
        {
            using (var db = new AppContext())
            {

                var findBook = db.Books.Where(b => b.Name == book.Name && b.PublishYear == book.PublishYear && b.AuthorId == book.AuthorId).ToList().FirstOrDefault();
                if (findBook != null)
                    throw new BookNotFoundException();

                db.Books.Remove(findBook);

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Поиск всех книг в бд с сортировкой
        /// </summary>
        /// <param name="bookSortParams">Параметр сортировки</param>
        /// <param name="sortType">Тип сортировки</param>
        /// <returns>Список книг</returns>
        public List<Book> FindAll(BookSortParams bookSortParams = BookSortParams.none, SortType sortType = SortType.ascending)
        {
            List<Book> allBooks;
            using (var db = new AppContext())
            {
                switch(bookSortParams)
                {
                    case BookSortParams.bookName:
                        if(sortType == SortType.ascending)
                            allBooks = db.Books.OrderBy(b => b.Name).ToList();
                        else
                            allBooks = db.Books.OrderByDescending(b => b.Name).ToList();
                        break;
                    case BookSortParams.bookPuplishYear:
                        if (sortType == SortType.ascending)
                            allBooks = db.Books.OrderBy(b => b.PublishYear).ToList();
                        else
                            allBooks = db.Books.OrderByDescending(b => b.PublishYear).ToList();
                        break;
                    default:
                        allBooks = db.Books.ToList();
                        break;
                }
            }
            return allBooks;
        }

        /// <summary>
        /// Найти книгу по Id
        /// </summary>
        /// <param name="id">Id книги</param>
        /// <returns></returns>
        public Book FindById(int id)
        {
            using (var db = new AppContext())
            {

                Book book = db.Books.Where(b => b.Id == id).FirstOrDefault();
                if (book != null)
                    throw new BookNotFoundException();
                return book;
            }
        }

        /// <summary>
        /// Обновить название книги по Id
        /// </summary>
        /// <param name="id">Id книги</param>
        /// <param name="value">Новое название книги</param>
        public void UpdateById(int id, string value)
        {
            using (var db = new AppContext())
            {

                var book = db.Books.Where(u => u.Id == id).ToList().FirstOrDefault();
                if (book != null)
                    throw new BookNotFoundException();

                book.Name = value;

                db.SaveChanges();

            }
        }

        /// <summary>
        /// Получает список книг определенного жанра и вышедших между определенными годами
        /// </summary>
        /// <param name="genre">жанр книги</param>
        /// <param name="minYear">минимальный год выпуска</param>
        /// <param name="maxYear">максимальный год выпуска</param>
        /// <returns></returns>
        public List<Book> GetBooksByGenreAndDate(Genre genre, uint minYear, uint maxYear)
        {
            using (var db = new AppContext())
            {

                return db.Books.Include(b => b.Genres)
                    .Where(b => b.Genres.Contains(genre) && b.PublishYear >= minYear && b.PublishYear <= maxYear)
                    .ToList();

            }
        }

        /// <summary>
        /// Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке
        /// </summary>
        /// <param name="name">название книги</param>
        /// <param name="author">автор книг</param>
        /// <returns>
        ///     true  - книга есть в библиотеке
        ///     false - книга отсутствует в библиотеке
        /// </returns>
        public bool HasBookByNameAndAutorInLib(string name, Author author)
        {
            using (var db = new AppContext())
            {

                var books = db.Books.Include(b => b.Author)
                    .Where(b => b.Author.FirstName == author.FirstName && b.Author.LastName == author.LastName && b.Name == name).FirstOrDefault().CountBookInLibrary;
                return books > 0;
            }
        }

        /// <summary>
        /// Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке
        /// </summary>
        /// <param name="name">название книги</param>
        /// <param name="authorId">id авторa книг</param>
        /// <returns>
        ///     true  - книга есть в библиотеке
        ///     false - книга отсутствует в библиотеке
        /// </returns>
        public bool HasBookByNameAndAutorInLib(string name, int authorId)
        {
            using (var db = new AppContext())
            {

                var books = db.Books.Include(b => b.Author)
                    .Where(b => b.AuthorId == authorId && b.Name == name).FirstOrDefault().CountBookInLibrary;
                return books > 0;
            }
        }

        /// <summary>
        /// находит последнюю по году книгу
        /// </summary>
        /// <returns></returns>
        public Book FindLastByYear()
        {
            using (var db = new AppContext())
            {
                return db.Books.OrderByDescending(b => b.PublishYear).FirstOrDefault();
            }
        }
    }
}
