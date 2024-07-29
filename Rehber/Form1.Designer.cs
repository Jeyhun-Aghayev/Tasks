namespace Rehber
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grb1 = new GroupBox();
            button1 = new Button();
            btnSave = new Button();
            txtMail = new TextBox();
            txtPhone = new TextBox();
            label5 = new Label();
            txtLastName = new TextBox();
            label4 = new Label();
            txtFirstName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            grb1.SuspendLayout();
            SuspendLayout();
            // 
            // grb1
            // 
            grb1.Controls.Add(button1);
            grb1.Controls.Add(btnSave);
            grb1.Controls.Add(txtMail);
            grb1.Controls.Add(txtPhone);
            grb1.Controls.Add(label5);
            grb1.Controls.Add(txtLastName);
            grb1.Controls.Add(label4);
            grb1.Controls.Add(txtFirstName);
            grb1.Controls.Add(label3);
            grb1.Controls.Add(label2);
            grb1.Controls.Add(label1);
            grb1.Font = new Font("Segoe UI", 25F);
            grb1.Location = new Point(152, 47);
            grb1.Name = "grb1";
            grb1.Size = new Size(566, 501);
            grb1.TabIndex = 0;
            grb1.TabStop = false;
            grb1.Text = "Kisi Ekle";
            grb1.Enter += grb1_Enter;
            // 
            // button1
            // 
            button1.Location = new Point(12, 391);
            button1.Name = "button1";
            button1.Size = new Size(206, 75);
            button1.TabIndex = 1;
            button1.Text = "View List";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnSave
            // 
            btnSave.BackgroundImageLayout = ImageLayout.Center;
            btnSave.Location = new Point(244, 391);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(280, 75);
            btnSave.TabIndex = 6;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(244, 301);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(280, 63);
            txtMail.TabIndex = 5;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(244, 218);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(280, 63);
            txtPhone.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 301);
            label5.Name = "label5";
            label5.Size = new Size(104, 57);
            label5.TabIndex = 0;
            label5.Text = "Mail";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(244, 140);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(280, 63);
            txtLastName.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 218);
            label4.Name = "label4";
            label4.Size = new Size(159, 57);
            label4.TabIndex = 0;
            label4.Text = "Telefon";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(244, 59);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(280, 63);
            txtFirstName.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 140);
            label3.Name = "label3";
            label3.Size = new Size(148, 57);
            label3.TabIndex = 0;
            label3.Text = "Soyadı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 59);
            label2.Name = "label2";
            label2.Size = new Size(87, 57);
            label2.TabIndex = 0;
            label2.Text = "Adı";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 59);
            label1.Name = "label1";
            label1.Size = new Size(87, 57);
            label1.TabIndex = 1;
            label1.Text = "Adı";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 255);
            ClientSize = new Size(863, 596);
            Controls.Add(grb1);
            Name = "Form1";
            Text = "Telefon";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            grb1.ResumeLayout(false);
            grb1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grb1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox txtMail;
        private TextBox txtPhone;
        private Label label5;
        private TextBox txtLastName;
        private Label label4;
        private TextBox txtFirstName;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnSave;
        private Button button1;
    }
}
