namespace LibraryManagementApi.Repositories.Interface
{ 
    public interface IUserRepository
    {
        public List<Models.User> GetAll();
        public Models.User? GetById(int id);
        public void Add(Models.User user);
        public void Delete(int id);
        public void Update(Models.User user);
        public Models.User? GetByEmail(string email);
    }
}