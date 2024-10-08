namespace ChallengeFIAPLibrary.Domain.ValueObjects
{
    public sealed class Name : ValueObject
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
