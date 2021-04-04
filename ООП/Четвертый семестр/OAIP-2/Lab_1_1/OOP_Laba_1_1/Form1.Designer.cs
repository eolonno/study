namespace OOP_Laba_1_1 {
  partial class Form1 {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && ( components != null )) {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gen = new System.Windows.Forms.Button();
            this.col_size = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sort_des = new System.Windows.Forms.Button();
            this.sort_as = new System.Windows.Forms.Button();
            this.linq_3 = new System.Windows.Forms.Button();
            this.linq_2 = new System.Windows.Forms.Button();
            this.linq_1 = new System.Windows.Forms.Button();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.display_2 = new System.Windows.Forms.ListBox();
            this.display_1 = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.col_size)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gen);
            this.groupBox1.Controls.Add(this.col_size);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(96, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(532, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // gen
            // 
            this.gen.Location = new System.Drawing.Point(273, 15);
            this.gen.Margin = new System.Windows.Forms.Padding(4);
            this.gen.Name = "gen";
            this.gen.Size = new System.Drawing.Size(171, 28);
            this.gen.TabIndex = 2;
            this.gen.Text = "Сгенерировать";
            this.gen.UseVisualStyleBackColor = true;
            this.gen.Click += new System.EventHandler(this.gen_Click);
            // 
            // col_size
            // 
            this.col_size.Location = new System.Drawing.Point(150, 19);
            this.col_size.Margin = new System.Windows.Forms.Padding(4);
            this.col_size.Maximum = new decimal(new int[] {
            150000,
            0,
            0,
            0});
            this.col_size.Name = "col_size";
            this.col_size.Size = new System.Drawing.Size(101, 22);
            this.col_size.TabIndex = 1;
            this.col_size.ValueChanged += new System.EventHandler(this.col_size_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Размер";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sort_des);
            this.groupBox2.Controls.Add(this.sort_as);
            this.groupBox2.Location = new System.Drawing.Point(15, 67);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(705, 50);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // sort_des
            // 
            this.sort_des.Location = new System.Drawing.Point(354, 14);
            this.sort_des.Margin = new System.Windows.Forms.Padding(4);
            this.sort_des.Name = "sort_des";
            this.sort_des.Size = new System.Drawing.Size(300, 28);
            this.sort_des.TabIndex = 1;
            this.sort_des.Text = "Сортировать по убыванию";
            this.sort_des.UseVisualStyleBackColor = true;
            this.sort_des.Click += new System.EventHandler(this.sort_des_Click);
            // 
            // sort_as
            // 
            this.sort_as.Location = new System.Drawing.Point(32, 14);
            this.sort_as.Margin = new System.Windows.Forms.Padding(4);
            this.sort_as.Name = "sort_as";
            this.sort_as.Size = new System.Drawing.Size(301, 28);
            this.sort_as.TabIndex = 0;
            this.sort_as.Text = "Сортировать по возрастанию";
            this.sort_as.UseVisualStyleBackColor = true;
            this.sort_as.Click += new System.EventHandler(this.sort_as_Click);
            // 
            // linq_3
            // 
            this.linq_3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linq_3.Location = new System.Drawing.Point(454, 13);
            this.linq_3.Margin = new System.Windows.Forms.Padding(4);
            this.linq_3.Name = "linq_3";
            this.linq_3.Size = new System.Drawing.Size(200, 28);
            this.linq_3.TabIndex = 4;
            this.linq_3.Text = "Запрос 3";
            this.linq_3.UseVisualStyleBackColor = true;
            this.linq_3.Click += new System.EventHandler(this.linq_3_Click);
            // 
            // linq_2
            // 
            this.linq_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linq_2.Location = new System.Drawing.Point(240, 13);
            this.linq_2.Margin = new System.Windows.Forms.Padding(4);
            this.linq_2.Name = "linq_2";
            this.linq_2.Size = new System.Drawing.Size(206, 28);
            this.linq_2.TabIndex = 3;
            this.linq_2.Text = "Запрос 2";
            this.linq_2.UseVisualStyleBackColor = true;
            this.linq_2.Click += new System.EventHandler(this.linq_2_Click);
            // 
            // linq_1
            // 
            this.linq_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linq_1.Location = new System.Drawing.Point(32, 13);
            this.linq_1.Margin = new System.Windows.Forms.Padding(4);
            this.linq_1.Name = "linq_1";
            this.linq_1.Size = new System.Drawing.Size(200, 28);
            this.linq_1.TabIndex = 2;
            this.linq_1.Text = "Запрос1 ";
            this.linq_1.UseVisualStyleBackColor = true;
            this.linq_1.Click += new System.EventHandler(this.linq_1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(32, 19);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.display_2);
            this.groupBox3.Controls.Add(this.display_1);
            this.groupBox3.Location = new System.Drawing.Point(15, 157);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(705, 210);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // display_2
            // 
            this.display_2.FormattingEnabled = true;
            this.display_2.ItemHeight = 16;
            this.display_2.Location = new System.Drawing.Point(354, 14);
            this.display_2.Margin = new System.Windows.Forms.Padding(4);
            this.display_2.Name = "display_2";
            this.display_2.Size = new System.Drawing.Size(300, 180);
            this.display_2.TabIndex = 3;
            this.display_2.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // display_1
            // 
            this.display_1.FormattingEnabled = true;
            this.display_1.ItemHeight = 16;
            this.display_1.Location = new System.Drawing.Point(32, 14);
            this.display_1.Margin = new System.Windows.Forms.Padding(4);
            this.display_1.Name = "display_1";
            this.display_1.Size = new System.Drawing.Size(300, 180);
            this.display_1.TabIndex = 2;
            this.display_1.SelectedIndexChanged += new System.EventHandler(this.display_1_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.linq_1);
            this.groupBox4.Controls.Add(this.linq_3);
            this.groupBox4.Controls.Add(this.linq_2);
            this.groupBox4.Location = new System.Drawing.Point(15, 117);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(705, 41);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 380);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.col_size)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.NumericUpDown col_size;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button sort_des;
    private System.Windows.Forms.Button sort_as;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    private System.Windows.Forms.Button linq_3;
    private System.Windows.Forms.Button linq_2;
    private System.Windows.Forms.Button linq_1;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Button gen;
    private System.Windows.Forms.ListBox display_1;
    private System.Windows.Forms.ListBox display_2;
    private System.Windows.Forms.GroupBox groupBox4;
  }
}

