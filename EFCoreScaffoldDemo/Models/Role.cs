using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreScaffoldDemo.Models
{
    [Keyless]
    public partial class Role
    {
        public long? Id { get; set; }
        public string? RoleName { get; set; }
        public long? UserId { get; set; }
    }
}
