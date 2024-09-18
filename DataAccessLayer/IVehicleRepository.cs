using DataAccessLayer.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IVehicleRepository
    {
        public VehicleDetail GetVehicleByName(string vehicleName);
        public List<VehicleDetail> GetAllVehicleData();
        public void InsertVehicleData(VehicleDetail data);

        public void deleteVehicleDetail(int id);
        public void UpdateVehcileDetail(VehicleDetail value);

    }
}
