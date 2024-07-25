namespace Rehber
{
    partial class MainForm
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
            btnList = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // btnList
            // 
            btnList.BackColor = Color.FromArgb(255, 192, 128);
            btnList.Font = new Font("Segoe UI", 25F);
            btnList.Location = new Point(366, 297);
            btnList.Name = "btnList";
            btnList.Size = new Size(232, 200);
            btnList.TabIndex = 0;
            btnList.Text = "Kisi listesi";
            btnList.UseVisualStyleBackColor = false;
            btnList.Click += button2_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(255, 128, 0);
            btnEdit.Font = new Font("Segoe UI", 25F);
            btnEdit.Location = new Point(366, 87);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(232, 200);
            btnEdit.TabIndex = 0;
            btnEdit.Text = "Edit Form";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(192, 64, 0);
            btnAdd.Font = new Font("Segoe UI", 25F);
            btnAdd.Location = new Point(122, 87);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(232, 410);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Kisi ekle";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1338, 572);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnList);
            Name = "MainForm";
            Text = "Telefon Rehberi";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button btnList;
        private Button btnEdit;
        private Button btnAdd;
    }
}