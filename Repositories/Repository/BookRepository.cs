using LibraryManagementApi.Data;
using LibraryManagementApi.Repositories.Interface;

namespace LibraryManagementApi.Repositories.Repository
{ 
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;
        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public List<Models.Book> GetAll()
        {
            return _context.Books.Where(b => !b.IsDeleted).ToList();
        }
        public Models.Book? GetById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.BookId == id && !b.IsDeleted);
        }
        public void Add(Models.Book book)
        {
            book.CreatedAt = DateTime.UtcNow;
            book.UpdatedAt = DateTime.UtcNow;
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public void Update(Models.Book book)
        {
            book.UpdatedAt = DateTime.UtcNow;
            _context.Books.Update(book);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookId == id);
            if (book != null)
            {
                book.IsDeleted = true;
                book.UpdatedAt = DateTime.UtcNow;
                _context.Books.Update(book);
                _context.SaveChanges();
            }
        }
    }
}