using MyEMShop.Data.Entities.PrivacyPolicy;

namespace MyEMShop.Application.Interfaces
{
    public interface IPrivacyService
    {
        Privacy GetPrivacy();
        Privacy GetPrivacyById(int privacyId);
        void UpdatePrivacy(Privacy privacy);
    }
}
