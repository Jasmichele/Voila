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
    
    public partial class Profile
    {
        public int ProfileId { get; set; }
        public string ProfileName { get; set; }
        public int ProffesionID { get; set; }
        public int CityID { get; set; }
        public int PriceID { get; set; }
        public int SpecialityID { get; set; }
        public int GenderID { get; set; }
        public string Bio { get; set; }
        public byte[] Image { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfileEmail { get; set; }
    
        public virtual City City { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Price Price { get; set; }
        public virtual Proffesion Proffesion { get; set; }
        public virtual Speciality Speciality { get; set; }
    }
}
