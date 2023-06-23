using static Visitor.Implementation;

Console.Title = "Visitor";

var container = new Container();

container.Customers.Add(new Customer("Paulo", 500));
container.Customers.Add(new Customer("Aline", 1000));
container.Customers.Add(new Customer("Maria", 800));
container.Employees.Add(new Employee("Christiane", 18));
container.Employees.Add(new Employee("Tom", 5));

DiscountVisitor dicountVisitor = new DiscountVisitor();

container.Accept(dicountVisitor);

Console.WriteLine($"Total dicount: {dicountVisitor.TotalDiscountGiven}");