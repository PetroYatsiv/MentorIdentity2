using AutoMapper;
using MentorIdentity2.DTO.Services.Account;
using MentorIdentity2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorIdentity2.Profiles
{
    public class RegisterProfile : Profile
    {
        public RegisterProfile()
        {
            CreateMap<RegisterViewModel, RegisterUserDTO>();
        }
    }
}
