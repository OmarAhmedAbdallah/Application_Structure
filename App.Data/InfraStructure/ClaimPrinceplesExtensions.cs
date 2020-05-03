using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace App.Data.InfraStructure
{
    public static class ClaimPrinceplesExtensions
    {
        public static string GetUserById (this ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
