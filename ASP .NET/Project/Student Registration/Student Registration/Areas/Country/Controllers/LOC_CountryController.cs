﻿using Microsoft.AspNetCore.Mvc;
using Student_Registration.Areas.Country.Models;
using System.Data;
using System.Data.SqlClient;

namespace Student_Registration.Areas.Country.Controllers
{
	[Area("Country")]
	public class LOC_CountryController : Controller
	{
		private readonly IConfiguration _configuration;
		public LOC_CountryController(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public IActionResult CountryList()
		{
			String connectionStr = this._configuration.GetConnectionString("myConnectionString");
			DataTable dt = new DataTable();
			SqlConnection conn = new SqlConnection(connectionStr);
			conn.Open();
			SqlCommand objCmd = conn.CreateCommand();
			objCmd.CommandType = CommandType.StoredProcedure;
			objCmd.CommandText = "PR_Country_SelectAll";
			SqlDataReader objDataReader = objCmd.ExecuteReader();
			dt.Load(objDataReader);
			conn.Close();
			return View("CountryList" , dt);
		}
        public IActionResult DeleteCountry(int id)
        {
            try
            {
                String connectionStr = this._configuration.GetConnectionString("myConnectionString");
                SqlConnection conn = new SqlConnection(connectionStr);
                conn.Open();
                SqlCommand objCmd = conn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Country_DeleteByPK"; // Assuming you have a stored procedure for deleting a country
                objCmd.Parameters.AddWithValue("@CountryID", id);
                int rowsAffected = objCmd.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                {
                    // Successful deletion
                    return RedirectToAction("CountryList");
                }
                else
                {
                    // Deletion failed
                    // You can handle this scenario according to your application's requirements
                    return RedirectToAction("CountryList"); // Redirect back to the list view
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                // You can log the exception, show an error message, or redirect to an error page
                return RedirectToAction("CountryList"); // Redirect back to the list view
            }
        }
        public IActionResult CountryAdd(int? id)
        {
            if (id != null)
            {
                String connectionStr = this._configuration.GetConnectionString("myConnectionString");
                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(connectionStr);
                conn.Open();
                SqlCommand objCmd = conn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Country_SelectByPK";
                objCmd.Parameters.AddWithValue("@CountryID", id);
                SqlDataReader objDataReader = objCmd.ExecuteReader();
                dt.Load(objDataReader);
                conn.Close();
                LOC_CountryModel cm = new LOC_CountryModel();
                cm.CountryID = id;
                cm.CountryName = (string)dt.Rows[0]["CountryName"];
                cm.CountryCode = (string)dt.Rows[0]["CountryCode"];
                try
                {
                    cm.Created = (DateTime)dt.Rows[0]["Created"];
                    cm.Modified = (DateTime)dt.Rows[0]["Modified"];
                }
                catch { }
                return View(cm);
            }
            else
            {
                return View();
            }

        }
        public IActionResult AddCountry(LOC_CountryModel cm)
        {
            try
            {
                if (cm.CountryID == null)
                {
                    String connectionStr = this._configuration.GetConnectionString("myConnectionString");
                    SqlConnection conn = new SqlConnection(connectionStr);
                    conn.Open();
                    SqlCommand objCmd = conn.CreateCommand();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Country_Insert_Record";
                    objCmd.Parameters.AddWithValue("@CountryName", cm.CountryName);
                    objCmd.Parameters.AddWithValue("@CountryCode", cm.CountryCode);
                    if (cm.Created != null) { objCmd.Parameters.AddWithValue("@Created", cm.Created); }
                    if (cm.Modified != null) { objCmd.Parameters.AddWithValue("@Modified", cm.Modified); }
                    int rowsAffected = objCmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        // Successful deletion
                        return RedirectToAction("CountryList");
                    }
                    else
                    {
                        // Deletion failed
                        // You can handle this scenario according to your application's requirements
                        return RedirectToAction("CountryList"); // Redirect back to the list view
                    }
                }
                else
                {
                    String connectionStr = this._configuration.GetConnectionString("myConnectionString");
                    SqlConnection conn = new SqlConnection(connectionStr);
                    conn.Open();
                    SqlCommand objCmd = conn.CreateCommand();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Country_UpdateByPK";
                    objCmd.Parameters.AddWithValue("@CountryID", cm.CountryID);
                    objCmd.Parameters.AddWithValue("@CountryName", cm.CountryName);
                    objCmd.Parameters.AddWithValue("@CountryCode", cm.CountryCode);
                    if (cm.Created != null) { objCmd.Parameters.AddWithValue("@Created", cm.Created); }
                    if (cm.Modified != null) { objCmd.Parameters.AddWithValue("@Modified", cm.Modified); }
                    int rowsAffected = objCmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                // You can log the exception, show an error message, or redirect to an error page
                return RedirectToAction("CountryList"); // Redirect back to the list view
            }
            return RedirectToAction("CountryList");
        }

    }
}