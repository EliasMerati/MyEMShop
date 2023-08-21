using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.PrivacyPolicy;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class PrivacyService : IPrivacyService
    {
        #region Inject Database
        private readonly DatabaseContext _db;
        public PrivacyService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion
        public void AddPrivacy(Privacy privacy)
        {
            _db.Privacies.Add(privacy);
            _db.SaveChanges();
        }

        public Privacy GetPrivacy()
        {
            return _db.Privacies.FirstOrDefault();
        }

        public Privacy GetPrivacyById(int privacyId)
        {
            return _db.Privacies.Find(privacyId);
        }

        public void UpdatePrivacy(Privacy privacy)
        {
            _db.Update(privacy);
            _db.SaveChanges();
        }
    }
}
