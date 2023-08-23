using Microsoft.AspNetCore.Mvc.Rendering;
using MyEMShop.Data.Entities.Faq;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IFaqGroupService
    {
        List<FaqGroup> GetFaqGroups();
        List<SelectListItem> GetAllFaqGroupForFaq();
        FaqGroup GetFaqGroupById(int faqGroupId);
        void AddFaqGroup(FaqGroup faqGroup);
        void UpdateFaqGroup(FaqGroup faqGroup);
        void DeleteFaqGroup(int faqGroupId);
    }
}
