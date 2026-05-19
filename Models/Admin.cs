namespace LibraryManagementApi.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public int UserId { get; set; }
        public string? AdminName { get; set; }
        public required string Email { get; set; }
        public RoleType RoleType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }


        public User? User { get; set; }

    }
    public enum RoleType
    {
        SuperAdmin,
        Librarian,
        Staff
    }
}