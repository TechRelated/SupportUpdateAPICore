using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace SupportUpdateAPICore.Models
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string StatusName { get; set; }
        public DateTime? RecordCreated { get; set; }
        public int? RecordCreatedBy { get; set; }
        public DateTime? RecordUpdated { get; set; }
        public int? RecordUpdatedBy { get; set; }

    }
}
