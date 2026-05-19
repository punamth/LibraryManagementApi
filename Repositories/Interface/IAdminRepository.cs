namespace LibraryManagementApi.Repositories.Interface
{
    public interface IAdminRepository
    {
        public List<Models.Admin> GetAll();
        public List<Models.Admin> Get(int id);
        public void Add(Models.Admin admin);
        public void Update(Models.Admin admin);
        public void Delete(int id);


    }
}