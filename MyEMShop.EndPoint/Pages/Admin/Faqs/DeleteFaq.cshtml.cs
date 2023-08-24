using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.Faq;

namespace MyEMShop.EndPoint.Pages.Admin.Faqs
{
    [PermissionChecker(68)]
    public class DeleteFaqModel : PageModel
    {
        #region Inject Service
        private readonly IFaqService _faqService;
        public DeleteFaqModel(IFaqService faqService)
        {
            _faqService = faqService;
        }
        #endregion

        [BindProperty]
        public Faq Faq { get; set; }
        public void OnGet(int id)
        {
            Faq = _faqService.GetFaqById(id);
        }
        public IActionResult OnPost(int id)
        {
            _faqService.DeleteFaq(id);
            return RedirectToPage("Index");
        }
    }
}
