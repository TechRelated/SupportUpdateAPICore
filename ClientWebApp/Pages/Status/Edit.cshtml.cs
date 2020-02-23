using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClientWebApp.Services;
using ClientWebApp.ViewModel;
using Microsoft.Extensions.Logging;
using System.Web.Http;

namespace SupportUpdateAPICore
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;
        private readonly StatusService _statusService;

        public EditModel(ILogger<EditModel> logger, StatusService statusService)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {

                await _statusService.EditStatus (id, st);
            }
            catch (HttpResponseException ex)
            {
                throw ex;
            }

            return RedirectToPage("./List");
        }
    }
}
