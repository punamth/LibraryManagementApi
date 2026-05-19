namespace LibraryManagementApi.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int? StudentId { get; set; }
        public int? BookId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string? TransactionType { get; set; }
        public decimal? FineAmount { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }


        public Student? Student { get; set; }
        public Book? Book { get; set; }
    }
}