namespace Facade
{
    internal class Implementation
    {
        internal class OrderService
        {
            public bool HasEnoughOrders(int customerId)
            {
                return customerId > 5;
            }
        }

        internal class CustomerDiscountBaseService
        {
            public double CalculateDiscountBase(int customerId)
            {
                return customerId > 8 ? 10 : 20;
            }
        }

        internal class DayOfTheWeekFactorService
        {
            public double CalculateDayOfTheWeekFactor()
            {
                switch (DateTime.UtcNow.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                    case DayOfWeek.Saturday:
                        return 0.8;
                    default:
                        return 1.2;
                }
            }
        }

        internal class DiscountFacade
        {
            private readonly OrderService orderService = new();
            private readonly CustomerDiscountBaseService customerDiscountBaseService = new();
            private readonly DayOfTheWeekFactorService dayOfTheWeekFactorService = new();   
        
            public double CalculateDiscountPercentage(int customerId)
            {
                if (!orderService.HasEnoughOrders(customerId))
                {
                    return 0;
                }

                return customerDiscountBaseService.CalculateDiscountBase(customerId) * dayOfTheWeekFactorService.CalculateDayOfTheWeekFactor();
            }
        }
    }
}
