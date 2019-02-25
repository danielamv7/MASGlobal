using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASGlobal.DTO
{
    public class DTOMonthlyEmployee : DTOEmployee
    {
        public override void CalculateSalary()
        {
            annualSalary = monthlySalary * 12;
        }
    }
}
