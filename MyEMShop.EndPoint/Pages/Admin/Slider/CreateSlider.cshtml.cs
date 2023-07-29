using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.Slider
{
    public class CreateSliderModel : PageModel
    {
        #region Injection
        private readonly ISliderService _sliderService;
        private readonly IDistributedCache _cache;
        public CreateSliderModel(ISliderService sliderService, IDistributedCache cache)
        {
            _sliderService = sliderService;
            _cache = cache;
        }

        #endregion

        [BindProperty]
        public MyEMShop.Data.Entities.Slider.Slider Slider { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(IFormFile MainimgSlider)
        {
            _sliderService.AddSlider(Slider, MainimgSlider);
            return RedirectToPage("Index");
        }
    }
}
