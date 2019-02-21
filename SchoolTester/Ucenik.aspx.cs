using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Ucenik : System.Web.UI.Page
{
    string subjecttests;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblLogin.Text = "Добредојде " + (string)Session["Korisnik"];
            btnOdgovori.Enabled = false;
            pnlOdgovoriPrikaz.Visible = false;
            IspolniView();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["KorisnikMаil"] = null;

        Session["Korisnik"] = null;
        Session["Status"] = null;
        Response.Redirect("Najava_Registracija.aspx");
    }

    protected void IspolniView()
    {

        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "SELECT * FROM Person WHERE Email=@emailot";
         string mail = (string)Session["KorisnikMail"];
         komanda.Parameters.Add("@emailot", mail);

         int activen = 0;

        try
        {
            konekcija.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            while (citac.Read())
            {
                string active = citac["ActiveTestID"].ToString();
                subjecttests = citac["Subjects"].ToString();
                string password = citac["Password"].ToString();
                Session["Password"] = password;

                if (active.Equals(" ") || active.Equals(""))
                {
                    pnlAktivenTest.Visible = false;
                    activen = 0;
                     Session["ActiveTestID"] = " ";
                     lblinfo.Text = "Нема објавен активен тест за вас !";

                    break;
                }
                else
                {
                    pnlAktivenTest.Visible = true;
                    lblinfo.Text = "Oбјавен e тест за вас !";
                    activen = 1;
                    Session["ActiveTestID"] = active; 
                    break;                   
                
                }

            }
            citac.Close();
        }
        catch (Exception ex) { lblinfo.Text = ex.ToString(); }

        finally
        {
            konekcija.Close();  
            }

        if (activen == 1)
        {
            komanda.CommandText = "SELECT * FROM Test WHERE TestID=@testid";

            komanda.Parameters.Add("@testid",(string)Session["ActiveTestID"]);
                        

            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    string tekst = "Тест по: " + citac["Subject"].ToString().Trim() + " Опис:" + citac["Description"].ToString().Trim()+" за учениците од класот "+
                             citac["Class"].ToString().Trim() + ". Создаден на датум:" + citac["Date"].ToString().Trim();
                    lblAktivenTest.Text = tekst;
                }
                citac.Close();
            }       
        
        
        
         catch (Exception ex) { lblAktivenTest.Text = ex.ToString(); }

        finally
        {
            konekcija.Close();  
        }

        
        }

        if (!(subjecttests.Equals("") || subjecttests.Equals(" ")))
        {
            ListItem it;
            string[] subjectsTestID = subjecttests.Split(';');
            ddlTestoviList.Items.Add(" ");
            for (int i = 0; i < subjectsTestID.Length; i++)
            {


                it = new ListItem();
                it.Text = subjectsTestID[i];
                it.Value = subjectsTestID[i];
                ddlTestoviList.Items.Add(it);   
                                    
            }

            
        
        
        
        }
     
      
    
    
    }

    protected void btnStartTest_Click(object sender, EventArgs e)
    {            
               
        Response.Redirect("Testiranje.aspx");
    }
    protected void ddlTestoviList_SelectedIndexChanged(object sender, EventArgs e)
    {
        // se ispisuva vo info objasnuvanje za testot i se ovozmozuva kopceto vidi odgovori  
        if (!(ddlTestoviList.SelectedItem.Text.Equals(" ") || ddlTestoviList.SelectedItem.Text.Equals("")))
        {
            pnlOdgovoriPrikaz.Visible = false;
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            string ttid = ddlTestoviList.SelectedItem.Text.Trim();
            komanda.CommandText = "SELECT * FROM Test WHERE TestID=@testID";
            komanda.Parameters.Add("@testID", ttid);


            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    lblTestInformacii.Text = "Тест по предметот: " + citac["Subject"].ToString().Trim() + " за " +
                       citac["Class"].ToString().Trim() + " клас. Датум: " + citac["Date"].ToString().Trim() +
                       "Опис: " + citac["Description"].ToString().Trim() + " Создаден од: " +
                       citac["Email"].ToString().Trim();

                }
                citac.Close();
            }
            catch (Exception ex) { lblTestInformacii.Text = ex.ToString(); }

            finally
            {
                konekcija.Close(); btnOdgovori.Enabled = true;
            }
        }
        else { 
            btnOdgovori.Enabled = false;
            pnlOdgovoriPrikaz.Visible = false;
        }
        
    
    
    }


    protected void btnOdgovori_Click(object sender, EventArgs e)
    {
        if (!ddlTestoviList.SelectedItem.Text.Equals(" "))
        {
            pnlOdgovoriPrikaz.Visible = true;
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;


            komanda.CommandText = "SELECT Answer.AnswerID,Question.QuestionContent,Answer.Answer,Answer.Points AS 'AP',Question.Points AS 'QP' FROM  Answer INNER JOIN Question ON Answer.TestID=Question.TestID WHERE (Answer.TestID=@tid AND Answer.Email=@em) AND Answer.AnswerID=Question.QuestionID ORDER BY Answer.AnswerID";
            komanda.Parameters.Add("@tid", ddlTestoviList.SelectedItem.Text.Trim());
            komanda.Parameters.Add("@em", (string)Session["KorisnikMail"]);

            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Ucenici Odgovori");

                gvOdgovoriUcenici.DataSource = ds;
                gvOdgovoriUcenici.DataBind();
                ViewState["datasetodgovori"] = ds;


            }
            catch (Exception ex) { lblInformacii123.Text = ex.Message; }
            finally { konekcija.Close(); }
        }
       
    }
    protected void btnSaveNewPass_Click(object sender, EventArgs e)
    {
       // proveri go stariot password
        string oldpass=(string) Session["Password"];

        if (txtOldPassword.Text.Equals(oldpass))
        {


            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;

            komanda.CommandText = "UPDATE Person SET Password=@password WHERE Email=@email";
            komanda.Parameters.Add("@password", txtNewPassword.Text);
            komanda.Parameters.Add("@email", (string)Session["KorisnikMail"]);

            int efekt = 0;
            try
            {

                konekcija.Open();
                efekt = komanda.ExecuteNonQuery();

            }
            catch (Exception ex) { lblInfoSave.Text = ex.Message; }

            finally { konekcija.Close(); if (efekt != 0) { lblInfoSave.Text = "Успешно променета лозинка ! "; Session["Password"] = txtNewPassword.Text; } else { lblInfoSave.Text = "Грешка при промена !"; } }


        }
        else { lblInfoSave.Text = "Погрешна стара лозинка !"; }

    }
}