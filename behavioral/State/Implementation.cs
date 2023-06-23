using System;

namespace State
{
    internal class Implementation
    {
        internal class BankAccount
        {
            public BankAccountState BankAccountState { get; set; }
            public decimal Balance => BankAccountState.Balance;

            public BankAccount()
            {
                BankAccountState = new RegularState(200, this);
            }

            public void Deposit(decimal amount) => BankAccountState.Deposit(amount);

            public void Withdraw(decimal amount) => BankAccountState.Withdraw(amount);
        }

        internal abstract class BankAccountState
        {
            public BankAccount BankAccount { get; protected set; }
            public decimal Balance { get; protected set; }

            protected BankAccountState(decimal balance, BankAccount bankAccount)
            {
                Balance = balance;
                BankAccount = bankAccount;
            }

            public abstract void Deposit(decimal amount);
            public abstract void Withdraw(decimal amount);
        }

        internal class RegularState : BankAccountState
        {
            public RegularState(decimal balance, BankAccount bankAccount)
                :base(balance, bankAccount) 
            {
            }

            public override void Deposit(decimal amount)
            {
                Console.WriteLine($"In {GetType()}, depositing {amount}");
                Balance += amount;
                if (Balance >= 1000)
                {
                    BankAccount.BankAccountState = new GoldState(Balance, BankAccount);
                }
            }

            public override void Withdraw(decimal amount)
            {
                Console.WriteLine($"In {GetType()}, withdrawing {amount} from {Balance}");
                Balance -= amount;
                if (Balance < 0)
                {
                    BankAccount.BankAccountState = new OverdrawnState(Balance, BankAccount);
                }
            }
        }

        internal class OverdrawnState : BankAccountState
        {
            public OverdrawnState(decimal balance, BankAccount bankAccount)
                : base(balance, bankAccount)
            {
            }

            public override void Deposit(decimal amount)
            {
                Console.WriteLine($"In {GetType()}, depositing {amount}");
                Balance += amount;
                if (Balance >= 0)
                {
                    BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
                }
            }

            public override void Withdraw(decimal amount)
            {
                Console.WriteLine($"In {GetType()}, cannot withdraw {amount} from {Balance}");
            }
        }

        internal class GoldState : BankAccountState
        {
            public GoldState(decimal balance, BankAccount bankAccount) : base(balance, bankAccount)
            {
            }

            public override void Deposit(decimal amount)
            {
                Console.WriteLine($"In {GetType()}, depositing {amount} + 10% bonus: {amount / 10}");
                Balance += amount + (amount / 10);
            }

            public override void Withdraw(decimal amount)
            {
                Console.WriteLine($"In {GetType()}, withdrawing {amount} from {Balance}");
                Balance -= amount;
                if (Balance >= 0 && Balance < 1000)
                {
                    BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
                }
                else if (Balance < 0)
                {
                    BankAccount.BankAccountState = new OverdrawnState(Balance, BankAccount);
                }
            }
        }
    }
}
