using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreScaffoldDemo.Models
{
    [Keyless]
    public partial class User
    {
        public long? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [StringLength(11)]
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}   
