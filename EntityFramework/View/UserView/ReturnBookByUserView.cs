using EntityFramework.Exceptions;
using EntityFramework.Repositories;

namespace EntityFramework.View.UserView
{
    public class ReturnBookByUserView
    {
        private IUserRepository userRepository;

        public ReturnBookByUserView(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите Id пользователя");
                var userId = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите Id книги");
                var bookId = int.Parse(Console.ReadLine());

                userRepository.ReturnBookToLibrary(userId, bookId);

            }
            catch (UserNotFoundException)
            { 
                Console.WriteLine("Ошибка! Пользователь с таким id отсутствует в базе");
            }
            catch(BookNotFoundException)
            {
                Console.WriteLine("Ошибка! Книга с таким id отсутствует в базе");
            }
        }
    }

}
