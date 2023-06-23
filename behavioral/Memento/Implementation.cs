namespace Memento
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
            private int managerId;
            private Employee? employee;

            public AddEmployeeToManagerList(IEmployeeManagerRepository employeeManagerRepository,
                int managerId,
                Employee? employee)
            {
                this.employeeManagerRepository = employeeManagerRepository;
                this.managerId = managerId;
                this.employee = employee;
            }

            public AddEmployeeToManagerListMemento CreateMemento()
            {
                return new AddEmployeeToManagerListMemento(managerId, employee);
            }

            public void RestoreMemento(AddEmployeeToManagerListMemento memento)
            {
                managerId = memento.ManagerId;
                employee = memento.Employee;
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

            internal void Undo()
            {
                return;
            }
        }

        internal class CommandManager
        {
            private readonly Stack<AddEmployeeToManagerListMemento> mementos = new();
            private AddEmployeeToManagerList? _command;

            public void Invoke(ICommand command)
            {
                if (_command == null)
                {
                    _command = (AddEmployeeToManagerList)command;
                }

                if (command.CanExecute())
                {
                    command.Execute();
                    mementos.Push(((AddEmployeeToManagerList)command).CreateMemento());
                }
            }

            public void Undo()
            {
                if (mementos.Any())
                {
                    _command?.RestoreMemento(mementos.Pop());
                    _command?.Undo();
                }
            }

            public void UndoAll()
            {
                while (mementos.Any())
                {
                    _command?.RestoreMemento(mementos.Pop());
                    _command?.Undo();   
                }
            }
        }

        internal class AddEmployeeToManagerListMemento
        {
            public int ManagerId { get; private set; }
            public Employee? Employee { get; private set; }

            public AddEmployeeToManagerListMemento(int managerId, Employee? employee)
            {
                ManagerId = managerId;
                Employee = employee;
            }
        }
    }
}
