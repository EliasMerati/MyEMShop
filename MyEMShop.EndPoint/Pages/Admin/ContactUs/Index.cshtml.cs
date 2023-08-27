using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Application.Services;
using MyEMShop.Data.Dtos.IsRead;
using MyEMShop.Data.Entities.ContactUs;
using Stimulsoft.System.Web.UI;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.ContactUs
{
    public class IndexModel : PageModel
    {
        #region Inject Service
        private readonly IContactUsConnectionService _contactUsConnection;
        public IndexModel(IContactUsConnectionService contactUsConnection)
        {
            _contactUsConnection = contactUsConnection;
        }
        #endregion

        public List<ContactUsConection> contactUs { get; set; }
        public void OnGet( int pageId = 1)
        {
            contactUs = _contactUsConnection.GetContactUsConnections(pageId).Item1;
            ViewData["rowsCount"] = _contactUsConnection.GetContactUsConnections().Item2;
            ViewData["pageId"] = pageId;
        }
    }
}
