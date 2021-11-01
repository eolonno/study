using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<StructZad1> listZad1 = new List<StructZad1>();
        public static List<StructZad1> listZad2 = new List<StructZad1>();
        public static List<StructZad1> listZad3B = new List<StructZad1>();
        public static List<StructZad1> listZad3C = new List<StructZad1>();
        public static List<StructZad1> listZad3D = new List<StructZad1>();

        public MainWindow()
        {
            InitializeComponent();
            FunctionZad1();
            FunctionZad2();
            FunctionZad3();
        }

        public void FunctionZad1()
        {
            float[,] data = new float[,] { { 0.7f, 0.5f, 0.3f }, { 0.6f, 0.9f, 0.4f } };

            listZad1.Add(new StructZad1()
            {
                Line = "A1",
                B1 = data[0,0].ToString(),
                B2 = data[0, 1].ToString(),
                B3 = data[0, 2].ToString(),
                a=Min(GetRow(data,0)).ToString()
            });;

            listZad1.Add(new StructZad1()
            {
                Line = "A2",
                B1 = data[1, 0].ToString(),
                B2 = data[1, 1].ToString(),
                B3 = data[1, 2].ToString(),
                a = Min(GetRow(data, 1)).ToString()
            });


            listZad1.Add(new StructZad1()
            {
                Line = "max",
                B1 = Max(GetColumn(data,0)).ToString(),
                B2 = Max(GetColumn(data, 1)).ToString(),
                B3 = Max(GetColumn(data, 2)).ToString()
            });

            foreach (var item in listZad1)
            {
                Console.WriteLine(item);
            }
            //Zad1.ItemsSource = listZad1;
            //TextBlockZad1.Text += "We do task number 1. Now lets speak about results. Minb(4) != Maxa(4) => in our example we have saddle point";
        }

        public void FunctionZad2()
        {
            int[] fullTechnicalCast = { 12, 8, 5 };
            int[] fullCastProduct1 = { 6, 3, 2 };
            int[] fullCastProduct2 = { 8, 2, 1 };
            int[,] averageCastRealisation = { { 10, 8, 6 }, { 8, 6, 4 }, { 6, 4, 2 } };
            int[,] demandOnProduction = new int[fullCastProduct1.Length,fullCastProduct2.Length];
            float[,] shareOfProduction = { { 0.57f, 0.42f, 0.25f }, { 0.8f, 0.4f, 0.3f }, { 0.92f, 0.85f, 0.72f } };

            for (int i = 0; i < demandOnProduction.GetLength(0); i++)
            {
                for (int j = 0; j < demandOnProduction.GetLength(1); j++)
                {
                    demandOnProduction[i,j] = 6 - (int)(0.5 * averageCastRealisation[i,j]);
                }
            }

            float[,] matrix = new float[fullCastProduct1.Length,fullCastProduct2.Length];
            for (int i = 0; i < fullCastProduct1.Length; i++)
            {
                for (int j = 0; j < fullCastProduct2.Length; j++)
                {
                    matrix[i,j] = CalculationD(demandOnProduction[i, j], shareOfProduction[i, j], fullTechnicalCast[i],
                        fullCastProduct1[i], fullTechnicalCast[j], fullCastProduct2[j]);
                }

                listZad2.Add(new StructZad1()
                {
                    Line = "A" + (i+1),
                    B1 = matrix[i,0].ToString(),
                    B2 = matrix[i,1].ToString(),
                    B3 = matrix[i,2].ToString(),
                    a = Min(GetRow(matrix,i)).ToString()
                });
            }
            listZad2.Add(new StructZad1()
            {
                Line = "max",
                B1 = Max(GetColumn(matrix,0)).ToString(),
                B2 = Max(GetColumn(matrix, 1)).ToString(),
                B3 = Max(GetColumn(matrix, 2)).ToString()
            });
            Zad2.ItemsSource = listZad2;
            float Minb = Min(new float[] { Max(GetColumn(matrix, 0)), Max(GetColumn(matrix, 1)), Max(GetColumn(matrix, 2)) });
            float Maxa = Max(new float[] { Min(GetRow(matrix, 0)), Min(GetRow(matrix, 1)), Min(GetRow(matrix, 2)) });
            int MinIndexb = GetIndexMin(new float[] { Max(GetColumn(matrix, 0)), Max(GetColumn(matrix, 1)), Max(GetColumn(matrix, 2)) });
            float MaxIndexa = GetIndexMax(new float[] { Min(GetRow(matrix, 0)), Min(GetRow(matrix, 1)), Min(GetRow(matrix, 2)) });
            string equals = Minb == Maxa ? "=" : "!=";
            string equalsWord = Minb == Maxa ? "" : "don't";
            var t = Zad2.Items[1];
            TextBlockZad2.Text += $"Самостоятельная работа № 1. \nMinb" + $"({Minb})" + $" {equals} Maxa" + $"({Maxa}) " +
                $"=> в нашем примере мы {equalsWord} имеем седловую точку. \nДля компании B наиболее оптимальная стратегия это {MinIndexb+1}." +
                $" \nДля компании A наиболее оптимальная стратегия {MaxIndexa+1}. \nВ этой игре выиграеит компания A.";
        }

        public void FunctionZad3()
        {
            float[,] zad3B = new float[,]{
                    {-2,0,3,-1,1 },
                    {-1,5,-2,-2,-1 },
                    {-3,-4,0,-2,-2 },
                    {3,5,3,3,1 }
                };

            float[,] zad3C = new float[,]{
                    {4,-4,-1,0 },
                    {7,6,2,6 },
                    {5,4,-6,0 }
                };

            float[,] zad3D = new float[,]{
                    {-6,5,-3,2 },
                    {-13,4,3,-6 },
                    {-3,7,5,-3 },
                    {-3,-1,-4,8},
                    {-6,1,-6,5 }
                };

            //туть добавление в первый лист
            { 
                listZad3B.Add(new StructZad1()
                {
                    Line = "A1",
                    B1 = zad3B[0, 0].ToString(),
                    B2 = zad3B[0, 1].ToString(),
                    B3 = zad3B[0, 2].ToString(),
                    B4 = zad3B[0, 3].ToString(),
                    B5 = zad3B[0, 4].ToString(),
                    a = Min(GetRow(zad3B, 0)).ToString()
                });
                listZad3B.Add(new StructZad1()
                {
                    Line = "A2",
                    B1 = zad3B[1, 0].ToString(),
                    B2 = zad3B[1, 1].ToString(),
                    B3 = zad3B[1, 2].ToString(),
                    B4 = zad3B[1, 3].ToString(),
                    B5 = zad3B[1, 4].ToString(),
                    a = Min(GetRow(zad3B, 1)).ToString()
                });
                listZad3B.Add(new StructZad1()
                {
                    Line = "A3",
                    B1 = zad3B[2, 0].ToString(),
                    B2 = zad3B[2, 1].ToString(),
                    B3 = zad3B[2, 2].ToString(),
                    B4 = zad3B[2, 3].ToString(),
                    B5 = zad3B[2, 4].ToString(),
                    a = Min(GetRow(zad3B, 2)).ToString()
                });
                listZad3B.Add(new StructZad1()
                {
                    Line = "A4",
                    B1 = zad3B[3, 0].ToString(),
                    B2 = zad3B[3, 1].ToString(),
                    B3 = zad3B[3, 2].ToString(),
                    B4 = zad3B[3, 3].ToString(),
                    B5 = zad3B[3, 4].ToString(),
                    a = Min(GetRow(zad3B, 3)).ToString()
                });
                listZad3B.Add(new StructZad1()
                {
                    Line = "max",
                    B1 = Max(GetColumn(zad3B, 0)).ToString(),
                    B2 = Max(GetColumn(zad3B, 1)).ToString(),
                    B3 = Max(GetColumn(zad3B, 2)).ToString(),
                    B4 = Max(GetColumn(zad3B, 3)).ToString(),
                    B5 = Max(GetColumn(zad3B, 4)).ToString()
                });
            }

            //тут добавление во второй лист
            {
                listZad3C.Add(new StructZad1()
                {
                    Line = "A1",
                    B1 = zad3C[0, 0].ToString(),
                    B2 = zad3C[0, 1].ToString(),
                    B3 = zad3C[0, 2].ToString(),
                    B4 = zad3C[0, 3].ToString(),
                    a = Min(GetRow(zad3C, 0)).ToString()
                });
                listZad3C.Add(new StructZad1()
                {
                    Line = "A2",
                    B1 = zad3C[1, 0].ToString(),
                    B2 = zad3C[1, 1].ToString(),
                    B3 = zad3C[1, 2].ToString(),
                    B4 = zad3C[1, 3].ToString(),
                    a = Min(GetRow(zad3C, 1)).ToString()
                });
                listZad3C.Add(new StructZad1()
                {
                    Line = "A3",
                    B1 = zad3C[2, 0].ToString(),
                    B2 = zad3C[2, 1].ToString(),
                    B3 = zad3C[2, 2].ToString(),
                    B4 = zad3C[2, 3].ToString(),
                    a = Min(GetRow(zad3C, 2)).ToString()
                }); 
                listZad3C.Add(new StructZad1()
                {
                    Line = "max",
                    B1 = Max(GetColumn(zad3C, 0)).ToString(),
                    B2 = Max(GetColumn(zad3C, 1)).ToString(),
                    B3 = Max(GetColumn(zad3C, 2)).ToString(),
                    B4 = Max(GetColumn(zad3C, 3)).ToString()
                });
            }

            //тут добавление в третий лист
            {
                listZad3D.Add(new StructZad1()
                {
                    Line = "A1",
                    B1 = zad3D[0, 0].ToString(),
                    B2 = zad3D[0, 1].ToString(),
                    B3 = zad3D[0, 2].ToString(),
                    B4 = zad3D[0, 3].ToString(),
                    a = Min(GetRow(zad3D, 0)).ToString()
                });
                listZad3D.Add(new StructZad1()
                {
                    Line = "A2",
                    B1 = zad3D[1, 0].ToString(),
                    B2 = zad3D[1, 1].ToString(),
                    B3 = zad3D[1, 2].ToString(),
                    B4 = zad3D[1, 3].ToString(),
                    a = Min(GetRow(zad3D, 1)).ToString()
                });
                listZad3D.Add(new StructZad1()
                {
                    Line = "A3",
                    B1 = zad3D[2, 0].ToString(),
                    B2 = zad3D[2, 1].ToString(),
                    B3 = zad3D[2, 2].ToString(),
                    B4 = zad3D[2, 3].ToString(),
                    a = Min(GetRow(zad3D, 2)).ToString()
                });
                listZad3D.Add(new StructZad1()
                {
                    Line = "A4",
                    B1 = zad3D[3, 0].ToString(),
                    B2 = zad3D[3, 1].ToString(),
                    B3 = zad3D[3, 2].ToString(),
                    B4 = zad3D[3, 3].ToString(),
                    a = Min(GetRow(zad3D, 3)).ToString()
                });
                listZad3D.Add(new StructZad1()
                {
                    Line = "A5",
                    B1 = zad3D[4, 0].ToString(),
                    B2 = zad3D[4, 1].ToString(),
                    B3 = zad3D[4, 2].ToString(),
                    B4 = zad3D[4, 3].ToString(),
                    a = Min(GetRow(zad3D, 4)).ToString()
                });
                listZad3D.Add(new StructZad1()
                {
                    Line = "max",
                    B1 = Max(GetColumn(zad3D, 0)).ToString(),
                    B2 = Max(GetColumn(zad3D, 1)).ToString(),
                    B3 = Max(GetColumn(zad3D, 2)).ToString(),
                    B4 = Max(GetColumn(zad3D, 3)).ToString()
                });
            }
            float MinBab = Min(new float[] { Max(GetColumn(zad3B, 0)), Max(GetColumn(zad3B, 1)), Max(GetColumn(zad3B, 2)), Max(GetColumn(zad3B, 3)), Max(GetColumn(zad3B, 4)) });
            float MaxAab = Max(new float[] { Min(GetRow(zad3B, 0)), Min(GetRow(zad3B, 1)), Min(GetRow(zad3B, 2)),Min(GetRow(zad3B,3)) });
            string equalsab = MinBab == MaxAab ? "=" : "!+";
            string equalsWordab = MinBab == MaxAab ? "" : "don't";

            float MinBac = Min(new float[] { Max(GetColumn(zad3C, 0)), Max(GetColumn(zad3C, 1)), Max(GetColumn(zad3C, 2)), Max(GetColumn(zad3C, 3)) });
            float MaxAac = Max(new float[] { Min(GetRow(zad3C, 0)), Min(GetRow(zad3C, 1)), Min(GetRow(zad3C, 2)) });
            string equalsac = MinBac == MaxAac ? "=" : "!=";
            string equalsWordac = MinBac == MaxAac ? "" : "don't";

            float MinBad = Min(new float[] { Max(GetColumn(zad3D, 0)), Max(GetColumn(zad3D, 1)), Max(GetColumn(zad3D, 2)), Max(GetColumn(zad3D, 3)) });
            float MaxAad = Max(new float[] { Min(GetRow(zad3D, 0)), Min(GetRow(zad3D, 1)), Min(GetRow(zad3D, 2)), Min(GetRow(zad3D, 3)), Min(GetRow(zad3D, 4)) });
            string equalsad = MinBad == MaxAad ? "=" : "!+";
            string equalsWordad = MinBad == MaxAad ? "" : "don't";

            var t = Zad2.Items[1];
            string bestVariant="";

            if (equalsab == "=" && equalsac == "=" && equalsad == "=")
            {
                bestVariant = MaxAab > MaxAac ? MaxAab.ToString() : MaxAac.ToString();
                bestVariant = MaxAac > MaxAad ? MaxAac.ToString() : MaxAad.ToString();
            }

            TextBlockZad3.Text += "Самостоятельная работа 2. \n" +
                "MinBab" + $"({MinBab})" + $" {equalsab} MaxAab" + $"({MaxAab}) => в нашем примере мы {equalsWordab} имеем седловую точку. \n" +
                "MinBac" + $"({MinBac})" + $" {equalsac} MaxAac" + $"({MaxAac}) => в нашем примере мы {equalsWordac} имеем седловую точку. \n" +
                "MinBad" + $"({MinBad})" + $" {equalsad} MaxAad" + $"({MaxAad}) => в нашем примере мы {equalsWordad} имеем седловую точку. \n" +
                $"В результате наиболее прибыльныя вариант работы с компанией {bestVariant}.";

            Zad3B.ItemsSource = listZad3B;
            Zad3C.ItemsSource = listZad3C;
            Zad3D.ItemsSource = listZad3D;
        }

        public static float Max(float [] array)
        {
            float max = -1000;

            foreach (var item in array)
            {
                max=item > max ? item : max;
            }

            return max;
        }

        public static float Min(float[] array)
        {
            float min = 1000;

            foreach (var item in array)
            {
                min = item < min ? item : min;
            }

            return min;
        }

        public static int GetIndexMax(float[] array)
        {
            float max = -1000;
            int index=0;

            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                    index = i;
                }
            }
            return index;
        }

        public static int GetIndexMin(float[] array)
        {
            float min = 1000;
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (min > array[i])
                {
                    min = array[i];
                    index = i;
                }
            }
            return index;
        }

        public static float CalculationD(float S,float p,float R1,float C1,float R2,float C2)
        {
            return S * (p * (R1 - C1) - (1 - p) * (R2 - C2));
        }

        public float[] GetColumn(float[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

        public float[] GetRow(float[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }

        public struct StructZad1
        {
            public string Line { get; set; }
            public string B1 { get; set; }
            public string B2 { get; set; }
            public string B3 { get; set; }
            public string B4 { get; set; }
            public string B5 { get; set; }
            public string a { get; set; }
        }
    }
}
