namespace Visitor
{
    internal class Implementation
    {
        internal class Customer : IElement
        {
            public decimal AmountOrdered { get; }
            public decimal Discount { get; set; }
            public string Name { get; }

            public Customer(string name, decimal amountOrdered)
            {
                Name = name;
                AmountOrdered = amountOrdered;
            }

            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
                Console.WriteLine($"Visited {nameof(Customer)} {Name}, discount given: {Discount}");
            }
        }

        internal class Employee : IElement
        {
            public int YearsEmployed { get; }
            public decimal Discount { get; set; }
            public string Name { get; }

            public Employee(string name, int yearsEmployed)
            {
                Name = name;
                YearsEmployed = yearsEmployed;
            }

            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
                Console.WriteLine($"Visited {nameof(Employee)} {Name}, discount given: {Discount}");
            }
        }

        internal interface IVisitor
        {
            void Visit(IElement element);
        }

        internal interface IElement
        {
            void Accept(IVisitor visitor);
        }

        internal class DiscountVisitor : IVisitor
        {
            public decimal TotalDiscountGiven { get; set; }

            public void Visit(IElement element)
            {
                if (element is Customer)
                {
                    VisitCustomer(element as Customer);
                }
                else if (element is Employee)
                {
                    VisitEmployee(element as Employee);
                }
            }

            private void VisitCustomer(Customer customer)
            {
                var discount = customer.AmountOrdered / 10;
                customer.Discount = discount;

                TotalDiscountGiven += discount;
            }

            private void VisitEmployee(Employee employee)
            {
                var discount = employee.YearsEmployed < 10 ? 100 : 200;
                employee.Discount = discount;
                TotalDiscountGiven += discount;
            }
        }

        internal class Container
        {
            public List<Employee> Employees { get; set; } = new();
            public List<Customer> Customers { get; set; } = new();

            public void Accept(IVisitor visitor)
            {
                foreach (var employee in Employees)
                {
                    employee.Accept(visitor);
                }

                foreach (var customer in Customers)
                {
                    customer.Accept(visitor);
                }
            }
        }
    }
}
