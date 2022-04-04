using System;
using System.Collections.Generic;
using System.Text;

namespace Uksbs.Connect.AutomatedTests.Common
{

    public class MyExpenseClaims
    {
        public List<ExpenseClaim> ExpenseClaims { get; set; }
    }


    public class ExpenseClaim
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string DateSubmitted { get; set; }
        public string TotalExpenseItems { get; set; }
        public string TotalExpenseAmount { get; set; }
        public string ApproverInfo { get; set; }
        public string HeadsUpMessage { get; set; }
        public string Status { get; set; }
        public string elementID { get; set; }
    }
}
