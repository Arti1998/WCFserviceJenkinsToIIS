using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VehicleServices
{
  
    public class VehicleService : IVehicleService
    {
         static int idGen = 10;                                  /*genrate id for new vehicle*/
         static List<Vehicle> vehicleList = new List<Vehicle>(); /* In-memory storage */
         Vehicle lst = new Vehicle();
         Vehicle lst1 = new Vehicle();

        /*provide details of all vehicles*/
        public List<Vehicle> GetVehicle()
        {
            //Vehicle lst = new Vehicle();
            lst.Id = 1;
            lst.Year = 2022;
            lst.Make = "IND";
            lst.Model = "XM";
            lst1.Id = 2;
            lst1.Year = 2022;
            lst1.Make = "IND";
            lst1.Model = "XM++";
            vehicleList.Add(lst);
            vehicleList.Add(lst1);
            return vehicleList;
        }

        /*provide vehicle details based on id*/
        public Vehicle getVehicleById(string id)
        {
           Vehicle result = vehicleList.Find(x => x.Id == Int32.Parse(id));
           return result;
        }

        /*Validation for range of Year*/
        public Boolean yearRange(int year) {
            if (year >= 1950 && year <= 2050) 
                return true; 
            else
                return false;
        }

        /*Check for empty or null string*/
        public Boolean IsEmpty(String str) {
                return String.IsNullOrEmpty(str);
        }

        /*Paramter filter : model,make */
        public List<Vehicle> GetVehicleByMakeModel(string model, string make)
        {
           return vehicleList.FindAll(x => x.Model == model && x.Make == make);
        }

        /*Paramter filter : model,year */
        public List<Vehicle> GetVehicleByModelYear(string model, string year)
        {
            return vehicleList.FindAll(x => x.Model == model && x.Year == Int32.Parse(year));
        }

        /*Paramter filter : make,year */
        public List<Vehicle> GetVehicleByMakeYear(string make, string year)
        {
            return vehicleList.FindAll(x => x.Make == make && x.Year == Int32.Parse( year));
        }

        ///*request handling*/
        //public void HandleHttpOptionsRequest()
        //{
        //}

        /*update vehicle details*/
        public void UpdateVehicle(Vehicle vehicle)
        {
            if (!IsEmpty(vehicle.Make) && !IsEmpty(vehicle.Model) && yearRange(vehicle.Year))
            {
                Vehicle result = vehicleList.Find(x => x.Id == vehicle.Id);
                result.Make = vehicle.Make;
                result.Model = vehicle.Model;
                result.Year = vehicle.Year;
            }
        }

        /* create new vehicle */
        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            if (!IsEmpty(vehicle.Make) && !IsEmpty(vehicle.Model) && yearRange(vehicle.Year))
            {
                idGen = idGen + 1;
                vehicle.Id = idGen;
                vehicleList.Add(vehicle);
            }
            return vehicle;
        }

        /*Delete vehicle based on id*/
        public void DeleteVehicle(string id)
        {
            vehicleList.Remove(vehicleList.Where(x => x.Id == Int32.Parse(id)).First());
        }
    }
}
