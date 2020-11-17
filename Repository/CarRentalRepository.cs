using Nikunj_Interview_Cisive.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Nikunj_Interview_Cisive.Repository
{
    public class CarRentalRepository : ICarRentalRepository
    {
        public string CarResigtration(CarDetails oDetails)
        {
            DataTable dt = new DataTable();
            ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["ConnectionString"];
            using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
            {
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCnn;
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "SP_CAR_REGISTRATION";
                    objCmd.Parameters.Add(new SqlParameter("@FLAG", "CAR_REGISTRATION"));
                    objCmd.Parameters.Add(new SqlParameter("@CAR_NAME", oDetails.CarName));
                    objCmd.Parameters.Add(new SqlParameter("@CAR_IMAGE", oDetails.CarImagePath));
                    objCmd.Parameters.Add(new SqlParameter("@CAR_RATE", oDetails.CarRateHourly));
                    objCmd.Parameters.Add(new SqlParameter("@REGISTERED_BY", 1));

                    objCmd.CommandTimeout = 0;
                    SqlDataAdapter objDa = new SqlDataAdapter(objCmd);
                    objDa.Fill(dt);
                }
            }

            return dt.Rows[0]["Result"].ToString(); ;
        }


        public string CarRentingRequest(CarRentingRequest oDetails)
        {
            DataTable dt = new DataTable();
            ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["ConnectionString"];
            using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
            {
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCnn;
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "SP_CAR_RENTING";
                    objCmd.Parameters.Add(new SqlParameter("@FLAG", "REQUEST_RENTING"));
                    objCmd.Parameters.Add(new SqlParameter("@CAR_NUMBER", oDetails.CarNumber));
                    objCmd.Parameters.Add(new SqlParameter("@CUSTOMER_NAME", oDetails.CustomerName));
                    objCmd.Parameters.Add(new SqlParameter("@REQUESTED_BY", 1));

                    objCmd.CommandTimeout = 0;
                    SqlDataAdapter objDa = new SqlDataAdapter(objCmd);
                    objDa.Fill(dt);
                }
            }

            return dt.Rows[0]["Result"].ToString(); ;
        }


        public string CarReturnRequest(Car_Base oDetails)
        {
            DataTable dt = new DataTable();
            ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["ConnectionString"];
            using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
            {
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCnn;
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "SP_CAR_RENTING";
                    objCmd.Parameters.Add(new SqlParameter("@FLAG", "RETURN_RENTING"));
                    objCmd.Parameters.Add(new SqlParameter("@CAR_NUMBER", oDetails.CarNumber));

                    objCmd.CommandTimeout = 0;
                    SqlDataAdapter objDa = new SqlDataAdapter(objCmd);
                    objDa.Fill(dt);
                }
            }

            return dt.Rows[0]["Result"].ToString(); ;
        }


        public string CarDeRegistration(Car_Base oDetails)
        {
            DataTable dt = new DataTable();
            ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["ConnectionString"];
            using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
            {
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = objCnn;
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "SP_CAR_REGISTRATION";
                    objCmd.Parameters.Add(new SqlParameter("@FLAG", "CAR_DEREGISTRATION"));
                    objCmd.Parameters.Add(new SqlParameter("@CAR_NUMBER", oDetails.CarNumber));

                    objCmd.CommandTimeout = 0;
                    SqlDataAdapter objDa = new SqlDataAdapter(objCmd);
                    objDa.Fill(dt);
                }
            }

            return dt.Rows[0]["Result"].ToString(); ;
        }
    }
}