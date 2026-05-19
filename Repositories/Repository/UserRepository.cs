using LibraryManagementApi.Repositories.Interface;

namespace LibraryManagementApi.Repositories.Repository
{ 
    public class UserRepository : IUserRepository
    {
        private readonly Data.LibraryDbContext _context;
        public UserRepository(Data.LibraryDbContext context)
        {
            _context = context;
        }
        public List<Models.User> GetAll()
        {
            return _context.Users.Where(u => !u.IsDeleted).ToList();
        }
        public Models.User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserID == id && !u.IsDeleted);
        }
        public void Add(Models.User user)
        {
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void Update(Models.User user)
        {
            user.UpdatedAt = DateTime.UtcNow;
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserID == id);
            if (user != null)
            {
                user.IsDeleted = true;
                user.UpdatedAt = DateTime.UtcNow;
                _context.Users.Update(user);
                _context.SaveChanges();
            }
        }
        public Models.User? GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && !u.IsDeleted);
        }
    }
}