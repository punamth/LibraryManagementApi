using LibraryManagementApi.Data;
using LibraryManagementApi.Models;
using LibraryManagementApi.Repositories.Interface;

namespace LibraryManagementApi.Repositories.Repository
{ 
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _context;

        public AuthorRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public List<Author> GetAll()
        {
            return _context.Authors.Where(a => !a.IsDeleted).ToList();
        }
        public Author? GetById(int id)
        {
            return _context.Authors.FirstOrDefault(a => a.AuthorId == id && !a.IsDeleted);

        }
        public void Add(Author author)
        {
            author.CreatedAt = DateTime.UtcNow;
            author.UpdatedAt = DateTime.UtcNow;
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
        public void Update(Author author)
        {
            author.UpdatedAt = DateTime.UtcNow;
            _context.Authors.Update(author);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var author = _context.Authors.FirstOrDefault(a => a.AuthorId == id);
            if (author != null)
            {
                author.IsDeleted = true;
                author.UpdatedAt = DateTime.UtcNow;
                _context.Authors.Update(author);
                _context.SaveChanges();
            }
        }
    }
}