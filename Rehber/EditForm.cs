using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rehber
{
    public partial class EditForm : Form
    {
        public EditForm(string id)
        {
            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // EditForm
            // 
            ClientSize = new Size(788, 443);
            Name = "EditForm";
            Load += EditForm_Load_1;
            ResumeLayout(false);
        }

        private void EditForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
