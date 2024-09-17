using QL.Infra.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Training
{
    public class FilterResponse:QLTrainingsDto
    {
        public string EmpName {  get; set; }
        public string EmpEmail {  get; set; }
        public bool IsAttended { get; set; }
    }
}
