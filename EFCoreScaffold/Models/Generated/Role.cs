using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreScaffold.Models
{
    [Index("UserId", Name = "IX_Roles_UserId")]
    public partial class Role
    {
        [Key]
        public long Id { get; set; }
        public string RoleName { get; set; } = null!;
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Roles")]
        public virtual User User { get; set; } = null!;
    }
}
