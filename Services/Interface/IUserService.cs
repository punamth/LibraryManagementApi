namespace LibraryManagementApi.Services.Interface
{
    public interface IUserService
    {
        Models.User? GetUserById(int id);
        Models.User? GetUserByEmail(string email);

        void RegisterUser(Models.User user);
        Models.User? Login(string email, string password);
    }
}