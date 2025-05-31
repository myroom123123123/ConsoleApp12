namespace ConsoleApp12.classes
{
    using System;

    public class Program
    {
        // Делегати
        public static Action DisplayCurrentTime = () =>
            Console.WriteLine($"Поточний час: {DateTime.Now:HH:mm:ss}");

        public static Action DisplayCurrentDate = () =>
            Console.WriteLine($"Поточна дата: {DateTime.Now:dd.MM.yyyy}");

        public static Action DisplayCurrentDayOfWeek = () =>
            Console.WriteLine($"Поточний день тижня: {DateTime.Now.DayOfWeek}");

        public static Func<double, double, double> CalculateTriangleArea = (b, h) =>
        {
            if (b <= 0 || h <= 0)
                throw new ArgumentException("Сторони мають бути більше 0");
            return 0.5 * b * h;
        };

        public static Func<double, double, double> CalculateRectangleArea = (w, h) =>
        {
            if (w <= 0 || h <= 0)
                throw new ArgumentException("Сторони мають бути більше 0");
            return w * h;
        };

        public static Predicate<DateTime> IsWeekend = date =>
            date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;

        public static void Main()
        {
            // Виклик методів через делегати
            Console.WriteLine("1. Відображення часу, дати та дня тижня:");
            DisplayCurrentTime();
            DisplayCurrentDate();
            DisplayCurrentDayOfWeek();

            // Перевірка на вихідний
            Console.WriteLine($"\n2. Сьогодні вихідний? {IsWeekend(DateTime.Now)}");

            // Обчислення площ
            Console.WriteLine("\n3. Обчислення площ фігур:");
            try
            {
                double triangleArea = CalculateTriangleArea(5, 4);
                Console.WriteLine($"Площа трикутника (основа 5, висота 4): {triangleArea}");

                double rectangleArea = CalculateRectangleArea(6, 3);
                Console.WriteLine($"Площа прямокутника (ширина 6, висота 3): {rectangleArea}");

                // Помилка - від'ємні значення
                // double invalidArea = CalculateTriangleArea(-2, 5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            // Додатковий приклад з Func
            Console.WriteLine("\n4. Конвертація метрів у фути:");
            Func<double, double> metersToFeet = m => m * 3.28084;
            Console.WriteLine($"2 метри = {metersToFeet(2):F2} футів");
        }
    }
}
