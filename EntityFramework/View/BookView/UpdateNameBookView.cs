using EntityFramework.Exceptions;
using EntityFramework.Repositories;

namespace EntityFramework.View.BookView
{
    public class UpdateNameBookView
    {
        private IBookRepository bookRepository;

        public UpdateNameBookView(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите Id книги");
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите новое название");
                var name = Console.ReadLine();
                bookRepository.UpdateById(id, name);
            }
            catch (BookNotFoundException)
            {
                Console.WriteLine("Ошибка! Книга с таким id отсутствует в базе");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }

}
