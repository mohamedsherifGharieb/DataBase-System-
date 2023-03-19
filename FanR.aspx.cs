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
    public partial class FanR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SUB(object sender, EventArgs e)
        {
            DateTime Birthdate = Calendar1.SelectedDate;
            String printOutput = "";
            if (username.Text == "" || name.Text == "" || password.Text == "" || national.Text == "" || phone.Text == "" || address.Text == "" || Birthdate == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('One of the fields is empty');window.location = 'FanR.aspx';", true);
            }
            else {
                String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
                SqlConnection Conn = new SqlConnection(connStr);

                String User = username.Text;
                String Name = name.Text;
                String pass = password.Text;
                String National = national.Text;
                String Phone = phone.Text;
                String Address = address.Text;

                Conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) =>
                {
                    printOutput += e1.Message;
                };

                SqlCommand AddF = new SqlCommand("AddFan", Conn);
                AddF.CommandType = System.Data.CommandType.StoredProcedure;
                AddF.Parameters.Add(new SqlParameter("@username", User));
                AddF.Parameters.Add(new SqlParameter("@name", Name));
                AddF.Parameters.Add(new SqlParameter("@password", pass));
                AddF.Parameters.Add(new SqlParameter("@date", Birthdate));
                AddF.Parameters.Add(new SqlParameter("@phone", Phone));
                AddF.Parameters.Add(new SqlParameter("@address", Address));
                AddF.Parameters.Add(new SqlParameter("@nationalID", National));

                Conn.Open();
                AddF.ExecuteNonQuery();
                if (printOutput == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Registration Success');window.location = 'login.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + printOutput + "');window.location = 'FanR.aspx';", true);
                }
                Conn.Close();
            }
            
        }
    }
}