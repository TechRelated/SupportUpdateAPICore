using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;

namespace SupportUpdateAPICore.Models
{
   public  interface IStatusRepository
    {
        Task<List<Status>> GetStatuses();

        Task<Status> GetStatus(int id);

        Task<ActionResult<Status>> PutStatus(int id, Status status);

        Task<ActionResult<Status>> PostStatus(Status status);

        Task<ActionResult<Status>> DeleteStatus(int id);

        bool StatusExists(int id);
    }
}
