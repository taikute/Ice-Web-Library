﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
    public class Role
    {
        public int RoleId { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
