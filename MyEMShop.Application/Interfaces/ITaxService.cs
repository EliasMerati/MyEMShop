using MyEMShop.Data.Entities.Tax;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface ITaxService
    {
        List<Tax> ShowTax();
        void CreateTax(Tax tax);
        void UpdateTax(Tax tax);
        bool IsExistTax();
        Tax GetTaxById(int id);
       
    }
}
