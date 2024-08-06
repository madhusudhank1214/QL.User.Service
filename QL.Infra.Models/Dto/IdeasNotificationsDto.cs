using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace QL.Infra.Models.Dto
{
    public class IdeasNotificationsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IdeaDescription { get; set; }
        public int IdeaType { get; set; }
        public string Benefits { get; set; }
        public string Technology { get; set; }
        public int EstimatedEffort { get; set; }
        public int ActualEffort { get; set; }
        public int AnnualSaving { get; set; }
        public int Status { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string ManagerId { get; set; }
        public string ManagerName { get; set; }
    }
}
