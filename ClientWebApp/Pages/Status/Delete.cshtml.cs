using System.Collections.Generic;
using System.Threading.Tasks;
using ClientWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ClientWebApp.ViewModel;
using System.Web.Http;

namespace SupportUpdateAPICore
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;
        private readonly StatusService _statusService;

        public DeleteModel(ILogger<DeleteModel> logger, StatusService statusService)
        {
            _logger = logger;
            _statusService = statusService;
        }

        [BindProperty]
        public SupportStatus st { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            st = await _statusService.GetStatus(id);

            if (st == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {

                await _statusService.DeleteStatus(id);
            }
            catch (HttpResponseException ex)
            {
                throw ex;
            }

            return RedirectToPage("./List");
        }
    }
}
