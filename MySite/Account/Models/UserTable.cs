//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Account.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserTable
    {
        public System.Guid Id { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public string ImageBase64 { get; set; }
        public string ImageContentType { get; set; }
    }
}
