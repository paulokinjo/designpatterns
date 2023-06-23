using static Memento.Implementation;

Console.Title = "Memento";

CommandManager commandManager = new CommandManager();
IEmployeeManagerRepository repository = new EmployeManagerRepository();

commandManager.Invoke(new AddEmployeeToManagerList(repository, 1, new Employee(111, "Paulo")));
repository.WriteDataStore();