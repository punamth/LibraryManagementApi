using LibraryManagementApi.Repositories.Interface;

namespace LibraryManagementApi.Repositories.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Data.LibraryDbContext _context;
        public StudentRepository(Data.LibraryDbContext context)
        {
            _context = context;
        }
        public List<Models.Student> GetAll()
        {
            return _context.Students.Where(s => !s.IsDeleted).ToList();
        }
        public Models.Student? GetById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.StudentId == id && !s.IsDeleted);
        }
        public void Add(Models.Student student)
        {
            student.CreatedAt = DateTime.UtcNow;
            student.UpdatedAt = DateTime.UtcNow;
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public void Update(Models.Student student)
        {
            student.UpdatedAt = DateTime.UtcNow;
            _context.Students.Update(student);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                student.IsDeleted = true;
                student.UpdatedAt = DateTime.UtcNow;
                _context.Students.Update(student);
                _context.SaveChanges();
            }
        }
    }
}