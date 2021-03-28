
namespace ЛР__2
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SearchOut = new System.Windows.Forms.DataGridView();
            this.FIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Passport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SMS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.InTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchField = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Since = new System.Windows.Forms.TextBox();
            this.To = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сортировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поФИОToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поСпециальностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохраниитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.SearchOut)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchOut
            // 
            this.SearchOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FIO,
            this.Passport,
            this.Birth,
            this.AccountType,
            this.Balance,
            this.SMS,
            this.Banking});
            this.SearchOut.Location = new System.Drawing.Point(59, 55);
            this.SearchOut.Name = "SearchOut";
            this.SearchOut.Size = new System.Drawing.Size(555, 619);
            this.SearchOut.TabIndex = 46;
            // 
            // FIO
            // 
            this.FIO.HeaderText = "ФИО";
            this.FIO.Name = "FIO";
            this.FIO.ReadOnly = true;
            this.FIO.Width = 200;
            // 
            // Passport
            // 
            this.Passport.HeaderText = "Паспорт";
            this.Passport.Name = "Passport";
            this.Passport.ReadOnly = true;
            // 
            // Birth
            // 
            this.Birth.HeaderText = "Дата рождения";
            this.Birth.Name = "Birth";
            this.Birth.ReadOnly = true;
            // 
            // AccountType
            // 
            this.AccountType.HeaderText = "Тип счета";
            this.AccountType.Name = "AccountType";
            this.AccountType.ReadOnly = true;
            // 
            // Balance
            // 
            this.Balance.HeaderText = "Баланс";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // SMS
            // 
            this.SMS.HeaderText = "СМС";
            this.SMS.Name = "SMS";
            this.SMS.ReadOnly = true;
            // 
            // Banking
            // 
            this.Banking.HeaderText = "Банкинг";
            this.Banking.Name = "Banking";
            this.Banking.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(750, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 29);
            this.label1.TabIndex = 47;
            this.label1.Text = "Поиск";
            // 
            // InTextBox
            // 
            this.InTextBox.Location = new System.Drawing.Point(677, 136);
            this.InTextBox.Name = "InTextBox";
            this.InTextBox.Size = new System.Drawing.Size(197, 20);
            this.InTextBox.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(677, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Поиск по:";
            // 
            // SearchField
            // 
            this.SearchField.AutoCompleteCustomSource.AddRange(new string[] {
            "ФИО",
            "Паспорт",
            "Баланс",
            "Тип вклада"});
            this.SearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchField.FormattingEnabled = true;
            this.SearchField.Items.AddRange(new object[] {
            "ФИО",
            "Паспорт"});
            this.SearchField.Location = new System.Drawing.Point(677, 109);
            this.SearchField.Name = "SearchField";
            this.SearchField.Size = new System.Drawing.Size(197, 21);
            this.SearchField.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(677, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Диапазон по балансу:";
            // 
            // Since
            // 
            this.Since.Location = new System.Drawing.Point(677, 179);
            this.Since.Name = "Since";
            this.Since.Size = new System.Drawing.Size(197, 20);
            this.Since.TabIndex = 51;
            // 
            // To
            // 
            this.To.Location = new System.Drawing.Point(677, 205);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(197, 20);
            this.To.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(657, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "С";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(650, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "По";
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(755, 231);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearch.TabIndex = 57;
            this.ButtonSearch.Text = "Поиск";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сортировкаToolStripMenuItem,
            this.сохраниитьToolStripMenuItem,
            this.поискToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(960, 24);
            this.menuStrip1.TabIndex = 58;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сортировкаToolStripMenuItem
            // 
            this.сортировкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поФИОToolStripMenuItem,
            this.поСпециальностиToolStripMenuItem});
            this.сортировкаToolStripMenuItem.Name = "сортировкаToolStripMenuItem";
            this.сортировкаToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.сортировкаToolStripMenuItem.Text = "Сортировка";
            // 
            // поФИОToolStripMenuItem
            // 
            this.поФИОToolStripMenuItem.Name = "поФИОToolStripMenuItem";
            this.поФИОToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.поФИОToolStripMenuItem.Text = "По типу счета";
            this.поФИОToolStripMenuItem.Click += new System.EventHandler(this.поТипуСчетаToolStripMenuItem_Click);
            // 
            // поСпециальностиToolStripMenuItem
            // 
            this.поСпециальностиToolStripMenuItem.Name = "поСпециальностиToolStripMenuItem";
            this.поСпециальностиToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.поСпециальностиToolStripMenuItem.Text = "По дате рождения владельца";
            this.поСпециальностиToolStripMenuItem.Click += new System.EventHandler(this.поСпециальностиToolStripMenuItem_Click);
            // 
            // сохраниитьToolStripMenuItem
            // 
            this.сохраниитьToolStripMenuItem.Name = "сохраниитьToolStripMenuItem";
            this.сохраниитьToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.сохраниитьToolStripMenuItem.Text = "Сохраниить";
            this.сохраниитьToolStripMenuItem.Click += new System.EventHandler(this.сохраниитьToolStripMenuItem_Click);
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.поискToolStripMenuItem.Text = "Поиск";
            this.поискToolStripMenuItem.Click += new System.EventHandler(this.поискToolStripMenuItem_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 728);
            this.Controls.Add(this.ButtonSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.To);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Since);
            this.Controls.Add(this.SearchField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchOut);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            ((System.ComponentModel.ISupportInitialize)(this.SearchOut)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SearchOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Passport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birth;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn SMS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SearchField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Since;
        private System.Windows.Forms.TextBox To;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сортировкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поФИОToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поСпециальностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохраниитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
    }
}