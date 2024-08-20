using EntityFramework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.View
{
    public class MainView
    {
        enum Tables
        {
            books,
            users,
            authors,
            genres

        }

        public void Show()
        {
            Console.Write("Выберите таблицу для работы: ");

            var table = Console.ReadLine();
            Console.WriteLine();
            switch (table)
            {
                case nameof(Tables.users):
                    Program.userMainView.Show();
                    break;
                case nameof(Tables.books):
                    Program.bookMainView.Show();
                    break;
                case nameof(Tables.authors):
                    Program.authorMainView.Show();
                    break;
                case nameof(Tables.genres):
                    Program.genreMainView.Show();
                    break;
                default:
                    throw new EnteredTableException();
            }


        }
    }
}
