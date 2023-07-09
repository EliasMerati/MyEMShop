using Microsoft.AspNetCore.Mvc;
using MyEMShop.Application.Interfaces;
using System.Threading.Tasks;

namespace MyEMShop.EndPoint.Component
{
    public class NavbarComponent : ViewComponent
    {
        #region Injection
        private readonly IGroupService _groupService;
        public NavbarComponent(IGroupService groupService)
        {
            _groupService = groupService;
        }
        #endregion


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("Navbar",_groupService.GetGroups()));
        }
    }
}
