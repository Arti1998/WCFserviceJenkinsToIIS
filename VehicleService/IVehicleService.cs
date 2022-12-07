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
        List<Vehicle> GetVehicle();

        [WebGet(UriTemplate = "/vehicles/{id}",ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Vehicle getVehicleById(String id);

        [WebInvoke(Method = "PUT", UriTemplate = "/updatevehicles", RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        void UpdateVehicle(Vehicle vehicle);

        [WebInvoke(Method = "POST",UriTemplate = "/vehicles", RequestFormat=WebMessageFormat.Json, ResponseFormat=WebMessageFormat.Json)]
        [OperationContract]
        Vehicle CreateVehicle(Vehicle vehicle);

        [WebInvoke(Method = "DELETE", UriTemplate = "/vehicles/{id}")]
        [OperationContract]
        void DeleteVehicle( String id);

        //[WebGet(UriTemplate = "/vehicles/model/{model}/make/{make}", ResponseFormat = WebMessageFormat.Json)]
        //[OperationContract]
        //List<Vehicle> GetVehicleByMakeModel(string model, string make);

        //[WebGet(UriTemplate = "/vehicles/model/{model}/year/{year}", ResponseFormat = WebMessageFormat.Json)]
        //[OperationContract]
        //List<Vehicle> GetVehicleByModelYear(string model, string year);

        //[WebGet(UriTemplate = "/vehicles/make/{make}/year/{year}", ResponseFormat = WebMessageFormat.Json)]
        //[OperationContract]
        //List<Vehicle> GetVehicleByMakeYear(string make, string year);
        
    }
}
