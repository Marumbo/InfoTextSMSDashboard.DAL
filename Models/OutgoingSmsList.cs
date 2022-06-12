using System;
using System.Collections.Generic;

#nullable disable

namespace InfoTextSMSDashboard.DAL.Models
{
    public partial class OutgoingSmsList
    {
        public int SmsId { get; set; }
        public string Message { get; set; }
        public string SenderUsername { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string RecipientNumber { get; set; }
        public string RecipientStatus { get; set; }
        public string AtMessageid { get; set; }
        public string MessageCost { get; set; }
    }
}
