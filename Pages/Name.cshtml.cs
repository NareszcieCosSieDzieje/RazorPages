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
        public String name { get; set; } = "";

        public void OnGet()
        {
            var getName = Request.Query["fnameGet"];
            if (string.IsNullOrEmpty(getName))
            {
                name = "Robert  Paulson";
            }
            else {
                name = getName;
            }
            
        }

        public void OnPost()
        { 
            var postName = Request.Form["fnamePost"];
            if (string.IsNullOrEmpty(postName))
            {
                name = "Robert  Paulson";
            }
            else
            {
                name = postName;
            }
        }

    }
}
