using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportUpdateAPICore.Models;

namespace SupportUpdateAPICore.Models
{
    [ApiController]
    [Route("[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _staffRepository;

        public StaffController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        // GET: api/Status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
        {
            return await _staffRepository.GetStaffs();
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            return await _staffRepository.GetStaff(id);
        }

        // PUT: api/Status/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<Staff>> PutStaff(int id, Staff staff)
        {
            return await _staffRepository.PutStaff(id, staff);
        }

        // POST: api/Status
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            return await _staffRepository.PostStaff(staff);
        }

        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Staff>> DeleteStatus(int id)
        {
            return await _staffRepository.DeleteStaff(id);
        }

        private bool StatusExists(int id)
        {
            return _staffRepository.StaffExists(id);
        }
    }
}
