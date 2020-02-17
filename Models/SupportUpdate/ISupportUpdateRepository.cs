using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SupportUpdateAPICore.Models
{
   public  interface ISupportUpdateRepository 
    {

        Task<ActionResult<IEnumerable<Staff>>> GetStaffssAsync();
        Task<ActionResult<IEnumerable<Client>>> GetClientsAsync();
        Task<ActionResult<IEnumerable<Priorities>>> GetPrioritiessAsync();

        Task<ActionResult<IEnumerable<Status>>> GetStatusessAsync();

        Task<ActionResult<IEnumerable<SupportUpdate>>> GetSupportUpdatesAsync();

        Task<ActionResult<SupportUpdate>> GetSupportUpdate(int supportupdateid);

        Task<ActionResult<SupportUpdate>> AddSupportUpdate(SupportUpdate supportupdate);

        Task<ActionResult<SupportUpdate>> DeleteSupportUpdate(int supportupdateid);

        Task<ActionResult<SupportUpdate>> PutSupportUpdate(int supportupdateid, SupportUpdate supportupdate);

        Task<ActionResult<SupportUpdate>> PostSupportUpdate(SupportUpdate supportupdate);

   
        bool SupportUpdateExists(int id);
        
    }
}
