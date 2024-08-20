using EntityFramework.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace EntityFramework.View.BookView
{
    public class ShowAllBookView
    {
        private IBookRepository bookRepository;

        public ShowAllBookView(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            try
            {
                var books = bookRepository.FindAll();
                if (books.IsNullOrEmpty())
                {
                    Console.WriteLine("В базе нет ни одной книги");
                }
                foreach (var item in books)
                {
                    Console.WriteLine("Id: " + item.Id + ", Name: " + item.Name + ", Year Publisher: " + item.PublishYear);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }

}
