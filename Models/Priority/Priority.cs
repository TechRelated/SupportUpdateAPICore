using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportUpdateAPICore.Models
{
    public class Priorities
    {
        [Key]
        public int PriorityID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string PriorityName { get; set; }
        public DateTime? RecordCreated { get; set; }
        public int? RecordCreatedBy { get; set; }
        public DateTime? RecordUpdated { get; set; }
        public int? RecordUpdatedBy { get; set; }
    }
}
