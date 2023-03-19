using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.EnterpriseServices;
using System.Drawing.Printing;

namespace Web.Registration_Form
{
    public partial class AssManagerR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SUB(object sender, EventArgs e)
        {
            
            String printOutput = "";
            if (Username.Text == "" || Name.Text == "" || Password.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('One of the fields is empty');window.location = 'AssManagerR.aspx';", true);
            }
            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection Conn = new SqlConnection(connStr);
            Conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) =>
            {
                printOutput += e1.Message;
            };

            String User = Username.Text;
            String name = Name.Text;
            String pass = Password.Text;

            SqlCommand AddAs = new SqlCommand("addAssociationManager", Conn);
            AddAs.CommandType = System.Data.CommandType.StoredProcedure;
            AddAs.Parameters.Add(new SqlParameter("@username", User));
            AddAs.Parameters.Add(new SqlParameter("@name", name));
            AddAs.Parameters.Add(new SqlParameter("@Password", pass));
            Conn.Open();
            AddAs.ExecuteNonQuery();
            if (printOutput == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Registration Success');window.location = 'login.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + printOutput + "');window.location = 'AssManagerR.aspx';", true);
            }
            Conn.Close();
        }
    }
}