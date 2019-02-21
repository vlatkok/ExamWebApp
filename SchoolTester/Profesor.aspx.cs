using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Profesor : System.Web.UI.Page
{
   
 static string saved;
 static string ttID;
  static string emID;
  static int num;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblLogin.Text = "Добредојде " + (string)Session["Korisnik"];
            OnRefreshPage();
            lblInfoSubjects.Text = "";
            saved = "";
            pnlDodadiPredmeti.Visible = false;
            pnlNewTest.Visible = false;
            pnlMoiTestovi.Visible = false;
            this.ddlTestedStudents.SelectedIndex = -1;
            this.ddlTestoviTest.SelectedIndex = -1;
            this.ddlTestoviPredmet.SelectedIndex = -1;
            gvPoeni.Visible = false;
            ddlTestedStudents.Visible = false;
            lblUcenikInformacii.Visible = false;
            lblizberiucenikprasanje.Visible = false;

        }

        if (saved == "autopostback")
        { 

         for (int i = 0; i < num; i++)
           {
            QuestionControl kontrola = LoadControl("QuestionControl.ascx") as QuestionControl;
               
               kontrola.Read_TestID_Email_questionID(ttID,emID,i+1);
               form1.Controls.Add(kontrola);


          }
      
        
      }  


      

    }


    void OnRefreshPage()
    {
        if (Session["Predmeti"] != null)
        {
            ddlTestoviPredmet.Items.Clear();
            ddlTestoviPredmet.Items.Add(" ");
            ddlChooseSubject.Items.Clear();
            lstPredmeti.Items.Clear();

            string[] predmeti = ((string)Session["Predmeti"]).Trim().Split(';');          
            for (int i = 0; i < predmeti.Length; i++)
            {
                if (!predmeti[i].Equals(""))
                {
                    lstPredmeti.Items.Add(predmeti[i]);
                    ddlChooseSubject.Items.Add(predmeti[i]);
                    ddlTestoviPredmet.Items.Add(predmeti[i]);
                }
            }
           

        }
        else { Response.Redirect("Najava_Registracija.aspx"); }

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
   
        Session["KorisnikMаil"]=null;
      
        Session["Korisnik"]=null;
        Session["Status"] = null;
        Response.Redirect("Najava_Registracija.aspx");
       
    }
    protected void btnDodadiPredmet_Click(object sender, EventArgs e)
    {
        if (lstPredmeti.SelectedIndex == -1)
        {
            lstPredmeti.Items.Add(txtPredmetDodadi.Text + " " + ddlYear.SelectedItem.Text + " година");

            txtPredmetDodadi.Text = "";
        }
        else { lstPredmeti.Items.RemoveAt(lstPredmeti.SelectedIndex);
        lstPredmeti.Items.Add(txtPredmetDodadi.Text + " " + ddlYear.SelectedItem.Text + " година");
        }

        lblInfoSubjects.Text = "";


    }
    protected void lstPredmeti_SelectedIndexChanged(object sender, EventArgs e)
    {
      //  string[] subject = lstPredmeti.SelectedItem.Text.Split(' ');
      //  txtPredmetDodadi.Text = subject[0];
      //  ddlYear.SelectedIndex=subject
    }
    protected void btnRemoveSubject_Click(object sender, EventArgs e)
    {
        if(lstPredmeti.SelectedIndex!=-1)
        lstPredmeti.Items.RemoveAt(lstPredmeti.SelectedIndex);
        lblInfoSubjects.Text = "";
    }

    protected void zacuvajListaPredmeti_Click(object sender, EventArgs e)
    {
        string subjects = "";

        for (int i = 0; i < lstPredmeti.Items.Count; i++)
        {


            if (lstPredmeti.Items[i].Equals("")) lstPredmeti.Items.RemoveAt(i);         
        }


        for (int i = 0; i < lstPredmeti.Items.Count;i++ )
        {
            subjects += lstPredmeti.Items[i] + ";";
            subjects.Trim();
        }
       subjects=subjects.Trim();
       Session["Predmeti"] = subjects;

// zacuvaj ja listata na predmeti vo bazata 


        if (Session["KorisnikMail"]!=null)
        {

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;

            komanda.CommandText = "UPDATE Person SET Subjects=@subjects"+
                                        " WHERE Email=@email";
            komanda.Parameters.Add("@subjects", subjects);
            string mailot = (string)Session["KorisnikMail"];
            komanda.Parameters.Add("@email",mailot);
           
           int rows=0;
            try
            {
                konekcija.Open();
               rows = komanda.ExecuteNonQuery();
             

            }
            catch (Exception ex) { lblInfoSubjects.Text = ex.ToString(); }

            finally { konekcija.Close(); if (rows!=1) { lblInfoSubjects.Text = "Грешка"; } else { lblInfoSubjects.Text = "Предметите се зачувани !"; } }



            OnRefreshPage();

        }
        else { Response.Redirect("Najava_Registracija.aspx"); }



    }

    protected void btnNewTest_Click(object sender, EventArgs e)
    {
        btnSubjectsPreview.Enabled = true;
        btnNewTest.Enabled = false;
        pnlDodadiPredmeti.Visible = false;
        form1.Visible = true;
        pnlNewTest.Visible = true;
        ddlChooseSubject.Visible = true;
        lblIzberiPredmet.Visible = true;
        lblDatum.Visible = true;
        lblOpisTest.Visible = true;
        txtDatum.Visible = true;
        txtOpisTest.Visible = true;
        btnZacuvajKarakteristiki.Visible = true;
        lblBrojNaPrasanja.Visible = true;
        txtBrojNaPrasanja.Visible = true;
        // moi testovi
        btnMoiTestovi.Enabled = true;
        pnlMoiTestovi.Visible = false;
        pnlOcenkiPoeni.Visible = false;
        pnlPrasanjaTest.Visible = false;


        /***
        Panel questionType = new Panel();
        RadioButton button = new RadioButton();
        button.ID = "1";
        button.GroupName = "Prasanja";
        button.Text = "Прашање + одговор";
        button.Checked = false;
        questionType.Controls.Add(button);
        pnlNewTest.Controls.Add(questionType);
    ***/
    }
    protected void btnZacuvajKarakteristiki_Click(object sender, EventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "INSERT INTO Test (TestID,Email,Subject,Description,StudentsList,Date,Start,Finished,Class) VALUES(@testID,@email,@subject,@description,@studentList,@date,@start,@finished,@class)";
        string emailot = (string)Session["KorisnikMail"];
        emID = emailot;
        string testID = ddlChooseSubject.SelectedItem.Text.Trim() + txtDatum.Text.Trim() + emailot.Trim();
        ttID = testID;
        komanda.Parameters.Add("@testID",testID);
        komanda.Parameters.Add("@email",emailot.Trim());        
        komanda.Parameters.Add("@subject",ddlChooseSubject.SelectedItem.Text.Trim());
        komanda.Parameters.Add("@description",txtOpisTest.Text.Trim() );
        komanda.Parameters.Add("@studentList","");
        komanda.Parameters.Add("@date",txtDatum.Text.Trim());
          komanda.Parameters.Add("@start"," ");
          komanda.Parameters.Add("@finished"," ");
          komanda.Parameters.Add("@class"," ");

        try
        {
            konekcija.Open();
            komanda.ExecuteNonQuery();
        }
        catch (Exception ex) { lblZacuvajKarakteristiki.Text = ex.ToString(); }
        finally { konekcija.Close(); btnZacuvajKarakteristiki.Enabled = false; lblZacuvajKarakteristiki.Text = "Успешно зачувување!"; }

        int number = Convert.ToInt16(txtBrojNaPrasanja.Text);
        num = number;
        saved = "autopostback";
      for (int i = 0; i < number; i++)
        {
            QuestionControl kontrola = LoadControl("QuestionControl.ascx") as QuestionControl;
            kontrola.Read_TestID_Email_questionID(testID,emailot,i+1);
           form1.Controls.Add(kontrola);
           

        }
    
      
        
        
    }
    protected void btnSubjectsPreview_Click(object sender, EventArgs e)
    {
        
        pnlDodadiPredmeti.Visible=true;
        if (pnlNewTest.Visible == true)
        {
            pnlNewTest.Visible=false;
            Response.Redirect("Profesor.aspx");
        }
        btnNewTest.Enabled = true;
        btnSubjectsPreview.Enabled = false;
        btnMoiTestovi.Enabled = true;
        pnlMoiTestovi.Visible = false;
        pnlOcenkiPoeni.Visible = false;
        pnlPrasanjaTest.Visible = false;
    }
    protected void btnMoiTestovi_Click(object sender, EventArgs e)
    {
        pnlMoiTestovi.Visible = true;
        btnMoiTestovi.Enabled = false;
        btnNewTest.Enabled = true;

       
        pnlOcenkiPoeni.Visible = true;
        pnlPrasanjaTest.Visible = true;

       
        btnSubjectsPreview.Enabled = true;
        pnlDodadiPredmeti.Visible = false;

        OnRefreshPage();
        if (pnlNewTest.Visible == true)
        {
            pnlNewTest.Visible = false;
            Response.Redirect("Profesor.aspx");
        }
    }

    protected void ddlTestoviPredmet_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddlTestoviPredmet.SelectedItem.Text.Equals(" "))
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;

            komanda.CommandText = "SELECT * FROM Test WHERE Email=@email AND Subject=@subject";
            string mailot = (string)Session["KorisnikMail"];
            komanda.Parameters.Add("@email", mailot);
            komanda.Parameters.Add("@subject", ddlTestoviPredmet.SelectedItem.Text.Trim());
            ddlTestoviTest.Items.Clear();
            ddlTestoviTest.Items.Add(" ");
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    string itemstext = citac["Date"].ToString().Trim() + " " + citac["Description"].ToString().Trim();

                    ListItem it = new ListItem();
                    it.Text = itemstext;
                    it.Value = citac["TestID"].ToString().Trim();
                    ddlTestoviTest.Items.Add(it);

                }
                citac.Close();
            }
            catch (Exception ex) { lblInformacii.Text = ex.ToString(); }
            finally { konekcija.Close(); }
            ddlTestoviTest.SelectedIndex = -1;
            lblDescription.Text = " ";
        }
        else { ddlTestoviTest.Items.Clear(); }
    }
    protected void ddlTestoviTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblDescription.Text = " ";
        gvPrasanjaTest.Visible = true;
        if (!ddlTestoviTest.SelectedItem.Text.ToString().Equals(" "))
        IspolniGridView(ddlTestoviTest.SelectedItem.Value.ToString().Trim());

        gvPrasanjaTest.Visible = true;
        pnlPrasanjaTest.Visible = true;
        pnlOcenkiPoeni.Visible = false;
        

    }
    protected void gvPrasanjaTest_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["dataset"];
        gvPrasanjaTest.EditIndex = e.NewEditIndex;
        gvPrasanjaTest.DataSource = ds;
        gvPrasanjaTest.DataBind();
    }
    protected void gvPrasanjaTest_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["dataset"];
        gvPrasanjaTest.EditIndex = -1;
        gvPrasanjaTest.DataSource = ds;
        gvPrasanjaTest.DataBind();
    }
    protected void gvPrasanjaTest_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "UPDATE Question SET QuestionType=@questiontype,QuestionContent=@questioncontent,PossibleOptions=@possibleoptions1,Points=@points" +
                                        " WHERE (TestID=@testID AND Email=@email) AND QuestionID=@qi";

        TextBox tb = (TextBox)gvPrasanjaTest.Rows[e.RowIndex].Cells[1].Controls[0];
        komanda.Parameters.AddWithValue("@questiontype", tb.Text.Trim());

       string  st = gvPrasanjaTest.Rows[e.RowIndex].Cells[0].Text.Trim();
         komanda.Parameters.AddWithValue("@qi",st);

         tb = (TextBox)gvPrasanjaTest.Rows[e.RowIndex].Cells[2].Controls[0];
        komanda.Parameters.AddWithValue("@questioncontent", tb.Text.Trim());

        tb = (TextBox)gvPrasanjaTest.Rows[e.RowIndex].Cells[4].Controls[0];
        komanda.Parameters.AddWithValue("@points", tb.Text.Trim());

        tb = (TextBox)gvPrasanjaTest.Rows[e.RowIndex].Cells[3].Controls[0];
        komanda.Parameters.AddWithValue("@possibleoptions1", tb.Text.Trim());

      ///   tb = (TextBox)gvPrasanjaTest.Rows[e.RowIndex].Cells[4].Controls[0];
        komanda.Parameters.AddWithValue("@testID",ddlTestoviTest.SelectedItem.Value.ToString().Trim());
        string mailot = (string)Session["KorisnikMail"];
        komanda.Parameters.Add("@email",mailot);
        int efekt = 0;
        try
        {

            konekcija.Open();
            efekt = komanda.ExecuteNonQuery();

        }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }

        finally { konekcija.Close(); gvPrasanjaTest.EditIndex = -1; }

        if (efekt != 0)
        {
            IspolniGridView(ddlTestoviTest.SelectedItem.Value.ToString().Trim());
        }
      
    
    }

    protected void IspolniGridView( string testID)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "SELECT * FROM Question WHERE TestID=@testid AND Email=@email";
        string mailot = (string)Session["KorisnikMail"];
        komanda.Parameters.Add("@email", mailot);
        komanda.Parameters.Add("@testid",testID );
        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();
        try
        {
            konekcija.Open();
            adapter.Fill(ds, "Prasanja");
           
            gvPrasanjaTest.DataSource = ds;
            gvPrasanjaTest.DataBind();
            ViewState["dataset"] = ds;
          

        }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }
        finally { konekcija.Close(); }

        komanda.CommandText = "SELECT * FROM Test WHERE TestID=@testid AND Email=@email";

        try
        {
            konekcija.Open();
             SqlDataReader citac = komanda.ExecuteReader();
             while (citac.Read())
             { lblDescription.Text = citac["Description"].ToString().Trim();

             if (citac["Start"].ToString().Trim().Equals("yes")&&citac["Finished"].ToString().Trim().Equals("no"))
             {
                 lblClassSelect.Visible = false;
                 ddlClass.Visible = false;

                 string[] test_ucenici = citac["StudentsList"].ToString().Trim().Split(';');
                 ViewState["Studentslist"] = citac["StudentsList"].ToString().Trim();
                 for (int i = 0; i < test_ucenici.Length; i++)
                 {
                     lstUcenici.Items.Add(test_ucenici[i]);                 
                 }

                 btnobjavi.Enabled = false;
                 btnsimniobjava.Enabled = true;
                 Info2.Text = "Објавен е Тест !!!";
             }
             
             }     
            citac.Close();

        }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }
        finally { konekcija.Close(); }
    
    }


    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!(ddlTestoviPredmet.SelectedIndex == -1||ddlTestoviPredmet.SelectedItem.Text.Equals(" ")))
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            string[] subject = ddlTestoviPredmet.SelectedItem.Text.Trim().Split(' ');
            string year = subject[subject.Length - 2].ToString();

            if (year.Equals("I")) { year = "1"; }
            if (year.Equals("II")) { year = "2"; }
            if (year.Equals("III")) { year = "3"; }
            if (year.Equals("IV")) { year = "4"; }

            komanda.CommandText = "SELECT * FROM Person WHERE (Year=@year AND Class=@class) AND Status=@status";

            komanda.Parameters.Add("@year", year);
            komanda.Parameters.Add("@class", ddlClass.SelectedItem.Value);
            komanda.Parameters.Add("@status", "ucenik");
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Ucenici");

                gvUcenici.DataSource = ds;
                gvUcenici.DataBind();
                ViewState["datasetucenik"] = ds;


            }
            catch (Exception ex) { lblInformacii.Text = ex.Message; }
            finally { konekcija.Close(); }
            lstUcenici.Visible = true;
            gvUcenici.Visible = true;
            gvPrasanjaTest.Visible = true;

            // od ocenuvanjeto da se isklucat

            gvPoeni.Visible = false;
            ddlTestedStudents.Visible = false;
            lblUcenikInformacii.Visible = false;
            lblizberiucenikprasanje.Visible = false;
        }

    }
    protected void ddlChooseSubject_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvUcenici_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListItem i = new ListItem();
        i.Text = gvUcenici.SelectedRow.Cells[0].Text.Trim() + " " + gvUcenici.SelectedRow.Cells[1].Text.Trim();
        i.Value = gvUcenici.SelectedRow.Cells[2].Text.Trim();
        if (lstUcenici.Items.Count != 0)
        {
            int a = 0;
            for (int p = 0; p < lstUcenici.Items.Count; p++)
            {
                if (lstUcenici.Items[p].Value.Trim() == i.Value) { a = 1; }
                
            }
            if (a == 0) { lstUcenici.Items.Add(i); }


        }
        else { lstUcenici.Items.Add(i); }
    }
  
  
    protected void lstUcenici_SelectedIndexChanged(object sender, EventArgs e)
    {
        lstUcenici.Items.RemoveAt(lstUcenici.SelectedIndex);

    }
    protected void btnobjavi_Click(object sender, EventArgs e)
    {
        string studentlist="";
        if (lstUcenici.Items.Count != 0)
        {
            for (int i = 0; i < lstUcenici.Items.Count; i++)
            {

                studentlist += lstUcenici.Items[i].Value.Trim() + ";";

            }
            /// proverka dali za nekoj od ucenicite e veke objaven test !!! 
            string info=VekeObjavenTestzaUcenikTest(studentlist);
            // AKO NIKOJ OD IZBRANITE KORISNICI NE SE TESTIRA MOMENTALNO PRODOLZI AKO NE E TAKA ISPISI PORAKA
            if (info.Equals(""))
            {
                ViewState["Studentslist"] = studentlist;
                SqlConnection konekcija = new SqlConnection();
                konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

                SqlCommand komanda = new SqlCommand();
                komanda.Connection = konekcija;

                komanda.CommandText = "UPDATE Test SET StudentsList=@studentList,Start=@start,Finished=@finished,Class=@class" +
                                               " WHERE TestID=@testID AND Email=@email";

                komanda.Parameters.Add("@studentList", studentlist);
                komanda.Parameters.Add("@start", "yes");
                komanda.Parameters.Add("@testID", ddlTestoviTest.SelectedItem.Value.ToString().Trim());
                string mailot = (string)Session["KorisnikMail"];
                komanda.Parameters.Add("@email", mailot);
                komanda.Parameters.Add("@class", ddlClass.SelectedItem.Value);
                komanda.Parameters.Add("@finished", "no");
                int rows = 0;
                try
                {
                    konekcija.Open();
                    rows = komanda.ExecuteNonQuery();


                }
                catch (Exception ex) { Info2.Text = ex.ToString(); rows = 0; }
                finally
                {
                    konekcija.Close(); if (rows != 1) { Info2.Text = "Грешка"; } else { Info2.Text = "Успешен старт !"; btnobjavi.Enabled = false; btnsimniobjava.Enabled = true; }


                }


                string id_test = ddlTestoviTest.SelectedItem.Value.ToString().Trim();
                string[] uceniclista = studentlist.Trim().Split(';');
                komanda.Parameters.Clear();
                for (int i = 0; i < uceniclista.Length; i++)
                {



                    string ucenik = uceniclista[i].Trim();
                    komanda.CommandText = "UPDATE Person SET ActiveTestID=@activetestID" +
                                           " WHERE Email=@em";
                    komanda.Parameters.Add("@activetestID", id_test);
                    komanda.Parameters.Add("@em", ucenik);
                    if (!(ucenik.Equals("") || ucenik.Equals(" ")))
                    {
                        try
                        {
                            konekcija.Open();
                            rows = komanda.ExecuteNonQuery();


                        }
                        catch (Exception ex) { Info2.Text = ex.ToString(); rows = 0; }
                        finally
                        {
                            konekcija.Close(); if (rows == 0) { Info2.Text = "Грешка во испраќање на пораки за активен тест !!!"; }


                        }


                    }
                    komanda.Parameters.Clear();

                }





            }
            else { Info2.Text = "За корисниците: " + info + " веќе е објавен тест. Избришете ги од листата за тестирање или обидете се ПОДОЦНА !!!"; }



        } // else poraka za greska
        else { Info2.Text = "Немате внесено ученици за да го објавите тестот !!!"; }


    }

    protected string VekeObjavenTestzaUcenikTest(string listaUcenici)
    {
        string InfoResponse="";

        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "SELECT * FROM Person" +
                                       " WHERE Email=@email";       
      
      
             string[] uceniclista = listaUcenici.Trim().Split(';');         
             
        for (int i = 0; i < uceniclista.Length; i++)
            {

            komanda.Parameters.Clear();
        komanda.Parameters.Add("@email", uceniclista[i]);
       
      try{
         konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {


                    if (!(citac["ActiveTestID"].ToString().ToLower().Equals("") ||citac["ActiveTestID"].ToString().ToLower().Equals(" ")))
                    {

                        InfoResponse+=uceniclista[i]+";";                       

                        
                    }

                }
                citac.Close();
            }
          
        
         
        catch (Exception ex) { Info2.Text = ex.ToString();  }
        finally
        {
            konekcija.Close(); 
      }

        }

        return InfoResponse;

            
        
    
    }


    protected void btnsimniobjava_Click(object sender, EventArgs e)
    {
        

        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;
      
        
        komanda.CommandText = "UPDATE Test SET StudentsList=@studentList,Start=@start,Finished=@finished" +
                                       " WHERE TestID=@testID AND Email=@email";


        string id_test = ddlTestoviTest.SelectedItem.Value.ToString().Trim();
        komanda.Parameters.Add("@studentList","");
        komanda.Parameters.Add("@start", "no");
        komanda.Parameters.Add("@testID", id_test);
        string mailot = (string)Session["KorisnikMail"];
        komanda.Parameters.Add("@email", mailot);       
        komanda.Parameters.Add("@finished", "yes");
        int rows = 0;
        try
        {
            konekcija.Open();
            rows = komanda.ExecuteNonQuery();


        }
        catch (Exception ex) { Info2.Text = ex.ToString(); rows = 0; }

        finally
        {
            konekcija.Close(); 
            
            if (rows != 1) { Info2.Text = "Грешка"; }
            else
            {
                lstUcenici.Items.Clear();
                btnobjavi.Enabled = true;
                btnsimniobjava.Enabled = false;
                lblClassSelect.Visible = true;
                ddlClass.Visible = true;
                Info2.Text = "Тестот е симнат од објава !!!";
                btnPregledajRezultati.Enabled = true;
            }


        }

        /// brishenje na aktiven test kaj soodvetnite ucenici koi sto se testiraat
        string uceniciL = (string)ViewState["Studentslist"];
        string[] uceniclista = uceniciL.Trim().Split(';');
        komanda.Parameters.Clear();
        for (int i = 0; i < uceniclista.Length; i++)
        {



            string ucenik = uceniclista[i].Trim();
            komanda.CommandText = "UPDATE Person SET ActiveTestID=@activetestID" +
                                   " WHERE Email=@em";
            komanda.Parameters.Add("@activetestID", " ");
            komanda.Parameters.Add("@em", ucenik);
            if (!(ucenik.Equals("") || ucenik.Equals(" ")))
            {
                try
                {
                    konekcija.Open();
                    rows = komanda.ExecuteNonQuery();


                }
                catch (Exception ex) { Info2.Text = ex.ToString(); rows = 0; }
                finally
                {
                    konekcija.Close(); if (rows == 0) { Info2.Text = "Грешка во испраќање на пораки за симинање на тест до учениците !!!"; }


                }


            }
            komanda.Parameters.Clear();

        }

        
    }
    protected void gvPrasanjaTest_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnPregledajRezultati_Click(object sender, EventArgs e)
    {
        pnlPrasanjaTest.Visible = false;
        pnlOcenkiPoeni.Visible = true;
        lstUcenici.Visible = false;
        gvUcenici.Visible = false;
        ddlClass.SelectedIndex = -1;
        lblUcenikInformacii.Visible = false;
        gvPoeni.Visible = false;
        ddlTestedStudents.Visible = true;
        lblUcenikInformacii.Visible = false;
        
        lblizberiucenikprasanje.Visible = true;

        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;        

        komanda.CommandText = "SELECT DISTINCT Email FROM Answer WHERE TestID=@tid ";

        komanda.Parameters.Add("@tid", ddlTestoviTest.SelectedItem.Value.ToString().Trim());
        ddlTestedStudents.Items.Clear();
        ddlTestedStudents.Items.Add(" ");
        try
        {
            konekcija.Open();
            SqlDataReader citac = komanda.ExecuteReader();
            while (citac.Read())
            {


                ddlTestedStudents.Items.Add(citac["Email"].ToString().ToLower().Trim());       

                              
            }
            citac.Close();
        }
        catch (Exception ex) { lblUcenikInformacii.Text = ex.ToString(); }

        finally { konekcija.Close(); }     
        
        
    



    }
    protected void ddlTestedStudents_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddlTestedStudents.SelectedItem.Text.ToString().Equals(" "))
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;

            komanda.CommandText = "SELECT * FROM Person WHERE Email=@em";

            komanda.Parameters.Add("@em", ddlTestedStudents.SelectedItem.Text.ToString().Trim());

            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {

                    lblUcenikInformacii.Text = "Резултaти од ученикот: " + citac["Name"].ToString().Trim() + " " + citac["Surname"].ToString().Trim() + " од " + citac["Year"].ToString().Trim() + "-" + citac["Class"].ToString().Trim() + " клас !";

                }
                citac.Close();
            }
            catch (Exception ex) { lblUcenikInformacii.Text = ex.ToString(); }

            finally { konekcija.Close(); }

            

            /// se povikuva ispolnuvanje na gridview so ocenikite 


            IspolniOcenki(ddlTestedStudents.SelectedItem.Text.ToString().Trim());



        }
    }

    protected void IspolniOcenki(string email)
    {

        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "SELECT Answer.AnswerID,Question.QuestionContent,Answer.Answer,Answer.Points AS 'AP',Question.Points AS 'QP' FROM  Answer INNER JOIN Question ON Answer.TestID=Question.TestID WHERE (Answer.TestID=@tid AND Answer.Email=@em) AND Answer.AnswerID=Question.QuestionID ORDER BY Answer.AnswerID";
        komanda.Parameters.Add("@tid", ddlTestoviTest.SelectedItem.Value.ToString().Trim());
        komanda.Parameters.Add("@em", email);

        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();

        try
        {
            konekcija.Open();
            adapter.Fill(ds, "Ucenici Odgovori Poeni");

           gvPoeni.DataSource = ds;
            gvPoeni.DataBind();
            ViewState["datasetpoeni"] = ds;


        }
        catch (Exception ex) { lblUcenikInformacii.Text = ex.Message; }
        finally { konekcija.Close(); gvPoeni.Visible = true; lblUcenikInformacii.Visible = true; }


        /// proveri ocenki   
    
    
    
    
    
    
    }

    protected void gvPoeni_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["datasetpoeni"];
        gvPoeni.EditIndex = e.NewEditIndex;
        gvPoeni.DataSource = ds;
        gvPoeni.DataBind();
    }
    protected void gvPoeni_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "UPDATE Answer SET Points=@points" +
                                        " WHERE (TestID=@testID AND Email=@email) AND AnswerID=@ai";

        TextBox tb = (TextBox)gvPoeni.Rows[e.RowIndex].Cells[4].Controls[0];
        komanda.Parameters.AddWithValue("@points", tb.Text.Trim());

        string st = gvPoeni.Rows[e.RowIndex].Cells[0].Text.Trim();
        komanda.Parameters.AddWithValue("@ai", st);     

        

        ///   tb = (TextBox)gvPrasanjaTest.Rows[e.RowIndex].Cells[4].Controls[0];
        komanda.Parameters.AddWithValue("@testID", ddlTestoviTest.SelectedItem.Value.ToString().Trim());
       
       string mailot=ddlTestedStudents.SelectedItem.Text.ToString().Trim();
        komanda.Parameters.Add("@email", mailot);

        int efekt = 0;
        try
        {

            konekcija.Open();
            efekt = komanda.ExecuteNonQuery();

        }
        catch (Exception ex) { lblUcenikInformacii.Text = ex.Message; }

        finally { konekcija.Close(); gvPoeni.EditIndex = -1; }

        if (efekt != 0)
        {
            IspolniOcenki(mailot);
        }
    }
    protected void gvPoeni_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvPoeni_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["datasetpoeni"];
       gvPoeni.EditIndex = -1;
        gvPoeni.DataSource = ds;
        gvPoeni.DataBind();
    }
}