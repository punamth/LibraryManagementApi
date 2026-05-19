namespace LibraryManagementApi.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Isbn { get; set; }
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        public string? Description { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string? Publisher { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public string? Category { get; set; }
        public string? ShelfLocation { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }


        public Author? Author { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}