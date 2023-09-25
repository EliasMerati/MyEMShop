using MyEMShop.Data.Dtos.UserDto;
using MyEMShop.Data.Entities.User;

namespace MyEMShop.Application.Interfaces
{
    public interface IAccountServices
    {
        bool IsExistEmail(string email);
        bool IsExistUserName(string userName);
        bool Register(User user);
        User GetUserByEmail(string email);  
        User GetUserByActiveCode(string activeCode);
        void UpdateUser(User user);
        User LoginUser(LoginDto login);
        string HashPassword(string password);
        bool ActiveAccount(string activeCode);
        bool IsAdmin(string email);
    }
}
