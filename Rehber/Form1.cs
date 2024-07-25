using MetroFramework.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Rehber;

public partial class Form1 : MetroForm
{
    public Form1()
    {
        InitializeComponent();
    }
    void Clear(Control ctrl)
    {
        foreach (Control c in ctrl.Controls)
        {
            if (c is TextBox txt)
            {
                txt.Clear();
            }
        }
    }
    private void btnSave_Click(object sender, EventArgs e)
    {
        string connection = "server=localhost;database=PhoneBook;Trusted_Connection=True";
        SqlConnection con = new SqlConnection(connection);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO People VALUES(@firstName,@lastName,@mail,@phone);";
        cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
        cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
        cmd.Parameters.AddWithValue("@mail", txtMail.Text);
        cmd.Parameters.AddWithValue("@phone", txtPhone.Text);


        cmd.CommandType = CommandType.Text;
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }

        bool result = cmd.ExecuteNonQuery() > 0;


        MessageBox.Show(result ? "Kayit eklendi" : "Islem Hatasi", "Kayıt Ekleme Bildirimi", MessageBoxButtons.OK, result ? MessageBoxIcon.Asterisk : MessageBoxIcon.Error);
        Clear(grb1);
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
        ListForm lf = new ListForm();
        lf.Show();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        MainForm frm = new MainForm();
       frm.Show();
    }
}
