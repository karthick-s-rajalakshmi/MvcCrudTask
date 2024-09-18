using DataAccessLayer.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class VehicleRepository:IVehicleRepository
    {
        VehicleDbContext dbContext = null;
        public VehicleRepository(VehicleDbContext context)
        {
            dbContext = context;
        }
       
        public void InsertVehicleData(VehicleDetail data)
        {

            try
            {
                dbContext.Add(data);
                dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw;
            }

        }
      
       
        public List<VehicleDetail> GetAllVehicleData()
        {
            try
            {
                return dbContext.vehicleDetails.ToList();

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public VehicleDetail GetVehicleByName(string vehicleName)
        {
            try
            {
                return dbContext.vehicleDetails.FirstOrDefault(X => X.vehicleName == vehicleName);

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        
        public void UpdateVehcileDetail(VehicleDetail value)
        {
            try {
                dbContext.Update(value);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            
        }

        public void deleteVehicleDetail( int id)
        {
            var count = dbContext.vehicleDetails.Find(id);
            dbContext.Remove(count);
            dbContext.SaveChanges();
        }


    }

}

