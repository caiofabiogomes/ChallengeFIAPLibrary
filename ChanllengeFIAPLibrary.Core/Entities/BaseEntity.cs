namespace ChallengeFIAPLibrary.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; protected set; }
        
        public DateTime CreatedAt { get; protected set; }

        public DateTime? UpdatedAt { get; private set; } = null;

        public DateTime? DeletedAt { get; private set; } = null;

        public bool IsDeleted { get; private set; } = false;

        public void Update()
        {
            UpdatedAt = DateTime.Now;
        }

        public void Delete()
        {
            IsDeleted = true;
            DeletedAt = DateTime.Now;
        }

    }
}
