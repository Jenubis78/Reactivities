using System.Security.Claims;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Security
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor __httpContextAccesor;
        public UserAccessor(IHttpContextAccessor httpContextAccesor)
        {
            __httpContextAccesor = httpContextAccesor;
            
        }
        public string GetUsername()
        {
            return __httpContextAccesor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }
    }
}