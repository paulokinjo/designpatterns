using static Bridge.Implementation;

Console.Title = "Bridge";

var noCoupon = new NoCoupon();
var oneDollarCoupon = new OneDollarCoupon();

var meatBasedMenu = new MeatBasedMenu(noCoupon);
Console.WriteLine($"Meat based menu, no coupon: {meatBasedMenu.CalculatePrice()} dollar.");

meatBasedMenu = new MeatBasedMenu(oneDollarCoupon);
Console.WriteLine($"Meat based menu, one dollar coupon: {meatBasedMenu.CalculatePrice()} dollar.");

var vegetarianMenu = new VegetarianMenu(noCoupon);
Console.WriteLine($"Vegetarian menu, no coupon: {vegetarianMenu.CalculatePrice()} dollar.");

vegetarianMenu = new VegetarianMenu(oneDollarCoupon);
Console.WriteLine($"Vegetarian menu, one dollar coupon: {vegetarianMenu.CalculatePrice()} dollar.");