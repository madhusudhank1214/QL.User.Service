using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Dto
{
    public class RequestDto
    {
        public RequestDto() { }
        public string Project {  get; set; }
        public string Comments { get; set; }

    }
}
