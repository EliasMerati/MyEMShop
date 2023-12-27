using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Dtos.VisitorDto;
using System.Collections.Generic;

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

        public List<VisitorsDto> Top10 { get; set; }
        public void OnGet()
        {
            Top10 = _visitorService.GetLast10Visitors();
            ViewData["TotalUsers"] = _visitorService.TotalUsers();
            ViewData["TotalVisitors"] = _visitorService.TotalVisitors();
            ViewData["TodayVisitors"] = _visitorService.TodayVisitors();
            ViewData["TodayVisits"] = _visitorService.TodayVisits();
            ViewData["TotalVisits"]=_visitorService.TotalVisits();
            ViewData["NewOrder"] = _visitorService.NewOrder();
            //ViewData["MonthVisits"] = _visitorService.MonthVisits();
            //ViewData["MonthVisitors"] = _visitorService.MonthVisitors();

        }
    }
}
