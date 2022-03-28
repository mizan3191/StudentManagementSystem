﻿using Autofac;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMS.Web.Models.AccountModel
{
    public class LoginModel : BaseModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        private ILifetimeScope _scope;

        public LoginModel()
        {
        }

        public override void Resolve(ILifetimeScope scope)
        {
            _scope = scope;

            base.Resolve(_scope);
        }
    }
}