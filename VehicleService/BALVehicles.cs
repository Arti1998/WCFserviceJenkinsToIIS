using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VehicleServices
{
    public class Vehicles
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public String Make { get; set; }
        public String Model { get; set; }

    }

    public class BALDAL
    {

        public List<Vehicles> DALGetVehicles()
        {

            DataTable VehicleSet = new DataTable();
            List<Vehicles> vehicleList = new List<Vehicles>();
            try
            {

                string ConnectionString = @"Data Source=VM1122;Initial Catalog=master;User ID=myadmin;Password=Admin@12345678";
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "dbo.Get_VehiclesDetails";
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    VehicleSet = ds.Tables[0];
                    con.Close();
                    foreach (DataRow vehicleDr in VehicleSet.Rows)
                    {
                        Vehicles item = new Vehicles();
                        item.Id = int.Parse(vehicleDr[0].ToString());
                        item.Year = int.Parse(vehicleDr[1].ToString());
                        item.Make = vehicleDr[2].ToString();
                        item.Model = vehicleDr[3].ToString();
                        vehicleList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();

            }

            return vehicleList;
        }

    }
    
}