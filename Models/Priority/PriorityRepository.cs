using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SupportUpdateAPICore.Models
{
    public class PriorityRepository : IPriorityRepository
    {
        private readonly SupportUpdateContext _context;

        public PriorityRepository(SupportUpdateContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Priorities>> DeletePriority(int id)
        {
            var priority = await  _context.Priority.FindAsync(id);

            if(priority == null)
            {
                return new NotFoundResult();
            }

            _context.Priority.Remove(priority);
           await _context.SaveChangesAsync();

            return priority;

        }

        public async Task<ActionResult<IEnumerable<Priorities>>> GetPriorities()
        {
            return await _context.Priority.ToListAsync();
        }

        public async Task<ActionResult<Priorities>> GetPriority(int id)
        {
            var priority = await _context.Priority.FindAsync(id);

            if(priority == null)
            {
                return new NotFoundResult();
            }

            return priority;
        }

        public async Task<ActionResult<Priorities>> PostPriority(Priorities priority)
        {
            _context.Priority.Add(priority);
            await _context.SaveChangesAsync();

            return new CreatedAtActionResult("GetPriority", "Priorities", new { id = priority.PriorityID }, priority);

        }

        public bool PriorityExists(int id)
        {
            return _context.Priority.Any(e => e.PriorityID == id);
        }

        public async Task<ActionResult<Priorities>> PutPriority(int id, Priorities priority)
        {
            if (id != priority.PriorityID)
            {
                return new BadRequestResult();
            }

            _context.Entry(priority).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriorityExists(id))
                {
                    return new NotFoundResult();
                }
                else
                {
                    throw;
                }
            }

            return new NoContentResult();
        }
    }
}
