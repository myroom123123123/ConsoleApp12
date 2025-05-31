using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12.classes
{
    // Делегат для фільтрації чисел
    public delegate bool NumberFilter(int number);

    public class ArrayProcessor
    {
        private int[] _numbers;

        public ArrayProcessor(int[] numbers)
        {
            _numbers = numbers ?? throw new ArgumentNullException(nameof(numbers));
        }

        // Метод для фільтрації чисел з використанням делегата
        public int[] FilterNumbers(NumberFilter filter)
        {
            return _numbers.Where(n => filter(n)).ToArray();
        }

        // Метод для виведення масиву
        public void PrintArray(string title, int[] array)
        {
            Console.WriteLine($"{title}: [{string.Join(", ", array)}]");
        }
    }
}
