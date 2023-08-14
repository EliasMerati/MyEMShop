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

        public void OnGet()
        {
        }

        public IActionResult OnPost(int id)
        {
            _sliderService.RemoveSlider(id);
            return RedirectToPage("Index");
        }
    }
}
