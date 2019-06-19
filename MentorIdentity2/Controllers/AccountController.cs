using AutoMapper;
using MentorIdentity2.BLL;
using MentorIdentity2.DAL.Models;
using MentorIdentity2.DTO.Services.Account;
using MentorIdentity2.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MentorIdentity2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AccountService service = new AccountService(_userManager, _signInManager );
                RegisterUserDTO userRegisterModel = _mapper.Map<RegisterUserDTO>(model);

                var result = await service.Register(userRegisterModel);

                if (result.Status == ServiceResultStatus.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                AccountService service = new AccountService(_signInManager);
                LoginUserDTO userLoginModel = _mapper.Map<LoginUserDTO>(model);

                var loginUser = await service.Login(userLoginModel);

                if (loginUser.Status == ServiceResultStatus.Success)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or pass");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            AccountService service = new AccountService(_signInManager);
            service.Logout();            
            return RedirectToAction("Index", "Home");
        }
        

    }
}
