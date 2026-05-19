using LibraryManagementApi.Models;

namespace LibraryManagementApi.Repositories.Interface
{
    public interface IBookRepository
    {
        public List<Book> GetAll();
        public Book? GetById(int id);
        public void Add(Book book);
        public void Delete(int id);
        public void Update(Book book);
    }
}