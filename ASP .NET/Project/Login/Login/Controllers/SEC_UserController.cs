using Login.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace Login.Controllers
{
    public class SEC_UserController : Controller
    {
        private readonly IConfiguration _configuration;
        public SEC_UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            string ErrorMsg = string.Empty;
            if (string.IsNullOrEmpty(userLoginModel.LoginName))
            {
                ErrorMsg += "User Name is Required";
            }
            if (string.IsNullOrEmpty(userLoginModel.LoginPassword))
            {
                ErrorMsg += "<br/>Password is Required";
            }
            if(ModelState.IsValid)
 {
                SqlConnection conn = new
               SqlConnection(this._configuration.GetConnectionString("myConnectionString"));

                conn.Open();
                SqlCommand objCmd = conn.CreateCommand();
                objCmd.CommandType = System.Data.CommandType.StoredProcedure;
                /*objCmd.CommandText = "PR_SEC_User_Login";*/
                objCmd.Parameters.AddWithValue("@UserName", userLoginModel.LoginName);
                objCmd.Parameters.AddWithValue("@Password", userLoginModel.LoginPassword);
                SqlDataReader objSDR = objCmd.ExecuteReader();
                DataTable dtLogin = new DataTable();

                if (!objSDR.HasRows)
                {
                    TempData["ErrorMessage"] = "Invalid User Name or Password";
                    return RedirectToAction("Index", "SEC_User");
                }
                else
                {
                    dtLogin.Load(objSDR);
                    //Load the retrived data to session through HttpContext.
                    foreach (DataRow dr in dtLogin.Rows)
                    {
                        HttpContext.Session.SetString("LoginId", dr["LoginId"].ToString());
                        HttpContext.Session.SetString("LoginName", dr["LoginName"].ToString());
                        HttpContext.Session.SetString("LoginPassword", dr["LoginPassword"].ToString());

                    }
                    return RedirectToAction("Index", "Home");
                }
            }
 else
            {
                TempData["ErrorMessage"] = ErrorMsg;
                return RedirectToAction("Index", "SEC_User");
            }

        }
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
