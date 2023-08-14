using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.Slider
{
    public class DeleteSliderModel : PageModel
    {
        #region Injection
        private readonly ISliderService _sliderService;
        public DeleteSliderModel(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        #endregion

        [BindProperty]
        public MyEMShop.Data.Entities.Slider.Slider Slider { get; set; }
        public void OnGet(int id)
        {
           Slider = _sliderService.GetSliderById(id);
            ViewData["id"] = id;
        }

        public IActionResult OnPost(int id)
        {
            _sliderService.RemoveSlider(id);
            return RedirectToPage("Index");
        }
    }
}
