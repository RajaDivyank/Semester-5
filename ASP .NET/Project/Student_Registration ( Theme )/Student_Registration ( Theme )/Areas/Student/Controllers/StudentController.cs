using Microsoft.AspNetCore.Mvc;
using Student_Registration___Theme__.Areas.Student.Models;
using System.Data;
using System.Data.SqlClient;

namespace Student_Registration___Theme__.Areas.Student.Controllers
{
    [Area("Student")]
    public class StudentController : Controller
    {
        private readonly IConfiguration _configuration;
        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult StudentView()
        {
            string connectionString = this._configuration.GetConnectionString("myConnectionString");
            SqlConnection conn = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_MST_Student_SelectAll";
            SqlDataReader objDataReader = cmd.ExecuteReader();
            dt.Load(objDataReader);
            return View(dt);
        }
        public IActionResult DeleteStudent(int id)
        {
            string connectionString = this._configuration.GetConnectionString("myConnectionString");
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_MST_Student_DeleteByStudentID";
            cmd.Parameters.AddWithValue("@StudentID", id);
            int rowsAffected = cmd.ExecuteNonQuery();

            return RedirectToAction("StudentView");
        }

        public IActionResult StudentAddEdit(int? id)
        {
            string connectionString = this._configuration.GetConnectionString("myConnectionString");
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select CityID,CityName from LOC_City";
            List<CityModel> list = new List<CityModel>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    CityModel city = new CityModel();
                    {
                        city.CityId = Convert.ToInt32(reader["CityID"]);
                        city.CityName = reader["CityName"].ToString();
                    };
                    list.Add(city);
                }
            }
            conn.Close();
            StudentModel model = new StudentModel();
            model.Cities = list;

            conn.Open();
            SqlCommand cmd2 = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select BranchID,BranchName from MST_Branch";
            List<BranchModel> list2 = new List<BranchModel>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    BranchModel branch = new BranchModel();
                    {
                        branch.BranchID = Convert.ToInt32(reader["BranchID"]);
                        branch.BranchName = reader["BranchName"].ToString();
                    };
                    list2.Add(branch);
                }
            }
            conn.Close();
            model.Branches = list2;
            if (id != null)
            {
                conn.Open();
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "PR_MST_Student_GetStudentByID";
                cmd1.Parameters.AddWithValue("@StudentID", id);
                SqlDataReader sqlDataReader = cmd1.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sqlDataReader);
                conn.Close();
                model.StudentID = id;
                model.BranchID = (int)dt.Rows[0]["BranchID"];
                model.SelectedCityId = (int)dt.Rows[0]["CityID"];
                model.StudentName = (string)dt.Rows[0]["StudentName"];
                model.MobileNoStudent = (string)dt.Rows[0]["MobileNoStudent"];
                model.EmailAddress = (string)dt.Rows[0]["Email"];
                model.MobileNoFather = (string)dt.Rows[0]["MobileNoFather"];
                model.Address = (string)dt.Rows[0]["Address"];
                model.BirthDate = (DateTime)dt.Rows[0]["BirthDate"];
                model.IsActive = (bool)dt.Rows[0]["IsActive"];
                model.Gender = (string)dt.Rows[0]["Gender"];
                model.Password = (string)dt.Rows[0]["Password"];
            }
            return View(model);
        }
        public IActionResult Save(StudentModel sm)
        {
            string str = this._configuration.GetConnectionString("myConnectionString");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            if (sm.StudentID == null)
            {
                cmd.CommandText = "PR_MST_Student_Insert";
                TempData["Message"] = "Record Inserted Successfully";
            }
            else
            {
                cmd.CommandText = "PR_MST_Student_UpdateByPK";
                cmd.Parameters.AddWithValue("@StudentID", sm.StudentID);
                TempData["Message"] = "Record Updated Successfully";
            }
            cmd.Parameters.AddWithValue("@BranchID", sm.BranchID);
            cmd.Parameters.AddWithValue("@CityID", sm.SelectedCityId);
            cmd.Parameters.AddWithValue("@StudentName", sm.StudentName);
            cmd.Parameters.AddWithValue("@MobileNoStudent", sm.MobileNoStudent);
            cmd.Parameters.AddWithValue("@Email", sm.EmailAddress);
            cmd.Parameters.AddWithValue("@MobileNoFather", sm.MobileNoFather);
            cmd.Parameters.AddWithValue("@Address", sm.Address);
            cmd.Parameters.AddWithValue("@BirthDate", sm.BirthDate);
            cmd.Parameters.AddWithValue("@IsActive", 1);
            cmd.Parameters.AddWithValue("@Gender", sm.Gender);
            cmd.Parameters.AddWithValue("@Password", sm.Password);
            cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("StudentView");
        }

        public IActionResult StudentFilter(string StudentName, string BranchName, string CityName, string Gender)
        {
            string str = _configuration.GetConnectionString("myConnectionString");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_MST_Student_Filter";
            cmd.Parameters.AddWithValue("@CityName", CityName);
            cmd.Parameters.AddWithValue("@BranchName", BranchName);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@StudentName", StudentName);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dr);
            conn.Close();
            return View("StudentView", dataTable);
        }
    }
}
