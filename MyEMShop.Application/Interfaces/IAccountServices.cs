﻿using MyEMShop.Data.Entities.User;

namespace MyEMShop.Application.Interfaces
{
    public interface IAccountServices
    {
        bool IsExistEmail(string email);
        bool IsExistUserName(string userName);
        bool Register(User user);
        bool CompareOldPassword(string password, string username);
        void ChangeNewPassword(string username,string password);
    }
}
