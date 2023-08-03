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

        public Tuple<List<ShowWalletDto>, int> GetWallet(string userName, int pageId = 1)
        {
            
            int skip = (pageId - 1) * 8;

            int userid = _db.Users.Single(u => u.UserName == userName).UserId;
            int totalcount = _db.Wallets.Where(w => w.UserId == userid && w.IsPay)
                .Select(w => new ShowWalletDto
                {
                    Amount = w.Amount,
                    CreateDate = w.CreateDate,
                    Description = w.Description,
                    TypeId = w.TypeId,
                })
                .Count()/8;
            var walletList = _db.Wallets.Where(w => w.UserId == userid && w.IsPay)
                .Select(w => new ShowWalletDto
                {
                    Amount = w.Amount,
                    CreateDate = w.CreateDate,
                    Description = w.Description,
                    TypeId = w.TypeId,
                })
                .OrderByDescending(w => w.CreateDate)
                .Skip(skip)
                .Take(8)
                .ToList();

            return Tuple.Create(walletList, totalcount);
        }

        public int ChargeWallet(string userName, string description, int amount, bool ispay = false)
        {
            var wallet = new Wallet()
            {
                Amount = amount,
                CreateDate = DateTime.Now,
                Description = description,
                IsPay = ispay,
                TypeId = 1,
                UserId = _db.Users.Single(u => u.UserName == userName).UserId,
            };
            return AddWallet(wallet);
        }

        public int AddWallet(Wallet wallet)
        {
            _db.Wallets.Add(wallet);
            _db.SaveChanges();
            return wallet.WalletId;
        }

        public Wallet GetWalletByWalletId(int walletId)
        {
            return _db.Wallets.Find(walletId);
        }

        public void UpdateWallet(Wallet wallet)
        {
            _db.Update(wallet);
            _db.SaveChanges();
        }
    }
}
