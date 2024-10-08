namespace ChallengeFIAPLibrary.Domain.ValueObjects
{
    public sealed class Email : ValueObject
    {
        public string Address { get; init; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Address;
        }
    }
}
