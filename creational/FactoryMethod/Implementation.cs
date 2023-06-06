namespace FactoryMethod
{
    internal class Implementation
    {
        public abstract class DiscountService
        {
            public abstract int DiscountPercentage { get; }

            public override string ToString() => GetType().Name;
        }

        public class CountryDiscountService : DiscountService
        {
            private readonly string countryIdentifier;

            public CountryDiscountService(string countryIdentifier) => this.countryIdentifier = countryIdentifier;

            public override int DiscountPercentage
            {
                get => countryIdentifier switch
                {
                    "BE" => 20,
                    _ => 10
                };
            }
        }

        public class CodeDiscountService : DiscountService
        {
            private readonly Guid code;

            public CodeDiscountService(Guid code) => this.code = code;

            public override int DiscountPercentage
            {
                get => 15;
            }
        }

        public abstract class DiscountFactory
        {
            public abstract DiscountService CreateDiscountService();
        }

        public class CountryDiscountFactory : DiscountFactory
        {
            private readonly string countryIdentifier;

            public CountryDiscountFactory(string countryIdentifier)
            {
                this.countryIdentifier = countryIdentifier;
            }

            public override DiscountService CreateDiscountService()
            {
                return new CountryDiscountService(countryIdentifier);
            }
        }

        public class CodeDiscountFactory : DiscountFactory
        {
            private readonly Guid code;

            public CodeDiscountFactory(Guid code)
            {
                this.code = code;
            }

            public override DiscountService CreateDiscountService()
            {
                return new CodeDiscountService(code);
            }
        }
    }
}
