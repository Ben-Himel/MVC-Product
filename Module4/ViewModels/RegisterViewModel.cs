﻿using System.ComponentModel.DataAnnotations;

namespace Module4.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set;}
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
