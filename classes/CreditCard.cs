using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12.classes
{
    public class CreditCard
    {
        // Властивості
        public string CardNumber { get; }
        public string OwnerName { get; }
        public DateTime ExpiryDate { get; }
        private int _pin;
        public decimal CreditLimit { get; }
        private decimal _balance;

        // Події
        public event Action<decimal> FundsDeposited;
        public event Action<decimal> FundsWithdrawn;
        public event Action CreditUsageStarted;
        public event Action CreditLimitReached;
        public event Action PinChanged;

        // Конструктор
        public CreditCard(string cardNumber, string ownerName, DateTime expiryDate, int pin, decimal creditLimit, decimal initialBalance = 0)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;
            ExpiryDate = expiryDate;
            _pin = pin;
            CreditLimit = creditLimit;
            Balance = initialBalance;
        }

        // Властивість для балансу з логікою кредитного ліміту
        public decimal Balance
        {
            get => _balance;
            private set
            {
                bool wasInCredit = _balance < 0;
                _balance = value;

                if (wasInCredit && _balance >= 0)
                {
                    CreditUsageStarted?.Invoke();
                }

                if (_balance <= -CreditLimit)
                {
                    CreditLimitReached?.Invoke();
                }
            }
        }

        // Методи для роботи з карткою

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сума поповнення має бути більше 0");

            Balance += amount;
            FundsDeposited?.Invoke(amount);
        }

        public bool Withdraw(decimal amount, int pin)
        {
            if (amount <= 0)
                throw new ArgumentException("Сума зняття має бути більше 0");

            if (!VerifyPin(pin))
                return false;

            if (Balance - amount < -CreditLimit)
                return false;

            Balance -= amount;
            FundsWithdrawn?.Invoke(amount);
            return true;
        }

        public bool ChangePin(int oldPin, int newPin)
        {
            if (!VerifyPin(oldPin) || newPin.ToString().Length != 4)
                return false;

            _pin = newPin;
            PinChanged?.Invoke();
            return true;
        }

        private bool VerifyPin(int pin) => _pin == pin;

        // Метод для виведення інформації
        public void PrintInfo()
        {
            Console.WriteLine($"Картка: {CardNumber}");
            Console.WriteLine($"Власник: {OwnerName}");
            Console.WriteLine($"Термін дії: {ExpiryDate:MM/yy}");
            Console.WriteLine($"Баланс: {Balance:C}");
            Console.WriteLine($"Кредитний ліміт: {CreditLimit:C}");
            Console.WriteLine($"Доступно: {(Balance + CreditLimit):C}");
            Console.WriteLine(new string('-', 30));
        }
    }
}
