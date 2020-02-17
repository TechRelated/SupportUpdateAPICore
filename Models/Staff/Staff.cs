using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SupportUpdateAPICore.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        public string StaffName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        public string StaffEmail { get; set; }
        public DateTime? RecordCreated { get; set; }
        public int? RecordCreatedBy { get; set; }
        public DateTime? RecordUpdated { get; set; }
        public int? RecordUpdatedBy { get; set; }
    }
}
