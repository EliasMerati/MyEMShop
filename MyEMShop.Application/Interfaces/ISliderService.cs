using Microsoft.AspNetCore.Http;
using MyEMShop.Data.Entities.Slider;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface ISliderService
    {
        List<Slider> GetAllSliders();
        void AddSlider(Slider slider, IFormFile ImageFile);
        void RemoveSlider(int sliderId);
        void UpdateSlider(Slider slider);
        void SetImageForSlider(Slider slider, IFormFile ImageFile);
    }
}
