using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RSS_FEED.Models
{
    public class IdentityModel : DbContext
    {
        public IdentityModel(DbContextOptions<IdentityModel> options) : base(options)
        {
        }
        public DbSet<Login> login { get; set; }
    }
}
