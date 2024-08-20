using EntityFramework.View.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.View.AuthorView
{
    public class AuthorMainView
    {
        private void ShowCommands()
        {
            Console.WriteLine();
            Console.WriteLine("Список команд для работы консоли:");
            Console.WriteLine(AuthorCommands.stop + ": прекращение работы с таблицей");
            Console.WriteLine(AuthorCommands.findById + ": найти автора по ID");
            Console.WriteLine(AuthorCommands.add + ": добавление автора");
            Console.WriteLine(AuthorCommands.delete + ": удаление автора");
            Console.WriteLine(AuthorCommands.showAllBooks + ": просмотр всех книг автора");
            Console.WriteLine(AuthorCommands.showAll + ": просмотр всех авторов");
            Console.WriteLine(AuthorCommands.countAuthorBooks + ": количество всех книг автора");

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
                    case nameof(AuthorCommands.stop):
                        return;
                    case nameof(AuthorCommands.findById):
                        Program.findAuthorView.Show();
                        break;
                    case nameof(AuthorCommands.add):
                        Program.addAuthorView.Show();
                        break;
                    case nameof(AuthorCommands.delete):
                        Program.deleteAuthorView.Show();
                        break;
                    case nameof(AuthorCommands.showAllBooks):
                        Program.ShowAllAuthorBooksView.Show();
                        break;
                    case nameof(AuthorCommands.countAuthorBooks):
                        Program.showCountBooksByAuthorsInLibraryView.Show();
                        break;
                    case nameof(AuthorCommands.showAll):
                        Program.ShowAllAuthorsView.Show();
                        break;
                    default:
                        Console.WriteLine("Введена неверная команда");
                        break;
                }

            } while (command != nameof(AuthorCommands.stop));

        }
    }

}
