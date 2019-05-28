namespace WorldOfCinema
{
    partial class Form2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильмыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.апаапToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.апиаиавиаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(450, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.Checked = true;
            this.менюToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фильмыToolStripMenuItem,
            this.апаапToolStripMenuItem,
            this.апиаиавиаToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // фильмыToolStripMenuItem
            // 
            this.фильмыToolStripMenuItem.Name = "фильмыToolStripMenuItem";
            this.фильмыToolStripMenuItem.ShowShortcutKeys = false;
            this.фильмыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.фильмыToolStripMenuItem.Text = "фильмы";
            this.фильмыToolStripMenuItem.Click += new System.EventHandler(this.ФильмыToolStripMenuItem_Click);
            // 
            // апаапToolStripMenuItem
            // 
            this.апаапToolStripMenuItem.Name = "апаапToolStripMenuItem";
            this.апаапToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.апаапToolStripMenuItem.Text = "апаап";
            // 
            // апиаиавиаToolStripMenuItem
            // 
            this.апиаиавиаToolStripMenuItem.Name = "апиаиавиаToolStripMenuItem";
            this.апиаиавиаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.апиаиавиаToolStripMenuItem.Text = "апиаиавиа";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 280);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильмыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem апаапToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem апиаиавиаToolStripMenuItem;
    }
}