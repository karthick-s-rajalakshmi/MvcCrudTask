using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.entity
{
  public  class VehicleDetail
    {
        [Key]
        public int vehicleId { get; set; }
        public string vehicleName { get; set; }
        public string vehicleNumber { get; set; }
        public long InsuranceNumber { get; set; }
        public long DriverContactNumber { get; set; }
        public DateTime FCdate { get; set; }
        public string OwnerName { get; set; }
    }
}
