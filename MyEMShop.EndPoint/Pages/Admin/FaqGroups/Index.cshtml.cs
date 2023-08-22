using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.Faq;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.FaqGroups
{
    public class IndexModel : PageModel
    {

        #region Inject Service
        private readonly IFaqGroupService _faqGroupService;
        public IndexModel(IFaqGroupService faqGroupService)
        {
            _faqGroupService = faqGroupService;
        }
        #endregion

        public List<FaqGroup> FaqGroup { get; set; }
        public void OnGet()
        {
            FaqGroup = _faqGroupService.GetAllFaqGroup();
        }
    }
}
