using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Resources;

namespace Lab4_5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();

            FontFamily font = new FontFamily("Times New Roman");
            comboBoxFonts.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            comboBoxFonts.SelectedItem = font;
            labelValue.Content = sliderValue.Value;
            this.Cursor = Cursors.Pen;
            rtbEditor.AddHandler(RichTextBox.DragOverEvent, new DragEventHandler(RichTextBox_DropOver), true);
            rtbEditor.AddHandler(RichTextBox.DropEvent, new DragEventHandler(RichTextBox_Drop), true);
            
        }
        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);
                statusWay.Text = "Путь к файлу:\t" + dlg.FileName;
            }
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }
        private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxFonts.SelectedItem != null)
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, comboBoxFonts.SelectedItem);
        }

        private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, sliderValue.Value);
            
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            rtbEditor.Undo();
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            rtbEditor.Redo();
        }

        private void RichTextBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] docPath = (string[])e.Data.GetData(DataFormats.FileDrop);

                var dataFormat = DataFormats.Rtf;


                if (e.KeyStates == DragDropKeyStates.ShiftKey)
                {
                    dataFormat = DataFormats.Text;
                }

                System.Windows.Documents.TextRange range;
                System.IO.FileStream fStream;
                if (System.IO.File.Exists(docPath[0]))
                {
                    try
                    {
                        range = new System.Windows.Documents.TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                        fStream = new System.IO.FileStream(docPath[0], System.IO.FileMode.OpenOrCreate);
                        range.Load(fStream, dataFormat);
                        fStream.Close();
                        statusWay.Text = "Путь к файлу:\t" + docPath[0] ;
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("File could not be opened. Make sure the file is a text file.");
                    }
                }
            }
        }

        private void RichTextBox_DropOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.All;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = false;
        }

        private void Color_Click(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            SolidColorBrush b = new SolidColorBrush(_Picker.SelectedColor.GetValueOrDefault());
            rtbEditor.Selection.ApplyPropertyValue(Inline.ForegroundProperty, b);


        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (rtbEditor != null)
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, sliderValue.Value);
                labelValue.Content = (int)sliderValue.Value;

            }
        }

        private void StyleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void rtbEdition_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            var text = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
            try
            {
                statusLength.Text = "Количество символов:\t" + (text.Text.Length - 2).ToString();
            }
            catch(NullReferenceException)
            {

            }
        }
    }
}
