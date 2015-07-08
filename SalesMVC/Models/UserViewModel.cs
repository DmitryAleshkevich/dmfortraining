using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesMVC.Models
{
    public class UserViewModel : LoginViewModel
    {
        [Required]
        public string UserRole { get; set; }        
    }
}