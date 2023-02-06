using PruebaTecnica.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Models.Helpers
{
    public class Messages
    {
        public int Code { get; set; }
        public TypeMessage Type { get; set; }
        public string Message { get; set; } = null!;
    }
}
