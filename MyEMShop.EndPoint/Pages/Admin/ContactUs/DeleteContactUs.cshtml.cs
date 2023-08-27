using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.ContactUs;

namespace MyEMShop.EndPoint.Pages.Admin.ContactUs
{
    public class DeleteContactUsModel : PageModel
    {
        #region Inject Service
        private readonly IContactUsConnectionService _contactUsConnection;
        public DeleteContactUsModel(IContactUsConnectionService contactUsConnection)
        {
            _contactUsConnection = contactUsConnection;
        }

        #endregion
        [BindProperty]
        public ContactUsConection contact { get; set; }
        public void OnGet(int id)
        {
            contact = _contactUsConnection.GetById(id);
        }

        public IActionResult OnPost(int id)
        {
            _contactUsConnection.RemoveContactUsConnection(id);
            return RedirectToPage("Index");
        }
    }
}
