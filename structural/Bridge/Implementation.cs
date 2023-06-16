namespace Bridge
{
    internal class Implementation
    {
        internal abstract class Menu
        {
            public readonly ICoupon coupon;

            public Menu(ICoupon coupon)
            {
                this.coupon = coupon;   
            }

            public abstract int CalculatePrice();
        }

        internal interface ICoupon
        {
            int CouponValue { get; }
        }

        internal class NoCoupon : ICoupon
        {
            public int CouponValue { get => 0; }
        }

        internal class OneDollarCoupon : ICoupon
        {
            public int CouponValue { get => 1; }
        }

        internal class TwoDollarCoupon : ICoupon
        {
            public int CouponValue { get => 2; }
        }

        internal class VegetarianMenu : Menu
        {
            public VegetarianMenu(ICoupon coupon) : base(coupon)
            {

            }

            public override int CalculatePrice()
            {
                return 20 - coupon.CouponValue;
            }
        }

        internal class MeatBasedMenu : Menu
        {
            public MeatBasedMenu(ICoupon coupon) : base(coupon)
            {

            }

            public override int CalculatePrice()
            {
                return 10 - coupon.CouponValue;
            }
        }
    }
}
