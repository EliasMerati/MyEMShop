using MyEMShop.Data.Entities.Terms;

namespace MyEMShop.Application.Interfaces
{
    public interface ITermsService
    {
        Term GetTerm();
        Term GetTermById(int termId);
        void UpdateTerm(Term term);
    }
}
