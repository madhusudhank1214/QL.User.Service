﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Models.Dto
{
    public class NotificationsDto
    {
        public int Sl_no { get; set; }
        public string Title { get; set; }
        public string Notification_status { get; set; }
        private DateTime Created_date { get; set; }
        public DateTime? Approved_date { get; set; }
        public Guid Request_id { get; set; }
        public bool Read { get; set; }
        public string Rejected_reason { get; set; }
    }
}
