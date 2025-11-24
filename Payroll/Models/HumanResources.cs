using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Models
{
    public class HumanResources
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmployeeID { get; set; }
        public string Email { get; set; }
        public long ContactNum { get; set; }
        public string Address { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Status { get; set; }
    }
}