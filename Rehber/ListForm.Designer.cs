namespace Rehber
{
    partial class ListForm
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
            components = new System.ComponentModel.Container();
            lstPeople = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            contextMenuStrip1 = new ContextMenuStrip(components);
            duzenleToolStripMenuItem = new ToolStripMenuItem();
            cmsSil = new ToolStripMenuItem();
            yenileToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lstPeople
            // 
            lstPeople.BackColor = SystemColors.AppWorkspace;
            lstPeople.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            lstPeople.ContextMenuStrip = contextMenuStrip1;
            lstPeople.Dock = DockStyle.Fill;
            lstPeople.FullRowSelect = true;
            lstPeople.GridLines = true;
            lstPeople.Location = new Point(20, 60);
            lstPeople.Name = "lstPeople";
            lstPeople.Size = new Size(1284, 478);
            lstPeople.TabIndex = 0;
            lstPeople.UseCompatibleStateImageBehavior = false;
            lstPeople.View = View.Details;
            lstPeople.SelectedIndexChanged += ListForm_Load;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Id";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "FirstName";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "LastName";
            columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Phone";
            columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Mail";
            columnHeader5.Width = 100;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { duzenleToolStripMenuItem, cmsSil, yenileToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(137, 82);
            // 
            // duzenleToolStripMenuItem
            // 
            duzenleToolStripMenuItem.Image = Properties.Resources.EditPencil;
            duzenleToolStripMenuItem.Name = "duzenleToolStripMenuItem";
            duzenleToolStripMenuItem.Size = new Size(136, 26);
            duzenleToolStripMenuItem.Text = "Duzenle";
            duzenleToolStripMenuItem.Click += duzenleToolStripMenuItem_Click;
            // 
            // cmsSil
            // 
            cmsSil.Image = Properties.Resources.TrashIcon;
            cmsSil.Name = "cmsSil";
            cmsSil.Size = new Size(136, 26);
            cmsSil.Text = "Sil";
            cmsSil.Click += cmsSil_Click;
            // 
            // yenileToolStripMenuItem
            // 
            yenileToolStripMenuItem.Image = Properties.Resources.Reflesh;
            yenileToolStripMenuItem.Name = "yenileToolStripMenuItem";
            yenileToolStripMenuItem.Size = new Size(136, 26);
            yenileToolStripMenuItem.Text = "yenile";
            yenileToolStripMenuItem.Click += yenileToolStripMenuItem_Click;
            // 
            // ListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1324, 558);
            Controls.Add(lstPeople);
            Name = "ListForm";
            Text = "ListForm";
            FormClosing += ListForm_FormClosing;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView lstPeople;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem duzenleToolStripMenuItem;
        private ToolStripMenuItem cmsSil;
        private ToolStripMenuItem yenileToolStripMenuItem;
    }
}