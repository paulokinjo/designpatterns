namespace Command
{
    internal class Implementation
    {
        internal class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Employee(int id, string name)
            {
                Name = name;
                Id = id;
            }
        }

        internal class Manager : Employee
        {
            public List<Employee> Employees = new();
            public Manager(int id, string name) : base(id, name) { }
        }

        internal interface IEmployeeManagerRepository
        {
            void AddEmployee(int managerId, Employee employee);
            void WriteDataStore();
        }

        internal class EmployeManagerRepository : IEmployeeManagerRepository
        {
            private List<Manager> managers = new()
            { new Manager(1, "Katie"), new Manager(2, "Mark") };

            public void AddEmployee(int managerId, Employee employee)
            {
                managers.First(m => m.Id == managerId).Employees.Add(employee);
            }

            public void WriteDataStore()
            {
                Console.WriteLine($"Writing to database...");
                foreach (var m in managers)
                {
                    Console.WriteLine(m.Name);
                    foreach (var e in m.Employees)
                    {
                        Console.WriteLine("\t" + e.Name);
                    }
                }
            }
        }

        internal interface ICommand
        {
            void Execute();
            bool CanExecute();
        }

        internal class AddEmployeeToManagerList : ICommand
        {
            private readonly IEmployeeManagerRepository employeeManagerRepository;
            private readonly int managerId;
            private readonly Employee? employee;

            public AddEmployeeToManagerList(IEmployeeManagerRepository employeeManagerRepository,
                int managerId,
                Employee? employee)
            {
                this.employeeManagerRepository = employeeManagerRepository;
                this.managerId = managerId;
                this.employee = employee;
            }
            public bool CanExecute()
            {
                return employee != null;
            }

            public void Execute()
            {
                if (employee == null)
                {
                    return;
                }

                employeeManagerRepository.AddEmployee(managerId, employee);
            }
        }

        internal class CommandManager
        {
            public void Invoke(ICommand command)
            {
                if (command.CanExecute())
                {
                    command.Execute();
                }
            }
        }
    }
}
