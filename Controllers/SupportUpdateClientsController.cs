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
    public class ClientController : ControllerBase
    {
            private readonly IClientRepository _ClientRepository;
        
            public ClientController(IClientRepository ClientRepository)
            {
                _ClientRepository = ClientRepository;
            }

            // GET: api/Client
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Client>>> GetClient()
            {
                return await _ClientRepository.GetClient();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Client>> GetClient(int id)
            {
                return await _ClientRepository.GetClient(id);
            }

            // PUT: api/Client/5
            [HttpPut("{id}")]
            public async Task<ActionResult<Client>> PutClient(int id, Client client)
                {
                return await _ClientRepository.PutClient(id, client);
            }

        // PUT: api/Client/5
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient( Client client)
            {
                return await _ClientRepository.PostClient(client);
            }
        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteClient(int id)
        {
            return await _ClientRepository.DeleteClient(id);
        }
    }
    //    private readonly SupportUpdateContext _context;

    //    public ClientController(SupportUpdateContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: api/Client
    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<Client>>> GetClient()
    //    {
    //        return await _context.Client.ToListAsync();
    //    }

    //    // GET: api/Client/5
    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<Client>> GetClient(int id)
    //    {
    //        var client = await _context.Client.FindAsync(id);

    //        if (client == null)
    //        {
    //            return NotFound();
    //        }

    //        return client;
    //    }

    //    // PUT: api/Client/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    //    // more details see https://aka.ms/RazorPagesCRUD.
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> PutClient(int id, Client client)
    //    {
    //        if (id != client.SupportClientId)
    //        {
    //            return BadRequest();
    //        }

    //        _context.Entry(client).State = EntityState.Modified;

    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!ClientExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return NoContent();
    //    }

    //    // POST: api/Client
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    //    // more details see https://aka.ms/RazorPagesCRUD.
    //    [HttpPost]
    //    public async Task<ActionResult<Client>> PostClient(Client client)
    //    {
    //        _context.Client.Add(client);
    //        await _context.SaveChangesAsync();

    //        return CreatedAtAction("GetClient", new { id = client.SupportClientId }, client);
    //    }

    //    // DELETE: api/Client/5
    //    [HttpDelete("{id}")]
    //    public async Task<ActionResult<Client>> DeleteClient(int id)
    //    {
    //        var client = await _context.Client.FindAsync(id);
    //        if (client == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.Client.Remove(client);
    //        await _context.SaveChangesAsync();

    //        return client;
    //    }

    //    private bool ClientExists(int id)
    //    {
    //        return _context.Client.Any(e => e.SupportClientId == id);
    //    }
    //}
}
