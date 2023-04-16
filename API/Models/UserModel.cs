﻿using API.Data;

namespace API.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; } = 1;
        public virtual Role? Role { get; set; }
    }
}