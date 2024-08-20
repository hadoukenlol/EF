using EntityFramework.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace EntityFramework.View.UserView
{
    public class ShowAllUserView
    {
        private IUserRepository userRepository;

        public ShowAllUserView(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            var users = userRepository.FindAll();
            if (users.IsNullOrEmpty())
            {
                Console.WriteLine("В базе нет ни одного пользователя");
            }
            foreach (var item in users)
            {
                Console.WriteLine("Id: " + item.Id + ", Name: " + item.Name + ", Email: " + item.Email);
            }




        }
    }

}
