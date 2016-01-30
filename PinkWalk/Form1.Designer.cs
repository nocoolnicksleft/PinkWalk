namespace PinkWalk
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pinkyOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemRight = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemWait = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pinkyOptionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.menuItemRight,
            this.menuItemLeft,
            this.menuItemWait,
            this.toolStripMenuItem1,
            this.menuItemOptions,
            this.menuItemExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 170);
            // 
            // pinkyOptionsToolStripMenuItem
            // 
            this.pinkyOptionsToolStripMenuItem.Enabled = false;
            this.pinkyOptionsToolStripMenuItem.Name = "pinkyOptionsToolStripMenuItem";
            this.pinkyOptionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pinkyOptionsToolStripMenuItem.Text = "Pinky";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // menuItemRight
            // 
            this.menuItemRight.Checked = true;
            this.menuItemRight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemRight.Name = "menuItemRight";
            this.menuItemRight.Size = new System.Drawing.Size(152, 22);
            this.menuItemRight.Text = "Right";
            this.menuItemRight.Click += new System.EventHandler(this.menuItemRight_Click);
            // 
            // menuItemLeft
            // 
            this.menuItemLeft.Name = "menuItemLeft";
            this.menuItemLeft.Size = new System.Drawing.Size(152, 22);
            this.menuItemLeft.Text = "Left";
            this.menuItemLeft.Click += new System.EventHandler(this.menuItemLeft_Click);
            // 
            // menuItemWait
            // 
            this.menuItemWait.Name = "menuItemWait";
            this.menuItemWait.Size = new System.Drawing.Size(152, 22);
            this.menuItemWait.Text = "Wait";
            this.menuItemWait.Click += new System.EventHandler(this.menuItemWait_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // menuItemOptions
            // 
            this.menuItemOptions.Name = "menuItemOptions";
            this.menuItemOptions.Size = new System.Drawing.Size(152, 22);
            this.menuItemOptions.Text = "Options";
            this.menuItemOptions.Visible = false;
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(152, 22);
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(287, 322);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pinkyOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemRight;
        private System.Windows.Forms.ToolStripMenuItem menuItemLeft;
        private System.Windows.Forms.ToolStripMenuItem menuItemWait;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemOptions;


    }
}

