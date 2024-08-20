using EntityFramework.Models;
using EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.View.UserView
{
    public class AddUserView
    {
        private IUserRepository userRepository;

        public AddUserView(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите имя пользователя");
                var name = Console.ReadLine();
                Console.WriteLine("Введите Email пользователя");
                var email = Console.ReadLine();

                userRepository.Add(new User { Email = email, Name = name, Books = new List<Book>() });
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message); 
            }

        }
    }


}
