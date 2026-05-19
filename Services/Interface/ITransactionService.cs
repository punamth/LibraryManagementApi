namespace LibraryManagementApi.Services.Interface
{
    public interface ITransactionService
    {
        public List<Models.Transaction> GetAll();
        public Models.Transaction? GetById(int id);

        public void Delete(int id);
        public void Update(Models.Transaction transaction);
        public void Add(Models.Transaction transaction);
        public List<Models.Transaction> GetTransactionsByStudentId(int studentId);

        public string IssueBook(Models.Transaction transaction);
        public string ReturnBook(int transactionId);
    }
}