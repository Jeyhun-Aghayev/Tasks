using StudentManagment.Models;
using System.Data.SqlClient;
namespace StudentManagment.BisnessLogic.StudentService
{

    public class StudentService
    {

        string connection = "server=localhost;database=PhoneBook;Trusted_Connection=True";
        public void Create(Student student)
        {
            using SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"INSERT INTO Student (FirstName, LastName, UserName, Password) VALUES ({student.FirstName}, {student.LastName},{student.UserName}, {student.Password});";
            cmd.CommandType = System.Data.CommandType.Text;
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            con.Close();
        }
        public void Update(Student student)
        {
            using SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"UPDATE Student SET FirstName = {student.FirstName}, LastName = {student.LastName}, UserName = {student.UserName}, Password = {student.Password} WHERE Id = 1;";
            cmd.CommandType = System.Data.CommandType.Text;
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }

            con.Close();
        }
        public void Delete(int id)
        {
            using SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"DELETE FROM Student WHERE Id = {id};";
            cmd.CommandType = System.Data.CommandType.Text;
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }

            con.Close();
        } 
        public Student 
    }
 
}

