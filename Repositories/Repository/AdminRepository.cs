using LibraryManagementApi.Repositories.Interface;
using LibraryManagementApi.Data;

namespace LibraryManagementApi.Repositories.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly Data.LibraryDbContext _context;
        public AdminRepository(Data.LibraryDbContext context)
        {
            _context = context;
        }
        public List<Models.Admin> GetAll()
        {
            return _context.Admins.Where(a => !a.IsDeleted).ToList();
        }
        public List<Models.Admin> Get(int id)
        {
            return _context.Admins.Where(a => a.AdminId == id && !a.IsDeleted).ToList();
        }
        public void Add(Models.Admin admin)
        {
            admin.CreatedAt = DateTime.UtcNow;
            admin.UpdatedAt = DateTime.UtcNow;
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }
        public void Update(Models.Admin admin)
        {
            admin.UpdatedAt = DateTime.UtcNow;
            _context.Admins.Update(admin);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.AdminId == id);
            if (admin != null)
            {
                admin.IsDeleted = true;
                admin.UpdatedAt = DateTime.UtcNow;
                _context.Admins.Update(admin);
                _context.SaveChanges();
            }
        }
    }
}