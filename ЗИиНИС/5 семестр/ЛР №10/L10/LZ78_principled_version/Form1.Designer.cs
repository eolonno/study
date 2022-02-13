namespace LZ78_principled_version
{
    partial class Form1
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
            this.StartCoding = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.listResult = new System.Windows.Forms.ListBox();
            this.txtResultCrypt = new System.Windows.Forms.TextBox();
            this.btnDecode = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.list = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartCoding
            // 
            this.StartCoding.Location = new System.Drawing.Point(544, 119);
            this.StartCoding.Name = "StartCoding";
            this.StartCoding.Size = new System.Drawing.Size(169, 23);
            this.StartCoding.TabIndex = 0;
            this.StartCoding.Text = "Закодировать сообщение";
            this.StartCoding.UseVisualStyleBackColor = true;
            this.StartCoding.Click += new System.EventHandler(this.StartCoding_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(40, 119);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(404, 76);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.Text = "abcdabceabcdabceabcabcababcaabcdabceabceca";
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // listResult
            // 
            this.listResult.FormattingEnabled = true;
            this.listResult.Location = new System.Drawing.Point(40, 268);
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(404, 95);
            this.listResult.TabIndex = 2;
            // 
            // txtResultCrypt
            // 
            this.txtResultCrypt.Location = new System.Drawing.Point(40, 397);
            this.txtResultCrypt.Multiline = true;
            this.txtResultCrypt.Name = "txtResultCrypt";
            this.txtResultCrypt.Size = new System.Drawing.Size(404, 106);
            this.txtResultCrypt.TabIndex = 3;
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(544, 172);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(169, 23);
            this.btnDecode.TabIndex = 4;
            this.btnDecode.Text = "Декодировать сообщение";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(481, 397);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(346, 105);
            this.txtOutput.TabIndex = 5;
            // 
            // list
            // 
            this.list.FormattingEnabled = true;
            this.list.Location = new System.Drawing.Point(481, 268);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(346, 95);
            this.list.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Введите сообщение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Промежуточные данные";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Результат";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(518, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Результат";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(490, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Декодированное сообщение";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 565);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.list);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.txtResultCrypt);
            this.Controls.Add(this.listResult);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.StartCoding);
            this.Name = "Form1";
            this.Text = "LZ78";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartCoding;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ListBox listResult;
        private System.Windows.Forms.TextBox txtResultCrypt;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.ListBox list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

