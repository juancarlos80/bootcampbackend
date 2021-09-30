using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.ActionFilters
{
    public class AuthDataFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Entre al action");
            Dictionary<string, string> tokenInfo = new Dictionary<string, string>();
            var claims = context.HttpContext.User.Identities;
            var principal = context.HttpContext.User;

            if (principal?.Claims != null)
            {
                Console.WriteLine("1");
                foreach (var claim in principal.Claims)
                {
                    Console.WriteLine("Claim: "+ claim.Value);
                    tokenInfo.Add(claim.Type, claim.Value);
                }
            }

            context.HttpContext.Items.Add("authenticationData", tokenInfo);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
