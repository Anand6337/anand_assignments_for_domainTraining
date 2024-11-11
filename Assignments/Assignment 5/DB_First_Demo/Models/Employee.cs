using System;
using System.Collections.Generic;

namespace DB_First_Demo.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public int? DeptId { get; set; }
    }
}
