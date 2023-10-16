using Microsoft.EntityFrameworkCore;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.Tax;
using System.Collections.Generic;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class TaxService : ITaxService
    {
        private readonly DatabaseContext _db;
        #region Inject Database
        public TaxService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion
        public void CreateTax(Tax tax)
        {
            _db.Taxes.Add(tax);
            _db.SaveChanges();
        }

        public Tax GetTax()
        {
            return _db.Taxes.FirstOrDefault();
        }

        public Tax GetTaxById(int id)
        {
            return _db.Taxes.Find(id);
        }

        public bool IsExistTax()
        {
            return _db.Taxes.Any();
        }

        public List<Tax> ShowTax()
        {
            return _db.Taxes.AsNoTracking().ToList();
        }

        public void UpdateTax(Tax tax)
        {
            _db.Taxes.Update(tax);
            _db.SaveChanges();
        }
    }
}
