﻿using Microsoft.EntityFrameworkCore;
using TestWebAPI.Models.Domain;

namespace TestWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options) 
        { 

        }

        public DbSet<BlogPost>BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
