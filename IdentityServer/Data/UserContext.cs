﻿using IdentityServer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Data
{
    public class UserContext : DbContext
    {
        public UserContext()
        {
        }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
    }
}