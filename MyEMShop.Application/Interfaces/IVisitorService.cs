using MyEMShop.Data.Dtos.VisitorDto;
using MyEMShop.Data.Entities.Visitors;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IVisitorService
    {
        void AddVisitorInfo(Visitor visitor);
        long TodayVisits();
        long TodayVisitors();
        long TotalVisits();
        long MonthVisits();
        long MonthVisitors();
        long TotalVisitors();
        int NewOrder();
        long TotalUsers();
        List<VisitorsDto> GetLast10Visitors();
    }
}
