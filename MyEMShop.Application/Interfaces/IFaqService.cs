using MyEMShop.Data.Entities.Faq;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IFaqService
    {
        List<Faq> GetFaqList();
        Faq GetFaqById(int faqId);
        void AddFaq(Faq faq);
        void UpdateFaq(Faq faq);
        void DeleteFaq(int faqId);
    }
}
