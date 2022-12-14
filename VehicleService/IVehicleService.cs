using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VehicleServices
{
   
    [ServiceContract]
    public interface IVehicleService
    {
        //[OperationContract]
        //[WebInvoke(UriTemplate = "*", Method = "*")]
        //void HandleHttpOptionsRequest();

        [WebGet(UriTemplate = "/vehicles", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Vehicles> GetVehicle();

        [WebGet(UriTemplate = "/vehicles/{id}",ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Vehicles> getVehicleById(String id);

        [WebInvoke(Method = "PUT", UriTemplate = "/updatevehicles", RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        string UpdateVehicle(Vehicle vehicle);

        [WebInvoke(Method = "POST",UriTemplate = "/AddVehicles", RequestFormat=WebMessageFormat.Json)]
        [OperationContract]
        string CreateVehicle(Vehicle vehicle);

        [WebInvoke(Method = "DELETE", UriTemplate = "/RemoveVehicles/{id}")]
        [OperationContract]
        string DeleteVehicle(string id);

        //[WebGet(UriTemplate = "/vehicles/model/{model}/make/{make}", ResponseFormat = WebMessageFormat.Json)]
        //[OperationContract]
        //List<Vehicles> GetVehicleByMakeModel(string model, string make);

        //[WebGet(UriTemplate = "/vehicles/model/{model}/year/{year}", ResponseFormat = WebMessageFormat.Json)]
        //[OperationContract]
        //List<Vehicles> GetVehicleByModelYear(string model, string year);

        //[WebGet(UriTemplate = "/vehicles/make/{make}/year/{year}", ResponseFormat = WebMessageFormat.Json)]
        //[OperationContract]
        //List<Vehicles> GetVehicleByMakeYear(string make, string year);
        
    }

    [DataContract]
    public class Vehicle
    {
        //bool boolValue = true;
        //string stringValue = "Hello ";

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public string Make { get; set; }
        [DataMember]
        public string Model { get; set; }

    }
}
