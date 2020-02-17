using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SupportUpdateAPICore.Models
{
    public class SupportUpdateRepository : ISupportUpdateRepository
    {
        private readonly SupportUpdateContext _context;

        public SupportUpdateRepository(SupportUpdateContext context)
        {
            _context = context;
        }


        public async Task<ActionResult<IEnumerable<Client>>> GetClientsAsync()
        {
            if (_context != null)
            {
                return await _context.Client.ToListAsync();
            }

            return null;
        }

        public async Task<ActionResult<IEnumerable<Priorities>>> GetPrioritiessAsync()
        {
            if (_context != null)
            {
                return await _context.Priority.ToListAsync();
            }

            return null;
        }

        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffssAsync()
        {
            if (_context != null)
            {
                return await _context.Staff.ToListAsync();
            }

            return null;
        }

        public async Task<ActionResult<IEnumerable<Status>>> GetStatusessAsync()
        {
            if (_context != null)
            {
                return await _context.Status.ToListAsync();
            }

            return null;
        }

        public async Task<ActionResult<IEnumerable<SupportUpdate>>> GetSupportUpdatesAsync()
        {

            //https://www.mssqltips.com/sqlservertip/6241/eager-loading-in-entity-framework-core/


            if (_context != null)
            {
                //return await _context.SupportUpdate
                //  .Include(d => d.PriorityList)
                //  .Include(p => p.StatusList)
                //  .Include(a => a.StaffList)
                //  .Include(b => b.ClientList)
                //  .ToListAsync();

                return await _context.SupportUpdate.ToListAsync();
            }

            return null;
        }

        public async  Task<ActionResult<SupportUpdate>> AddSupportUpdate(SupportUpdate supportupdate)
        {
            _context.SupportUpdate.Add(supportupdate);
            await _context.SaveChangesAsync();

            return new CreatedAtActionResult("GetSupportUpdate", "SupportUpdate", 
                new { id = supportupdate.StaffId               
                
                }, supportupdate);
        }

        public async Task<ActionResult<SupportUpdate>> DeleteSupportUpdate(int supportupdateid)
        {
            //throw new NotImplementedException();
            var supportupdate = await _context.SupportUpdate.FindAsync(supportupdateid);

            if (supportupdate == null)
            {
                return new NotFoundResult();
            }

            _context.SupportUpdate.Remove(supportupdate);
            await _context.SaveChangesAsync();

            return supportupdate;
        }

        public async Task<ActionResult<SupportUpdate>> PostSupportUpdate(SupportUpdate supportupdate)
        {
            _context.SupportUpdate.Add(supportupdate);
            await _context.SaveChangesAsync();

            return new CreatedAtActionResult("GetSupportUpdate", "SupportUpdate", 
                new { id = supportupdate.SupportUpdateID,
                    ZdId = supportupdate.ZdId,
                    ZdDescr = supportupdate.ZdDescr,
                    TimeSpent = supportupdate.TimeSpent,
                    DateWorked = supportupdate.DateWorked,
                    PriorityId = supportupdate.PriorityId,
                    StatusId = supportupdate.StatusId,
                    StaffId = supportupdate.StaffId,
                    ClientId = supportupdate.ClientId,
                }, supportupdate);
        }

        public async Task<ActionResult<SupportUpdate>> PutSupportUpdate(int id, SupportUpdate supportupdate)
        {
            if (id != supportupdate.SupportUpdateID)
            {
                return new BadRequestResult();
            }
            _context.Entry(supportupdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportUpdateExists(id))
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

        public bool SupportUpdateExists(int id)
        {
            return _context.SupportUpdate.Any(e => e.SupportUpdateID == id);
        }

        public async Task<ActionResult<SupportUpdate>> GetSupportUpdate(int supportupdateid)
        {
            var supportupdate = await _context.SupportUpdate.FindAsync(supportupdateid);

            if (supportupdate == null)
            {
                return new NotFoundResult();
            }

            return supportupdate;
        }

     }
}
