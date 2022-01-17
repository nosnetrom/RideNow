using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RideNow.admin
{
    public partial class addcar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddCar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            string path = Server.MapPath("/images/");
            if (FileUpload.HasFile)
            {
                FileInfo fi = new FileInfo(FileUpload.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".gif")
                {
                    string filename = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + FileUpload.FileName;
                    FileUpload.SaveAs(path + filename);
                    string photopath = "/images/" + filename;
                    string connStr = ConfigurationManager.ConnectionStrings["RideNowConnStr"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO Cars (ModelName, BrandName, Year, Descr, Amt, ShowType, PhotoPath)";
                    cmd.CommandText += " VALUES (@modelname, @brandname, @year, @descr, @amt, @showtype, @photopath)";
                    cmd.Parameters.AddWithValue("@modelname", modelname.Value);
                    cmd.Parameters.AddWithValue("@brandname", brandname.Value);
                    cmd.Parameters.AddWithValue("@year", year.Value);
                    cmd.Parameters.AddWithValue("@descr", description.Value);
                    cmd.Parameters.AddWithValue("@amt", numInStock.Value);
                    cmd.Parameters.AddWithValue("@showtype", salestype.Value);
                    cmd.Parameters.AddWithValue("@photopath", photopath);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("carinfo.aspx");
                }
                else
                {
                    lblError.Text = "Incorrect image format; use only .JPG, .PNG, or .GIF images.";
                }
            }
            else
            {
                lblError.Text = "An image is required for this form!";
            }
        }
    }
}