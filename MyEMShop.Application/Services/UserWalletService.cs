using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Dtos.UserDto;
using MyEMShop.Data.Entities.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class UserWalletService : IUserWalletService
    {
        #region Inject context
        private readonly DatabaseContext _db;
        public UserWalletService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion

        public IList<ShowWalletDto> GetWallet(string userName)
        {
            int userid = _db.Users.Single(u => u.UserName == userName).UserId;
            return _db.Wallets.Where(w => w.IsPay && w.UserId == userid)
                .Select(w => new ShowWalletDto
                {
                    Amount = w.Amount,
                    CreateDate = w.CreateDate,
                    Description = w.Description,
                    TypeId = w.TypeId,
                }).OrderByDescending(w => w.CreateDate)
                .ToList();
        }

        public void ChargeWallet(string userName, string description, int amount, bool ispay = false)
        {
            var wallet = new Wallet()
            {
                Amount= amount,
                CreateDate = DateTime.Now,
                Description = description,  
                IsPay= ispay,
                TypeId =1,
                UserId = _db.Users.Single(u => u.UserName == userName).UserId,
            };
            AddWallet(wallet);
        }

        public void AddWallet(Wallet wallet)
        {
            _db.Wallets.Add(wallet);
            _db.SaveChanges();
        }
    }
}
