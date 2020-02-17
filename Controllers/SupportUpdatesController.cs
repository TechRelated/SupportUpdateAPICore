using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportUpdateAPICore.Models;

namespace SupportUpdateAPICore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupportUpdatesController : ControllerBase
    {
        private readonly ISupportUpdateRepository _supportupdateRepository;

        public SupportUpdatesController(ISupportUpdateRepository supportupdateRepository)
        {
            _supportupdateRepository = supportupdateRepository;
        }

        // GET: api/SupportUpdates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportUpdate>>> GetSupportUpdatesAsync()
        {
            return await _supportupdateRepository.GetSupportUpdatesAsync();
        }

        // GET: api/SupportUpdates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupportUpdate>> GetSupportUpdate(int id)
        {
            return await _supportupdateRepository.GetSupportUpdate(id);
        }

        // PUT: api/SupportUpdates/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
         public async Task<ActionResult<SupportUpdate>> PutSupportUpdate(int id, SupportUpdate supportupdate)
        {
            return await _supportupdateRepository.PutSupportUpdate(id, supportupdate);
        }

        // POST: api/SupportUpdates
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SupportUpdate>> PostSupportUpdate(SupportUpdate supportUpdate)
        {
             return await _supportupdateRepository.PostSupportUpdate( supportUpdate);
        }

        // DELETE: api/SupportUpdates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SupportUpdate>> DeleteSupportUpdate(int id)
        {
            return await _supportupdateRepository.DeleteSupportUpdate(id);
        }

        private bool SupportUpdateExists(int id)
        {
            return _supportupdateRepository.SupportUpdateExists(id);
        }
    }
}
