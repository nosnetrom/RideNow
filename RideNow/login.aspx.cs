using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RideNow
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }

        }


        protected void LogIn_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM Profile WHERE Email = @user AND Password = @password";
            cmd.Parameters.AddWithValue("@user", email.Value.Trim());
            cmd.Parameters.AddWithValue("@password", Encrypt(pass.Value.Trim()));
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            int numRows = Convert.ToInt32(dt.Rows.Count.ToString());
            if (numRows == 1)
            {
                string strRedirect;
                SqlDataReader rdr;
                SqlConnection connSession = new SqlConnection(connStr);
                connSession.Open();
                SqlCommand cmdSession = new SqlCommand("SELECT * FROM Profile WHERE Email = @user AND Password = @password", connSession);
                cmdSession.Parameters.AddWithValue("@user", email.Value.Trim());
                cmdSession.Parameters.AddWithValue("@password", Encrypt(pass.Value.Trim()));
                rdr = cmdSession.ExecuteReader();
                rdr.Read();
                string role = Convert.ToString(rdr["Role"]);
                Session["FullName"] = Convert.ToString(rdr["FullName"]);
                rdr.Close();
                if (role == "Admin")
                {
                    Session["userName"] = email.Value;
                    Session["type"] = "Admin";
                    strRedirect = "/admin/index.aspx";
                }
                else if (role == "User")
                {
                    Session["userName"] = email.Value;
                    Session["type"] = "User";
                    strRedirect = "/user/index.aspx";
                }
                else
                {
                    // other user types to be handled in the future
                    strRedirect = "/index.aspx";
                }
                connSession.Close();
                conn.Close();
                Response.Redirect(strRedirect);
            }
            else
            {
                conn.Close();
                lblError.Text = "No such email/password combination found; please try again."; // No user found
            }
        }
    }
}