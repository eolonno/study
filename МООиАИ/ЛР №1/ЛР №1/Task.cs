using System;

namespace ЛР__1
{
    public static class Task
    {
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


    }
}
