namespace LibraryManagementApi.Models
{
    public class User
    {
        public int UserID { get; set; }
        public required string Username { get; set; }

        public required string Email { get; set; }
        public required String Role { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Boolean IsDeleted { get; set; }

        public Admin? Admin { get; set; }
        public Student? Student { get; set; }
        public string? Password { get; set; }
    }
}