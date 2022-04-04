using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uksbs.Connect.AutomatedTests.PageObjects
{
    class Demo
    {
        public static void main(String[] args)
        {
            string a = " i am in mastek";
            char ch = 'e';
            int count = a.Count(f => (f == ch));
            Console.WriteLine("Count" + count);
        }
        
    }
}
