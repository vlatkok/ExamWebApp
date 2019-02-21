using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

public partial class QuestionControl : System.Web.UI.UserControl
{
     string test_id;
     string emailID;
     int questionID;
   //  int tip;
    protected void Page_Load(object sender, EventArgs e)
    {
        
         lblPrasanjeBr.Text = questionID.ToString(); 
        
    }
    protected void rdb1_CheckedChanged(object sender, EventArgs e)
    {
        txtPrasanje.Visible = true;
        btnDodadiPrasanje.Visible=true;
        txtMozen1.Visible = false;
        txtMozen2.Visible = false;
        txtMozen3.Visible = false;
        txtMozen4.Visible = false;
        txtMozen5.Visible = false;
        lblPraznoPole1.Visible = false;
        lblPraznoPole2.Visible = false;
        lblPraznoPole3.Visible = false;
        lblPraznoPole4.Visible = false;
        lblMessage.Text = "";
        ViewState["tip"]=1;
    }
    protected void rdb2_CheckedChanged(object sender, EventArgs e)
    {
        txtPrasanje.Visible= true;
        btnDodadiPrasanje.Visible = true;
        txtMozen1.Visible = true;
        txtMozen2.Visible = true;
        txtMozen3.Visible = true;
        txtMozen4.Visible = true;
        txtMozen5.Visible = true;
        lblPraznoPole1.Visible = false;
        lblPraznoPole2.Visible = false;
        lblPraznoPole3.Visible = false;
        lblPraznoPole4.Visible = false;
        lblMessage.Text = "";
       // tip = 2;
        ViewState["tip"] = 2;
    }
    protected void rdb3_CheckedChanged(object sender, EventArgs e)
    {
        txtPrasanje.Visible = true;
        btnDodadiPrasanje.Visible = true;
        txtMozen1.Visible = true;
        txtMozen2.Visible = true;
        txtMozen3.Visible = true;
        txtMozen4.Visible = true;
        txtMozen5.Visible = true;
        lblPraznoPole1.Visible = true;
        lblPraznoPole2.Visible = true;
        lblPraznoPole3.Visible = true;
        lblPraznoPole4.Visible = true;
        lblMessage.Text = "";
      //  tip = 3;
        ViewState["tip"] = 3;

    }

