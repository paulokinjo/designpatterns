using static Prototype.Implementation;

Console.Title = "Prototype";

var manager = new Manager("Paulo");
var managerClone = (Manager)manager.Clone();
Console.WriteLine($"Manager was cloned: {managerClone.Name}");

var employee = new Employee("Deeb", managerClone);
var employeeClone = (Employee)employee.Clone(true);

Console.WriteLine($"Employee was cloned: {employeeClone.Name}, " +
    $" with manager {employeeClone.Manager.Name}");

managerClone.Name = "Renato";
Console.WriteLine($"Employee was cloned: {employeeClone.Name}, " +
    $" with manager {employeeClone.Manager.Name}");
