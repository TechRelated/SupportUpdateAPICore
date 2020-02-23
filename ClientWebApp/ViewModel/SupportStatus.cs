using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ClientWebApp.ViewModel
{
    [DataContract]
    public class SupportStatus
    {
        [DataMember(Name = "StatusID")]
        [Key]
        public int StatusID { get; set; }

        [DataMember(Name = "StatusName")]
        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string StatusName { get; set; }

        [DataMember(Name = "RecordCreated")]
        public DateTime? RecordCreated { get; set; }

        [DataMember(Name = "RecordCreatedBy")]
        public int? RecordCreatedBy { get; set; }

        [DataMember(Name = "RecordUpdated")]
        public DateTime? RecordUpdated { get; set; }

        [DataMember(Name = "RecordUpdatedBy")]
        public int? RecordUpdatedBy { get; set; }

    }
}
