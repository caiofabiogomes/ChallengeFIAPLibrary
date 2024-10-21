using ChallengeFIAPLibrary.Domain.ValueObjects;

namespace ChallengeFIAPLibrary.Domain.Entities
{
    public class Author : BaseEntity
    {
        public Author()
        {

        }

        public Author(Name name, Email email, Address address)
        {
            NameAuthor = name;
            Email = email;
            Address = address;
            Books = new List<Book>();
        }

        public Name NameAuthor { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        public ICollection<Book> Books { get; private set; }

        public void UpdateAddress(Address address) 
        {
            if(!Address.Equals(address))
                Address = address;
        }
    }
}