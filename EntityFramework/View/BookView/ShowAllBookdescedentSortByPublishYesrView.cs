using EntityFramework.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace EntityFramework.View.BookView
{
    public class ShowAllBookdescedentSortByPublishYesrView
    {
        private IBookRepository bookRepository;

        public ShowAllBookdescedentSortByPublishYesrView(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            try
            {
                var books = bookRepository.FindAll(bookSortParams: BookSortParams.bookPuplishYear, sortType: SortType.descending );
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
