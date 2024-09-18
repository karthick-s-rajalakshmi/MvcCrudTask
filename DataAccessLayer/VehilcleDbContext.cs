using DataAccessLayer.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public  class VehicleDbContext:DbContext
    {
        public VehicleDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<VehicleDetail> vehicleDetails { get; set; }
    }
}
