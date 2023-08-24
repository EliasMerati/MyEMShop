using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.Faq;

namespace MyEMShop.EndPoint.Pages.Admin.FaqGroups
{
    [PermissionChecker(63)]
    public class AddFaqGroupModel : PageModel
    {

        #region Inject Service
        private readonly IFaqGroupService _faqGroupService;
        public AddFaqGroupModel(IFaqGroupService faqGroupService)
        {
            _faqGroupService = faqGroupService;
        }
        #endregion

        [BindProperty]
        public FaqGroup FaqGroup { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _faqGroupService.AddFaqGroup(FaqGroup);
            return RedirectToPage("Index");
        }
    }
}
