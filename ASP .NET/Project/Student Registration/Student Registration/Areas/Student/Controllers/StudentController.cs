using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Student_Registration.Areas.Student.Models;

namespace Student_Registration.Areas.Student.Controllers
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
                model.BranchID = (int)dt.Rows[0]["BranchID"];//done
                model.SelectedCityId = (int)dt.Rows[0]["CityID"];//done
                model.StudentName = (string)dt.Rows[0]["StudentName"];//done
                model.MobileNoStudent = (string)dt.Rows[0]["MobileNoStudent"];//done
                model.EmailAddress = (string)dt.Rows[0]["Email"];//done
                model.MobileNoFather = (string)dt.Rows[0]["MobileNoFather"];//done
                model.Address = (string)dt.Rows[0]["Address"];//done
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
            }
            else
            {
                cmd.CommandText = "PR_MST_Student_UpdateByPK";
                cmd.Parameters.AddWithValue("@StudentID", sm.StudentID);
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
    }
}
