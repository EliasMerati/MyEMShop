﻿using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.ContactUs;
using MyEMShop.EndPoint.Filters;
using System;

namespace MyEMShop.EndPoint.Controllers
{
    [ServiceFilter(typeof(SaveVisitorsFilter))]
    public class ContactUsController : Controller
    {

        #region Injection
        private readonly IContactUsConnectionService _contactUsConnectionService;
        public ContactUsController(IContactUsConnectionService contactUsConnectionService)
        {
            _contactUsConnectionService = contactUsConnectionService;
        }
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Route("/AddContactUsConnection")]
        public IActionResult AddContactUsConnection(ContactUsConection conection)
        {
            ContactUsConection contact = new ContactUsConection()
            {
                Email = conection.Email,
                name = conection.name,
                Question = conection.Question,
            };
            #region Sanitize Comment
            var sanitizer = new HtmlSanitizer();
            var resault = sanitizer.Sanitize(contact.Question);
            contact.Question= resault;
            #endregion
            _contactUsConnectionService.AddContactUsConnection(contact);
            ViewData["IsSuccess"] = true;
            return RedirectToAction("Index");
        }
    }
}
