using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.Slider
{
    [PermissionChecker(36)]
    public class CreateSliderModel : PageModel
    {
        #region Injection
        private readonly ISliderService _sliderService;

        public CreateSliderModel(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        #endregion

        [BindProperty]
        public MyEMShop.Data.Entities.Slider.Slider Slider { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(IFormFile MainimgSlider)
        {
            _sliderService.SetImageForSlider(Slider, MainimgSlider);
            return RedirectToPage("Index");
        }
    }
}
