using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.Terms;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class TermsService : ITermsService
    {
        #region Inject Database
        private readonly DatabaseContext _db;
        public TermsService(DatabaseContext db)
        {
            _db = db;
        }

        #endregion
        public Term GetTerm()
        {
            return _db.Terms.FirstOrDefault();
        }

        public Term GetTermById(int termId)
        {
            return _db.Terms.Find(termId);
        }

        public void UpdateTerm(Term term)
        {
            _db.Update(term);
            _db.SaveChanges();
        }
    }
}
