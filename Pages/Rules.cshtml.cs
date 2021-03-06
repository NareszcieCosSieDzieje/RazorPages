﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

namespace Lab_9.Pages
{
    public class RulesModel : PageModel
    {

        public List<string> rulesList = new List<string>();

        public void OnGet()
        {
            var mStream = new MemoryStream();
            var binFormatter = new BinaryFormatter();
            if (HttpContext.Session.Get("rules") != null)
            {
                mStream.Write(HttpContext.Session.Get("rules"), 0, HttpContext.Session.Get("rules").Length);
                mStream.Position = 0;
                rulesList = binFormatter.Deserialize(mStream) as List<string>;
            }
            else {

                rulesList.Add("You do not talk about Fight Club.");
                rulesList.Add("You DO NOT talk about Fight Club.");
                rulesList.Add("The fight is over once a person yells ''stop'', taps out, or goes limp.");
                rulesList.Add("Only two guys are involved in a fight.");
                rulesList.Add("Only one fight occurs at a time.");
                rulesList.Add("No shirt, no shoes.");
                rulesList.Add("There is no time allotment associated with the fights.They go on until they end.");
                rulesList.Add("First timers at the club must fight.");
                binFormatter.Serialize(mStream, rulesList);
                HttpContext.Session.Set("rules", mStream.ToArray());
            }
        }


        public void OnPost() 
        {
            var mStream = new MemoryStream();
            var binFormatter = new BinaryFormatter();
            mStream.Write(HttpContext.Session.Get("rules"), 0, HttpContext.Session.Get("rules").Length);
            mStream.Position = 0;
            rulesList = binFormatter.Deserialize(mStream) as List<string>;
            
            
            rulesList.Add(Request.Form["ruleField"].ToString());
            //var binFormatter = new BinaryFormatter();
            //var mStream = new MemoryStream();
            var mS = new MemoryStream();
            var bF = new BinaryFormatter();
            bF.Serialize(mS, rulesList);
            HttpContext.Session.Set("rules", mS.ToArray());
            Response.Redirect("Rules");
        }
    }
}
