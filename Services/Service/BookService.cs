using LibraryManagementApi.Services.Interface;
using LibraryManagementApi.Repositories.Interface;

namespace LibraryManagementApi.Services.Service
{ 
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public void AddBook(Models.Book book)
        {
            _bookRepository.Add(book);
        }
        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }
        public List<Models.Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }
        public Models.Book? GetBookById(int id)
        {
            return _bookRepository.GetById(id);
        }
        public void UpdateBook(Models.Book book)
        {
            _bookRepository.Update(book);
        }
    }
}