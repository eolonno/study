using System;

namespace ЛР__1
{
    class Program
    {
        static void Main(string[] args)
        {
            //First task
            Console.WriteLine("First matrix: ");
            float[][] inMatrix = new float[3][];
            inMatrix[0] = new float[] { 6f, 4.9f, 7f, 6.7f, 5.8f, 6.1f, 5f, 6.9f, 6.8f, 5.9f };
            inMatrix[1] = new float[] { 2f, 0.8f, 3.7f, 3f, 1f, 2.1f, 0.9f, 2.6f, 3f, 1.1f };
            inMatrix[2] = new float[] { 25f, 30f, 20f, 21f, 28f, 26f, 30f, 22f, 20f, 29f };
            PrintMatrix(Task.CorrelationMatrix(inMatrix));
            Console.WriteLine();

            //Second task
            Console.WriteLine("Second matrix: ");
            inMatrix = new float[3][];
            inMatrix[0] = new float[] { 84f, 45f, 56f, 34f, 23f };
            inMatrix[1] = new float[] { 85f, 55f, 65f, 40f, 28f };
            inMatrix[2] = new float[] { 441f, 980f, 1400f, 1960f, 2030f };
            PrintMatrix(Task.CorrelationMatrix(inMatrix));
            Console.WriteLine();


        }
        private static void PrintMatrix(float[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write("{0} \t", double.IsNaN(Math.Round(matrix[i, j], 3)) ? "NaN": Math.Round(matrix[i, j], 3));
                Console.WriteLine();
            }
        }
    }
}
