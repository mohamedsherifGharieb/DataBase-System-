using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Web.Registration_Form;

namespace Web.View_Form
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
           }
        protected void UnBlockFan(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection Conn = new SqlConnection(connStr);
            String printOutput = "";
            if (Block.Text == "")
            {
                Response.Write("NationalID is Missing");
            }
            String User = UnBlock.Text;
            SqlCommand block = new SqlCommand("unblockFan", Conn);

            block.CommandType = System.Data.CommandType.StoredProcedure;

            block.Parameters.Add(new SqlParameter("@NationalID", User));
            Conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) =>
            {
                printOutput += e1.Message;
            };

            Conn.Open();
            block.ExecuteNonQuery();
            if (printOutput == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FanUNBlocked');window.location = 'Admin.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + printOutput + "');window.location = 'Admin.aspx';", true);
            }
            Conn.Close();
        }
        protected void BlockFan(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection Conn = new SqlConnection(connStr);
            String printOutput = "";
            if (Block.Text == "")
            {
                Response.Write("NationalID is Missing");
            }
            String User = Block.Text;
            SqlCommand block = new SqlCommand("blockFan", Conn);

            block.CommandType = System.Data.CommandType.StoredProcedure;

            block.Parameters.Add(new SqlParameter("@NationalID", User)); 
            Conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) =>
            {
                printOutput += e1.Message;
            };

            Conn.Open();
            block.ExecuteNonQuery();
            if (printOutput == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FanBlocked');window.location = 'Admin.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + printOutput + "');window.location = 'Admin.aspx';", true);
            }
            Conn.Close();

        }
        protected void DeleteS(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection Conn = new SqlConnection(connStr);
            String printOutput = "";
            if (Delete1.Text == "")
            {
                Response.Write("Stadium is Missing");
            }

            String User = Delete1.Text;
            SqlCommand DelS = new SqlCommand("deleteStadium", Conn);

            DelS.CommandType = System.Data.CommandType.StoredProcedure;

            DelS.Parameters.Add(new SqlParameter("@name", User));
            Conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) =>
            {
                printOutput += e1.Message;
            };
            Conn.Open();
            DelS.ExecuteNonQuery();
            if (printOutput == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Deleted');window.location = 'Admin.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + printOutput + "');window.location = 'Admin.aspx';", true);
            }
            Conn.Close();


        }
        protected void AddS(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection Conn = new SqlConnection(connStr);

            String NAME = ADD1.Text;
            String loc = location.Text;
            String Capacity = Cap.Text;
            SqlCommand ADDS = new SqlCommand("addStadium", Conn); 
            String printOutput = "";
            if (ADD1.Text == "" || location.Text == ""|| Cap.Text == "")
            {
                Response.Write("one if the Fields is Missing");
            }
            Conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) =>
            {
                printOutput += e1.Message;
            };
            ADDS.CommandType = System.Data.CommandType.StoredProcedure;
            ADDS.Parameters.Add(new SqlParameter("@name", NAME));
            ADDS.Parameters.Add(new SqlParameter("@location", loc));
            ADDS.Parameters.Add(new SqlParameter("@Capcity", Capacity));
            Conn.Open();
            ADDS.ExecuteNonQuery();
            if (printOutput == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Stadium added');window.location = 'Admin.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + printOutput + "');window.location = 'Admin.aspx';", true);
            }
            Conn.Close();

        }
        protected void AddC(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection Conn = new SqlConnection(connStr);

            String Club = Add.Text;
            String location = LocationAdd.Text;
            String printOutput = "";
            if (Add.Text == "" || LocationAdd.Text == "")
            {
                Response.Write("one if the Fields is Missing");
            }
            Conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) =>
            {
                printOutput += e1.Message;
            };

            SqlCommand ADDS = new SqlCommand("addClub", Conn);

            ADDS.CommandType = System.Data.CommandType.StoredProcedure;

            ADDS.Parameters.Add(new SqlParameter("@name", Club));
            ADDS.Parameters.Add(new SqlParameter("@location", location)) ;

            Conn.Open();
            ADDS.ExecuteNonQuery();
            if (printOutput == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Club Added');window.location = 'Admin.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + printOutput + "');window.location = 'Admin.aspx';", true);
            }
            Conn.Close();
        }
        protected void DeleteC(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection Conn = new SqlConnection(connStr);

            String Club = Delete.Text;
            SqlCommand ADDS = new SqlCommand("deleteClub", Conn);
            String printOutput = "";
            if (Delete.Text == "" )
            {
                Response.Write(" the Field is Missing");
            }
            Conn.InfoMessage += (object obj, SqlInfoMessageEventArgs e1) =>
            {
                printOutput += e1.Message;
            };
            ADDS.CommandType = System.Data.CommandType.StoredProcedure;

            ADDS.Parameters.Add(new SqlParameter("@name", Club));

            Conn.Open();
            ADDS.ExecuteNonQuery();
            if (printOutput == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Club Deleted');window.location = 'Admin.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + printOutput + "');window.location = 'Admin.aspx';", true);
            }
            Conn.Close();

        }
        protected void LogOut(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }


    }
}