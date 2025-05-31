using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12.classes
{
    public static class NumberFilters
    {
        // Фільтр парних чисел
        public static bool IsEven(int number) => number % 2 == 0;

        // Фільтр непарних чисел
        public static bool IsOdd(int number) => !IsEven(number);

        // Фільтр простих чисел
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        // Фільтр чисел Фібоначчі
        public static bool IsFibonacci(int number)
        {
            return IsPerfectSquare(5 * number * number + 4) ||
                   IsPerfectSquare(5 * number * number - 4);
        }

        private static bool IsPerfectSquare(int x)
        {
            int s = (int)Math.Sqrt(x);
            return s * s == x;
        }
    }
}
