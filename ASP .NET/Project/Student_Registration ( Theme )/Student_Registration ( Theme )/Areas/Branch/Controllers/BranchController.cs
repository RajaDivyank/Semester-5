using Microsoft.AspNetCore.Mvc;
using Student_Registration___Theme__.Areas.Branch.Models;
using System.Data.SqlClient;
using System.Data;

namespace Student_Registration___Theme__.Areas.Branch.Controllers
{
    [Area("Branch")]
    public class BranchController : Controller
    {
        private readonly IConfiguration _configuration;
        public BranchController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult BranchList()
        {
            try
            {
                string connectionStr = this._configuration.GetConnectionString("myConnectionString");

                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    conn.Open();

                    using (SqlCommand objCmd = new SqlCommand())
                    {
                        objCmd.Connection = conn;
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_MST_Branch_SelectAll";

                        using (SqlDataReader objDataReader = objCmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(objDataReader);

                            return View(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult DeleteBranch(int id)
        {
            string connectionString = this._configuration.GetConnectionString("myConnectionString");
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "PR_MST_Branch_DeleteByBranchID";
            sqlCommand.Parameters.AddWithValue("@BranchID", id);
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("BranchList");
        }
        public IActionResult SelectById(int? id)
        {
            if (id == null)
            {
                return View();

            }
            else
            {
                string connectionString = this._configuration.GetConnectionString("myConnectionString");
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_MST_Branch_SelectByBranchID";
                cmd.Parameters.AddWithValue("@branchID", id);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                BranchModel model = new BranchModel();
                model.Id = id;
                model.BranchName = (string)dataTable.Rows[0]["BranchName"];
                model.BranchCode = (string)dataTable.Rows[0]["BranchCode"];
                model.Created = (DateTime)dataTable.Rows[0]["Created"];
                model.Modified = (DateTime)dataTable.Rows[0]["Modified"];
                return View(model);
            }

        }
        public IActionResult AddEditBranch(BranchModel bm)
        {
            try
            {
                string connectionString = this._configuration.GetConnectionString("myConnectionString");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (bm.Id == null)
                        {
                            cmd.CommandText = "PR_MST_Branch_Insert";
                        }
                        else
                        {
                            cmd.CommandText = "PR_MST_Branch_UpdateByBranchID";
                            cmd.Parameters.AddWithValue("@BranchID", bm.Id);
                        }

                        cmd.Parameters.AddWithValue("@BranchName", bm.BranchName);
                        cmd.Parameters.AddWithValue("@BranchCode", bm.BranchCode);

                        if (bm.Created != null) { cmd.Parameters.AddWithValue("@Created", bm.Created); }
                        if (bm.Modified != null) { cmd.Parameters.AddWithValue("@Modified", bm.Modified); }

                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }

                return RedirectToAction("BranchList");
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, and return an appropriate response.
                // For example:
                // Log.Error("An error occurred: " + ex.Message);
                // Return a view with an error message.
                return RedirectToAction("BranchList");
            }
        }
        public IActionResult BranchFilter(string BranchName, string BranchCode)
        {
            String connectionStr = this._configuration.GetConnectionString("myConnectionString");
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connectionStr);
            conn.Open();
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_MST_Branch_Filter";
            objCmd.Parameters.AddWithValue("@BranchName", BranchName);
            objCmd.Parameters.AddWithValue("@BranchCode", BranchCode);
            SqlDataReader objDataReader = objCmd.ExecuteReader();
            dt.Load(objDataReader);
            conn.Close();
            return View("BranchList", dt);
        }
    }
}
