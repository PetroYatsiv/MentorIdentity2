using MentorIdentity2.BLL.Contracts;
using MentorIdentity2.DAL.Models;
using MentorIdentity2.DTO.Services.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MentorIdentity2.BLL
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        //public AccountService()
        //{
        //}
        public AccountService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }
        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public async Task<ServiceResult> Register(RegisterUserDTO model)
        {
            ServiceResult result = new ServiceResult();
            User user = new User()
            {
                Email = model.Email,
                BirthdayDate = model.BirthdayDate,
                RegistrationDate = DateTime.Now,
                UserName = model.Email
            };
            var createdResult = await _userManager.CreateAsync(user, model.Password);

            if (createdResult.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                result.Status = ServiceResultStatus.Success;
            }
            else
            {
                foreach (var error in createdResult.Errors)
                {
                    var errorDescription = error.Description;
                    result.Errors.Add(error);
                }
            }
            return result;
        }


        public async Task<ServiceResult> Login(LoginUserDTO model)
        {
            ServiceResult result = new ServiceResult();
            var logResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (logResult.Succeeded)
            {
                result.Status = ServiceResultStatus.Success;
            }


            return result;
        }

        public async void Logout()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
