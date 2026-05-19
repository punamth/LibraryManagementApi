namespace LibraryManagementApi.Services.Interface
{
    public interface IAuthorService
    {
        List<Models.Author> GetAll();
        Models.Author? GetById(int id);
        void Add(Models.Author author);
        void UpdateAuthor(Models.Author author);
        void DeleteAuthor(int id);
    }
}