namespace OOP_Laba_8._1 {
  partial class Form1 {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose( bool disposing ) {
      if ( disposing && ( components != null ) ) {
        components.Dispose( );
      }
      base.Dispose( disposing );
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent( ) {
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.addButton = new System.Windows.Forms.Button();
      this.saveButton = new System.Windows.Forms.Button();
      this.delete = new System.Windows.Forms.Button();
      this.nextButton = new System.Windows.Forms.Button();
      this.prevButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGridView1
      // 
      this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new System.Drawing.Point(0, -2);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(802, 374);
      this.dataGridView1.TabIndex = 0;
      // 
      // addButton
      // 
      this.addButton.Location = new System.Drawing.Point(174, 407);
      this.addButton.Name = "addButton";
      this.addButton.Size = new System.Drawing.Size(75, 23);
      this.addButton.TabIndex = 1;
      this.addButton.Text = "Add";
      this.addButton.UseVisualStyleBackColor = true;
      this.addButton.Click += new System.EventHandler(this.addButton_Click);
      // 
      // saveButton
      // 
      this.saveButton.Location = new System.Drawing.Point(347, 406);
      this.saveButton.Name = "saveButton";
      this.saveButton.Size = new System.Drawing.Size(75, 23);
      this.saveButton.TabIndex = 2;
      this.saveButton.Text = "Save";
      this.saveButton.UseVisualStyleBackColor = true;
      this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
      // 
      // delete
      // 
      this.delete.Location = new System.Drawing.Point(535, 406);
      this.delete.Name = "delete";
      this.delete.Size = new System.Drawing.Size(75, 23);
      this.delete.TabIndex = 3;
      this.delete.Text = "Delete";
      this.delete.UseVisualStyleBackColor = true;
      this.delete.Click += new System.EventHandler(this.deleteButton_Click);
      // 
      // nextButton
      // 
      this.nextButton.Location = new System.Drawing.Point(701, 405);
      this.nextButton.Name = "nextButton";
      this.nextButton.Size = new System.Drawing.Size(75, 23);
      this.nextButton.TabIndex = 4;
      this.nextButton.Text = "next";
      this.nextButton.UseVisualStyleBackColor = true;
      this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
      // 
      // prevButton
      // 
      this.prevButton.Location = new System.Drawing.Point(53, 405);
      this.prevButton.Name = "prevButton";
      this.prevButton.Size = new System.Drawing.Size(75, 23);
      this.prevButton.TabIndex = 5;
      this.prevButton.Text = "prev";
      this.prevButton.UseVisualStyleBackColor = true;
      this.prevButton.Click += new System.EventHandler(this.PrevButton_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.prevButton);
      this.Controls.Add(this.nextButton);
      this.Controls.Add(this.delete);
      this.Controls.Add(this.saveButton);
      this.Controls.Add(this.addButton);
      this.Controls.Add(this.dataGridView1);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Button addButton;
    private System.Windows.Forms.Button saveButton;
    private System.Windows.Forms.Button delete;
    private System.Windows.Forms.Button nextButton;
    private System.Windows.Forms.Button prevButton;
  }
}

