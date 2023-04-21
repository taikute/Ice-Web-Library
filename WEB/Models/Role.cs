﻿using Newtonsoft.Json;

namespace WEB.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
