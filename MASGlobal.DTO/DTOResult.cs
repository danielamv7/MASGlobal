using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASGlobal.DTO
{
    public class DTOResult<T>
    {
        /// <summary>
        /// Respuesta de la operación realizada
        /// </summary>
        public bool Result { get; set; }
        /// <summary>
        /// Data de la operación realizada
        /// </summary>
        public T Data { get; set; }
    }
}
