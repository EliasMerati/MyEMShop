using Microsoft.AspNetCore.Mvc;
using MyEMShop.Application.Interfaces;
using System.Threading.Tasks;

namespace MyEMShop.EndPoint.Component
{
    public class NavbarComponent : ViewComponent
    {
        #region Injection
        private readonly IProductService _groupService;
        public NavbarComponent(IProductService groupService)
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
