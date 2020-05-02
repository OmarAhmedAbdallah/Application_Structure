using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace App.Data.Models
{
    public class User : IdentityUser
    {   
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
