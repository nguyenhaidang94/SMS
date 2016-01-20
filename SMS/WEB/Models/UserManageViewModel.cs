using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Models
{
    public class UserManageViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public List<String> RolesList { get; set; }
    }
}