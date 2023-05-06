using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreScaffoldDemo.Models
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
        public string? PhoneNumber { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Role> Roles { get; set; }
    }
}
