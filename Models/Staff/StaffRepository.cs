using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SupportUpdateAPICore.Models
{
    public class StaffRepository : IStaffRepository
    {

        private readonly SupportUpdateContext _context;

        public StaffRepository(SupportUpdateContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<Staff>> DeleteStaff(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return new NotFoundResult();
            }

            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();

            return staff;
        }

        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            var staff = await _context.Staff.FindAsync(id);

            if (staff == null)
            {
                return new NotFoundResult();
            }

            return staff;
        }

        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
        {
            return await _context.Staff.ToListAsync();
        }

        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            _context.Staff.Add(staff);
            await _context.SaveChangesAsync();

            return new CreatedAtActionResult("GetStaff", "Staff", new { id = staff.StaffId }, staff);

        }

        public bool StaffExists(int id)
        {
            return _context.Staff.Any(e => e.StaffId == id);
        }

        public async Task<ActionResult<Staff>> PutStaff(int id, Staff staff)
        {
            if (id != staff.StaffId)
            {
                return new BadRequestResult();
            }

            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
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
