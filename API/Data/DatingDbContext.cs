using System;
using API.Entites;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DatingDbContext: DbContext
{
    public DatingDbContext(DbContextOptions<DatingDbContext> options): base(options)
    {
       
    }

    public DbSet<AppUser> Users { get; set; }
}
