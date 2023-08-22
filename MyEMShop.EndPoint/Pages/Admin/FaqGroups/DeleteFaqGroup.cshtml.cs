using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.Faq;

namespace MyEMShop.EndPoint.Pages.Admin.FaqGroups
{
    public class DeleteFaqGroupModel : PageModel
    {
        #region Inject Service
        private readonly IFaqGroupService _faqGroupService;
        public DeleteFaqGroupModel(IFaqGroupService faqGroupService)
        {
            _faqGroupService = faqGroupService;
        }
        #endregion

        [BindProperty]
        public FaqGroup FaqGroup { get; set; }
        public void OnGet(int id)
        {
            FaqGroup = _faqGroupService.GetFaqGroupById(id);
        }
        public IActionResult OnPost( int id)
        {
            _faqGroupService.DeleteFaqGroup(id);
            return RedirectToPage("Index");
        }
    }
}
