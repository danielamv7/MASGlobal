using MASGlobal.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MASGlobal.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<DTOEmployeeJsonResult>> GetEmployees();
    }
}
