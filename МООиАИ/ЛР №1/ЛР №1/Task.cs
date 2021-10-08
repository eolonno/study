using System;

namespace ЛР__1
{
    public static class Task
    {
        private static double[,] Y = new double[,] { { 1.3 }, { 2.3 }, { 1.8 }, { 1.4 }, { 1.1 }, { 1.2 }, { 2.7 }, { 1.9 }, { 1.5 }, { 2.1 }, { 1.7 } };
        private static double[,] X = new double[,] { { 1, 11, 20 }, { 1, 19, 14 }, { 1, 13, 12 }, { 1, 14, 8 }, { 1, 11, 10 }, { 1, 17, 6 },
                { 1, 23, 16}, {1, 11, 15 },{1, 13, 8 }, {1,20,17 }, {1,15,12 } };
        private static double[,] Xt = Transparent(X);

        private static double[,] A = Multiplication(Xt, X);//Произведение матриц X и Xt
        private static double[,] B = Multiplication(Xt, Y);//Произведение матриц Xt и Y

        private static double[,] adj = new double[A.GetLength(0), A.GetLength(0)];
        private static double[,] inv = new double[A.GetLength(0), A.GetLength(0)];
        private static double[,] A_1B = Multiplication(inv, B);

        static Task()
        {
            Y = new double[,] { { 1.3 }, { 2.3 }, { 1.8 }, { 1.4 }, { 1.1 }, { 1.2 }, { 2.7 }, { 1.9 }, { 1.5 }, { 2.1 }, { 1.7 } };
            X = new double[,] { { 1, 11, 20 }, { 1, 19, 14 }, { 1, 13, 12 }, { 1, 14, 8 }, { 1, 11, 10 }, { 1, 17, 6 },
                { 1, 23, 16}, {1, 11, 15 },{1, 13, 8 }, {1,20,17 }, {1,15,12 } };
            Xt = Transparent(X);
            A = Multiplication(Xt, X);
            B = Multiplication(Xt, Y);
            inv = new double[A.GetLength(0), A.GetLength(0)];
            inverse(A, inv);
            A_1B = Multiplication(inv, B);
        }
        public static float[,] CorrelationMatrix(float[][] inMatrix)
        {

            float[,] corellationMatrix = { { Correlation(inMatrix[0], inMatrix[0]), float.NaN, float.NaN},
                                           { Correlation(inMatrix[0], inMatrix[1]), Correlation(inMatrix[1], inMatrix[1]), float.NaN },
                                           { Correlation(inMatrix[0], inMatrix[2]), Correlation(inMatrix[1], inMatrix[2]), Correlation(inMatrix[2], inMatrix[2]) } };

            return corellationMatrix;
        }

        private static float Correlation(float[] frow, float[] srow)
        {
            float numerator = 0,
                  firstPartOfDenominator = 0,
                  secondPartOfDenominator = 0;
            float[] averages = new float[3];
            for(int i = 0; i < frow.Length; i++)
            {
                averages[0] += frow[i];
                averages[1] += srow[i];
            }
            averages[0] /= frow.Length;
            averages[1] /= srow.Length;

            for (int i = 0; i < frow.Length; i++)
            { 
                numerator += (frow[i] - averages[0]) * (srow[i] - averages[1]);
                firstPartOfDenominator += (float)Math.Pow(frow[i] - averages[0], 2);
                secondPartOfDenominator += (float)Math.Pow(srow[i] - averages[1], 2);
            }
            return numerator / (float)Math.Sqrt(firstPartOfDenominator * secondPartOfDenominator);
        }

        public static void PrintRegressionGraph(double[] x, double[] y)
        {
            double a, b;
            LinearLeastSquares(x, y, out a, out b);


        }

