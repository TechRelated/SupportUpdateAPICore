using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClientWebApp.ViewModel;
using Microsoft.Extensions.Logging;
using ClientWebApp.Services;
using System.Web.Http;

namespace SupportUpdateAPICore
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly StatusService _statusService;

        public CreateModel(ILogger<CreateModel> logger, StatusService statusService)
        {
            _logger = logger;
            _statusService = statusService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SupportStatus st { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _statusService.SaveStatus(st);
            }
            catch (HttpResponseException ex)
            {
                throw ex;
            }

            return RedirectToPage("./List");
        }
    }
}
