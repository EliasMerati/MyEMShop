using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.ContactUs;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.ContactUs
{
    [PermissionChecker(69)]
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
        public void OnGet(int pageId = 1)
        {
            contactUs = _contactUsConnection.GetContactUsConnections(pageId).Item1;
            ViewData["rowsCount"] = _contactUsConnection.GetContactUsConnections().Item2;
            ViewData["pageId"] = pageId;
        }
    }
}
