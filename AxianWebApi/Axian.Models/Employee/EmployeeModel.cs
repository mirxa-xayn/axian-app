using System;
using System.Collections.Generic;
using System.Text;

namespace Axian.Models.Employee
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
    }
}
