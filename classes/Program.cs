namespace ConsoleApp12.classes
{
    class Program
    {
        static void Main()
        {
            // Створення кредитної картки
            var card = new CreditCard(
                "1234 5678 9012 3456",
                "Іван Петренко",
                new DateTime(2025, 12, 1),
                1234,
                5000,
                1000);

            // Підписка на події
            card.FundsDeposited += amount =>
                Console.WriteLine($"Рахунок поповнено на {amount:C}");

            card.FundsWithdrawn += amount =>
                Console.WriteLine($"Знято {amount:C} з рахунку");

            card.CreditUsageStarted += () =>
                Console.WriteLine("Увага! Ви почали використовувати кредитні кошти");

            card.CreditLimitReached += () =>
                Console.WriteLine("Увага! Досягнуто кредитний ліміт");

            card.PinChanged += () =>
                Console.WriteLine("PIN-код успішно змінено");

            // Виведення інформації про картку
            card.PrintInfo();

            // Тестування операцій
            card.Deposit(2000);
            card.PrintInfo();

            if (!card.Withdraw(4000, 0000))
                Console.WriteLine("Помилка: невірний PIN або недостатньо коштів");

            if (card.Withdraw(4000, 1234))
                card.PrintInfo();

            if (card.Withdraw(3000, 1234))
                card.PrintInfo();

            if (card.ChangePin(1234, 5678))
                Console.WriteLine("PIN успішно змінено");
        }
    }
}
