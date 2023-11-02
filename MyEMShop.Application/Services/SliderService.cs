using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.Slider;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class SliderService : ISliderService
    {
        #region Injection
        private readonly DatabaseContext _db;
        public SliderService(DatabaseContext db)
        {
            _db = db;
        }

        #endregion


        public List<Slider> GetAllSliders()
        {
            return _db.Sliders.AsNoTracking().ToList();
        }

        public Slider GetSliderById(int sliderId)
        {
            return _db.Sliders.Find(sliderId);
        }

        public void RemoveSlider(int sliderId)
        {
            var slider = _db.Sliders.Find(sliderId);
            var sliderImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/slider/", slider.SliderImageName);
            if (File.Exists(sliderImage))
            {
                File.Delete(sliderImage);
            } 
            _db.Remove(slider);
            _db.SaveChanges();
        }

        public void SetImageForSlider(Slider slider, IFormFile ImgFile)
        {
            if (ImgFile is not null)
            {
                slider.SliderImageName = GenerateCode.GenerateUniqueCode() + Path.GetExtension(ImgFile.FileName);
                string Imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/slider/", slider.SliderImageName);

                using (var stream = new FileStream(Imagepath, FileMode.CreateNew))
                {
                    ImgFile.CopyTo(stream);
                }
                _db.Sliders.Add(new Slider {SliderId = slider.SliderId, SliderImageName = slider.SliderImageName });
                _db.SaveChanges();
            }
        }
    }
}
