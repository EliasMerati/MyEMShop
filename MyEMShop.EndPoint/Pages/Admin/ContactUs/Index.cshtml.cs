using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.ContactUs;
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
        public void OnGet()
        {
            contactUs = _contactUsConnection.GetContactUsConnections();
        }
    }
}
