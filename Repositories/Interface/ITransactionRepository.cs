using System.Collections.Generic;
using LibraryManagementApi.Models;

namespace LibraryManagementApi.Repositories.Interface
{
    public interface ITransactionRepository
    {
        public List<Transaction> GetAll();
        public Transaction? GetById(int id);
        public void Add(Transaction transaction);
        public void Delete(int id);
        public void Update(Transaction transaction);
        public List<Transaction> GetTransactionsByStudentId(int studentId);
    }
}