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
    public partial class register : System.Web.UI.Page
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

        protected void Register_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblSuccess.Text = "";
            string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Profile WHERE Email = @user"; // Is this an existing user?
            cmd.Parameters.AddWithValue("@User", email.Value);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            int numRowsEmail = Convert.ToInt32(dt.Rows.Count.ToString());
            if (numRowsEmail == 0)
            {
                if (pass.Value == cpass.Value) // password values match; keep going
                {
                    SqlCommand cmdRegister = conn.CreateCommand();
                    cmdRegister.CommandType = CommandType.Text;
                    cmdRegister.CommandText = "INSERT INTO Profile (Email, FullName, Password) VALUES (@email, @fullname, @pwd)";
                    cmdRegister.Parameters.AddWithValue("@email", email.Value.Trim());
                    cmdRegister.Parameters.AddWithValue("@fullname", fullname.Value.Trim());
                    cmdRegister.Parameters.AddWithValue("@pwd", Encrypt(pass.Value.Trim()));
                    cmdRegister.ExecuteNonQuery();
                    cpass.Value = pass.Value = email.Value = fullname.Value = "";
                    lblSuccess.Text = "SUCCESS! Thank you for registering! You may now log in.";
                }
                else // mismatched pwd values; write reject msg
                {
                    lblError.Text = "Your passwords do not match; please try again!";
                }
            }
            else // email exists; write reject msg
            {
                lblError.Text = "This email address has already been registered. Please try again with a different address.";
            }
            conn.Close();
        }
    }
}