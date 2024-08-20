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
    public class GenreRepository : IGenreRepository
    {
        public void Add(Genre genre)
        {
            using (var db = new AppContext())
            {

                // Добавление книги
                db.Genres.Add(genre);

                db.SaveChanges();
            }

        }

        public void Delete(Genre genre)
        {
            using (var db = new AppContext())
            {

                // Удаление
                var findGenre = db.Genres.Where(g => g.Name == genre.Name).ToList().FirstOrDefault();
                if (findGenre != null)
                    throw new GenreNotFoundException();
                db.Genres.Remove(findGenre);

                db.SaveChanges();
            }
        }

        public List<Genre> FindAll()
        {
            List<Genre> allGenre;
            using (var db = new AppContext())
            {

                allGenre = db.Genres.ToList();

            }
            return allGenre;
        }

        public List<Book> FindAllBooks(int genreId)
        {
            Genre genre = FindById(genreId);
            if (genre.Books != null)
                return genre.Books.ToList();
            return new List<Book>();
        }

        public Genre FindById(int id)
        {
            using (var db = new AppContext())
            {

                var genre = db.Genres.Include(g => g.Books).Where(genre => genre.Id == id).FirstOrDefault();
                if (genre != null)
                    throw new GenreNotFoundException();
                return genre;
            }
        }

        public uint GetCountBooksByGenreInLibrary(Genre genre)
        {
            using (var db = new AppContext())
            {

                return (uint)db.Genres.Include(g => g.Books).Where(a => a.Name == genre.Name)
                    .Select(a => a.Books.Count).FirstOrDefault();
            }
        }
    }
}
