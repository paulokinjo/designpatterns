using static State.Implementation;

Console.Title = "State";

BankAccount bankAccount = new();
bankAccount.Deposit(100);
bankAccount.Deposit(800);
bankAccount.Withdraw(500);
bankAccount.Withdraw(1000);
bankAccount.Withdraw(1000);
bankAccount.Deposit(800);
bankAccount.Deposit(800);
bankAccount.Deposit(800);