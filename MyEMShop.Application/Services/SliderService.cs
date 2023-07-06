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
        public void AddSlider(Slider slider, IFormFile ImageFile)
        {
            SetImageForSlider(slider, ImageFile);
            _db.SaveChangesAsync();
        }

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

        public void SetImageForSlider(Slider slider, IFormFile ImageFile)
        {
            if (ImageFile is not null)
            {
                slider.SliderImageName = GenerateCode.GenerateUniqueCode() + Path.GetExtension(ImageFile.FileName);
                string Imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/slider/", slider.SliderImageName);

                using (var stream = new FileStream(Imagepath, FileMode.CreateNew))
                {
                    ImageFile.CopyTo(stream);
                }

            }

        }

        public void UpdateSlider(Slider slider)
        {
            _db.Update(slider);
            _db.SaveChanges();
        }
    }
}
