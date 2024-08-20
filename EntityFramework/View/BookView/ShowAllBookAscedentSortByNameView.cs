using EntityFramework.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace EntityFramework.View.BookView
{
    public class ShowAllBookAscedentSortByNameView
    {
        private IBookRepository bookRepository;

        public ShowAllBookAscedentSortByNameView(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            try
            {
                var books = bookRepository.FindAll(bookSortParams: BookSortParams.bookName, sortType: SortType.ascending);
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
    public class ShowLastPublisherBooksView
    {
        private IBookRepository bookRepository;

        public ShowLastPublisherBooksView(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            try
            {
                var book = bookRepository.FindAll(bookSortParams: BookSortParams.bookName, sortType: SortType.ascending);
                if (book.IsNullOrEmpty())
                {
                    Console.WriteLine("В базе нет ни одной книги");
                }
                foreach (var item in book)
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
