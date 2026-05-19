namespace LibraryManagementApi.Repositories.Interface
{
    public interface IStudentRepository
    {
        public List<Models.Student> GetAll();
        public Models.Student? GetById(int id);
        public void Add(Models.Student student);
        public void Delete(int id);
        public void Update(Models.Student student);
    }
}