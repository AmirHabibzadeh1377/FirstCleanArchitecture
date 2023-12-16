using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace CleanArichitecture.Application.Models.Idnetity
{
    public class ExternalResponse
    {
        public ClaimsPrincipal ClaimsPrincipal { get; set; }    
        public AuthenticationProperties AuthenticationProperties { get; set; }
        public bool Success { get; set; }
     }
}