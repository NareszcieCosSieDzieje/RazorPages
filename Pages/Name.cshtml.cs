using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab_9
{
    public class NameModel : PageModel
    {
        //[BindProperty]
        public String name { get; set; } = "Robert  Paulson";

        public void OnGet()
        {
            name = Request.Query["fnameGet"];
        }

        public void OnPost()
        {
            name = Request.Form["fnamePost"];
        }

    }
}
