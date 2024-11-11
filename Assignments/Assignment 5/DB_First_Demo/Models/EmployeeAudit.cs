using System;
using System.Collections.Generic;

namespace DB_First_Demo.Models
{
    public partial class EmployeeAudit
    {
        public int AuditId { get; set; }
        public int? EmployeeId { get; set; }
        public string? Operation { get; set; }
        public string? Name { get; set; }
        public int? DeptId { get; set; }
        public DateTime? ChangeDate { get; set; }
    }
}
