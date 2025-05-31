using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12.classes
{
    public class Matrix : IEquatable<Matrix>
    {
        private readonly double[,] _data;

        // Властивості
        public int Rows { get; }
        public int Columns { get; }

        // Індексатор
        public double this[int row, int col]
        {
            get => _data[row, col];
            set => _data[row, col] = value;
        }

        // Конструктори
        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Columns = cols;
            _data = new double[rows, cols];
        }

        public Matrix(double[,] data) : this(data.GetLength(0), data.GetLength(1))
        {
            Array.Copy(data, _data, data.Length);
        }

        // Перевантаження операторів
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new ArgumentException("Матриці мають різні розміри");

            Matrix result = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Columns; j++)
                    result[i, j] = a[i, j] + b[i, j];
            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new ArgumentException("Матриці мають різні розміри");

            Matrix result = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Columns; j++)
                    result[i, j] = a[i, j] - b[i, j];
            return result;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Columns != b.Rows)
                throw new ArgumentException("Неправильні розміри для множення матриць");

            Matrix result = new Matrix(a.Rows, b.Columns);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < b.Columns; j++)
                    for (int k = 0; k < a.Columns; k++)
                        result[i, j] += a[i, k] * b[k, j];
            return result;
        }

        public static Matrix operator *(Matrix a, double scalar)
        {
            Matrix result = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Columns; j++)
                    result[i, j] = a[i, j] * scalar;
            return result;
        }

        public static bool operator ==(Matrix a, Matrix b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            if (a.Rows != b.Rows || a.Columns != b.Columns) return false;

            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Columns; j++)
                    if (Math.Abs(a[i, j] - b[i, j]) > double.Epsilon)
                        return false;
            return true;
        }

        public static bool operator !=(Matrix a, Matrix b) => !(a == b);

        // Реалізація IEquatable
        public bool Equals(Matrix other) => this == other;

        public override bool Equals(object obj) => obj is Matrix matrix && this == matrix;

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Rows.GetHashCode();
                hash = hash * 23 + Columns.GetHashCode();
                for (int i = 0; i < Rows; i++)
                    for (int j = 0; j < Columns; j++)
                        hash = hash * 23 + _data[i, j].GetHashCode();
                return hash;
            }
        }

        // Метод для виведення матриці
        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                    Console.Write($"{_data[i, j],8:F2}");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
