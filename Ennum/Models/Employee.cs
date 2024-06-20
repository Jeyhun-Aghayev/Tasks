using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ennum.Models
{
 
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Department Department { get; set; }

    }
    public enum Status
    {
        None,
        Active,
        Inactive,
        Pending,
        Deleted,
        Approved,
        Rejected,
        Completed
    }
    public enum Department
    {
        HR,
        IT,
        Finance,
        Marketing,
        Sales
    }
}
