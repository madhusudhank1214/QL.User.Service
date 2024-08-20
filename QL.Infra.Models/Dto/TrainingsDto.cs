using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Dto
{
    public class TrainingsDto
    {
        public Guid TRCode { get; set; }
        public bool? IsVirtual { get; set; }
        public bool? IsInternal { get; set; }
        public bool? Active { get; set; }
        public bool? RequestBusinessApproval { get; set; }
        public string BusinessUnitHead { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
