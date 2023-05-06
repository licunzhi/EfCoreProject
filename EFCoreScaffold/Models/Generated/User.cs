using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreScaffold.Models
{
    public partial class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }

        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [StringLength(11)]
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Role> Roles { get; set; }
    }
}
