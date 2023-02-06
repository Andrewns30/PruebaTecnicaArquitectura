using PruebaTecnica.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Models.Dtos
{
    public class ResponseServiceDto<T>
    {
        public TypeMessage Code { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
    }
}
