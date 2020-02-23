using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClientWebApp.ViewModel;
using Microsoft.Extensions.Logging;
using ClientWebApp.Services;

namespace SupportUpdateAPICore
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly StatusService _statusService;

        public DetailsModel(ILogger<DetailsModel> logger, StatusService statusService)
        {
            _logger = logger;
            _statusService = statusService;
        }

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
    }
}
