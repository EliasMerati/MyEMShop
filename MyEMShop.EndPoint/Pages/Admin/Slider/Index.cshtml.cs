using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Slider
{
    [PermissionChecker(35)]
    public class IndexModel : PageModel
    {
        #region Injection
        private readonly ISliderService _sliderService;
        public IndexModel(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        #endregion

        public List<MyEMShop.Data.Entities.Slider.Slider> Sliders { get; set; }
        public void OnGet()
        {
            Sliders = _sliderService.GetAllSliders();
        }
    }
}
