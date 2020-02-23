using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ClientWebApp.Services;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClientWebApp.Pages
{
    public class IndexModel1 : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        //private readonly StatusService _statusService;
        //private bool GetIssuesError;

        //[BindProperty]
        //public List<dynamic> StatusList { get; set; }

        //public IndexModel1(ILogger<IndexModel> logger, StatusService statusService)
        //{
        //    _logger = logger;
        //    _statusService  = statusService;
        //}


        public async Task OnGetAsync()
        {
        //    try
        //    {
        //        // StatusList = await _statusService.GetStatuses();
        //        // ViewData["Statuses"] = new SelectList(StatusList, "StatusID", "StatusName", 1);

        //        ViewData["Statuses"] = "";                
        //       // var res = await _statusService.GetTodoAsync(1);
                              

        //        //https://www.c-sharpcorner.com/article/different-ways-bind-the-value-to-razor-dropdownlist-in-aspnet-mvc5/

        //        List<SelectListItem> mySkills = new List<SelectListItem>() {
        //        new SelectListItem {
        //            Text = "ASP.NET MVC", Value = "1"
        //        },
        //        new SelectListItem {
        //            Text = "ASP.NET WEB API", Value = "2"
        //        },
        //        new SelectListItem {
        //            Text = "ENTITY FRAMEWORK", Value = "3"
        //        },
        //        new SelectListItem {
        //            Text = "DOCUSIGN", Value = "4"
        //        },
        //        new SelectListItem {
        //            Text = "ORCHARD CMS", Value = "5"
        //        },
        //        new SelectListItem {
        //            Text = "JQUERY", Value = "6"
        //        },
        //        new SelectListItem {
        //            Text = "ZENDESK", Value = "7"
        //        },
        //        new SelectListItem {
        //            Text = "LINQ", Value = "8"
        //        },
        //        new SelectListItem {
        //            Text = "C#", Value = "9"
        //        },
        //        new SelectListItem {
        //            Text = "GOOGLE ANALYTICS", Value = "10"
        //        },
        //    };
        //        ViewData["MySkills"] = mySkills;


        //}
        //    catch (HttpRequestException)
        //    {
        //        GetIssuesError = true;
        //        //StatusList = Array.Empty<string>();
        //        StatusList = null;
        //    }
}

        //public IActionResult OnGetStatus()
        //{
        //    return new JsonResult("Hello status");
        //}
    }
}
