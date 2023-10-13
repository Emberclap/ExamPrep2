using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>(); 
        }

        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; } 

        public void AddVehicle(Vehicle vehicle)
        {
            if (Capacity > Vehicles.Count)
            {
                Vehicles.Add(vehicle);
            }
        }
        public bool RemoveVehicle(string VIN)
        {
            if(Vehicles.Any(x => x.VIN == VIN))
            {
                Vehicle vehicle = Vehicles.FirstOrDefault(x => x.VIN == VIN);
                Vehicles.Remove(vehicle);
                return true;
            }
            else { return false; }
        }
        public int GetCount()
        {
            return Vehicles.Count;
        }
        public Vehicle GetLowestMileage()
        {
            Vehicle vehicle = Vehicles.MinBy(x => x.Mileage);
            return vehicle;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");
            foreach (Vehicle vehicle in Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
