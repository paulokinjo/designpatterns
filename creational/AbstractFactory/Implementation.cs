using System.Diagnostics.CodeAnalysis;

namespace AbstractFactory
{
    internal class Implementation
    {
        internal interface IShoppingCartPurchaseFactory
        {
            IDiscountService CreateDiscountService();
            IShippingCostsService CreateShippingCostsService();
        }

        internal interface IDiscountService
        {
            int DiscountPercentage { get; }
        }

        internal interface IShippingCostsService
        {
            decimal ShippingCosts { get; }
        }

        internal class BrazilDiscountService : IDiscountService
        {
            public int DiscountPercentage => 20;
        }

        internal class JapanDiscountService : IDiscountService
        {
            public int DiscountPercentage => 10;
        }

        internal class BrazilShippingCostsService : IShippingCostsService
        {
            public decimal ShippingCosts => 20;
        }

        internal class JapanShippingCostsService : IShippingCostsService
        {
            public decimal ShippingCosts => 25;
        }

        internal class BrazilShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
        {
            public IDiscountService CreateDiscountService()
            {
                return new BrazilDiscountService();
            }

            public IShippingCostsService CreateShippingCostsService()
            {
                return new BrazilShippingCostsService();
            }
        }

        internal class JapanShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
        {
            public IDiscountService CreateDiscountService()
            {
                return new JapanDiscountService();
            }

            public IShippingCostsService CreateShippingCostsService()
            {
                return new JapanShippingCostsService();
            }
        }

        internal class ShoppingCart
        {
            private readonly IDiscountService discountService;
            private readonly IShippingCostsService shippingCostsService;
            private readonly int orderCosts;

            public ShoppingCart(IShoppingCartPurchaseFactory factory)
            {
                discountService = factory.CreateDiscountService();
                shippingCostsService = factory.CreateShippingCostsService();
                orderCosts = 200;
            }

            public void CalculateCosts()
            {
                Console.WriteLine($"Total costs = {orderCosts - (orderCosts / 100 * discountService.DiscountPercentage) +
                    shippingCostsService.ShippingCosts}");
            }
        }
    }
}
