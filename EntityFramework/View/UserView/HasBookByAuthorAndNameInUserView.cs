using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View.UserView
{
    public class HasBookByAuthorAndNameInUserView
    {
        private IUserRepository userRepository;

        public HasBookByAuthorAndNameInUserView(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите id автора");
                var authorId = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите id пользователя");
                var userId = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите название книги");
                var bookName = Console.ReadLine();
                var hasBook = userRepository.HasBookByNameAndAutorInUser(bookName, authorId, userId)
                    ? "Книга есть на руках у пользователя"
                    : "Книга отсутсвует на руках у пользователя";
                Console.WriteLine(hasBook);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
