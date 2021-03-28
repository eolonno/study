using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ЛР__2
{
    public partial class Form1 : Form
    {
        private List<Account> Accounts = new List<Account>();
        private List<Operation> Operations = new List<Operation>();
        private AbstractFactory AbstractFactory = new AbstractFactory();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //AccountGenerator();
        }

        private void DataGridRowAdd(DataGridView dgv, DateTime? Date = null)
        {
            int Index = dataGridView1.Rows.Add();
            dgv.Rows[Index].Cells["FIO"].Value = Accounts[Index].owner.FIO;
            dgv.Rows[Index].Cells["Passport"].Value = Accounts[Index].owner.Passport;
            dgv.Rows[Index].Cells["Birth"].Value = Accounts[Index].owner.BirthDate;
            dgv.Rows[Index].Cells["AccountType"].Value = Accounts[Index].AccountType;
            dgv.Rows[Index].Cells["Balance"].Value = Accounts[Index].Balance;
            dgv.Rows[Index].Cells["SMS"].Value = Accounts[Index].SMSNotifications ? "+" : "-";
            dgv.Rows[Index].Cells["Banking"].Value = Accounts[Index].InternetBanking ? "+" : "-";

            Operations.Add(AbstractFactory.CreateOperation("Создание счета", null, Date != null ? Convert.ToDateTime(Date) : DateTime.Now));
        }
        private void ClearFields()
        {
            FIOField.ResetText();
            PassporField.ResetText();
            BirthDateField.ResetText();
            AccountTypeField.SelectedIndex = -1;
            BalanceField.ResetText();
            foreach (RadioButton rb in SMSPanel.Controls)
                rb.Checked = false;
            foreach (RadioButton rb in BankingPanel.Controls)
                rb.Checked = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("Accounts.xml", FileMode.Create))
                {
                    XmlSerializer xml = new XmlSerializer(Accounts.GetType());
                    xml.Serialize(fs, Accounts);
                }
                Observer obs = new Observer();
                obs.Notify("Данные успешно сохранены!", "Успех!");
            }
            catch(Exception ex)
            {
                Observer obs = new Observer();
                obs.Notify(ex.Message, "Ошибка!");
            }
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("Accounts.xml", FileMode.Open))
                {
                    Adapter adapter = new Adapter();
                    List<Account> accs = JsonConvert.DeserializeObject<List<Account>>(adapter.XMLToJSON(fs));
                    foreach (var acc in accs)
                        Accounts.Add(acc);
                }
                RewriteDataGrid(dataGridView1);
                Observer obs = new Observer();
                obs.Notify("Данные успешно восстановлены!", "Успех!");
            }
            catch (Exception ex)
            {
                Observer obs = new Observer();
                obs.Notify(ex.Message, "Ошибка!");
            }
        }
        private void RewriteDataGrid(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
                row.Dispose();
            foreach (var acc in Accounts)
            {
                Random rand = new Random();
                DataGridRowAdd(dgv);
                DateTime start = new DateTime(2010, 1, 1);
                int range = (DateTime.Now - start).Days;
                DateTime RandDate = start.AddDays(rand.Next(range));

                Operations.Add(new Operation("Создание счета", null, RandDate));

                HistoryAdd(HistoryGridView);
            }
        }
        private void AccountGenerator()
        {
            using (StreamReader sw = new StreamReader("names.txt", Encoding.UTF8))
            {
                Random rand = new Random();
                while (!sw.EndOfStream)
                {
                    
                    string Passport = "";
                    for (int i = 0; i < 2; i++)
                        Passport += (char)rand.Next(65, 90);
                    Passport += rand.Next(1000000, 9999999);

                    DateTime start = new DateTime(1950, 1, 1);
                    int range = (new DateTime(2005, 1, 1) - start).Days;
                    DateTime RandDate = start.AddDays(rand.Next(range));

                    Accounts.Add(new Account(new Owner(sw.ReadLine(), Passport, RandDate),
                        AccountTypeField.Items[rand.Next(0, 4)].ToString(),
                        rand.Next(0, 1000) + Math.Round(rand.NextDouble(), 2),
                        Convert.ToBoolean(rand.Next(0, 2)),
                        Convert.ToBoolean(rand.Next(0, 2))));
                }
            }
        }

        private void BalanceField_Validating(object sender, CancelEventArgs e)
        {
            int points = 0;
            foreach (var ch in BalanceField.Text)
                if (ch == '.')
                    points++;
            if (points > 1)
            { 
                e.Cancel = true;
                errorProvider1.SetError(BalanceField, "Введены некорректные данные!");
            }

        }

        private void BalanceField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
                e.Handled = !Char.IsDigit(e.KeyChar);
        }

        private void BalanceField_Validated(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void PassporField_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(PassporField.Text))
            {
                e.Cancel = true;
                errorProvider2.SetError(PassporField, "Введите данные!");
            }
            else if (PassporField.Text.Length != 9)
            {
                e.Cancel = true;
                errorProvider2.SetError(PassporField, "Введите корректные данные!");
            }
            else
            {
                for (int i = 0; i < PassporField.Text.Length; i++)
                {
                    if((i == 0 || i == 1) && Char.IsDigit(PassporField.Text[i]))
                    {
                        e.Cancel = true;
                        errorProvider2.SetError(PassporField, "Введите корректные данные!");
                    }
                }
            }
        }

        private void PassporField_Validated(object sender, EventArgs e)
        {
            errorProvider2.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
                return;
            Accounts.Add(AbstractFactory.CreateAccount(
                        FIOField,
                        PassporField,
                        BirthDateField,
                        AccountTypeField,
                        BalanceField,
                        SMSPanel,
                        BankingPanel
                        ));

            DataGridRowAdd(dataGridView1);
            ClearFields();
        }
        
        private void Transaction_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
                return;

            Operations.Add(AbstractFactory.CreateOperation(OperationType.Text, Convert.ToDouble(Total.Text), DateTime.Now));
            
            HistoryAdd(HistoryGridView);
        }
        private void HistoryAdd(DataGridView dgv)
        {
            int Index = HistoryGridView.Rows.Add();
            dgv.Rows[Index].Cells["DateGridView"].Value = Operations[Index].Date;
            dgv.Rows[Index].Cells["OperationTypeGridView"].Value = Operations[Index].OperationType;
            dgv.Rows[Index].Cells["TotalGridView"].Value = Operations[Index].Total != null ? Operations[Index].Total.ToString() : "-";
        }

        private void Total_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
                e.Handled = !Char.IsDigit(e.KeyChar);
        }

        private void Total_Validating(object sender, CancelEventArgs e)
        {
            int points = 0;
            foreach (var ch in Total.Text)
                if (ch == '.')
                    points++;
            if (points > 1)
            {
                e.Cancel = true;
                errorProvider3.SetError(Total, "Введены некорректные данные!");
            }
        }

        private void Total_Validated(object sender, EventArgs e)
        {
            errorProvider3.Clear();
        }
    }
}
