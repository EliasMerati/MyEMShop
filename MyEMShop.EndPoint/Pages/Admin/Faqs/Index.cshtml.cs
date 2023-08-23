using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.Faq;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Faqs
{
    public class IndexModel : PageModel
    {
        #region Inject Service
        private readonly IFaqService _faqService;
        public IndexModel(IFaqService faqService)
        {
            _faqService = faqService;
        }
        #endregion

        public List<Faq> Faq { get; set; }
        public void OnGet()
        {
            Faq = _faqService.GetFaqList();
        }
    }
}
