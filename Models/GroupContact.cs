using System;
using System.Collections.Generic;

#nullable disable

namespace InfoTextSMSDashboard.DAL.Models
{
    public partial class GroupContact
    {
        public int GroupContactId { get; set; }
        public int? GroupId { get; set; }
        public int? ContactId { get; set; }

        public virtual Group Group { get; set; }
    }
}
