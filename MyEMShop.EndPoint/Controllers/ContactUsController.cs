using Ganss.Xss;
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
            var sanitizer = new HtmlSanitizer();
            var resault = sanitizer.Sanitize(conection.Question);
            ContactUsConection contact = new ContactUsConection()
            {
                Email = conection.Email,
                name = conection.name,
                Question = resault,
            };

            _contactUsConnectionService.AddContactUsConnection(contact);
            ViewData["IsSuccess"] = true;
            return RedirectToAction("Index");
        }
    }
}
