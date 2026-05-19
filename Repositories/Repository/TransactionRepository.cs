using System.Collections.Generic;
using LibraryManagementApi.Models;
using LibraryManagementApi.Repositories.Interface;

namespace LibraryManagementApi.Repositories.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly Data.LibraryDbContext _context;
        public TransactionRepository(Data.LibraryDbContext context)
        {
            _context = context;
        }
        public List<Transaction> GetAll()
        {
            return _context.Transactions.Where(t => !t.IsDeleted).ToList();
        }
        public Transaction? GetById(int id)
        {
            return _context.Transactions.FirstOrDefault(t => t.TransactionId == id && !t.IsDeleted);
        }
        public void Add(Transaction transaction)
        {
            transaction.CreatedAt = DateTime.UtcNow;
            transaction.UpdatedAt = DateTime.UtcNow;
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var transaction = _context.Transactions.FirstOrDefault(t => t.TransactionId == id);
            if (transaction != null)
            {
                transaction.IsDeleted = true;
                transaction.UpdatedAt = DateTime.UtcNow;
                _context.Transactions.Update(transaction);
                _context.SaveChanges();
            }
        }
        public void Update(Transaction transaction)
        {
            transaction.UpdatedAt = DateTime.UtcNow;
            _context.Transactions.Update(transaction);
            _context.SaveChanges();
        }
        public List<Transaction> GetTransactionsByStudentId(int studentId)
        {
            return _context.Transactions.Where(t => t.StudentId == studentId && !t.IsDeleted).ToList();
        }
    }
}