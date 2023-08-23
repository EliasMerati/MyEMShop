using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.Faq;

namespace MyEMShop.EndPoint.Pages.Admin.Faqs
{
    public class UpdateFaqModel : PageModel
    {
        #region Inject Service
        private readonly IFaqService _faqService;
        private readonly IFaqGroupService _faqGroupService;
        public UpdateFaqModel(IFaqService faqService, IFaqGroupService faqGroupService)
        {
            _faqService = faqService;
            _faqGroupService = faqGroupService;
        }
        #endregion

        [BindProperty]
        public Faq Faq { get; set; }
        public void OnGet(int id)
        {
           Faq = _faqService.GetFaqById(id);

            var faqgroup = _faqGroupService.GetAllFaqGroupForFaq();
            ViewData["Groups"] = new SelectList(faqgroup, "Value", "Text",Faq.FaqGroupId);
        }

        public IActionResult OnPost()
        {
            _faqService.UpdateFaq(Faq);
            return RedirectToPage("Index");
        }
    }
}
