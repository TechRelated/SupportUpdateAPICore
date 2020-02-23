using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportUpdateAPICore.Models;


namespace SupportUpdateAPICore.Models
{

    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        // GET: api/Status
        //[Authorize]
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Status>>> GetStatuses()
        //{
        //    return await _statusRepository.GetStatuses();
        //}

        [HttpGet("statuslist")]
        public async Task<List<Status>> GetStatusesAsync()
        {
            return await _statusRepository.GetStatuses();
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public async Task<Status> GetStatus(int id)
        {
            return await _statusRepository.GetStatus(id);
        }

        // PUT: api/Status/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<Status>> PutStatus(int id, Status status)
        {
            return await _statusRepository.PutStatus(id, status);
        }

        // POST: api/Status
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Status>> PostStatus(Status status)
        {
            return await _statusRepository.PostStatus(status);
        }

        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Status>> DeleteStatus(int id)
        {
            return await _statusRepository.DeleteStatus(id);
        }

        private bool StatusExists(int id)
        {
            return _statusRepository.StatusExists(id);
        }
    }
}
