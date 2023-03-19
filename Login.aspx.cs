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

namespace Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Web"].ToString();
            SqlConnection Conn = new SqlConnection(connStr);
            if (Username.Text == "" || Password.Text == "" )
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('One of the fields is empty');window.location = 'Login.aspx';", true);
            }

            String User = Username.Text;
            String pass = Password.Text;

            SqlCommand login = new SqlCommand("CheckUser", Conn);

            login.CommandType = System.Data.CommandType.StoredProcedure;

            login.Parameters.Add(new SqlParameter("@Username", User));

            login.Parameters.Add(new SqlParameter("@Password", pass));

            SqlParameter success = login.Parameters.Add("@success", SqlDbType.Int);
            success.Direction = ParameterDirection.Output;

            Conn.Open();
            login.ExecuteNonQuery();
            Conn.Close();

            Conn.Open();
            if (success.Value.ToString() == "1")
            {
                try
                {
                    //To Check Manager
                    SqlCommand CheckM = new SqlCommand("CheckManger", Conn);
                    CheckM.CommandType = System.Data.CommandType.StoredProcedure;
                    CheckM.Parameters.Add(new SqlParameter("@Username", User));
                    CheckM.Parameters.Add(new SqlParameter("@Password", pass));
                    SqlParameter Manager1 = CheckM.Parameters.Add("@success", SqlDbType.Int);
                    Manager1.Direction = ParameterDirection.Output;
                    CheckM.ExecuteNonQuery();

                    if (Manager1 != null)
                    {
                        if (Manager1.Value.ToString() == "1")
                        {
                            Conn.Close();

                            Session["USER"] = User;
                            Response.Redirect("Stadium_Manager.aspx");
                        }

                    }

                    //To Check Represntive
                    SqlCommand CheckR = new SqlCommand("CheckREP", Conn);
                    CheckR.CommandType = System.Data.CommandType.StoredProcedure;
                    CheckR.Parameters.Add(new SqlParameter("@Username", User));
                    CheckR.Parameters.Add(new SqlParameter("@Password", pass));
                    SqlParameter Rep1 = CheckR.Parameters.Add("@success", SqlDbType.Int);
                    Rep1.Direction = ParameterDirection.Output;
                    CheckR.ExecuteNonQuery();


                    if (Rep1 != null)
                    {
                        if (Rep1.Value.ToString() == "1")
                        {
                            Conn.Close();

                            Session["USER"] = User;
                            Response.Redirect("Repsantative.aspx");
                        }

                    }

                    //To Check Fan
                    SqlCommand CheckF = new SqlCommand("CheckFAN", Conn);
                    CheckF.CommandType = System.Data.CommandType.StoredProcedure;
                    CheckF.Parameters.Add(new SqlParameter("@Username", User));
                    CheckF.Parameters.Add(new SqlParameter("@Password", pass));
                    SqlParameter FAN1 = CheckF.Parameters.Add("@success", SqlDbType.Int);
                    FAN1.Direction = ParameterDirection.Output;
                    CheckF.ExecuteNonQuery();


                    if (FAN1 != null)
                    {
                        if (FAN1.Value.ToString() == "1")
                        {
                            Conn.Close();

                            Session["USER"] = User;
                            Response.Redirect("FanPage.aspx");
                        }

                    }

                    //To Check SPORT ASSOCITAION
                    SqlCommand CheckAS = new SqlCommand("CheckAS", Conn);
                    CheckAS.CommandType = System.Data.CommandType.StoredProcedure;
                    CheckAS.Parameters.Add(new SqlParameter("@Username", User));
                    CheckAS.Parameters.Add(new SqlParameter("@Password", pass));
                    SqlParameter AS1 = CheckAS.Parameters.Add("@success", SqlDbType.Int);
                    AS1.Direction = ParameterDirection.Output;
                    CheckAS.ExecuteNonQuery();

                    if (AS1 != null)
                    {
                        if (AS1.Value.ToString() == "1")
                        {
                            Conn.Close();

                            Session["USER"] = User;
                            Response.Redirect("AsForm.aspx");
                        }

                    }

                    //TO CHECK ADMIN 
                    SqlCommand CheckA = new SqlCommand("CheckA", Conn);
                    CheckA.CommandType = System.Data.CommandType.StoredProcedure;
                    CheckA.Parameters.Add(new SqlParameter("@Username", User));
                    CheckA.Parameters.Add(new SqlParameter("@Password", pass));
                    SqlParameter ADMIN = CheckA.Parameters.Add("@success", SqlDbType.Int);
                    ADMIN.Direction = ParameterDirection.Output;
                    CheckA.ExecuteNonQuery();

                    if (ADMIN != null)
                    {
                        if (ADMIN.Value.ToString() == "1")
                        {
                            Session["USER"] = User;
                            Conn.Close();
                            Response.Redirect("Admin.aspx");
                        }

                    }

                }
                catch (System.Exception ex)
                {
                    // Handle the exception...
                    string errorMessage = ex.Message;
                    string errorSource = ex.Source;
                    Exception innerException = ex.InnerException;
                    // etc.
                }




            }

            else
            {
                Conn.Close();
                Response.Write("Invalid Username or password");
            }
        }
        protected void Register(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}