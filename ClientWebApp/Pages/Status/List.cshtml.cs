using System.Collections.Generic;
using System.Threading.Tasks;
using ClientWebApp.Services;
using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ClientWebApp.ViewModel;

namespace ClientWebApp.Pages
{
    public class ListModel : PageModel
    {
        private readonly ILogger<ListModel> _logger;
        private readonly StatusService _statusService;
        public List<SupportStatus> st;

        public ListModel(ILogger<ListModel> logger, StatusService statusService)
        {
            _logger = logger;
            _statusService = statusService;
        }
      
        public async Task OnGetAsync()
        {
            st = await _statusService.GetStatuses();
        }
    }
}
