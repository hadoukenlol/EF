using EntityFramework.Exceptions;
using EntityFramework.View.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.View.UserView
{
    public class UserMainView
    {
        private void ShowCommands()
        {
            Console.WriteLine();
            Console.WriteLine("Список команд для работы консоли:");
            Console.WriteLine(UserCommands.stop + ": прекращение работы с таблицей");
            Console.WriteLine(UserCommands.findById + ": найти пользователя по ID");
            Console.WriteLine(UserCommands.add + ": добавление пользователя");
            Console.WriteLine(UserCommands.delete + ": удаление пользователя");
            Console.WriteLine(UserCommands.updateName + ": обновление имени пользователя по Id");
            Console.WriteLine(UserCommands.updateEmail + ": обновление Email пользователя по Id");
            Console.WriteLine(UserCommands.getBook + ": получить книгу из библиотеки по Id пользователя и Id книги");
            Console.WriteLine(UserCommands.returnBook + ": вернуть книгу в библиотеку по Id пользователя и Id книги");
            Console.WriteLine(UserCommands.showAllBooks + ": просмотреть список всех книг, взятых пользователем из библиотеки, по Id пользователя");
            Console.WriteLine(UserCommands.showAll + ": просмотр всех пользователей");
            Console.WriteLine(UserCommands.countBook + ": количество книг на руках у пользователя");

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
                    case nameof(UserCommands.stop):
                        return;
                    case nameof(UserCommands.findById):
                        Program.findUserView.Show();
                        break;
                    case nameof(UserCommands.add):
                        Program.addUserView.Show();
                        break;
                    case nameof(UserCommands.delete):
                        Program.deleteUserView.Show();
                        break;
                    case nameof(UserCommands.updateName):
                        Program.updateNameUserView.Show();
                        break;
                    case nameof(UserCommands.updateEmail):
                        Program.updateEmailUserView.Show();
                        break;
                    case nameof(UserCommands.getBook):
                        Program.getBookByUserView.Show();
                        break;
                    case nameof(UserCommands.returnBook):
                        Program.returnBookByUserView.Show();
                        break;
                    case nameof(UserCommands.showAllBooks):
                        Program.showAllUserBooksView.Show();
                        break;
                    case nameof(UserCommands.showAll):
                        Program.showAllUserView.Show();
                        break;
                    case nameof(UserCommands.countBook):
                        Program.showAllUserView.Show();
                        break;
                    default:
                        Console.WriteLine("Введена неверная команда");
                        break;
                }
            } while (command != nameof(UserCommands.stop));



        }
    }

}
