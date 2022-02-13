using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace LZ78_principled_version
{
    public partial class Form1 : MaterialForm
    {
        public readonly MaterialSkinManager materialSkinManager;
        public Form1()
        {

            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, )
            materialSkinManager.AddFormToManage(this);
        }
        Dictionary<string, int> dict_sequence_letters = new Dictionary<string, int>();
        int count_code;
        List<int> arrayResult;

        private void StartCoding_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(sizeof(String).ToString());
            listResult.Items.Clear();
            list.Items.Clear();
            txtResultCrypt.Clear();

            arrayResult = new List<int>();
            dict_sequence_letters.Clear();
            count_code = 256;

            FormationDictionary();

            string message = txtMessage.Text; // сообщение, введённое пользователем
            this.CryptMessage(message);
        }

        void FormationDictionary() // формирование словаря
        {
            byte[] cods = new byte[256];
            int count = 0;
            for (int i = 0; i < 256; i++) // коды ASCII
            {
                cods[count] = (byte)i;
                count++;
            }

            char[] chars = Encoding.Default.GetChars(cods); // символы, полученые по коду

            //string s = "Рука";
            //byte[] c = Encoding.Default.GetBytes(s);
            for (int i = 0; i < 256; i++) // формирование словаря
            {
                if (i == 32)
                    dict_sequence_letters.Add("⋅", i);

                dict_sequence_letters.Add(chars[i].ToString(), i);
            }
        }

        public void CryptMessage(string message)
        {
            string buffer_sequence_letters = "";
            int code_output = 0;

            foreach (char letter in message) // перебор символов строки
            {
                string convert_letter = letter.ToString(); // конвертирования символа

                listResult.Items.Add("Данные на входе: " + letter + "; Текущий фрагмент: " + buffer_sequence_letters);

                buffer_sequence_letters += convert_letter; // добавление символа к последовательности

                int value;
                if (dict_sequence_letters.TryGetValue(buffer_sequence_letters, out value)) // ключ найден
                {
                    code_output = dict_sequence_letters[buffer_sequence_letters]; // сохранение кода символа

                    if (code_output == 277)
                        MessageBox.Show("Закодировано!"); // fdgdf

                }
                else // ключ не найден
                {
                    count_code++; // хранение значения кода для последующих последовательностей
                    dict_sequence_letters.Add(buffer_sequence_letters, count_code); // добавление послежовательности в словарь
                    arrayResult.Add(code_output); //добавление результата


                    // вывод на форму
                    txtResultCrypt.Text += code_output.ToString() + " ";
                    string write = string.Format("Добавление фрагмента в словарь: '{0}' : {1}; Данные на выходе: {2}", buffer_sequence_letters, dict_sequence_letters[buffer_sequence_letters].ToString(), code_output);
                    listResult.Items.Add(write);


                    buffer_sequence_letters = convert_letter;  // присваиваем текущий символ
                    code_output = dict_sequence_letters[buffer_sequence_letters];
                }
            }
            arrayResult.Add(dict_sequence_letters[buffer_sequence_letters]); // добавляем последнюю последовательность

            // вывод на форму
            txtResultCrypt.Text += code_output.ToString();
            string writ = string.Format("Добавление фрагмента в словарь: '{0}' : {1}; Данные на выходе: {2}", buffer_sequence_letters, dict_sequence_letters[buffer_sequence_letters].ToString(), code_output);
            listResult.Items.Add(writ);
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            dict_sequence_letters.Clear();
            count_code = 256;

            FormationDictionary(); // формирование первых символов
            this.DecodeMessage();
        }

        public void DecodeMessage()
        {
            string message = "";
            string current_letter = "";

            foreach (int code in arrayResult)
            {
                string key = GetKeyByValue(code); // узнать ключ по значению
                message += key;

                if (key != null)
                {
                    if (code > 256) // формируем последовательность символов для добавления в словарь
                        current_letter += key[0].ToString();
                    else
                        current_letter += key;

                    list.Items.Add("Данные на входе: " + code + " Данные на выходе: " + current_letter);


                    int value;
                    if (!dict_sequence_letters.TryGetValue(current_letter, out value)) // если значения нет в словаре, то добавляем его
                    {
                        count_code++;
                        dict_sequence_letters.Add(current_letter, count_code);

                        string wr = string.Format("Добавление фрагмента: '{0}' : {1} ", current_letter, count_code);
                        list.Items.Add(wr);

                        current_letter = key;
                    }

                }
                else // если кода нет в словаре, то берём текущий символ и прибавляем к нему первый байт
                {
                    count_code++;
                    current_letter += current_letter[0];
                    message += current_letter;

                    dict_sequence_letters.Add(current_letter, count_code);
                    string wr = string.Format("Кода нет в словаре. Добавление фрагмента: '{0}' : {1} ", current_letter, count_code);
                    list.Items.Add(wr);
                }


            }
            txtOutput.Text = message;
        }

        public string GetKeyByValue(int value)
        {
            foreach (var record in dict_sequence_letters)
            {
                if (record.Value.Equals(value))
                    return record.Key;
            }
            return null;
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
