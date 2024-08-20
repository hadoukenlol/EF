using EntityFramework.Exceptions;
using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View.UserView
{
    public class FindUserView
    {
        private IUserRepository userRepository;

        public FindUserView(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите Id пользователя");
                var id = int.Parse(Console.ReadLine());
                User user = userRepository.FindById(id);
                Console.WriteLine("Id: " + user.Id + ", Name: " + user.Name + ", Email: " + user.Email);

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
