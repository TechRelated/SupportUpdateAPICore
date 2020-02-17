using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SupportUpdateAPICore.Models
{
    public class ClientRepository : IClientRepository
    {
        private readonly SupportUpdateContext _context;

        public ClientRepository(SupportUpdateContext context)
        {
            _context = context;
        }

        public bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.SupportClientId == id);
        }

        public async Task<ActionResult<Client>> DeleteClient(int id)
        {
            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return new NotFoundResult();
            }

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();

            return client;
        }

        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _context.Client.FindAsync(id);

            if (client == null)
            {
                return new NotFoundResult();
            }

            return client;
        }

        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
            return await _context.Client.ToListAsync();
            // throw new NotImplementedException();
        }

        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _context.Client.Add(client);
            await _context.SaveChangesAsync();

            return new CreatedAtActionResult("GetClient", "Client", new { id = client.SupportClientId }, client);
        }

        public async Task<ActionResult<Client>> PutClient(int id, Client client)
        {
            if (id != client.SupportClientId)
            {
                return new BadRequestResult();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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
