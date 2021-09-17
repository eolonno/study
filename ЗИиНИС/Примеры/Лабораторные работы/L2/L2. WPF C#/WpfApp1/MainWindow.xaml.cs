using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string str;
        double Entropy = 0;
               
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_File_Button_Click(object sender, RoutedEventArgs e)
        {
            str = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                str = File.ReadAllText(openFileDialog.FileName);

            if (str == "") MessageBox.Show("Ошибка");
            else
            {
                kolva_inf_Button.IsEnabled = true;

                foreach (float letterEntropy in GetAlphabetEntropy(str))
                {
                    Entropy -= letterEntropy * Math.Log(letterEntropy, 2);
                }

                MessageBox.Show(Entropy.ToString()+ " бит");
            }
        }

        List<float> GetAlphabetEntropy(string str)
        {
            List<string> letters = new List<string>();
            List<float> AlphabetEntropy = new List<float>();

            for (int i = 0; i < str.Length; i++)
            {
                if (!letters.Contains(str[i].ToString()))
                    letters.Add(str[i].ToString());
            }

            foreach(string let in letters)
            {
                float count = 0;

                for (int j = 0; j < str.Length; j++)
                {
                    if (let == str[j].ToString())
                        count++;
                }
                AlphabetEntropy.Add(count / str.Length);
            }

            return AlphabetEntropy;
        }

        



        private void Entropy_Counting_Button_Click(object sender, RoutedEventArgs e)
        {
            int FIOCountLetters = TextBoxFIO.Text.Replace(" ", "").Length;

            double FIOEntropy = Entropy * (double)FIOCountLetters;

            MessageBox.Show(FIOEntropy.ToString()+ " бит");
        }
    }
}
