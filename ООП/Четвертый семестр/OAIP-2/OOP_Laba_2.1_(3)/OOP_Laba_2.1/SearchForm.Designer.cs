namespace OOP_Laba_2._1 {
  partial class SearchForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && ( components != null )) {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.search_textbox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.search_btn = new System.Windows.Forms.Button();
      this.search_from_display = new System.Windows.Forms.TreeView();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // search_textbox
      // 
      this.search_textbox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.search_textbox.Location = new System.Drawing.Point(15, 25);
      this.search_textbox.Name = "search_textbox";
      this.search_textbox.Size = new System.Drawing.Size(162, 26);
      this.search_textbox.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Найти:";
      // 
      // search_btn
      // 
      this.search_btn.Location = new System.Drawing.Point(183, 25);
      this.search_btn.Name = "search_btn";
      this.search_btn.Size = new System.Drawing.Size(86, 26);
      this.search_btn.TabIndex = 2;
      this.search_btn.Text = "Поиск";
      this.search_btn.UseVisualStyleBackColor = true;
      this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
      // 
      // search_from_display
      // 
      this.search_from_display.Dock = System.Windows.Forms.DockStyle.Fill;
      this.search_from_display.Location = new System.Drawing.Point(0, 0);
      this.search_from_display.Name = "search_from_display";
      this.search_from_display.Size = new System.Drawing.Size(280, 263);
      this.search_from_display.TabIndex = 3;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.search_textbox);
      this.splitContainer1.Panel1.Controls.Add(this.search_btn);
      this.splitContainer1.Panel1.Controls.Add(this.label1);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.search_from_display);
      this.splitContainer1.Size = new System.Drawing.Size(280, 329);
      this.splitContainer1.SplitterDistance = 62;
      this.splitContainer1.TabIndex = 4;
      // 
      // SearchForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(280, 329);
      this.Controls.Add(this.splitContainer1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimumSize = new System.Drawing.Size(296, 368);
      this.Name = "SearchForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Поиск";
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox search_textbox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button search_btn;
    private System.Windows.Forms.TreeView search_from_display;
    private System.Windows.Forms.SplitContainer splitContainer1;
  }
}