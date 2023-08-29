using MyEMShop.Data.Entities.AboutUs;

namespace MyEMShop.Application.Interfaces
{
    public interface IAboutUsService
    {
        AboutUs GetAboutUs();
        AboutUs GetAboutUsById(int aboutUsId);
        void AddAboutUs(AboutUs aboutUs);
        void EditAboutUs(AboutUs aboutUs);
        bool IsAboutUsExist();
    }
}
