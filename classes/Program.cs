namespace ConsoleApp12.classes
{
    class Program
    {
        static void Main()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var processor = new ArrayProcessor(numbers);

            // Використання делегатів для фільтрації
            var evenNumbers = processor.FilterNumbers(NumberFilters.IsEven);
            var oddNumbers = processor.FilterNumbers(NumberFilters.IsOdd);
            var primeNumbers = processor.FilterNumbers(NumberFilters.IsPrime);
            var fibonacciNumbers = processor.FilterNumbers(NumberFilters.IsFibonacci);

            // Виведення результатів
            processor.PrintArray("Вихідний масив", numbers);
            processor.PrintArray("Парні числа", evenNumbers);
            processor.PrintArray("Непарні числа", oddNumbers);
            processor.PrintArray("Прості числа", primeNumbers);
            processor.PrintArray("Числа Фібоначчі", fibonacciNumbers);

            // Альтернативний спосіб використання через лямбда-вирази
            Console.WriteLine("\nВикористання лямбда-виразів:");
            var multiplesOf3 = processor.FilterNumbers(n => n % 3 == 0);
            processor.PrintArray("Числа, кратні 3", multiplesOf3);
        }
    }
}
