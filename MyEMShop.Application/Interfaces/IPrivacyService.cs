using MyEMShop.Data.Entities.PrivacyPolicy;

namespace MyEMShop.Application.Interfaces
{
    public interface IPrivacyService
    {
        Privacy GetPrivacy();
        Privacy GetPrivacyById(int privacyId);
        void AddPrivacy(Privacy privacy);
        void UpdatePrivacy(Privacy privacy);
        bool IsExistPrivacy();
    }
}
