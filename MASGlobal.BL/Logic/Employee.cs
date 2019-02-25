using MASGlobal.BL.Interfaces;
using MASGlobal.DTO;
using MASGlobal.DTO.Configuration;
using MASGlobal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MASGlobal.DAL.Interfaces;
using AutoMapper;

namespace MASGlobal.BL.Logic
{
    public class Employee 
    {
        private EmployeeRepository employeeRepository = new EmployeeRepository();
        //private IMapper mapper;


        public async Task<DTOResult<List<DTOEmployeeResult>>> GetAllEmployees()
        {
            var result = new DTOResult<List<DTOEmployeeResult>>();
            result.Data = await GetEmployees();
            return result;
        }

        public async Task<DTOResult<DTOEmployeeResult>> GetEmployee(int id)
        {
            var result = new DTOResult<DTOEmployeeResult>();
            var ResultEmployee = await GetEmployees();
            result.Data = ResultEmployee.Where(e => e.id == id).FirstOrDefault();
            return result;
        }

        private async Task<List<DTOEmployeeResult>> GetEmployees()
        {
            var Employeeresults = await employeeRepository.GetEmployees();
            var results = new List<DTOEmployeeResult>();

            var HourlyEmployee = Employeeresults.Where(e => e.contractTypeName == "HourlySalaryEmployee").ToList();
            var MonthlyEmployee = Employeeresults.Where(e => e.contractTypeName == "MonthlySalaryEmployee").ToList();


            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<DTOEmployeeJsonResult, DTOHourlyEmployee>();
                cfg.CreateMap<DTOEmployeeJsonResult, DTOMonthlyEmployee>();
                cfg.CreateMap<DTOHourlyEmployee, DTOEmployeeResult>();
                cfg.CreateMap<DTOMonthlyEmployee, DTOEmployeeResult>();

            });

           IMapper mapper = config.CreateMapper();

            var HourlyEmployeeMap = mapper.Map<List<DTOEmployeeJsonResult>, List<DTOHourlyEmployee>>(HourlyEmployee).ToList();
            var MonthlyEmployeeMap = mapper.Map<List<DTOEmployeeJsonResult>, List<DTOMonthlyEmployee>>(MonthlyEmployee).ToList();

            HourlyEmployeeMap.ForEach(e => e.CalculateSalary());
            MonthlyEmployeeMap.ForEach(e => e.CalculateSalary());

            results.AddRange(mapper.Map<IEnumerable<DTOHourlyEmployee>, IEnumerable<DTOEmployeeResult>>(HourlyEmployeeMap).ToList());
            results.AddRange(mapper.Map<IEnumerable<DTOMonthlyEmployee>, IEnumerable<DTOEmployeeResult>>(MonthlyEmployeeMap).ToList());

            return results;

        }

    }
}
