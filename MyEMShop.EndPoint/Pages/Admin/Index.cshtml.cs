using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin
{
    [PermissionChecker(1)]
    public class IndexModel : PageModel
    {

        #region Inject Service
        private readonly IVisitorService _visitorService;
        public IndexModel(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }
        #endregion

        public void OnGet()
        {
            ViewData["TotalUsers"] = _visitorService.TotalUsers();
            ViewData["TotalVisitors"] = _visitorService.TotalVisitors();
            ViewData["TodayVisitors"] = _visitorService.TodayVisitors();
            ViewData["TodayVisits"] = _visitorService.TodayVisits();
            ViewData["TotalVisits"]=_visitorService.TotalVisits();
            ViewData["NewOrder"] = _visitorService.NewOrder();
        }
    }
}
