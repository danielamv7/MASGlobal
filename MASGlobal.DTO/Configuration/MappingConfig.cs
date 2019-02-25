using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace MASGlobal.DTO.Configuration
{
    public static class MappingConfig
    {
        public static void RegisterMap()
        {
            var config = new MapperConfiguration(conf =>
            {
                conf.CreateMap<DTOEmployee, DTOHourlyEmployee>();
                conf.CreateMap<DTOEmployeeResult, DTOHourlyEmployee>();
                conf.CreateMap<DTOEmployeeResult, DTOMonthlyEmployee>();
                conf.CreateMap<DTOEmployeeResult, DTOEmployeeResult>();
            });
        }
        
    }
}
