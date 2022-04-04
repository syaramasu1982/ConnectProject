using System;
using System.Collections.Generic;
using System.Text;

namespace Uksbs.Connect.AutomatedTests.Common
{
    public class MyAbsenceDashboard
    {
        public List<Absence> AllAbsences { get; set; }
    }


    public class Absence
    {
        public string Type { get; set; }
        public string Reason { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Duration { get; set; }
        public string DateSubmitted { get; set; }
        public string Status { get; set; }
        public string EmpName { get; set; }
        public string LeaveRequest { get; set; }
        public string Priority { get; set; }
        public string ToAction { get; set; }
        public string Position { get; set; }
        public string elementID { get; set; }
    }
}
