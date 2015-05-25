using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework.XamlTypes;

namespace Account.Models
{
    public class User
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Email should not be empty")]
        [RegularExpression(@"^\S+@\S+$", ErrorMessage = "Wrong email format. Try new one")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Description should not be empty")]
        [MinLength(50)]
        [MaxLength(200)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(5)]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } 

        [Required(ErrorMessage = "Image should not be empty")]
        public string Base64String { get; set; }

        public string ContentType { get; set; }
    }
}