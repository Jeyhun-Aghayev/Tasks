using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.Models
{
    public class Student
    {
        public int? Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage ="Max leng 50")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage ="Max leng 50")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage ="Max leng 50")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage ="Max leng 50")]
        [MinLength(6,ErrorMessage ="Minimum 6 karakter olmalidi")]
        public string Password { get; set; }


        public Student(string firstname,string lastname, string username,string password)
        {
            FirstName = firstname;
            LastName = lastname;
            UserName = username;
            Password = password;
        }
    }
}
