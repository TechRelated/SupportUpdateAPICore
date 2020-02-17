using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportUpdateAPICore.Models
{
    public interface IClientRepository
    {
        Task<ActionResult<IEnumerable<Client>>> GetClient();

        Task<ActionResult<Client>> GetClient(int id);

        Task<ActionResult<Client>> PutClient(int id, Client client);

        Task<ActionResult<Client>> PostClient(Client client);

        Task<ActionResult<Client>> DeleteClient(int id);

       bool ClientExists(int id);

    }
}
