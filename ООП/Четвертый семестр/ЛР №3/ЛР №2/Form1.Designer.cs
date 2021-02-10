
namespace ЛР__2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Transaction = new System.Windows.Forms.Button();
            this.Total = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.OperationType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.SMSPanel = new System.Windows.Forms.Panel();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.BankingPanel = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.PassporField = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BirthDateField = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.FIOField = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BalanceField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AccountTypeField = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Passport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SMS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.HistoryGridView = new System.Windows.Forms.DataGridView();
            this.DateGridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalGridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationTypeGridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SMSPanel.SuspendLayout();
            this.BankingPanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HistoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(-1, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(954, 730);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Transaction);
            this.tabPage1.Controls.Add(this.Total);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.OperationType);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.SaveButton);
            this.tabPage1.Controls.Add(this.RestoreButton);
            this.tabPage1.Controls.Add(this.AddButton);
            this.tabPage1.Controls.Add(this.SMSPanel);
            this.tabPage1.Controls.Add(this.BankingPanel);
            this.tabPage1.Controls.Add(this.PassporField);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.BirthDateField);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.FIOField);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.BalanceField);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.AccountTypeField);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(946, 704);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Добавление";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Transaction
            // 
            this.Transaction.Location = new System.Drawing.Point(365, 503);
            this.Transaction.Name = "Transaction";
            this.Transaction.Size = new System.Drawing.Size(197, 23);
            this.Transaction.TabIndex = 54;
            this.Transaction.Text = "Выполнить";
            this.Transaction.UseVisualStyleBackColor = true;
            this.Transaction.Click += new System.EventHandler(this.Transaction_Click);
            // 
            // Total
            // 
            this.Total.Location = new System.Drawing.Point(365, 457);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(197, 20);
            this.Total.TabIndex = 53;
            this.Total.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Total_KeyPress);
            this.Total.Validating += new System.ComponentModel.CancelEventHandler(this.Total_Validating);
            this.Total.Validated += new System.EventHandler(this.Total_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(362, 440);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 13);
            this.label12.TabIndex = 52;
            this.label12.Text = "Сумма транзакции";
            // 
            // OperationType
            // 
            this.OperationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OperationType.FormattingEnabled = true;
            this.OperationType.Items.AddRange(new object[] {
            "Перевод",
            "Снятие",
            "Пополнение",
            "Платеж"});
            this.OperationType.Location = new System.Drawing.Point(365, 407);
            this.OperationType.Name = "OperationType";
            this.OperationType.Size = new System.Drawing.Size(197, 21);
            this.OperationType.TabIndex = 51;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(362, 390);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 50;
            this.label13.Text = "Тип транзакции";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(332, 340);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(291, 29);
            this.label11.TabIndex = 49;
            this.label11.Text = "Выполнить транзакцию";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(360, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 29);
            this.label10.TabIndex = 48;
            this.label10.Text = "Добавить счет";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(626, 222);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(197, 23);
            this.SaveButton.TabIndex = 47;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // RestoreButton
            // 
            this.RestoreButton.Location = new System.Drawing.Point(626, 193);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(197, 23);
            this.RestoreButton.TabIndex = 46;
            this.RestoreButton.Text = "Восстановить";
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(626, 164);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(197, 23);
            this.AddButton.TabIndex = 45;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // SMSPanel
            // 
            this.SMSPanel.Controls.Add(this.radioButton5);
            this.SMSPanel.Controls.Add(this.radioButton6);
            this.SMSPanel.Location = new System.Drawing.Point(90, 240);
            this.SMSPanel.Name = "SMSPanel";
            this.SMSPanel.Size = new System.Drawing.Size(132, 25);
            this.SMSPanel.TabIndex = 43;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(76, 3);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(44, 17);
            this.radioButton5.TabIndex = 9;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Нет";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(8, 3);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(40, 17);
            this.radioButton6.TabIndex = 8;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Да";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // BankingPanel
            // 
            this.BankingPanel.Controls.Add(this.radioButton3);
            this.BankingPanel.Controls.Add(this.radioButton4);
            this.BankingPanel.Location = new System.Drawing.Point(90, 286);
            this.BankingPanel.Name = "BankingPanel";
            this.BankingPanel.Size = new System.Drawing.Size(132, 25);
            this.BankingPanel.TabIndex = 42;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(76, 3);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(44, 17);
            this.radioButton3.TabIndex = 9;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Нет";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(8, 3);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(40, 17);
            this.radioButton4.TabIndex = 8;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Да";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // PassporField
            // 
            this.PassporField.Location = new System.Drawing.Point(365, 241);
            this.PassporField.Name = "PassporField";
            this.PassporField.Size = new System.Drawing.Size(197, 20);
            this.PassporField.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(362, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Серия и номер паспорта";
            // 
            // BirthDateField
            // 
            this.BirthDateField.Location = new System.Drawing.Point(365, 191);
            this.BirthDateField.MaxDate = new System.DateTime(2023, 12, 29, 0, 0, 0, 0);
            this.BirthDateField.MinDate = new System.DateTime(1920, 12, 31, 0, 0, 0, 0);
            this.BirthDateField.Name = "BirthDateField";
            this.BirthDateField.Size = new System.Drawing.Size(197, 20);
            this.BirthDateField.TabIndex = 39;
            this.BirthDateField.Value = new System.DateTime(2021, 2, 7, 0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(362, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Дата рождения";
            // 
            // FIOField
            // 
            this.FIOField.Location = new System.Drawing.Point(365, 141);
            this.FIOField.Name = "FIOField";
            this.FIOField.Size = new System.Drawing.Size(197, 20);
            this.FIOField.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(362, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "ФИО";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(361, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(243, 24);
            this.label7.TabIndex = 35;
            this.label7.Text = "Информация о владельце";
            // 
            // BalanceField
            // 
            this.BalanceField.Location = new System.Drawing.Point(98, 191);
            this.BalanceField.Name = "BalanceField";
            this.BalanceField.Size = new System.Drawing.Size(197, 20);
            this.BalanceField.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Изначальное пополнение";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(94, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 24);
            this.label5.TabIndex = 32;
            this.label5.Text = "Информация о счете";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Подключить интернет-банкинг?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Подключить СМС-оповещения?";
            // 
            // AccountTypeField
            // 
            this.AccountTypeField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccountTypeField.FormattingEnabled = true;
            this.AccountTypeField.Items.AddRange(new object[] {
            "Текущий ",
            "Расчетный",
            "Кредитный",
            "Депозитный",
            "Бюджетный"});
            this.AccountTypeField.Location = new System.Drawing.Point(98, 141);
            this.AccountTypeField.Name = "AccountTypeField";
            this.AccountTypeField.Size = new System.Drawing.Size(197, 21);
            this.AccountTypeField.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Тип счета";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(946, 704);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "БД";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FIO,
            this.Passport,
            this.Birth,
            this.AccountType,
            this.Balance,
            this.SMS,
            this.Banking});
            this.dataGridView1.Location = new System.Drawing.Point(52, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(843, 619);
            this.dataGridView1.TabIndex = 45;
            // 
            // FIO
            // 
            this.FIO.Frozen = true;
            this.FIO.HeaderText = "ФИО";
            this.FIO.Name = "FIO";
            this.FIO.ReadOnly = true;
            this.FIO.Width = 200;
            // 
            // Passport
            // 
            this.Passport.Frozen = true;
            this.Passport.HeaderText = "Паспорт";
            this.Passport.Name = "Passport";
            this.Passport.ReadOnly = true;
            // 
            // Birth
            // 
            this.Birth.Frozen = true;
            this.Birth.HeaderText = "Дата рождения";
            this.Birth.Name = "Birth";
            this.Birth.ReadOnly = true;
            // 
            // AccountType
            // 
            this.AccountType.Frozen = true;
            this.AccountType.HeaderText = "Тип счета";
            this.AccountType.Name = "AccountType";
            this.AccountType.ReadOnly = true;
            // 
            // Balance
            // 
            this.Balance.Frozen = true;
            this.Balance.HeaderText = "Баланс";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // SMS
            // 
            this.SMS.Frozen = true;
            this.SMS.HeaderText = "СМС";
            this.SMS.Name = "SMS";
            this.SMS.ReadOnly = true;
            // 
            // Banking
            // 
            this.Banking.Frozen = true;
            this.Banking.HeaderText = "Банкинг";
            this.Banking.Name = "Banking";
            this.Banking.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.HistoryGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(946, 704);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "История";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // HistoryGridView
            // 
            this.HistoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HistoryGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateGridView,
            this.TotalGridView,
            this.OperationTypeGridView});
            this.HistoryGridView.Location = new System.Drawing.Point(160, 35);
            this.HistoryGridView.Name = "HistoryGridView";
            this.HistoryGridView.Size = new System.Drawing.Size(595, 622);
            this.HistoryGridView.TabIndex = 0;
            // 
            // DateGridView
            // 
            this.DateGridView.HeaderText = "Дата";
            this.DateGridView.Name = "DateGridView";
            this.DateGridView.ReadOnly = true;
            this.DateGridView.Width = 150;
            // 
            // TotalGridView
            // 
            this.TotalGridView.HeaderText = "Сумма";
            this.TotalGridView.Name = "TotalGridView";
            this.TotalGridView.ReadOnly = true;
            // 
            // OperationTypeGridView
            // 
            this.OperationTypeGridView.HeaderText = "Тип операции";
            this.OperationTypeGridView.Name = "OperationTypeGridView";
            this.OperationTypeGridView.ReadOnly = true;
            this.OperationTypeGridView.Width = 300;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 728);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Счет";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.SMSPanel.ResumeLayout(false);
            this.SMSPanel.PerformLayout();
            this.BankingPanel.ResumeLayout(false);
            this.BankingPanel.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HistoryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Panel SMSPanel;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.Panel BankingPanel;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.TextBox PassporField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker BirthDateField;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox FIOField;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox BalanceField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox AccountTypeField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Passport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birth;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn SMS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banking;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Transaction;
        private System.Windows.Forms.TextBox Total;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox OperationType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView HistoryGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperationTypeGridView;
        private System.Windows.Forms.ErrorProvider errorProvider3;
    }
}

