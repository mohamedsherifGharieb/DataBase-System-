using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.View_Form
{
    public partial class Stadium_Manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void View(object sender, EventArgs e)
        {
            String user = (String)Session["USER"];
            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection Conn = new SqlConnection(connStr);
            String Query = "Select * from allPendingRequests(@User)";
            
            SqlCommand command = new SqlCommand(Query, Conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@User", user);
            Conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            Conn.Close();
            GridView2.DataSource = data;
            GridView2.DataBind();
        }

        protected void Accept_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int index = row.RowIndex;
            string Host = GridView2.DataKeys[index]["Host"].ToString();
            string Guest = GridView2.DataKeys[index]["Guest"].ToString();
            DateTime Time = (DateTime)GridView2.DataKeys[index]["StartTime"];
            String user = (String)Session["USER"];
            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection Conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("acceptRequest", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@StadiumManger", user));
            command.Parameters.Add(new SqlParameter("@HostC", Host));
            command.Parameters.Add(new SqlParameter("@GuestC", Guest));
            command.Parameters.Add(new SqlParameter("@Z",Time));


            String printOutput = "";

            Conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) =>
            {
                printOutput += e1.Message;
            };


            Conn.Open();
            command.ExecuteNonQuery();
            if (printOutput == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Request Accepted');window.location = 'Stadium_Manager.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + printOutput + "');window.location = 'Stadium_Manager.aspx';", true);
            }
            Conn.Close();
        }

        protected void Reject_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int index = row.RowIndex;
            string Host = GridView2.DataKeys[index]["Host"].ToString();
            string Guest = GridView2.DataKeys[index]["Guest"].ToString();
            DateTime Time = (DateTime)GridView2.DataKeys[index]["StartTime"];
            String user = (String)Session["USER"];
            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection Conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("rejectRequest", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@StadiumManger", user));
            command.Parameters.Add(new SqlParameter("@HostC", Host));
            command.Parameters.Add(new SqlParameter("@GuestC", Guest));
            command.Parameters.Add(new SqlParameter("@Z", Time));

            String printOutput = "";

            Conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) =>
            {
                printOutput += e1.Message;
            };

            Conn.Open();
            command.ExecuteNonQuery();
            if (printOutput == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Request Rejected');window.location = 'Stadium_Manager.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + printOutput + "');window.location = 'Stadium_Manager.aspx';", true);
            }
            Conn.Close(); ;
        }
        protected void LogOut(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }


    }
}