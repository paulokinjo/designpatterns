namespace RulesEngine
{
    public class Customer
    {
        public DateTime? DateOfFirstPurchase { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsVeteran { get; set; }
    }

    public class DiscountCalculator
    {
        public decimal CalculateDiscountPercentage(Customer customer)
        {
            List<IDiscountRule> rules = new();
            rules.Add(new FirstTimeCustomerRule());
            rules.Add(new LoyalCustomerRule());
            rules.Add(new VeteranRule());
            rules.Add(new SeniorRule());
            rules.Add(new BirthdayRule());

            var engine = new DiscountRuleEngine(rules);
            return engine.CalculateDiscountPercentage(customer);
        }
    }

    public interface IDiscountRule
    {
        decimal CalculateDiscount(Customer customer, decimal currentDiscount);
    }

    public class FirstTimeCustomerRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (!customer.DateOfFirstPurchase.HasValue)
            {
                return .15m;
            }
            return 0m;
        }
    }

    public class LoyalCustomerRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (customer.DateOfFirstPurchase.HasValue)
            {

                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-15))
                {
                    return .15m;
                }

                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-10))
                {
                    return .12m;
                }

                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-5))
                {
                    return .10m;
                }

                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-2) && !customer.IsVeteran)
                {
                    return .08m;
                }

                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-1) && !customer.IsVeteran)
                {
                    return .05m;
                }
            }
            return 0;
        }
    }

    public class VeteranRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (customer.IsVeteran)
            {
                return .10m;
            }

            return 0;
        }
    }
    public class SeniorRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
            {
                return 0.5m;
            }

            return 0;
        }
    }

    public class BirthdayRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            bool isBirthday = customer.DateOfBirth.HasValue &&
              customer.DateOfBirth.Value.Day == DateTime.Today.Day &&
              customer.DateOfBirth.Value.Month == DateTime.Today.Month;

            if (isBirthday)
            {
                return currentDiscount + .10m;
            }

            return currentDiscount;
        }
    }

    public class DiscountRuleEngine
    {
        List<IDiscountRule> rules = new();

        public DiscountRuleEngine(IEnumerable<IDiscountRule> rules)
        {
            this.rules.AddRange(rules);
        }

        public decimal CalculateDiscountPercentage(Customer customer)
        {
            decimal discount = 0m;
            foreach (var rule in rules)
            {
                discount = Math.Max(discount, rule.CalculateDiscount(customer, discount));
            }

            return discount;
        }
    }
}

