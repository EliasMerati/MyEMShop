using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Areas.UserPannel.Controllers
{
    [Area("UserPannel")]
    [Authorize]
    public class FavoriteController : Controller
    {
        #region Injection
        private readonly IFavoriteProductService _favoriteProduct;
        private readonly IUserPannelService _userService;
        public FavoriteController(IFavoriteProductService favoriteProduct, IUserPannelService userService)
        {
            _favoriteProduct = favoriteProduct;
            _userService = userService;
        }
        #endregion

        public IActionResult Index(int pageId =1)
        {
            ViewBag.pageId = pageId;
            int userId = _userService.GetUserIdByUserName(User.Identity.Name);
            return View(_favoriteProduct.ShowMyFavorite(userId,pageId));
        }

        public IActionResult AddToFavorite(int productId)
        {
            int userId = _userService.GetUserIdByUserName(User.Identity.Name);
            _favoriteProduct.AddToFavorites(userId, productId);
            return Redirect(nameof(Index));
        }

        public IActionResult DeleteFromFavorite(int productid)
        {
            _favoriteProduct.DeleteFromFavorites(productid);
            return Redirect(nameof(Index));
        }
    }
}
