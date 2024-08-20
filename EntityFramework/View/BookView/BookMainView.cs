using EntityFramework.Exceptions;
using EntityFramework.View.Helper;

namespace EntityFramework.View.BookView
{
    public class BookMainView
    {
        private void ShowCommands()
        {
            Console.WriteLine();
            Console.WriteLine("Список команд для работы консоли:");
            Console.WriteLine(BookCommands.stop + ": прекращение работы с таблицей");
            Console.WriteLine(BookCommands.findById + ": найти книгу по ID");
            Console.WriteLine(BookCommands.add + ": добавление книги");
            Console.WriteLine(BookCommands.delete + ": удаление книги");
            Console.WriteLine(BookCommands.updateName + ": обновление названия книги по Id");
            Console.WriteLine(BookCommands.showAll + ": просмотр всех книг");
            Console.WriteLine(BookCommands.hasBookByNameAndAuthorInLib + ": есть ли книга определенного автора и с определенным названием в библиотеке");
            Console.WriteLine(BookCommands.showLast + ": показать последнюю вышедшую книгу");
            Console.WriteLine(BookCommands.showAllAscSortByName + ": список всех книг, отсортированного в алфавитном порядке по названию");
            Console.WriteLine(BookCommands.showAllDescSortByPublishYear + ": список всех книг, отсортированного в порядке убывания года их выхода");

            Console.WriteLine();
            Console.WriteLine("Введите команду: ");
        }
        public void Show()
        {
            string command;
            do
            {
                ShowCommands();
                command = Console.ReadLine();
                switch (command)
                {
                    case nameof(BookCommands.stop):
                        return;
                    case nameof(BookCommands.findById):
                        Program.findBookView.Show();
                        break;
                    case nameof(BookCommands.add):
                        Program.addBookView.Show();
                        break;
                    case nameof(BookCommands.delete):
                        Program.deleteBookView.Show();
                        break;
                    case nameof(BookCommands.updateName):
                        Program.updateNameBookView.Show();
                        break;
                    case nameof(BookCommands.showAll):
                        Program.showAllBookView.Show();
                        break;
                    case nameof(BookCommands.hasBookByNameAndAuthorInLib):
                        Program.hasBookByAuthorAndNameInLibView.Show();
                        break;
                    case nameof(BookCommands.showAllAscSortByName):
                        Program.showAllBookAscedentSortByNameView.Show();
                        break;
                    case nameof(BookCommands.showAllDescSortByPublishYear):
                        Program.showAllBookdescedentSortByPublishYesrView.Show();
                        break;
                    case nameof(BookCommands.showLast):
                        Program.showLastPublisherBooksView.Show();
                        break;
                    default:
                        Console.WriteLine("Введена неверная команда");
                        return;
                }
            } while (command != nameof(BookCommands.stop));



        }
    }
}
