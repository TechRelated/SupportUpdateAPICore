using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportUpdateAPICore.Models;

namespace SupportUpdateAPICore.Models.Priority
{
    [ApiController]
    [Route("[controller]")]
    public class PrioritiesController : ControllerBase
    {
        private readonly IPriorityRepository _priorityRepository;

        public PrioritiesController(IPriorityRepository priorityRepository)
        {
            _priorityRepository = priorityRepository;
        }

        // GET: api/Priorities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Priorities>>> GetPriority()
        {
            return await _priorityRepository.GetPriorities();
        }

        // GET: api/Priorities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Priorities>> GetPriority(int id)
        {
            return await _priorityRepository.GetPriority(id);
        }

        // PUT: api/Priorities/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<Priorities>> PutPriority(int id, Priorities priority)
        {
            return await _priorityRepository.PutPriority(id, priority);
        }

        // POST: api/Priorities
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Priorities>> PostPriority(Priorities priority)
        {
            return await _priorityRepository.PostPriority(priority);
        }

        // DELETE: api/Priorities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Priorities>> DeletePriority(int id)
        {
            return await _priorityRepository.DeletePriority(id);
        }

        private bool PriorityExists(int id)
        {
            return _priorityRepository.PriorityExists(id);
        }
    }
}
