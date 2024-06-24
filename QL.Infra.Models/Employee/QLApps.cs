using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Employee
{
    public class QLApps
    {
        public int Id { get; set; }
        public required string AppName { get; set; }
        public required string DisplayName { get; set; }
        public required string Uri { get; set; }

    }
}
