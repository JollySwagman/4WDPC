using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TroopyMonitor.Business
{
    public class Calculator
    {
        public static int CalculateAge(DateTime date)
        {
            var result = (DateTime.Now - date).Days;
            return result;
        }
    }
}