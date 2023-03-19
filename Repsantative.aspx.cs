using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Web.View_Form
{
    public partial class Repsantative : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Click(object sender, EventArgs e)
        {
            String user = (String)Session["USER"];
            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection Conn = new SqlConnection(connStr);
            String query = "Select * from upcomingMatchesOfClub(@ClubName)";
            String QueryName = "Select C.name from Club C INNER JOIN ClubRepresentive R ON C.Club_RID=R.ID Where @USER=R.Username";
            SqlCommand cmd = new SqlCommand(QueryName, Conn);
            cmd.Parameters.Add("@USER", SqlDbType.VarChar).Value = user;


            SqlCommand command = new SqlCommand(query, Conn);
            command.CommandType = CommandType.Text;
            Conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0);
                command.Parameters.AddWithValue("@ClubName", name);
            }
            reader.Close();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            Conn.Close();
            GridView4.DataSource = data;
            GridView4.DataBind();
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = Calendar1.SelectedDate;


            if (selectedDate != null)
            {
                Session["date"] = selectedDate;
                String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
                SqlConnection Conn = new SqlConnection(connStr);
                String query = "Select * from viewAvailableStadiumsOn(@date)";
                SqlCommand command = new SqlCommand(query, Conn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@date", selectedDate);
                Conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable data = new DataTable();
                adapter.Fill(data);
                Conn.Close();
                GridView3.DataSource = data;
                GridView3.DataBind();
            }
            else
            {
                Response.Write("Select A date");
            }
        }
        protected void Send(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int index = row.RowIndex;
            String USER=(String)Session["USER"];
            string StadiumNam = GridView3.DataKeys[index]["name"].ToString();
            DateTime time = (DateTime)Session["date"];
            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection Conn = new SqlConnection(connStr);
            String QueryName = "Select C.name from Club C INNER JOIN ClubRepresentive R ON C.Club_RID=R.ID Where @USER=R.Username";
            SqlCommand cmd = new SqlCommand(QueryName, Conn);
            cmd.Parameters.Add("@USER", SqlDbType.VarChar).Value = USER;
            String Query = "Exec addHostRequest @Clubname, @Stadium_name, @Z";
            SqlCommand command = new SqlCommand(Query, Conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Z", time);
            command.Parameters.AddWithValue("@Stadium_name", StadiumNam);


            String printOutput = "";
            
            Conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) =>
            {
                printOutput += e1.Message;
            };

            Conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0);
                // Do something with the name
                command.Parameters.AddWithValue("@Clubname", name);
            }
            reader.Close(); 
            command.ExecuteNonQuery();
            if (printOutput == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Request Sent');window.location = 'Repsantative.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + printOutput + "');window.location = 'Repsantative.aspx';", true);
            }
            Conn.Close();
        }
        protected void LogOut(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}