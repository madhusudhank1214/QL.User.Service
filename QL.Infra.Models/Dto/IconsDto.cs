using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Dto
{
    public class IconsDto
    {
        public int ID { get; set; }
        public  string Icon { get; set; }
        public required string Title { get; set; }
        public int Number { get; set; }
        public string Backgroundcolor { get; set; }
    }
}
