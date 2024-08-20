using EntityFramework.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace EntityFramework.View.AuthorView
{
    public class ShowAllAuthorsView
    {
        IAuthorRepository authorRepository;
        public ShowAllAuthorsView(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        public void Show()
        {
            try
            {
                var authors = authorRepository.FindAll();
                if (authors.IsNullOrEmpty())
                {
                    Console.WriteLine("В базе нет ни одного автора");
                }
                foreach (var item in authors)
                {
                    Console.WriteLine("Id: " + item.Id + ", First name: " + item.FirstName + ", Last name: " + item.LastName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
