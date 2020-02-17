using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SupportUpdateAPICore.Models
{
   public  interface IStaffRepository
    {
        Task<ActionResult<IEnumerable<Staff>>> GetStaffs();

        Task<ActionResult<Staff>> GetStaff(int id);

        Task<ActionResult<Staff>> PutStaff(int id, Staff staff);

        Task<ActionResult<Staff>> PostStaff(Staff staff);

        Task<ActionResult<Staff>> DeleteStaff(int id);

        bool StaffExists(int id);
    }
}
