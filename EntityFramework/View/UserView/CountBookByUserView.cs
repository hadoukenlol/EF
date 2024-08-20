using EntityFramework.Exceptions;
using EntityFramework.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace EntityFramework.View.UserView
{
    public class CountBookByUserView
    {
        private IUserRepository userRepository;

        public CountBookByUserView(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите Id пользователя");
                var userId = int.Parse(Console.ReadLine());
                var booksCount = userRepository.FindAllBooks(userId).Count;
                Console.WriteLine("На руках у пользователя " + booksCount + " книг");
            }
            catch (UserNotFoundException)
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
