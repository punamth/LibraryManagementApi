using LibraryManagementApi.Models;
using LibraryManagementApi.Repositories.Interface;
using LibraryManagementApi.Services.Interface;
using System;
using System.Collections.Generic;

namespace LibraryManagementApi.Services.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IBookRepository _bookRepository;

        public TransactionService(
            ITransactionRepository transactionRepository,
            IBookRepository bookRepository)
        {
            _transactionRepository = transactionRepository;
            _bookRepository = bookRepository;
        }

        public List<Transaction> GetAll()
        {
            return _transactionRepository.GetAll();
        }

        public Transaction? GetById(int id)
        {
            return _transactionRepository.GetById(id);
        }

        public void Delete(int id)
        {
            _transactionRepository.Delete(id);
        }

        public void Update(Transaction transaction)
        {
            _transactionRepository.Update(transaction);
        }

        public void Add(Transaction transaction)
        {
            _transactionRepository.Add(transaction);
        }

        public List<Transaction> GetTransactionsByStudentId(int studentId)
        {
            return _transactionRepository.GetTransactionsByStudentId(studentId);
        }

        public string IssueBook(Transaction transaction)
        {
            // Business rule 1: check if book exists
            var book = _bookRepository.GetById(transaction.BookId ?? 0);
            if (book == null)
                return "Book not found";

            // Business rule 2: check if book is available
            if (book.AvailableQuantity <= 0)
                return "Book is not available";

            // Business rule 3: set transaction details
            transaction.IssueDate = DateTime.Now;
            transaction.DueDate = DateTime.Now.AddDays(14);  // 2 week loan
            transaction.Status = "Issued";
            transaction.TransactionType = "Issue";

            // Reduce available quantity
            book.AvailableQuantity--;
            _bookRepository.Update(book);

            _transactionRepository.Add(transaction);
            return "Book issued successfully";
        }

        public string ReturnBook(int transactionId)
        {
            // Find the transaction
            var transaction = _transactionRepository.GetById(transactionId);
            if (transaction == null)
                return "Transaction not found";

            // Find the book
            var book = _bookRepository.GetById(transaction.BookId ?? 0);
            if (book == null)
                return "Book not found";

            // Calculate fine if overdue
            transaction.ReturnDate = DateTime.Now;
            if (DateTime.Now > transaction.DueDate)
            {
                var overdueDays = (DateTime.Now - transaction.DueDate!.Value).Days;
                transaction.FineAmount = overdueDays * 10;  // 10 per day fine
            }

            transaction.Status = "Returned";

            // Increase available quantity back
            book.AvailableQuantity++;
            _bookRepository.Update(book);

            _transactionRepository.Update(transaction);
            return "Book returned successfully";
        }
    }
}