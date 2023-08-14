using Microsoft.AspNetCore.Http;
using MyEMShop.Data.Entities.Slider;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface ISliderService
    {
        List<Slider> GetAllSliders();
        void RemoveSlider(int sliderId);
        void SetImageForSlider(Slider slider, IFormFile ImageFile);
        Slider GetSliderById(int sliderId);
    }
}
