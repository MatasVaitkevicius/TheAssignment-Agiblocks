﻿using Microsoft.EntityFrameworkCore;

namespace AssignmentAgiblocks.WebAPI.Models
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }
    }
}
