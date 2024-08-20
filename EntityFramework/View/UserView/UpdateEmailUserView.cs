using EntityFramework.Exceptions;
using EntityFramework.Repositories;

namespace EntityFramework.View.UserView
{
    public class UpdateEmailUserView
    {
        private IUserRepository userRepository;

        public UpdateEmailUserView(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите Id пользователя");
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите новый email");
                var email = Console.ReadLine();
                userRepository.UpdateEmailById(id, email);
            }
            catch(UserNotFoundException)
            {
                Console.WriteLine("Ошибка! Пользователь с таким id отсутствует в базе");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }

}
