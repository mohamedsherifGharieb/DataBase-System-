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
    public partial class FanPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = Calendar1.SelectedDate;
            if (selectedDate != null)
            {
                Session["date"] = selectedDate;
                String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
                SqlConnection Conn = new SqlConnection(connStr);
                String Query= "Select * from availableMatchesToAttend(@Date)";
                SqlCommand command = new SqlCommand(Query, Conn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Date", selectedDate);
                Conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable data = new DataTable();
                adapter.Fill(data);
                Conn.Close();
                GridView1.DataSource = data;
                GridView1.DataBind();
            }
            else
            {
                Response.Write("Select A date");
            }
        }

        protected void Select(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int index = row.RowIndex;
            string host = GridView1.DataKeys[index]["Host"].ToString();
            string guest = GridView1.DataKeys[index]["Guest"].ToString();
            String USER = Session["user"].ToString();
            String Query = "Select NationalID  From Fan Where Username=@user";
            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            DateTime time = (DateTime)Session["date"];
            SqlConnection Conn = new SqlConnection(connStr);

            String printOutput = "";
            Conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) =>
            {
                printOutput += e1.Message;
            };

            SqlCommand command = new SqlCommand("purchaseTicket", Conn);
            SqlCommand command2 = new SqlCommand(Query, Conn);
            command2.CommandType = CommandType.Text;
            command2.Parameters.AddWithValue("@user", USER); 
            command.CommandType=CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@HostC", host));
            command.Parameters.Add(new SqlParameter("@GuestC", guest));
            command.Parameters.Add(new SqlParameter("@Date",time));
            Conn.Open();
            String ID = (String)command2.ExecuteScalar();
            command.Parameters.Add(new SqlParameter("@Fan", ID));
            command.ExecuteNonQuery();
            if (printOutput == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('TicketPurchasedSuccess');window.location = 'FanPage.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + printOutput + "');window.location = 'FanPage.aspx';", true);
            }
            Conn.Close();
        }
        protected void LogOut(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }

}