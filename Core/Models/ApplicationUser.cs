using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Core.Models
{
    public class ApplicationUser:IdentityUser
    {
        [AllowNull]
        public string? FirstName { get; set; }
        [AllowNull]
        public string? LastName { get; set; }
    }
}
