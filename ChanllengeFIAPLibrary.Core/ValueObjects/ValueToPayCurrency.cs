using ChallengeFIAPLibrary.Domain.Enums;

namespace ChallengeFIAPLibrary.Domain.ValueObjects
{
    public sealed class ValueToPayCurrency : ValueObject
    {
        public decimal Value { get; init; }
        public ECurrency Currency { get; init; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
            yield return Currency;
        }
    }
}
