using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SupportUpdateAPICore.Models
{
    public class Client
    {
            [Key]
            public int SupportClientId { get; set; }

            [Required]
            [Column(TypeName = "nvarchar(200)")]
            public string ClientName { get; set; }
            public DateTime? RecordCreated { get; set; }
            public int? RecordCreatedBy { get; set; }
            public DateTime? RecordUpdated { get; set; }
            public int? RecordUpdatedBy { get; set; }
        
    }
}
