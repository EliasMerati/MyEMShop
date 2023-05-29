using MyEMShop.Data.Dtos.UserDto;

namespace MyEMShop.Application.Interfaces
{
    public interface IUserPannelService
    {
        ShowUserInformationForPannelDto GetUserInfo(string userName);
        ShowUserInfoForEditPannelDto GetInfoForEdit(string userName);
    }
}
