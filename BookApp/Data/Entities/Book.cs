using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Domain.Data
{
    public class Book : Entity
    {     
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
    }
}
