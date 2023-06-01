using MyEMShop.Data.Dtos.UserDto;
using MyEMShop.Data.Entities.Wallet;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IUserWalletService
    {
        IList<ShowWalletDto> GetWallet(string userName);
        int ChargeWallet(string userName , string description ,int amount, bool ispay = false);
        int AddWallet(Wallet wallet);
        Wallet GetWalletByWalletId(int walletId);
        void UpdateWallet(Wallet wallet);
    }
}
