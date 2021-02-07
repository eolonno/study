
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
            this.label2 = new System.Windows.Forms.Label();
            this.AccountTypeField = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BalanceField = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.FIOField = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BirthDateField = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.PassporField = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BankingPanel = new System.Windows.Forms.Panel();
            this.SMSPanel = new System.Windows.Forms.Panel();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Passport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SMS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddButton = new System.Windows.Forms.Button();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.BankingPanel.SuspendLayout();
            this.SMSPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип счета";
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
            this.AccountTypeField.Location = new System.Drawing.Point(52, 67);
            this.AccountTypeField.Name = "AccountTypeField";
            this.AccountTypeField.Size = new System.Drawing.Size(197, 21);
            this.AccountTypeField.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Подключить СМС-оповещения?";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Подключить интернет-банкинг?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(48, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Информация о счете";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Изначальное пополнение";
            // 
            // BalanceField
            // 
            this.BalanceField.Location = new System.Drawing.Point(52, 117);
            this.BalanceField.Name = "BalanceField";
            this.BalanceField.Size = new System.Drawing.Size(197, 20);
            this.BalanceField.TabIndex = 12;
            this.BalanceField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BalanceField_KeyPress);
            this.BalanceField.Validating += new System.ComponentModel.CancelEventHandler(this.BalanceField_Validating);
            this.BalanceField.Validated += new System.EventHandler(this.BalanceField_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(335, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(243, 24);
            this.label7.TabIndex = 15;
            this.label7.Text = "Информация о владельце";
            // 
            // FIOField
            // 
            this.FIOField.Location = new System.Drawing.Point(339, 67);
            this.FIOField.Name = "FIOField";
            this.FIOField.Size = new System.Drawing.Size(197, 20);
            this.FIOField.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(336, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "ФИО";
            // 
            // BirthDateField
            // 
            this.BirthDateField.Location = new System.Drawing.Point(339, 117);
            this.BirthDateField.MaxDate = new System.DateTime(2023, 12, 29, 0, 0, 0, 0);
            this.BirthDateField.MinDate = new System.DateTime(1920, 12, 31, 0, 0, 0, 0);
            this.BirthDateField.Name = "BirthDateField";
            this.BirthDateField.Size = new System.Drawing.Size(197, 20);
            this.BirthDateField.TabIndex = 19;
            this.BirthDateField.Value = new System.DateTime(2021, 2, 7, 0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(336, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Дата рождения";
            // 
            // PassporField
            // 
            this.PassporField.Location = new System.Drawing.Point(339, 167);
            this.PassporField.Name = "PassporField";
            this.PassporField.Size = new System.Drawing.Size(197, 20);
            this.PassporField.TabIndex = 21;
            this.PassporField.Validating += new System.ComponentModel.CancelEventHandler(this.PassporField_Validating);
            this.PassporField.Validated += new System.EventHandler(this.PassporField_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(336, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Серия и номер паспорта";
            // 
            // BankingPanel
            // 
            this.BankingPanel.Controls.Add(this.radioButton3);
            this.BankingPanel.Controls.Add(this.radioButton4);
            this.BankingPanel.Location = new System.Drawing.Point(44, 212);
            this.BankingPanel.Name = "BankingPanel";
            this.BankingPanel.Size = new System.Drawing.Size(132, 25);
            this.BankingPanel.TabIndex = 22;
            // 
            // SMSPanel
            // 
            this.SMSPanel.Controls.Add(this.radioButton5);
            this.SMSPanel.Controls.Add(this.radioButton6);
            this.SMSPanel.Location = new System.Drawing.Point(44, 166);
            this.SMSPanel.Name = "SMSPanel";
            this.SMSPanel.Size = new System.Drawing.Size(132, 25);
            this.SMSPanel.TabIndex = 23;
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
            this.dataGridView1.Location = new System.Drawing.Point(52, 243);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(843, 382);
            this.dataGridView1.TabIndex = 24;
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
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(610, 85);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(197, 23);
            this.AddButton.TabIndex = 25;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // RestoreButton
            // 
            this.RestoreButton.Location = new System.Drawing.Point(610, 114);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(197, 23);
            this.RestoreButton.TabIndex = 26;
            this.RestoreButton.Text = "Восстановить";
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(610, 143);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(197, 23);
            this.SaveButton.TabIndex = 27;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 645);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.RestoreButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.SMSPanel);
            this.Controls.Add(this.BankingPanel);
            this.Controls.Add(this.PassporField);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BirthDateField);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.FIOField);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BalanceField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AccountTypeField);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Счет";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.BankingPanel.ResumeLayout(false);
            this.BankingPanel.PerformLayout();
            this.SMSPanel.ResumeLayout(false);
            this.SMSPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox AccountTypeField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BalanceField;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox FIOField;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker BirthDateField;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox PassporField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel BankingPanel;
        private System.Windows.Forms.Panel SMSPanel;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Passport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birth;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn SMS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banking;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}

