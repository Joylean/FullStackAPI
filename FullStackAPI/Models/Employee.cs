using Microsoft.VisualBasic;

namespace FullStackAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateofJoining { get; set; }
        public string Email { get; set; }
        public long PrimaryContactNumber { get; set; }
        public virtual Department Department { get; set; }
        public virtual Project Project { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual Dependent Dependent { get; set; }


    }
}
