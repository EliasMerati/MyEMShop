﻿using MyEMShop.Data.Dtos.UserDto;

namespace MyEMShop.Application.Interfaces
{
    public interface IUserPannelService
    {
        ShowUserInformationForPannelDto GetUserInfo(string userName);
        ShowUserInfoForEditPannelDto GetInfoForEdit(string userName);
        void EditUserPannel(string userName, ShowUserInfoForEditPannelDto edit);
        bool CompareOldPassword(string password, string username);
        void ChangeNewPassword(string username, string password);
        string HashPassword(string password);
    }
}