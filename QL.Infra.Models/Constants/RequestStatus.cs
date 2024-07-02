using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Constants
{
    public class RequestStatus
    {

        public const int Approved = 1;
        public const int Rejected = 2;
        public const int Created = 3;
        public const int Hold= 4;
        public const int Read = 5;
        public const int UnRead = 6; 
        public const int Completed = 7;
    }
}
