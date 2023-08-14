using Microsoft.AspNetCore.Http;
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
            return _db.Sliders.ToList();
        }

        public void RemoveSlider(int sliderId)
        {
            var slider = _db.Sliders.Find(sliderId);
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
                _db.Sliders.Add(new Slider { SliderImageName = slider.SliderImageName });
                _db.SaveChanges();
            }
        }
    }
}
