using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MentorIdentity2.BLL
{
    public class ServiceResult
    {
        public ServiceResultStatus Status { get; set; }
        public string Message { get; set; }
        public ICollection<IdentityError> Errors { get; set; }
    }

    public enum ServiceResultStatus
    {
        Success,
        BadRequest,
        NotFound,
        ServerError
    }
}
