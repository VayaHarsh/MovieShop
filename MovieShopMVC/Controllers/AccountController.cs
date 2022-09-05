﻿using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            var userSuccess = await _accountService.ValidateUser(model);
            if (userSuccess == null)
            {
                // pasword matches
                // redirect to home page
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, userSuccess.Email),
                new Claim(ClaimTypes.NameIdentifier, userSuccess.Id.ToString()),
                new Claim(ClaimTypes.Surname, userSuccess.LastName),
                new Claim(ClaimTypes.GivenName, userSuccess.FirstName)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return LocalRedirect("~/");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            var userId = await _accountService.RegisterUser(model);

            if (userId != null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}
