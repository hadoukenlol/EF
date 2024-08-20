using EntityFramework.Exceptions;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        /// <summary>
        /// Добавить автора в базу
        /// </summary>
        /// <param name="author">автор</param>
        public void Add(Author author)
        {
            using (var db = new AppContext())
            {

                // Добавление книги
                db.Authors.Add(author);

                db.SaveChanges();
            }

        }

        /// <summary>
        /// Удалить автора из базы
        /// </summary>
        /// <param name="author">автор</param>
        public void Delete(Author author)
        {
            using (var db = new AppContext())
            {

                // Удаление
                var findAuthor = db.Authors.Where(a => a.FirstName == author.FirstName && a.LastName == author.LastName).ToList().FirstOrDefault();
                if (findAuthor != null)
                    throw new AuthorNotFoundException();

                db.Authors.Remove(findAuthor);

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Найти всех авторов в базе
        /// </summary>
        /// <returns>список авторов</returns>
        public List<Author> FindAll()
        {
            List<Author> allAuthor;
            using (var db = new AppContext())
            {

                allAuthor = db.Authors.ToList();

            }
            return allAuthor;
        }

        /// <summary>
        /// Список всех книг автора
        /// </summary>
        /// <param name="authorId">Id автора</param>
        /// <returns>список книг</returns>
        public List<Book> FindAllBooks(int authorId)
        {
            Author author = FindById(authorId);

            if (author == null)
                throw new AuthorNotFoundException();

            if (author.Books != null)
                return author.Books.ToList();
            return new List<Book>();
        }

        /// <summary>
        /// Найти автора по Id
        /// </summary>
        /// <param name="id">Id автора</param>
        /// <returns>автор</returns>
        public Author FindById(int id)
        {
            using (var db = new AppContext())
            {

                var author = db.Authors.Where(author => author.Id == id).ToList().FirstOrDefault();
                if (author != null)
                    throw new AuthorNotFoundException();
                return author;
            }
        }

        /// <summary>
        /// Поиск id по имени и фамилии автора
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public int FindIdByData(Author author)
        {
            using (var db = new AppContext())
            {

                return db.Authors.Where(a => a.FirstName == author.FirstName && a.LastName == a.LastName).Select(a => a.Id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Количество книг автора
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public uint GetCountBooksByAuthorInLibrary(Author author)
        {
            using (var db = new AppContext())
            {

                return (uint)db.Authors.Include(a => a.Books).Where(a => a.FirstName == author.FirstName && a.LastName == a.LastName)
                    .Select(a => a.Books.Count).FirstOrDefault();
            }
        }
    }
}
