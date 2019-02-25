using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MASGlobal.DTO;

namespace MASGlobal.BL.Interfaces
{
    public interface IEmployee
    {
        Task<DTOResult<List<DTOEmployeeResult>>> GetAllEmployees();
        Task<DTOResult<DTOEmployeeResult>> GetEmployee(int id);
    }
}
