using LibraryManagementApi.Services.Interface;
using LibraryManagementApi.Repositories.Interface;

namespace LibraryManagementApi.Services.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public List<Models.Student> GetAll()
        {
            return _studentRepository.GetAll();
        }
        public Models.Student? GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }
        public void AddStudent(Models.Student student)
        {
            _studentRepository.Add(student);
        }
        public void UpdateStudent(Models.Student student)
        {
            _studentRepository.Update(student);
        }
        public void DeleteStudent(int id)
        {
            _studentRepository.Delete(id);
        }
    }
}