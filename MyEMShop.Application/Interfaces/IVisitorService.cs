﻿using MyEMShop.Data.Entities.Visitors;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IVisitorService
    {
        void AddVisitorInfo(Visitor visitor);
        long TodayVisits();
        long TodayVisitors();
        long TotalVisits();
        long TotalVisitors();
        int NewOrder();
        long TotalUsers();
    }
}
