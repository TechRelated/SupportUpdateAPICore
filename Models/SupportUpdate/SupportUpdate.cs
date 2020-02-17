using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportUpdateAPICore.Models
{
    public class SupportUpdate
    {
        [Key]
        public int SupportUpdateID { get; set; }
        public int ZdId { get; set; }
        public string ZdDescr { get; set; }

        public int? TimeSpent { get; set; }
        public DateTime DateWorked { get; set; }

        public DateTime? RecordCreated { get; set; }
        public int? RecordCreatedBy { get; set; }
        public DateTime? RecordUpdated { get; set; }
        public int? RecordUpdatedBy { get; set; }
        public DateTime? Emailsent { get; set; }

        public int PriorityId { get; set; }
        public virtual Priorities PriorityList { get; set; }
        public int StatusId { get; set; }
        public virtual Status StatusList { get; set; }

        public int ClientId { get; set; }
        public virtual Client ClientList { get; set; }

        public int StaffId { get; set; }
        public virtual Staff StaffList { get; set; }

    }
}
