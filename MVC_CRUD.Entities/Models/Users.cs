using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVC_CRUD.Entities.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}
