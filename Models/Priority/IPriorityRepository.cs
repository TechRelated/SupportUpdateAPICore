using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportUpdateAPICore.Models
{
    public interface IPriorityRepository
    {

        Task<ActionResult<IEnumerable<Priorities>>> GetPriorities();

        Task<ActionResult<Priorities>> GetPriority(int id);

        Task<ActionResult<Priorities>> PutPriority(int id, Priorities priority);

        Task<ActionResult<Priorities>> PostPriority(Priorities priority);

        Task<ActionResult<Priorities>> DeletePriority(int id);

        bool PriorityExists(int id);
    }
}
