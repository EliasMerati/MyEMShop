using MyEMShop.Data.Entities.Faq;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IFaqGroupService
    {
        List<FaqGroup> GetAllFaqGroup();
        FaqGroup GetFaqGroupById(int faqGroupId);
        void AddFaqGroup(FaqGroup faqGroup);
        void UpdateFaqGroup(FaqGroup faqGroup);
        void DeleteFaqGroup(int faqGroupId);
    }
}
