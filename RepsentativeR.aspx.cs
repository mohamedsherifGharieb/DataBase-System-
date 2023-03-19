using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Registration_Form
{
    public partial class RepsentativeR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SUB(object sender, EventArgs e)
        {
            
            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection Conn = new SqlConnection(connStr);

            String User = Username.Text;
            String name = Name.Text;
            String pass = Password.Text;
            String club = Club.Text;
            String printOutput = "";
            if (Username.Text == "" || Name.Text == "" || Password.Text == "" || Club.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('One of the fields is empty');window.location = 'RepsentativeR.aspx';", true);
            }
            Conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) =>
            {
                printOutput += e1.Message;
            };
            SqlCommand AddR = new SqlCommand("addRepresentative", Conn);
            AddR.CommandType = System.Data.CommandType.StoredProcedure;
            AddR.Parameters.Add(new SqlParameter("@username", User));
            AddR.Parameters.Add(new SqlParameter("@name", name));
            AddR.Parameters.Add(new SqlParameter("@Password", pass));
            AddR.Parameters.Add(new SqlParameter("@Cname", club));

            Conn.Open();
            AddR.ExecuteNonQuery();
            if (printOutput == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Registration Success');window.location = 'login.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + printOutput + "');window.location = 'RepsentativeR.aspx';", true);
            }
            Conn.Close();
        }
    }
}
