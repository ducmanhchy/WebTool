using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSampleTool2.Models;

namespace WebSampleTool2.App_Start.IdentityPolicy
{
    public class CustomUserValidator<T> : UserValidator<ApplicationUser>
    {
        public CustomUserValidator(ApplicationUserManager manager)
            : base(manager)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(ApplicationUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            if (!user.Email.ToLower().EndsWith(EndEmail))
            {
                var errors = result.Errors.ToList();
                errors.Add("Only example.com email addresses are allowed");
                result = new IdentityResult(errors);
            }

            return result;
        }

        public string EndEmail { get; set; }
        public bool AllowOnlyAlphanumericUserNames { get; set; }
        public bool RequireUniqueEmail { get; set; }
    }
}