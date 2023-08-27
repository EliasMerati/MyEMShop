using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.ContactUs;

namespace MyEMShop.EndPoint.Pages.Admin.ContactUs
{
    public class AnswerModel : PageModel
    {
        #region Injection
        private readonly IContactUsConnectionService _contactUsConnectionService;
        public AnswerModel(IContactUsConnectionService contactUsConnectionService)
        {
            _contactUsConnectionService = contactUsConnectionService;
        }

        #endregion

        [BindProperty]
        public ContactUsConection contact { get; set; }
        public void OnGet(int id)
        {
            contact = _contactUsConnectionService.GetById(id);
        }

        public IActionResult OnPost(string answere)
        {
            _contactUsConnectionService.AnswerQuestion(answere,contact.Email);
            return RedirectToPage("Index");
        }
    }
}
