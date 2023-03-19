using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Web.Registration_Form
{
    public partial class StadiumR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GET(object sender, EventArgs e)
        {
           

            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection Conn = new SqlConnection(connStr);

            String User = username.Text;
            String Name = name.Text;
            String Pass = password.Text;
            String stadium = Stadium.Text;
            String printOutput = "";
            if (username.Text == "" || name.Text == "" || password.Text == "" || Stadium.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('One of the fields is empty');window.location = 'StadiumR.aspx';", true);
            }
            Conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) =>
                {
                    printOutput += e1.Message;
                };
            SqlCommand Adds = new SqlCommand("addStadiumManager", Conn);
            Adds.CommandType = System.Data.CommandType.StoredProcedure;
            Adds.Parameters.Add(new SqlParameter("@username", User));
            Adds.Parameters.Add(new SqlParameter("@name", Name));
            Adds.Parameters.Add(new SqlParameter("@Password", Pass));
            Adds.Parameters.Add(new SqlParameter("@stadium_name",stadium));
            Conn.Open();
            Adds.ExecuteNonQuery();
            if (printOutput == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Registration Success');window.location = 'login.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + printOutput + "');window.location = 'StadiumR.aspx';", true);
            }
            Conn.Close();

        }

    }
}