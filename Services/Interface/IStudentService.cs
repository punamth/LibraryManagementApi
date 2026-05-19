namespace LibraryManagementApi.Services.Interface
{
    public interface IStudentService
    {
        public List<Models.Student> GetAll();
        Models.Student? GetStudentById(int id);
        void AddStudent(Models.Student student);
        void DeleteStudent(int id);
        void UpdateStudent(Models.Student student);
    }
}