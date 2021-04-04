namespace Lab_1
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
      this.strField = new System.Windows.Forms.TextBox();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.btn_1 = new System.Windows.Forms.Button();
      this.btn_2 = new System.Windows.Forms.Button();
      this.btn_clear = new System.Windows.Forms.Button();
      this.btn_3 = new System.Windows.Forms.Button();
      this.btn_4 = new System.Windows.Forms.Button();
      this.btn_5 = new System.Windows.Forms.Button();
      this.btn_6 = new System.Windows.Forms.Button();
      this.btn_apply = new System.Windows.Forms.Button();
      this.btn_7 = new System.Windows.Forms.Button();
      this.btn_8 = new System.Windows.Forms.Button();
      this.opLabel = new System.Windows.Forms.Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // strField
      // 
      this.strField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.strField.Location = new System.Drawing.Point(13, 26);
      this.strField.Multiline = true;
      this.strField.Name = "strField";
      this.strField.Size = new System.Drawing.Size(299, 83);
      this.strField.TabIndex = 0;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.Controls.Add(this.btn_8, 1, 3);
      this.tableLayoutPanel1.Controls.Add(this.btn_7, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.btn_apply, 2, 2);
      this.tableLayoutPanel1.Controls.Add(this.btn_6, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.btn_5, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.btn_4, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.btn_3, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.btn_clear, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.btn_2, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.btn_1, 0, 0);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 124);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 4;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(299, 211);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // btn_1
      // 
      this.btn_1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btn_1.Location = new System.Drawing.Point(1, 1);
      this.btn_1.Margin = new System.Windows.Forms.Padding(1);
      this.btn_1.Name = "btn_1";
      this.btn_1.Size = new System.Drawing.Size(117, 50);
      this.btn_1.TabIndex = 0;
      this.btn_1.Text = "change substring";
      this.btn_1.UseVisualStyleBackColor = true;
      this.btn_1.Click += new System.EventHandler(this.BtnOnClick);
      // 
      // btn_2
      // 
      this.btn_2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btn_2.Location = new System.Drawing.Point(120, 1);
      this.btn_2.Margin = new System.Windows.Forms.Padding(1);
      this.btn_2.Name = "btn_2";
      this.btn_2.Size = new System.Drawing.Size(117, 50);
      this.btn_2.TabIndex = 1;
      this.btn_2.Text = "delete substring";
      this.btn_2.UseVisualStyleBackColor = true;
      this.btn_2.Click += new System.EventHandler(this.BtnOnClick);
      // 
      // btn_clear
      // 
      this.btn_clear.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btn_clear.Location = new System.Drawing.Point(239, 1);
      this.btn_clear.Margin = new System.Windows.Forms.Padding(1);
      this.btn_clear.Name = "btn_clear";
      this.tableLayoutPanel1.SetRowSpan(this.btn_clear, 2);
      this.btn_clear.Size = new System.Drawing.Size(59, 102);
      this.btn_clear.TabIndex = 2;
      this.btn_clear.Text = "clear";
      this.btn_clear.UseVisualStyleBackColor = true;
      this.btn_clear.Click += new System.EventHandler(this.BtnOnClick);
      // 
      // btn_3
      // 
      this.btn_3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btn_3.Location = new System.Drawing.Point(1, 53);
      this.btn_3.Margin = new System.Windows.Forms.Padding(1);
      this.btn_3.Name = "btn_3";
      this.btn_3.Size = new System.Drawing.Size(117, 50);
      this.btn_3.TabIndex = 3;
      this.btn_3.Text = "find symbol by index";
      this.btn_3.UseVisualStyleBackColor = true;
      this.btn_3.Click += new System.EventHandler(this.BtnOnClick);
      // 
      // btn_4
      // 
      this.btn_4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btn_4.Location = new System.Drawing.Point(120, 53);
      this.btn_4.Margin = new System.Windows.Forms.Padding(1);
      this.btn_4.Name = "btn_4";
      this.btn_4.Size = new System.Drawing.Size(117, 50);
      this.btn_4.TabIndex = 4;
      this.btn_4.Text = "string length";
      this.btn_4.UseVisualStyleBackColor = true;
      this.btn_4.Click += new System.EventHandler(this.BtnOnClick);
      // 
      // btn_5
      // 
      this.btn_5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btn_5.Location = new System.Drawing.Point(1, 105);
      this.btn_5.Margin = new System.Windows.Forms.Padding(1);
      this.btn_5.Name = "btn_5";
      this.btn_5.Size = new System.Drawing.Size(117, 50);
      this.btn_5.TabIndex = 6;
      this.btn_5.Text = "amount of vovels";
      this.btn_5.UseVisualStyleBackColor = true;
      this.btn_5.Click += new System.EventHandler(this.BtnOnClick);
      // 
      // btn_6
      // 
      this.btn_6.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btn_6.Location = new System.Drawing.Point(120, 105);
      this.btn_6.Margin = new System.Windows.Forms.Padding(1);
      this.btn_6.Name = "btn_6";
      this.btn_6.Size = new System.Drawing.Size(117, 50);
      this.btn_6.TabIndex = 7;
      this.btn_6.Text = "amount of consonants";
      this.btn_6.UseVisualStyleBackColor = true;
      this.btn_6.Click += new System.EventHandler(this.BtnOnClick);
      // 
      // btn_apply
      // 
      this.btn_apply.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btn_apply.Location = new System.Drawing.Point(239, 105);
      this.btn_apply.Margin = new System.Windows.Forms.Padding(1);
      this.btn_apply.Name = "btn_apply";
      this.tableLayoutPanel1.SetRowSpan(this.btn_apply, 2);
      this.btn_apply.Size = new System.Drawing.Size(59, 105);
      this.btn_apply.TabIndex = 8;
      this.btn_apply.Text = "apply";
      this.btn_apply.UseVisualStyleBackColor = true;
      this.btn_apply.Click += new System.EventHandler(this.BtnOnClick);
      // 
      // btn_7
      // 
      this.btn_7.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btn_7.Location = new System.Drawing.Point(1, 157);
      this.btn_7.Margin = new System.Windows.Forms.Padding(1);
      this.btn_7.Name = "btn_7";
      this.btn_7.Size = new System.Drawing.Size(117, 53);
      this.btn_7.TabIndex = 9;
      this.btn_7.Text = "amount of sentences";
      this.btn_7.UseVisualStyleBackColor = true;
      this.btn_7.Click += new System.EventHandler(this.BtnOnClick);
      // 
      // btn_8
      // 
      this.btn_8.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btn_8.Location = new System.Drawing.Point(120, 157);
      this.btn_8.Margin = new System.Windows.Forms.Padding(1);
      this.btn_8.Name = "btn_8";
      this.btn_8.Size = new System.Drawing.Size(117, 53);
      this.btn_8.TabIndex = 10;
      this.btn_8.Text = "amount of words";
      this.btn_8.UseVisualStyleBackColor = true;
      this.btn_8.Click += new System.EventHandler(this.BtnOnClick);
      // 
      // opLabel
      // 
      this.opLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.opLabel.AutoSize = true;
      this.opLabel.Location = new System.Drawing.Point(11, 10);
      this.opLabel.Margin = new System.Windows.Forms.Padding(0, 3, 6, 0);
      this.opLabel.Name = "opLabel";
      this.opLabel.Size = new System.Drawing.Size(53, 13);
      this.opLabel.TabIndex = 2;
      this.opLabel.Text = "Operation";
      this.opLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(324, 347);
      this.Controls.Add(this.opLabel);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Controls.Add(this.strField);
      this.Name = "Form1";
      this.Text = "Form1";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.TextBox strField;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button btn_8;
    private System.Windows.Forms.Button btn_7;
    private System.Windows.Forms.Button btn_apply;
    private System.Windows.Forms.Button btn_6;
    private System.Windows.Forms.Button btn_5;
    private System.Windows.Forms.Button btn_4;
    private System.Windows.Forms.Button btn_3;
    private System.Windows.Forms.Button btn_clear;
    private System.Windows.Forms.Button btn_2;
    private System.Windows.Forms.Button btn_1;
    private System.Windows.Forms.Label opLabel;
  }
}

