using EntityFramework.Exceptions;
using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View.BookView
{
    public class DeleteBookView
    {
        private IBookRepository bookRepository;

        public DeleteBookView(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите название");
                var name = Console.ReadLine();
                Console.WriteLine("Введите год издания");
                var year = uint.Parse(Console.ReadLine());

                Console.WriteLine("Введите Id автора книги");
                var authorId = int.Parse(Console.ReadLine());


                bookRepository.Delete(new Book { Name = name, PublishYear = year, AuthorId = authorId });
            }
            catch(BookNotFoundException)
            {
                Console.WriteLine("Ошибка! Книга с таким названием, годом выпуска и автором отсутствует в базе");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }

}
