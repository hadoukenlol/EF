using EntityFramework.Exceptions;
using EntityFramework.Repositories;

namespace EntityFramework.View.UserView
{
    public class GetBookByUserView
    {
        private IUserRepository userRepository;

        public GetBookByUserView(IUserRepository userRepository)
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

                userRepository.GetBookFromLibrary(userId, bookId);
            }
            catch (UserNotFoundException)
            {
                Console.WriteLine("Ошибка! Пользователь с таким id отсутствует в базе");
            }
            catch (BookNotFoundException)
            {
                Console.WriteLine("Ошибка! Книга с таким id отсутствует в базе");
            }
            catch (NoBooksInLibraryException)
            {
                Console.WriteLine("Ошибка! Все экземпляры книги находятся на руках у других пользователей");
            }
            catch(UserHaveNotBookException)
            {
                Console.WriteLine("Ошибка! Книга с таким id не была взята пользователем");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
