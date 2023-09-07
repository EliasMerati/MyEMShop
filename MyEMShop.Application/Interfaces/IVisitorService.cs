using MyEMShop.Data.Dtos.Visitor;
using MyEMShop.Data.Entities.Visitors;

namespace MyEMShop.Application.Interfaces
{
    public interface IVisitorService
    {
        void AddVisitorInfo(Visitor visitor);
    }
}
