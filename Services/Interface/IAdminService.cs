namespace LibraryManagementApi.Services.Interface
{
    public interface IAdminService
    {
        List<Models.Admin> GetAll();
        List<Models.Admin> Get(int id);
        void Add(Models.Admin admin);
        void Update(Models.Admin admin);
        void Delete(int id);
    }
}