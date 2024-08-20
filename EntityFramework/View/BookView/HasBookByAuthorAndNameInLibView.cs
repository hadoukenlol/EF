using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View.BookView
{
    public class HasBookByAuthorAndNameInLibView
    {
        private IBookRepository bookRepository;

        public HasBookByAuthorAndNameInLibView(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Выберете способ определения автора: id, data");
                var type = Console.ReadLine();
                switch (type)
                {
                    case "id":
                        {
                            Console.WriteLine("Введите id автора");
                            var id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите название книги");
                            var bookName = Console.ReadLine();
                            var hasBook = bookRepository.HasBookByNameAndAutorInLib(bookName, id)
                                ? "Книга есть в библиотеке"
                                : "Книга отсутствует в библиотеке";
                            Console.WriteLine(hasBook);
                            break;
                        }
                    case "data":
                        {
                            Console.WriteLine("Введите имя автора");
                            var authorFirstName = Console.ReadLine();
                            Console.WriteLine("Введите фамилию автора");
                            var authorLastName = Console.ReadLine();
                            Console.WriteLine("Введите название книги");
                            var bookName = Console.ReadLine();
                            var hasBook = bookRepository.HasBookByNameAndAutorInLib(bookName, new Author { FirstName = authorFirstName, LastName = authorLastName }) 
                                ? "Книга есть в библиотеке" 
                                : "Книга отсутствует в библиотеке";
                            Console.WriteLine(hasBook);
                            break;
                        }

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}

