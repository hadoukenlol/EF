using EntityFramework.Exceptions;
using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View.BookView
{
    public class FindBookView
    {
        private IBookRepository bookRepository;

        public FindBookView(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите Id пользователя");
                var id = int.Parse(Console.ReadLine());
                Book book = bookRepository.FindById(id);
                Console.WriteLine("Id: " + book.Id + ", Name: " + book.Name + ", Publish Year: " + book.PublishYear);
            }
            catch (BookNotFoundException)
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
