namespace LibraryManagementApi.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public int? UserId { get; set; }
        public string? StudentName { get; set; }
        public string? Email { get; set; }
        public string? ContactNo { get; set; }
        public long? Faculty { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }


        public User? User { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}