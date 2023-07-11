using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;

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
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _sliderService.AddSlider(Slider, MainimgSlider);
            _cache.RemoveAsync(CatchHelper.GenerateShowIndexCacheKey());
            _cache.RemoveAsync(CatchHelper.GenerateShowProductCacheKey());
            return RedirectToPage("Index");
        }
    }
}
