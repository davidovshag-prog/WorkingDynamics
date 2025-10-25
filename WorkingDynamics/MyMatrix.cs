using System;

namespace WorkingDynamics
{
    public class MyMatrix
    {
        // Властивості для зберігання даних та розмірів
        public double[,] Data { get; private set; }
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        // Конструктор для створення порожньої матриці
        public MyMatrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.Data = new double[rows, cols];
        }

        // Конструктор для створення матриці з масиву
        public MyMatrix(double[,] data)
        {
            this.Data = data;
            this.Rows = data.GetLength(0);
            this.Cols = data.GetLength(1);
        }


        // 1. Додавання (A + B)
        public static MyMatrix Add(MyMatrix a, MyMatrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
            {
                throw new ArgumentException("Матриці повинні мати однакові розміри для додавання.");
            }

            MyMatrix result = new MyMatrix(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    result.Data[i, j] = a.Data[i, j] + b.Data[i, j];
                }
            }
            return result;
        }

        // 2. Віднімання (A - B)
        public static MyMatrix Subtract(MyMatrix a, MyMatrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
            {
                throw new ArgumentException("Матриці повинні мати однакові розміри для віднімання.");
            }

            MyMatrix result = new MyMatrix(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    result.Data[i, j] = a.Data[i, j] - b.Data[i, j];
                }
            }
            return result;
        }

        // 3. Множення (A * B)
        public static MyMatrix Multiply(MyMatrix a, MyMatrix b)
        {
            if (a.Cols != b.Rows)
            {
                throw new ArgumentException("Кількість стовпців матриці A повинна дорівнювати кількості рядків матриці B.");
            }

            MyMatrix result = new MyMatrix(a.Rows, b.Cols);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Cols; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < a.Cols; k++) // a.Cols або b.Rows
                    {
                        sum += a.Data[i, k] * b.Data[k, j];
                    }
                    result.Data[i, j] = sum;
                }
            }
            return result;
        }
    }
}