using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Models
{
    public class User : IdentityUser
    {
        [Required, MaxLength(100)]
        public string? FirstName { get; set; }

        [Required, MaxLength(100)]
        public string? LastName { get; set; }
        public bool IsLocked { get; set; }
        [DataType(DataType.Date)]
        public DateTime? LockDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
