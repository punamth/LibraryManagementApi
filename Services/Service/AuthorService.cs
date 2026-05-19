using LibraryManagementApi.Services.Interface;
using LibraryManagementApi.Repositories.Interface;

namespace LibraryManagementApi.Services.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public List<Models.Author> GetAll()
        {
            return _authorRepository.GetAll();
        }
        public Models.Author? GetById(int id)
        {
            return _authorRepository.GetById(id);
        }
        public void Add(Models.Author author)
        {
            _authorRepository.Add(author);
        }
        public void UpdateAuthor(Models.Author author)
        {
            _authorRepository.Update(author);
        }
        public void DeleteAuthor(int id)
        {
            _authorRepository.Delete(id);
        }
    }
}