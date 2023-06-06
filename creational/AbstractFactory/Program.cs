using static AbstractFactory.Implementation;

Console.Title = "Abstract Factory";

var brazilShoppingCartPurchaseFactory = new BrazilShoppingCartPurchaseFactory();
var shoppingCartForBrazil = new ShoppingCart(brazilShoppingCartPurchaseFactory);
shoppingCartForBrazil.CalculateCosts();

var japanShoppingCartPurchaseFactory = new JapanShoppingCartPurchaseFactory();
var shoppingCartForJapan = new ShoppingCart(japanShoppingCartPurchaseFactory);
shoppingCartForJapan.CalculateCosts();