using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

public partial class Najava_Registracija : System.Web.UI.Page
{
   
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string a = (string)Session["KorisnikMail"];


                if ((a != null) && (Session["Status"]!=null))
                {
                    if (((string)Session["Status"]).Equals("ucenik")) { Response.Redirect("Ucenik.aspx"); }
                    else { Response.Redirect("Profesor.aspx"); }
                
                }

                ddlYear.Visible = false; ddlClass.Visible = false; lblClass.Visible = false; lblYear.Visible = false;
            

            }

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            bool cont = true;

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;

            komanda.CommandText = "SELECT Email FROM Person";

            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {


                    if (citac["Email"].ToString().ToLower() == txtRegMail.Text.ToString().ToLower())
                    {


                        cont = false;
                        lblRegMessage.Text = "Оваа емаил адреса не е достапна. Ве молиме внесете друга е-маил адреса !!!";


                        break;
                    }

                }
                citac.Close();
            }
            catch (Exception ex) { lblRegMessage.Text = ex.ToString(); }

            finally { konekcija.Close(); }

            if (cont)
            {
                //zapisi vo baza   
                komanda.CommandText = "INSERT INTO Approve (Name,Surname,Status,Password,Email,Year,Class,Subjects) VALUES(@name,@surname,@status,@password,@email,@year,@class,@subjects)";
                komanda.Parameters.Add("@email", txtRegMail.Text);
                komanda.Parameters.Add("@password", txtRegPassword.Text);
                komanda.Parameters.Add("@name", txtRegName.Text);
                komanda.Parameters.Add("@surname", txtRegSurname.Text);
                komanda.Parameters.Add("@status", ddlRole.SelectedItem.Value);
               

                if (ddlRole.SelectedItem.Value.Equals("profesor"))
                {
                    komanda.Parameters.Add("@year", "");
                    komanda.Parameters.Add("@class", "");
                }
                else
                {
                    komanda.Parameters.Add("@year", ddlYear.SelectedItem.Value);
                    komanda.Parameters.Add("@class", ddlClass.SelectedItem.Value);
                }

                komanda.Parameters.Add("@subjects", "");
                try
                {
                    konekcija.Open();
                    komanda.ExecuteNonQuery();
                }
                catch (Exception ex) { lblRegMessage.Text = ex.ToString(); }
                finally { konekcija.Close(); lblRegMessage.Text = "Успешна Регистрација.... Ќе можете да се најавите откако администраторот ќе го одобри барањето !!!"; }
            }




            /***

            if (cont)
            {
                //zapisi vo baza   
                komanda.CommandText = "INSERT INTO Person (Name,Surname,Status,Password,Email,Year,Class,Subjects,ActiveTestID) VALUES(@name,@surname,@status,@password,@email,@year,@class,@subjects,@activeTestID)";
                komanda.Parameters.Add("@email", txtRegMail.Text);
                komanda.Parameters.Add("@password", txtRegPassword.Text);
                komanda.Parameters.Add("@name", txtRegName.Text);
                komanda.Parameters.Add("@surname", txtRegSurname.Text);
                komanda.Parameters.Add("@status", ddlRole.SelectedItem.Value);
                komanda.Parameters.Add("@activeTestID","");
                
                if (ddlRole.SelectedItem.Value.Equals("profesor"))
                {
                    komanda.Parameters.Add("@year", "");
                    komanda.Parameters.Add("@class", "");
                }
                else
                {
                    komanda.Parameters.Add("@year", ddlYear.SelectedItem.Value);
                    komanda.Parameters.Add("@class", ddlClass.SelectedItem.Value);
                }

                komanda.Parameters.Add("@subjects","");
                try
                {
                    konekcija.Open();
                    komanda.ExecuteNonQuery();
                }
                catch (Exception ex) { lblRegMessage.Text = ex.ToString(); }
                finally { konekcija.Close(); lblRegMessage.Text = "Успешна Регистрација !";}
            }
             * **/

        }

        protected void ddlRole_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlRole.SelectedItem.Value.Equals("ucenik"))
            { ddlYear.Visible = true; ddlClass.Visible = true; lblYear.Visible=true;lblClass.Visible=true;}
            else { ddlYear.Visible = false; ddlClass.Visible = false; lblClass.Visible = false; lblYear.Visible = false; }
        }


        protected void btnNajava_Click(object sender, System.EventArgs e)
        {
            if (txtMail.Text.Equals("admin") && txtPass.Text.Equals("vkpass"))
            {
                Session["Korisnik"] = "Администратор";
                Session["KorisnikMail"] ="Администратор";
                Session["Status"] ="Администратор";
                Session["Predmeti"] = "Администратор";

                Response.Redirect("Administrator.aspx");
            }
            else
            {
                SqlConnection konekcija = new SqlConnection();
                konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

                SqlCommand komanda = new SqlCommand();
                komanda.Connection = konekcija;

                komanda.CommandText = "SELECT * FROM Person";

                try
                {
                    konekcija.Open();
                    SqlDataReader citac = komanda.ExecuteReader();
                    while (citac.Read())
                    {
                        string password = citac["Password"].ToString();
                        string email = citac["Email"].ToString();
                        if (password.Equals(txtPass.Text.ToString()) && (email.ToLower().Equals(txtMail.Text.ToString().ToLower())))
                        {


                            Session["Korisnik"] = citac["Name"].ToString() + " " + citac["Surname"].ToString();
                            Session["KorisnikMail"] = citac["Email"].ToString();
                            Session["Status"] = citac["Status"].ToString();
                            Session["Predmeti"] = citac["Subjects"].ToString();


                            break;
                        }

                    }
                    citac.Close();
                }
                catch (Exception ex) { lblInfo.Text = ex.ToString(); }

                finally
                {
                    konekcija.Close();

                    string mail = (string)Session["KorisnikMail"];
                    string stat = (string)Session["Status"];
                    if (mail != null && stat != null)
                    {

                        if (stat.Equals("profesor"))
                        { Response.Redirect("Profesor.aspx"); }
                        else { Response.Redirect("Ucenik.aspx"); }

                    }
                    else { lblInfo.Text = "Грешка. Обидете се повторно !!!"; }
                }
            }
        }
}
