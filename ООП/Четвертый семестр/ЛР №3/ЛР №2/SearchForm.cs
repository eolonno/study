using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;

namespace ЛР__2
{
    public partial class SearchForm : Form
    {
        List<Account> Accounts = new List<Account>();
        List<Account> SearchedAccounts = new List<Account>();
        public SearchForm(List<Account> accounts)
        {
            InitializeComponent();
            Accounts = accounts;
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            bool isFirstParameter = false;
            if(SearchField.Text != "")
            {
                switch (SearchField.Text)
                {
                    case "ФИО": 
                        foreach(var acc in Accounts)
                            if (Regex.IsMatch(acc.owner.FIO, $@"^{InTextBox.Text}\w*", RegexOptions.IgnoreCase))
                                SearchedAccounts.Add(acc);
                        break;
                    case "Паспорт":
                        foreach (var acc in Accounts)
                            if (Regex.IsMatch(acc.owner.Passport, $@"^{InTextBox.Text}\w*", RegexOptions.IgnoreCase))
                                SearchedAccounts.Add(acc);
                        break;
                    default: isFirstParameter = true;
                        break;
                }
            }
            if(Since.Text != "" || To.Text != "")
            {
                try
                {
                    if (Since.Text == "")
                        Since.Text = "0";
                    else if (To.Text == "0")
                        To.Text = "0";
                    if (!isFirstParameter)
                    {
                        foreach (var acc in Accounts)
                        {
                            if (Convert.ToDouble(Since.Text) <= acc.Balance && acc.Balance <= Convert.ToDouble(To.Text))
                                SearchedAccounts.Add(acc);
                        }
                    }
                    else
                    {
                        foreach (var acc in SearchedAccounts)
                            if (Convert.ToDouble(Since.Text) > acc.Balance && acc.Balance > Convert.ToDouble(To.Text))
                                SearchedAccounts.Remove(acc);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Неверно введены данные!\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            DataGridRowsAdd(SearchOut, SearchedAccounts);
        }
        private void DataGridRowsAdd(DataGridView dgv, List<Account> Accounts)
        {
            int Index = 0;
            while(Index < Accounts.Count - 1)
            {
                Index = dgv.Rows.Add();
                dgv.Rows[Index].Cells["FIO"].Value = Accounts[Index].owner.FIO;
                dgv.Rows[Index].Cells["Passport"].Value = Accounts[Index].owner.Passport;
                dgv.Rows[Index].Cells["Birth"].Value = Accounts[Index].owner.BirthDate;
                dgv.Rows[Index].Cells["AccountType"].Value = Accounts[Index].AccountType;
                dgv.Rows[Index].Cells["Balance"].Value = Accounts[Index].Balance;
                dgv.Rows[Index].Cells["SMS"].Value = Accounts[Index].SMSNotifications ? "+" : "-";
                dgv.Rows[Index].Cells["Banking"].Value = Accounts[Index].InternetBanking ? "+" : "-";
            }
        }

        private void поТипуСчетаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchedAccounts = SearchedAccounts.OrderBy(x => x.AccountType).ToList();
            SearchOut.Rows.Clear();
            DataGridRowsAdd(SearchOut, SearchedAccounts);
        }

        private void поСпециальностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchedAccounts = SearchedAccounts.OrderBy(x => x.owner.BirthDate).ToList();
            SearchOut.Rows.Clear();
            DataGridRowsAdd(SearchOut, SearchedAccounts);
        }

        private void сохраниитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("SearchedAccounts.xml", FileMode.Create))
                {
                    XmlSerializer xml = new XmlSerializer(SearchedAccounts.GetType());
                    xml.Serialize(fs, SearchedAccounts);
                }
                MessageBox.Show("Данные успешно сохранены!", "Успех!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonSearch_Click(sender, e);
        }
    }
}
