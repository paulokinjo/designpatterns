using static Command.Implementation;

Console.Title = "Command";

CommandManager commandManager= new CommandManager();
IEmployeeManagerRepository repository = new EmployeManagerRepository();

commandManager.Invoke(new AddEmployeeToManagerList(repository, 1, new Employee(111, "Paulo")));
repository.WriteDataStore();