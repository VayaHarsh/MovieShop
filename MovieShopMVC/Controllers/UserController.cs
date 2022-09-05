using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Infra;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ICurrentUser _currentUser;

        public UserController(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        [HttpGet]
        public async Task<IActionResult> Purchases()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(UserRegisterModel model)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BuyMovie()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FavoriteMovie()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
