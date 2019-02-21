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

public partial class Testiranje : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
      //  if (!IsPostBack)
        

            IspolniKopcinja();
        
        
    }

    protected void IspolniKopcinja()
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "SELECT * FROM Question WHERE TestID=@testid";
        string testid = (string)Session["ActiveTestID"];
        komanda.Parameters.Add("@testid", testid.Trim());
        int brojac = 0;

        try
        {
            konekcija.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            while (citac.Read())
            {
                if (citac["TestID"].ToString().Trim().Equals(testid.Trim()))
                {
                    brojac += 1;
                
                }

               

            }
            citac.Close();
        }
        catch (Exception ex) { lblInfo.Text = ex.ToString(); }
        finally
        {
            konekcija.Close(); ViewState["vkupnoprasanja"] = brojac;
        }
        Button tb;
        
        for (int i = 1; i < (brojac+1); i++)
        {
            tb = new Button();
        tb.ID=i.ToString();
            tb.Text=i.ToString();
            tb.Visible = true;
            tb.CssClass = "novoKopce";
          tb.Click+= new EventHandler(Button_Click);
          
            pnlButtons.Controls.Add(tb);       
        
        }
    }

    protected void Button_Click(object sender, EventArgs e)
    {       
            
        
     /// ovde se pisuva pri promena da se zacuva odgovort ili da se izvrsi akcijata

       
        
       //zapocnuva dodavanjeto na novoto prasanje 
        Button bt = (Button)sender;
        string id = bt.ID.ToString();
        if (id.Equals("1")) { ptnPrethodno.Enabled = false; } else { ptnPrethodno.Enabled = true; }

        if (id.Equals(((int)ViewState["vkupnoprasanja"]).ToString().Trim())) { btnSledno.Enabled = false; } else { btnSledno.Enabled = true; }

        Update_Save_Answer((string)ViewState["questionid"]);
        ViewState["questionid"] = id;
       
        IzberiPrasanje(id);           

    }

    protected void IzberiPrasanje(string id)
    {
        ViewReset();

        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "SELECT * FROM Question WHERE TestID=@testid AND QuestionID=@qi";
        string testid = (string)Session["ActiveTestID"];
        komanda.Parameters.Add("@testid", testid.Trim());
        komanda.Parameters.Add("@qi", id);

        try
        {
            konekcija.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            while (citac.Read())
            {
                string tip = citac["QuestionType"].ToString().Trim();
                ViewState["tip"] = tip;
                string prasanje = citac["QuestionContent"].ToString().Trim();
                string mozniodgovori = citac["PossibleOptions"].ToString().Trim();
                string points = citac["Points"].ToString().Trim();
                string url = citac["Image"].ToString().Trim();
                IspolniPrasanje(id, tip, prasanje, mozniodgovori,points,url);

            }
            citac.Close();
        }
        catch (Exception ex) { lblInfo.Text = ex.ToString(); }

        finally
        {
            konekcija.Close();
        }
    
    
    
    }

    protected void Update_Save_Answer(string id)
    {
        string previous = (string)ViewState["questionid"];
        string tipot = (string)ViewState["tip"];
        if ( (previous!= null) && (tipot!=null))
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;



            komanda.CommandText = "UPDATE Answer SET AnswerType=@at,Answer=@ans" +
                                            " WHERE (TestID=@tid AND Email=@em) AND AnswerID=@aid";
            string testid = (string)Session["ActiveTestID"];
            komanda.Parameters.Add("@tid", testid.Trim());
            komanda.Parameters.Add("@em", (string)Session["KorisnikMail"]);
            komanda.Parameters.Add("@aid", (string)ViewState["questionid"]);
            string tip=(string) ViewState["tip"];
            komanda.Parameters.Add("@at", tip);
            string answer="empty answer";
            if (tip.Equals("1")) { answer = txtOdgovor.Text.Trim(); }

            if (tip.Equals("2")) {

                if (rdbListOdgovori.SelectedIndex!=-1)
                {

                    answer = rdbListOdgovori.SelectedItem.Text.Trim();
                }
            
            }
            if (tip.Equals("3")) { answer = lbltext1.Text.Trim()+"<p>"+txt1.Text.Trim()+"<p>" +               
                                            lbltext2.Text.Trim()+"<p>"+txt2.Text.Trim()+"<p>"+
                                            lbltext3.Text.Trim()+"<p>"+txt3.Text.Trim()+"<p>"+
                                            lbltext4.Text.Trim()+"<p>"+txt4.Text.Trim()+"<p>"+
                                            lbltext5.Text.Trim()+"<p>"+txt5.Text.Trim()+"<p>"; 
            
            
            }

            komanda.Parameters.Add("@ans",answer);

            int count=0;

            try
            {
                konekcija.Open();
               
                        count = komanda.ExecuteNonQuery();


            }


            catch (Exception ex) { lblInfo.Text = ex.ToString(); count = 0; }

            finally { konekcija.Close(); if (count == 1) { lblInfo.Text = "Успешно ажурирање на прашањето бр." + ((string)ViewState["questionid"]); } else { lblInfo.Text = "Грешка!"; };}

            // insert nov odgovor :)
            if (count == 0)
            {

                komanda.CommandText = "INSERT INTO Answer (TestID,Email,AnswerID,AnswerType,Answer) VALUES(@tid,@em,@aid,@at,@ans)";

                 int a=0;

            try
            {
                konekcija.Open();
               
                        a= komanda.ExecuteNonQuery();


            }

            catch (Exception ex) { lblInfo.Text = ex.ToString(); a = 0; }

            finally { konekcija.Close(); if (a != 0) { lblInfo.Text = "Успешно зачувување на состојбата на прашањето бр." + ((string)ViewState["questionid"]); }; }
            
            
            }
            


        }
    
    }



    protected void IspolniPrasanje(string id,string type,string prasanje,string odgovori,string points,string url)
    {
       


        /// da se dodade ispolnuvanje na odgovorot od prasanjata sto se zacuvani

        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "SELECT Answer FROM Answer WHERE (TestID=@testid AND AnswerID=@ai) AND Email=@em";
        string testid = (string)Session["ActiveTestID"];
        komanda.Parameters.Add("@testid", testid.Trim());
        komanda.Parameters.Add("@ai", Int16.Parse(id));
        komanda.Parameters.Add("@em", (string) Session["KorisnikMail"]);
        string answer="";
        try
        {
            konekcija.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            while (citac.Read())
            {
              answer = citac["Answer"].ToString().Trim();
                

            }
            citac.Close();
        }
        catch (Exception ex) { lblInfo.Text = ex.ToString(); }

        finally
        {
            konekcija.Close();
        }



        if (type.Equals("1"))
        {
            lblredbroj.Text = id;
            lblPoeni.Text = points;
            lblPrasanje.Text = prasanje;
            if (!(url.Equals(" ") || url.Equals(null) || url.Equals("noimg")))
            {
                imgPreview.Visible = true;
                imgPreview.ImageUrl = url;

            }
            else { imgPreview.Visible = false; }

            txtOdgovor.Visible = true;
            if(!answer.Equals(""))
            txtOdgovor.Text = answer.ToString().Trim();

        }
        if (type.Equals("2"))
        {

            lblPrasanje.Text = prasanje;
            lblredbroj.Text = id;
            lblPoeni.Text = points;
            if (!(url.Equals(" ") || url.Equals(null) || url.Equals("noimg")))
            {
                imgPreview.Visible = true;
                imgPreview.ImageUrl = url;

            }
            else { imgPreview.Visible = false; }

            string[] options = odgovori.Split(';');
            rdbListOdgovori.Visible = true;
            for (int i = 0; i < options.Length; i++)
            {

                rdbListOdgovori.Items.Add(options[i].Trim());
                if (answer.Equals(options[i].Trim()))
                {
                    rdbListOdgovori.SelectedIndex = i;
                }
            }

       // **    if (!answer.Equals(""))
        //    {
       //         ListItem itemm = new ListItem();
        //        itemm.Text = answer.ToString().Trim();
         //       rdbListOdgovori.SelectedIndex = rdbListOdgovori.Items.IndexOf(itemm);
       //     }
            

        }
        if (type.Equals("3"))
        {
            lblredbroj.Text = id;
            lblPoeni.Text = points;
            if (!(url.Equals(" ") || url.Equals(null) || url.Equals("noimg")))
            {
                imgPreview.Visible = true;
                imgPreview.ImageUrl = url;

            }
            else { imgPreview.Visible = false; }

            lblPrasanje.Text = prasanje;
            string[] stringSeparators = new string[] { "<p>" };
            string[] fill = odgovori.Split(stringSeparators, StringSplitOptions.None);
            

            lbltext1.Text = fill[0].Trim();
            lbltext1.Visible = true;
            txt1.Visible = true;
           

            lbltext2.Text = fill[1].Trim();
            lbltext2.Visible = true;
            txt2.Visible = true;
            

            lbltext3.Text = fill[2].Trim();
            lbltext3.Visible = true;
            txt3.Visible = true;
            

            lbltext4.Text = fill[3].Trim();
            lbltext4.Visible = true;
            txt4.Visible = true;
            

            lbltext5.Text = fill[4].Trim();
            lbltext5.Visible = true;
            txt5.Visible = true;
           

            if (!answer.Equals(""))
            {
                string[] fillanswer = answer.Split(stringSeparators, StringSplitOptions.None);
                if (!fillanswer[1].Equals(""))
                { txt1.Text = fillanswer[1].Trim(); }
                else { txt1.Visible = false; }

                if (!fillanswer[3].Equals(""))
                { txt2.Text = fillanswer[3].Trim(); }
                else { txt2.Visible = false; }
                if (!fillanswer[5].Equals(""))
                { txt3.Text = fillanswer[5].Trim(); }
                else { txt3.Visible = false; }
                if (!fillanswer[7].Equals(""))
                { txt4.Text = fillanswer[7].Trim(); }
                else { txt4.Visible = false; }
                if (!fillanswer[9].Equals(""))
                { txt5.Text = fillanswer[9].Trim(); }
                else { txt5.Visible = false; }
            }



        }


    
    
    
    }

    protected void ViewReset()
    {
        txtOdgovor.Visible = false;
        txtOdgovor.Text = "";
        imgPreview.Visible = false;
        
        txt5.Visible = false;
        txt4.Visible = false;
        txt3.Visible = false;
        txt2.Visible = false;
        txt1.Visible = false;
        lbltext1.Visible = false;
        lbltext2.Visible = false;
        lbltext3.Visible = false;
        lbltext4.Visible = false;
        lbltext5.Visible = false;

        txt5.Text = "";
        txt4.Text = "";
        txt3.Text = "";
        txt2.Text = "";
        txt1.Text = "";
        lbltext1.Text = "";
        lbltext2.Text = "";
        lbltext3.Text = "";
        lbltext4.Text = "";
        lbltext5.Text = "";
        rdbListOdgovori.Visible = false;
        rdbListOdgovori.Items.Clear();    
    
    }



    protected void btnSledno_Click(object sender, EventArgs e)
    {

        ptnPrethodno.Enabled = true;

     int vkupno=(int)ViewState["vkupnoprasanja"];


        if (ViewState["questionid"] != null)
        {

            int actualid = Int16.Parse((string)ViewState["questionid"]);
            if (actualid <vkupno)
            {
                actualid = actualid + 1;
                Update_Save_Answer((string)ViewState["questionid"]);
                ViewState["questionid"] = actualid.ToString().Trim();
                if (actualid == vkupno) { btnSledno.Enabled = false; }

                IzberiPrasanje(actualid.ToString().Trim());

            }




        }

    }
    protected void ptnPrethodno_Click(object sender, EventArgs e)
    {
        btnSledno.Enabled = true;
        if (ViewState["questionid"] != null)
            {

                int actualid = Int16.Parse((string)ViewState["questionid"]);
                if (actualid != 1)
                { 
                actualid=actualid-1;
                Update_Save_Answer((string)ViewState["questionid"]);
                    ViewState["questionid"]=actualid.ToString().Trim();
                    if (actualid == 1) { ptnPrethodno.Enabled = false; }

                    IzberiPrasanje(actualid.ToString().Trim());
                
                
                }

        
        
        
        }
    }
    protected void btnKraj_Click(object sender, EventArgs e)
    {// dodadi go testot od active test vo subjects i napraj cekor nazad i refresh
        
        string subjectsTests="";
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "SELECT * FROM Person WHERE Email=@em AND ActiveTestID=@actid";
        string testid = (string)Session["ActiveTestID"];
        komanda.Parameters.Add("@actid", testid.Trim());       
        komanda.Parameters.Add("@em", (string)Session["KorisnikMail"]);
      
        try
        {
            konekcija.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            while (citac.Read())
            {
                subjectsTests= citac["Subjects"].ToString().Trim();


            }
            citac.Close();
        }
        catch (Exception ex) { lblInfo.Text = ex.ToString(); }

        finally
        {
            konekcija.Close();
        }

        if (subjectsTests.Equals("") || subjectsTests.Equals(" "))
        {
            subjectsTests = testid + ";";

        }
        else {
            subjectsTests += testid + ";";
        
        }

        // azuriraj ja novata promena

        Session["ActiveTestID"] = " ";


        komanda.CommandText = "UPDATE Person SET Subjects=@subjects,ActiveTestID=@ac" +
                                    " WHERE Email=@em AND Status=@status";


        komanda.Parameters.Add("@ac", ""); 
        komanda.Parameters.Add("@status", "ucenik");
        komanda.Parameters.Add("@subjects", subjectsTests);
        int rows = 0;
        try
        {
            konekcija.Open();
            rows = komanda.ExecuteNonQuery();


        }
        catch (Exception ex) { lblInfo.Text = ex.ToString(); rows = 0; }

        finally { konekcija.Close(); if (rows != 1) { lblInfo.Text = "Грешка"; } else { lblInfo.Text = "Успешно зачувување!"; Response.Redirect("Ucenik.aspx"); } }

    }
}