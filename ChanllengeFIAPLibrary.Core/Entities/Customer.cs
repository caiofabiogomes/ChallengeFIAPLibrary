using ChallengeFIAPLibrary.Domain.ValueObjects;

namespace ChallengeFIAPLibrary.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            
        }

        public Customer(Name name, Email email, Address address)
        {
            Name = name;
            Email = email;
            Address = address;
        }

        public Name Name { get; private set; }
        
        public Email Email { get; private set; }
        
        public Address Address { get; private set; }
        
        public List<Loan> Loans { get; private set; }

    }
}
