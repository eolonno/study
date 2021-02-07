namespace lab3_kgig
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
            this.zedGraph = new ZedGraph.ZedGraphControl();
            this.zedGraph1 = new ZedGraph.ZedGraphControl();
            this.zedGraph2 = new ZedGraph.ZedGraphControl();
            this.zedGraph3 = new ZedGraph.ZedGraphControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.F_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.F_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.F_3 = new System.Windows.Forms.ToolStripMenuItem();
            this.F_4 = new System.Windows.Forms.ToolStripMenuItem();
            this.F_ALL = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraph
            // 
            this.zedGraph.IsShowPointValues = false;
            this.zedGraph.Location = new System.Drawing.Point(12, 27);
            this.zedGraph.Name = "zedGraph";
            this.zedGraph.PointValueFormat = "G";
            this.zedGraph.Size = new System.Drawing.Size(411, 233);
            this.zedGraph.TabIndex = 0;
            // 
            // zedGraph1
            // 
            this.zedGraph1.IsShowPointValues = false;
            this.zedGraph1.Location = new System.Drawing.Point(473, 27);
            this.zedGraph1.Name = "zedGraph1";
            this.zedGraph1.PointValueFormat = "G";
            this.zedGraph1.Size = new System.Drawing.Size(411, 233);
            this.zedGraph1.TabIndex = 1;
            // 
            // zedGraph2
            // 
            this.zedGraph2.IsShowPointValues = false;
            this.zedGraph2.Location = new System.Drawing.Point(12, 266);
            this.zedGraph2.Name = "zedGraph2";
            this.zedGraph2.PointValueFormat = "G";
            this.zedGraph2.Size = new System.Drawing.Size(411, 233);
            this.zedGraph2.TabIndex = 2;
            // 
            // zedGraph3
            // 
            this.zedGraph3.IsShowPointValues = false;
            this.zedGraph3.Location = new System.Drawing.Point(473, 266);
            this.zedGraph3.Name = "zedGraph3";
            this.zedGraph3.PointValueFormat = "G";
            this.zedGraph3.Size = new System.Drawing.Size(411, 233);
            this.zedGraph3.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.F_1,
            this.F_2,
            this.F_3,
            this.F_4,
            this.F_ALL});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(911, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // F_1
            // 
            this.F_1.Name = "F_1";
            this.F_1.ShowShortcutKeys = false;
            this.F_1.Size = new System.Drawing.Size(36, 20);
            this.F_1.Text = "F_1";
            this.F_1.Click += new System.EventHandler(this.F_1_Click);
            // 
            // F_2
            // 
            this.F_2.Name = "F_2";
            this.F_2.Size = new System.Drawing.Size(36, 20);
            this.F_2.Text = "F_2";
            this.F_2.Click += new System.EventHandler(this.F_2_Click);
            // 
            // F_3
            // 
            this.F_3.Name = "F_3";
            this.F_3.Size = new System.Drawing.Size(36, 20);
            this.F_3.Text = "F_3";
            this.F_3.Click += new System.EventHandler(this.F_3_Click);
            // 
            // F_4
            // 
            this.F_4.Name = "F_4";
            this.F_4.Size = new System.Drawing.Size(36, 20);
            this.F_4.Text = "F_4";
            this.F_4.Click += new System.EventHandler(this.F_4_Click);
            // 
            // F_ALL
            // 
            this.F_ALL.Name = "F_ALL";
            this.F_ALL.Size = new System.Drawing.Size(50, 20);
            this.F_ALL.Text = "F_ALL";
            this.F_ALL.Click += new System.EventHandler(this.F_ALL_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 511);
            this.Controls.Add(this.zedGraph3);
            this.Controls.Add(this.zedGraph2);
            this.Controls.Add(this.zedGraph1);
            this.Controls.Add(this.zedGraph);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "MyPlot2D (VladSenyuk)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraph;
        private ZedGraph.ZedGraphControl zedGraph1;
        private ZedGraph.ZedGraphControl zedGraph2;
        private ZedGraph.ZedGraphControl zedGraph3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem F_1;
        private System.Windows.Forms.ToolStripMenuItem F_2;
        private System.Windows.Forms.ToolStripMenuItem F_3;
        private System.Windows.Forms.ToolStripMenuItem F_4;
        private System.Windows.Forms.ToolStripMenuItem F_ALL;
    }
}

