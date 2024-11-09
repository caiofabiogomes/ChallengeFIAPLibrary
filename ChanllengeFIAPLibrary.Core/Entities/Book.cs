using ChallengeFIAPLibrary.Domain.Entities;

namespace ChallengeFIAPLibrary.Domain.Entities
{
    public class Book : BaseEntity
    {
        public Book()
        {
            
        }
        public Book(string title, string description, int stockQuantity, Guid authorId)
        {
            Title = title;
            Description = description;
            StockQuantity = stockQuantity;
            AuthorId = authorId;
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public int StockQuantity {get; private set; }

        public Guid AuthorId { get; private set;  }

        public Author Author { get; private set; } 

        public void ChangeStockQuantity(int quantity)
        {

            StockQuantity = quantity;
        }
    }
}