    public void Read_TestID_Email_questionID(string tid, string email,int qid)
    {
        test_id = tid;
        emailID = email;
        questionID = qid;       
    }
    protected void btnDodadiPrasanje_Click(object sender, EventArgs e)
    {
        
       /// zapocni proverka dali prethodno ima zacuvano takvo prasanje
        int tip = (int)ViewState["tip"];
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;
        komanda.CommandText = "SELECT * FROM Question WHERE (TestID=@testID AND Email=@email) AND QuestionID=@questionID";
        komanda.Parameters.Add("@testID", test_id);
        komanda.Parameters.Add("@email", emailID);
        komanda.Parameters.Add("@questionID", questionID);

      
        int counter = 0;
        try
        {
            
            konekcija.Open();
            SqlDataReader citac = komanda.ExecuteReader();

            while (citac.Read())
            {


                counter++;


            }
            citac.Close();
        }
        catch (Exception ex) { }
        finally { konekcija.Close(); lblMessage.Text = "Проверка!"; }

        if (counter!=0)
        {

           

            komanda.CommandText = "UPDATE Question SET QuestionType=@questiontype,QuestionContent=@questioncontent,PossibleOptions=@possibleoptions1,Points=@points,Image=@img" +
                                        " WHERE (TestID=@testID AND Email=@email) AND QuestionID=@questionIDD";

           
        
            komanda.Parameters.Add("@questionIDD", questionID.ToString());
            komanda.Parameters.Add("@questiontype", tip);
            komanda.Parameters.Add("@questioncontent", txtPrasanje.Text.Trim());
            komanda.Parameters.Add("@points", txtPoeni.Text.Trim());

            string slika=(string)ViewState["image"];
            if (slika != null)
            { komanda.Parameters.Add("@img", slika); }
            else { komanda.Parameters.Add("@img", "noimg");}
          
            string stringot = "";
            if (tip == 1)
            {
                stringot = " ";
            }
            if (tip == 2)
            {
                stringot = txtMozen1.Text.Trim() + ";" + txtMozen2.Text.Trim() + ";" + txtMozen3.Text.Trim() + ";" + txtMozen4.Text.Trim() + ";" + txtMozen5.Text.Trim();


            }
            if (tip == 3)
            {
                stringot = txtMozen1.Text.Trim() + "<p>" + txtMozen2.Text.Trim() + "<p>" + txtMozen3.Text.Trim() + "<p>" + txtMozen4.Text.Trim() + "<p>" + txtMozen5.Text.Trim();

            }
            komanda.Parameters.Add("@possibleoptions1", stringot);
           
            int rows = 1;

            try
            {
                konekcija.Open();
                rows = komanda.ExecuteNonQuery();


            }
            catch (Exception ex) { lblMessage.Text = ex.ToString(); rows = 0; }

            finally { konekcija.Close(); if (rows != 1) { lblMessage.Text = "Грешка"; } else {lblMessage.Text = "Успешно ажурирање !"; } }

        }
        else
        {

            /// zapocni so zapisuvanje vo bazata na novoto prasanje
            /// 
           
            komanda.CommandText = "INSERT INTO Question (TestID,Email,QuestionID,QuestionType,QuestionContent,PossibleOptions,Points,Image) VALUES(@testID,@email,@questionID2,@questionType,@questionContent,@possibleOptions,@points,@img)";

           
            
            komanda.Parameters.Add("@questionID2", questionID.ToString());
            komanda.Parameters.Add("@questionType", tip);
            komanda.Parameters.Add("@questionContent", txtPrasanje.Text.Trim());
            komanda.Parameters.Add("@points", txtPoeni.Text.Trim());
            string slika = (string)ViewState["image"];
            if (slika != null)
            { komanda.Parameters.Add("@img", slika); }
            else { komanda.Parameters.Add("@img", " "); }

            string stringot = "";
            if (tip == 1)
            {
                stringot = " ";
            }
            if (tip == 2)
            {
                stringot = txtMozen1.Text.Trim() + ";" + txtMozen2.Text.Trim() + ";" + txtMozen3.Text.Trim() + ";" + txtMozen4.Text.Trim() + ";" + txtMozen5.Text.Trim();


            }
            if (tip == 3)
            {
                stringot = txtMozen1.Text.Trim() + "<p>" + txtMozen2.Text.Trim() + "<p>" + txtMozen3.Text.Trim() + "<p>" + txtMozen4.Text.Trim() + "<p>" + txtMozen5.Text.Trim();

            }
            komanda.Parameters.Add("@possibleOptions", stringot);
            int i = 0;
            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();
            }
            catch (Exception ex) { lblMessage.Text = ex.ToString(); i = 1; }
            finally
            {
                konekcija.Close();
                if (i == 0)
                { lblMessage.Text = "Успешно зачувување!"; }
            }
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        
        if (file.HasFile)
        {
            string fname = file.FileName;
            string fpath = Server.MapPath("~/images/");
            int flen = file.PostedFile.ContentLength;
            string fext = Path.GetExtension(fname);
            fext = fext.ToLower();
            string link = "~/images/" + fname;   //this link will be stored in database
            if (flen < 1048576)
            {
                if (fext == ".jpg" || fext == ".png" || fext == ".gif" || fext == ".bmp")
                {
                    file.SaveAs(fpath + fname);
                }
                else
                {
                    Response.Write("<script>alert('Дозволени се само слики !!!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Максимална дозволена големина е 1 MB');</script>");
            }

            //zacuvaj

            ViewState["image"] = link;
            lblSlika.Text = "Сликата беше успешно зачувана во "+link;
        }
        else
        {
            Response.Write("<script>alert('Ве молиме одберете датотека за upload');</script>");
        }
    
    }
}