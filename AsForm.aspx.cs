using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Xml.Linq;
using System.Security.Principal;

namespace Web.View_Form
{

    public partial class AsForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            String query = "Select * from clubsNeverMatched";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(reader);

            conn.Close();
            GridView5.DataSource = data;
            GridView5.DataBind();

        }

 

        protected void AddM(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection Conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("addNewMatch", Conn);
            command.CommandType = CommandType.StoredProcedure;
            String hostA = HostA.Text;
            String guestA = GuestA.Text;
            String stA = StA.Text;
            String etA = EtA.Text;
            DateTime dateTime;
            DateTime dateTime2;
            String printOutput = "";
            if (HostA.Text == "" || GuestA.Text == "" || StA.Text == "" || EtA.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('One of the fields is empty');window.location = 'AsForm.aspx';", true);
            }
            Conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) =>
            {
                printOutput += e1.Message;
            };

            if (DateTime.TryParse(stA, out dateTime))
            {

                if (DateTime.TryParse(etA, out dateTime2))
                {
                    command.Parameters.Add(new SqlParameter("@FirstClub", hostA));
                    command.Parameters.Add(new SqlParameter("@SecClub", guestA));
                    command.Parameters.Add(new SqlParameter("@Date", dateTime));
                    command.Parameters.Add(new SqlParameter("@End", dateTime2));

                    Conn.Open();
                    command.ExecuteNonQuery();
                    if (printOutput == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Match Added');window.location = 'AsForm.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + printOutput + "');window.location = 'AsForm.aspx';", true);
                    }
                    Conn.Close();
                }
                else
                {
                    Response.Write("Invalid EndDate");
                }
            }
            else
            {
                Response.Write("Invalid Startdate");
            }
        }
        protected void DelM(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection Conn = new SqlConnection(connStr);
            SqlCommand command = new SqlCommand("deleteMatch", Conn);
            command.CommandType = CommandType.StoredProcedure;
            String hostA = HostD.Text;
            String guestA = GuestD.Text;
            String stA = StD.Text;
            String etA = EtD.Text;
            DateTime dateTime;
            DateTime dateTime2;
            String printOutput = "";
            if (HostD.Text == "" || GuestD.Text == "" || StD.Text == "" || EtD.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('One of the fields is empty');window.location = 'AsForm.aspx';", true);
            }
            Conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) =>
            {
                printOutput += e1.Message;
            };
            if (DateTime.TryParse(stA, out dateTime))
            {

                if (DateTime.TryParse(etA, out dateTime2))
                {
                    command.Parameters.Add(new SqlParameter("@Fname", hostA));
                    command.Parameters.Add(new SqlParameter("@Sname", guestA));
                  

                    Conn.Open();
                    command.ExecuteNonQuery();
                    if (printOutput == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('MatchDeleted');window.location = 'AsForm.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + printOutput + "');window.location = 'AsForm.aspx';", true);
                    }
                    Conn.Close();
                }
                else
                {
                    Response.Write("Invalid EndDate");
                }
            }
            else
            {
                Response.Write("Invalid Startdate");
            }

        }

        protected void Click(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();
    
            String query = "Select * from allMatches Where StartTime>CURRENT_TIMESTAMP";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(reader);
            conn.Close();
            GridView7.DataSource = data;
            GridView7.DataBind();


        }
        protected void Click2(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
          conn.Open();

            String query = "Select * from allMatches Where StartTime<CURRENT_TIMESTAMP";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();
         DataTable data = new DataTable();
            data.Load(reader);

            conn.Close();
            GridView6.DataSource = data;
            GridView6.DataBind();

        }
        protected void LogOut(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}


