using System;
using System.Collections.Generic;

#nullable disable

namespace InfoTextSMSDashboard.DAL.Models
{
    public partial class Group
    {
        public Group()
        {
            GroupContacts = new HashSet<GroupContact>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<GroupContact> GroupContacts { get; set; }
    }
}
