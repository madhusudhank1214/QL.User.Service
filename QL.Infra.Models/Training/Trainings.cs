using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Training
{
    public class Trainings
    {
        public Guid TRCode { get; set; }
        public bool? IsVirtual { get; set; }
        public bool? IsInternal { get; set; }
        public bool? IsActive { get; set; }
        public bool? RequestBuisnessApproval { get; set; }
        public string BuisnessUnitHead { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
