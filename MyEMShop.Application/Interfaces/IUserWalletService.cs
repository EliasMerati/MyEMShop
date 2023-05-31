using MyEMShop.Data.Dtos.UserDto;
using MyEMShop.Data.Entities.Wallet;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IUserWalletService
    {
        IList<ShowWalletDto> GetWallet(string userName);
        void ChargeWallet(string userName , string description ,int amount, bool ispay = false);
        void AddWallet(Wallet wallet);
    }
}
