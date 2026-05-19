namespace LibraryManagementApi.Services.Interface
{
    public interface IBookService
    {
        List<Models.Book> GetAllBooks();
        Models.Book? GetBookById(int id);
        void UpdateBook(Models.Book book);
        void DeleteBook(int id);
        void AddBook(Models.Book book);
    }
}