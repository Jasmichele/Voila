//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int GenderID { get; set; }
        public int CityID { get; set; }
        public string Address { get; set; }
        public string Billing { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] Image { get; set; }
        public string ClientEmail { get; set; }
    
        public virtual City City { get; set; }
        public virtual Gender Gender { get; set; }
    }
}