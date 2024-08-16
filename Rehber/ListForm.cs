using MetroFramework.Forms;
using Microsoft.Extensions.Configuration;
using Rehber.Models;
using System.Data;
using System.Data.SqlClient;
using System.Security.Permissions;

namespace Rehber
{
    public partial class ListForm : MetroForm
    {
        public ListForm()
        {
            InitializeComponent();
        }

        public void Refles()
        {

            lstPeople.Items.Clear();
            using SqlConnection con = new SqlConnection(Program.Configuration.GetConnectionString("default"));
            using SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select [Id], [FirstName], [LastName], [Phone], [Mail] FROM People";
            cmd.CommandType = System.Data.CommandType.Text;
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            using SqlDataReader dr = cmd.ExecuteReader();
            List<Person> people = new List<Person>();
            while (dr.Read())
            {
                #region basic

                /*Person person = new()
                {
                    Id = dr[nameof(Person.Id)] as int? ?? 0,
                    FirstName = dr[nameof(Person.FirstName)] as string,
                    LastName = dr[nameof(Person.LastName)] as string,
                    Phone = dr[nameof(Person.Phone)] as string,
                    Mail = dr[nameof(Person.Mail)] as string,
                };
                people.Add(person);*/
                #endregion
                ListViewItem item = new(dr.GetInt32(nameof(Person.Id)).ToString());
                item.SubItems.Add(dr[nameof(Person.FirstName)] as string);
                item.SubItems.Add(dr[nameof(Person.LastName)] as string);
                item.SubItems.Add(dr[nameof(Person.Phone)] as string);
                item.SubItems.Add(dr[nameof(Person.Mail)] as string);
                lstPeople.Items.Add(item);
            }
            con.Close();
        }

        string connection = Program.Configuration.GetConnectionString("default");
        private void ListForm_Load(object sender, EventArgs e)
        {
            Refles();
        }

        private void lstPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void cmsSil_Click(object sender, EventArgs e)
        {
            if (lstPeople.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a recoerd to delete", "Delete item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result1 = MessageBox.Show(
                "Are you sure you want to delete the selected record?",
                "Deleted item",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (result1 == DialogResult.No)
            {
                return;
            }
            string selectefId = lstPeople.SelectedItems[0].Text;
            using SqlConnection con = new SqlConnection(connection);
            using SqlCommand cmd = new();
            cmd.Connection = con;
            cmd.CommandText = "Delete From People Where Id = @Id";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", selectefId);
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            bool result = cmd.ExecuteNonQuery() > 0;
            if (result)
            {
                lstPeople.SelectedItems[0].Remove();
            }

            MessageBox.Show(
                text: result ? "Kayıt silindi" : "İşlem Hatası",
                caption: "Kayıt silme bildirimi",
                buttons: MessageBoxButtons.OK,
                icon: result ? MessageBoxIcon.Asterisk : MessageBoxIcon.Error
                );
        }

        private void duzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refles();
        }

        private void ListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            MainForm form = new MainForm();
            form.Show();
        }
    }
}

