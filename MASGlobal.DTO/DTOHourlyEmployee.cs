using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASGlobal.DTO
{
    public class DTOHourlyEmployee : DTOEmployee
    {
        public override void CalculateSalary()
        {
            annualSalary = 120 * hourlySalary * 12;
        }
    }
}
