﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AOLHack.Domain;

namespace AOLHack.Site.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        [HttpGet]
        public ActionResult Index(string location)
        {
            return View(location as object);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)//FormCollection form)
        {
            var context = new AOLHackEntities();
            var users = context.Users.ToList();
            var loggedinUser = users.FirstOrDefault(u => u.Email == form["email"]);

            if (loggedinUser == null)
            {
                // sign up in future
            }

            StateAgent.CurrentViewer = loggedinUser as Viewer;
            return RedirectToAction("Curator", "View", null);
        }

    }
}