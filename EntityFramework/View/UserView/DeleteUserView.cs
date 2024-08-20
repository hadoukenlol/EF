using EntityFramework.Exceptions;
using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View.UserView
{
    public class DeleteUserView
    {
        private IUserRepository userRepository;

        public DeleteUserView(IUserRepository userRepository)
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

                userRepository.Delete(new User { Email = email, Name = name });
            }
            catch (UserNotFoundException)
            {
                Console.WriteLine("Ошибка! Пользователь с такими именем и фамилией отсутствует в базе");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }

}