        public static void Theme2Task2()
        {
            Console.WriteLine($"y = {A_1B[0, 0]} + {A_1B[1, 0]} * 15 + {A_1B[2, 0]} * 18 = {A_1B[0, 0] + A_1B[1, 0] * 15 + A_1B[2, 0] * 18}\n");
        }
        public static void Theme2Task3()
        {
            Console.WriteLine($"The savings will increase to {A_1B[1, 0] * 5}\n");
        }
        public static void Theme2Task4()
        {
            Console.WriteLine($"The savings will increase to {A_1B[1, 0] * 3 + A_1B[2, 0] * 5}\n");
        }
        public static void Theme2Task5()
        {
            Console.WriteLine($"The savings will change to {A_1B[0, 0] + 1.1 * 11 * A_1B[1, 0] + 20 * A_1B[2, 0]}");
            Console.WriteLine($"The savings will change to {A_1B[0, 0] + 1.1 * 19 * A_1B[1, 0] + 14 * A_1B[2, 0]}");
            Console.WriteLine($"The savings will change to {A_1B[0, 0] + 1.1 * 13 * A_1B[1, 0] + 12 * A_1B[2, 0]}");
            Console.WriteLine($"The savings will change to {A_1B[0, 0] + 1.1 * 14 * A_1B[1, 0] + 8 * A_1B[2, 0]}");
            Console.WriteLine($"The savings will change to {A_1B[0, 0] + 1.1 * 11 * A_1B[1, 0] + 10 * A_1B[2, 0]}");
            Console.WriteLine($"The savings will change to {A_1B[0, 0] + 1.1 * 17 * A_1B[1, 0] + 6 * A_1B[2, 0]}");
            Console.WriteLine($"The savings will change to {A_1B[0, 0] + 1.1 * 23 * A_1B[1, 0] + 16 * A_1B[2, 0]}");
            Console.WriteLine($"The savings will change to {A_1B[0, 0] + 1.1 * 11 * A_1B[1, 0] + 15 * A_1B[2, 0]}");
            Console.WriteLine($"The savings will change to {A_1B[0, 0] + 1.1 * 13 * A_1B[1, 0] + 8 * A_1B[2, 0]}");
            Console.WriteLine($"The savings will change to {A_1B[0, 0] + 1.1 * 20 * A_1B[1, 0] + 17 * A_1B[2, 0]}");
            Console.WriteLine($"The savings will change to {A_1B[0, 0] + 1.1 * 15 * A_1B[1, 0] + 12 * A_1B[2, 0]}\n");
        }
        public static void Theme2Task6and7()
        {
            double sumx1y = 0;
            double sumx1 = 0;
            double sumy = 0;
            double sumy2 = 0;
            double sumx12 = 0;
            double sumx2y = 0;
            double sumx2 = 0;
            double sumx22 = 0;

            for (int i = 0; i < Y.GetLength(0); i++)
            {
                sumx1y += X[i, 1] * Y[i, 0];
                sumx1 += X[i, 1];
                sumy += Y[i, 0];
                sumy2 += Y[i, 0] * Y[i, 0];
                sumx12 += X[i, 1] * X[i, 1];
                sumx2y += X[i, 2] * Y[i, 0];
                sumx2 += X[i, 2];
                sumx22 += X[i, 2] * X[i, 2];
            }

            double Gy = sumy2 / Y.GetLength(0) - Math.Pow(sumy / Y.GetLength(0), 2);
            double Gx12 = sumx12 / X.GetLength(0) - Math.Pow(sumx1 / X.GetLength(0), 2);
            double Gx22 = sumx22 / X.GetLength(0) - Math.Pow(sumx2 / X.GetLength(0), 2);
            double b1 = (sumx1y / X.GetLength(0) - (sumx1 / X.GetLength(0) * sumy / X.GetLength(0))) / (sumx12 / X.GetLength(0) - Math.Pow(sumx1 / X.GetLength(0), 2));
            double b2 = (sumx2y / X.GetLength(0) - (sumx2 / X.GetLength(0) * sumy / X.GetLength(0))) / (sumx22 / X.GetLength(0) - Math.Pow(sumx2 / X.GetLength(0), 2));

            Console.WriteLine($"rx1y = {b1 * Math.Sqrt(Gx12) / Math.Sqrt(Gy)}");
            Console.WriteLine($"rx2y = {b2 * Math.Sqrt(Gx22) / Math.Sqrt(Gy)}");

            double a1 = sumy / X.GetLength(0) - b1 * sumx1 / X.GetLength(0);
            double a2 = sumy / X.GetLength(0) - b2 * sumx2 / X.GetLength(0);
        }
        private static void LinearLeastSquares(double[] x, double[] y, out double a, out double b)
        {
            if (x.Length != y.Length || x.Length <= 1)
                throw new ArgumentException("Неверные размеры данных");
            double a11 = 0.0, a12 = 0.0, a22 = x.Length, b1 = 0.0, b2 = 0.0;
            for (int i = 0; i < x.Length; i++)
            {
                a11 += x[i] * x[i];
                a12 += x[i];
                b1 += x[i] * y[i];
                b2 += y[i];
            }
            double det = a11 * a22 - a12 * a12;
            if (Math.Abs(det) < 1e-17)
                throw new ArgumentException("Данные не верны");
            a = (b1 * a22 - a12 * b2) / det;
            b = (a11 * b2 - b1 * a12) / det;
        }

        static double[,] Multiplication(double[,] a, double[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Matrices cannot be multiplied");
            double[,] r = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }

        static double[,] Transparent(double[,] matrix)
        {
            double[,] trans = new double[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    trans[i, j] = matrix[j, i];
                }
            }
            return trans;
        }

        static void getCofactor(double[,] A, double[,] temp, int p, int q, int n)
        {
            int i = 0, j = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row != p && col != q)
                    {
                        temp[i, j++] = A[row, col];

                        if (j == n - 1)
                        {
                            j = 0;
                            i++;
                        }
                    }
                }
            }
        }

        static double determinant(double[,] A, int n)
        {
            double D = 0;
            if (n == 1)
                return A[0, 0];

            double[,] temp = new double[A.GetLength(0), A.GetLength(0)];

            int sign = 1;

            for (int f = 0; f < n; f++)
            {
                getCofactor(A, temp, 0, f, n);
                D += sign * A[0, f] * determinant(temp, n - 1);

                sign = -sign;
            }
            return D;
        }

        static void adjoint(double[,] A, double[,] adj)
        {
            if (A.Length == 1)
            {
                adj[0, 0] = 1;
                return;
            }

            int sign = 1;
            double[,] temp = new double[A.GetLength(0), A.GetLength(0)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(0); j++)
                {
                    getCofactor(A, temp, i, j, A.GetLength(0));

                    sign = ((i + j) % 2 == 0) ? 1 : -1;

                    adj[j, i] = (sign) * (determinant(temp, A.GetLength(0) - 1));
                }
            }
        }

        static bool inverse(double[,] A, double[,] inverse)
        {
            double det = determinant(A, A.GetLength(0));
            if (det == 0)
            {
                Console.Write("Singular matrix, can't find its inverse");
                return false;
            }

            double[,] adj = new double[A.GetLength(0), A.GetLength(0)];
            adjoint(A, adj);

            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(0); j++)
                    inverse[i, j] = adj[i, j] / (double)det;

            return true;
        }

        static void Print(double[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", Math.Round(a[i, j], 5));
                }
                Console.WriteLine();
            }
        }
    }
}
