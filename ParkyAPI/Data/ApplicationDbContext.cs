﻿using Microsoft.EntityFrameworkCore;
using ParkyAPI.Models;

namespace ParkyAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options){}

        public DbSet<NationalPark> NationalParks { get; set; }
    }
}