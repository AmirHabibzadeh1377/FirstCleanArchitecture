using Microsoft.AspNetCore.Identity;

using System;

namespace CleanArchitecture.Identity.Models
{
public class ApplicationUser:IdentityUser
    {
        public Guid UserId { get; set; }
        public string FirstName{ get; set; }
        public string  LastName { get; set; }
        public int NationalCode { get; set; }
        public int IdCard { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public bool IsCompeletedRegister { get; set; }
        public bool IsApproved { get; set; }
        public long StudentId { get; set; }
    }
}