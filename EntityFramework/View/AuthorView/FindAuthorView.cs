using EntityFramework.Exceptions;
using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View.AuthorView
{
    public class FindAuthorView
    {
        IAuthorRepository authorRepository;
        public FindAuthorView(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        public void Show()
        {
            try
            {
                Console.WriteLine("Введите Id автора");
                var id = int.Parse(Console.ReadLine());
                var author = authorRepository.FindById(id);
                Console.WriteLine(author.FirstName + " " + author.LastName);
            }
            catch (AuthorNotFoundException)
            {
                Console.WriteLine("Ошибка! Автор с таким id отсутствует в базе");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
