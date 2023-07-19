using MyEMShop.Data.Dtos.UserDto;
using MyEMShop.Data.Entities.User;

namespace MyEMShop.Application.Interfaces
{
    public interface IUserPannelService
    {
        ShowUserInformationForPannelDto GetUserInfo(string userName);
        ShowUserInformationForPannelDto GetUserInfo(int userId);
        ShowUserInformationForPannelDto GetUserRefreshInfo(int userId);
        ShowUserInfoForEditPannelDto GetInfoForEdit(string userName);
        void EditUserPannel(string userName, ShowUserInfoForEditPannelDto edit);
        bool CompareOldPassword(string password, string username);
        void ChangeNewPassword(string username, string password);
        string HashPassword(string password);
        int BalanceWallet(string userName);
        int GetUserIdByUserName(string userName);
        User GetUserByUserName(string userName);
        UserAddressDto GetUserAddressForOrder(string userName);
    }
}
