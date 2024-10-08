using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection.Emit;

namespace ChallengeFIAPLibrary.Domain.ValueObjects
{
    public sealed  class Address : ValueObject
    {
        public string Street { get; init; }
        public string HouseNumber { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string Country { get; init; }
        public string ZipCode { get; init; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return HouseNumber;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
        }
    }
}
