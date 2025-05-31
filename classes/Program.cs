namespace ConsoleApp12.classes
{
    class Program
    {
        static void Main()
        {
            // Створення матриць
            Matrix m1 = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            Matrix m2 = new Matrix(new double[,] { { 5, 6 }, { 7, 8 } });

            Console.WriteLine("Матриця 1:");
            m1.Print();

            Console.WriteLine("Матриця 2:");
            m2.Print();

            // Додавання
            Console.WriteLine("Сума матриць:");
            (m1 + m2).Print();

            // Віднімання
            Console.WriteLine("Різниця матриць:");
            (m1 - m2).Print();

            // Множення матриць
            Console.WriteLine("Добуток матриць:");
            (m1 * m2).Print();

            // Множення на скаляр
            Console.WriteLine("Матриця 1 * 2.5:");
            (m1 * 2.5).Print();

            // Порівняння
            Console.WriteLine($"m1 == m2: {m1 == m2}");
            Console.WriteLine($"m1 != m2: {m1 != m2}");

            Matrix m3 = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            Console.WriteLine($"m1 == m3: {m1 == m3}");
            Console.WriteLine($"m1.Equals(m3): {m1.Equals(m3)}");
        }
    }
}
