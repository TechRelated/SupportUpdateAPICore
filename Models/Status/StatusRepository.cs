using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SupportUpdateAPICore.Models
{
    public class StatusRepository : IStatusRepository
    {
        private readonly SupportUpdateContext _context;

        public StatusRepository(SupportUpdateContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Status>> DeleteStatus(int id)
        {
            //throw new NotImplementedException();
            var status = await _context.Status.FindAsync(id);

            if (status == null)
            {
                return new NotFoundResult();
            }

            _context.Status.Remove(status);
            await _context.SaveChangesAsync();

            return status;
        }

        public async Task<ActionResult<Status>> GetStatus(int id)
        {
            var status = await _context.Status.FindAsync(id);


            if (status == null)
            {
                return new NotFoundResult();
            }

            return status;
        }

        public async Task<ActionResult<IEnumerable<Status>>> GetStatuses()
        {
            return await _context.Status.ToListAsync();
        }

        public async Task<ActionResult<Status>> PostStatus(Status status)
        {
            _context.Status.Add(status);
            await _context.SaveChangesAsync();

            return new CreatedAtActionResult("GetStatus", "Status", new { id = status.StatusID }, status);
        }

        public async Task<ActionResult<Status>> PutStatus(int id, Status status)
        {
            if (id != status.StatusID)
            {
                return new BadRequestResult();
            }
            _context.Entry(status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(id))
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

        public bool StatusExists(int id)
        {
            return _context.Status.Any(e => e.StatusID == id);
        }

    }
}
