using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Administrator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

           lblLogin.Text = "Добредојде " + (string)Session["Korisnik"];
        }
      
    }

    protected void ResetView()
    {
        gvAnswer.Visible = false;
        gvPerson.Visible = false;
        gvQuestion.Visible = false;
        gvTest.Visible = false;
        gvApprove.Visible = false;
        lblInformacii.Text = " ";
    
    }


    protected void IspolniGvApprove()
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;


        komanda.CommandText = "SELECT * FROM Approve";

        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();

        try
        {
            konekcija.Open();
            adapter.Fill(ds, "Approve");

            gvApprove.DataSource = ds;
            gvApprove.DataBind();
            ViewState["datasetapprove"] = ds;

            //

       }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }
        finally { konekcija.Close(); }
    }

    protected void IspolniGvQuestion()
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;


        komanda.CommandText = "SELECT * FROM Question";

        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();

        try
        {
            konekcija.Open();
            adapter.Fill(ds, "Question");

            gvQuestion.DataSource = ds;
            gvQuestion.DataBind();
            ViewState["datasetquestion"] = ds;

            //





        }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }
        finally { konekcija.Close(); }
    
    
    
    
    
    }
    protected void IspolniGvTest()
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;


        komanda.CommandText = "SELECT * FROM Test";

        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();

        try
        {
            konekcija.Open();
            adapter.Fill(ds, "Question");

            gvTest.DataSource = ds;
            gvTest.DataBind();
            ViewState["datasettest"] = ds;

            //





        }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }
        finally { konekcija.Close(); }





    }


    protected void IspolniGvPerson()
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;


        komanda.CommandText = "SELECT * FROM Person";      

        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();

        try
        {
            konekcija.Open();
            adapter.Fill(ds, "Person");

            gvPerson.DataSource = ds;
            gvPerson.DataBind();
            ViewState["datasetperson"] = ds;

            //
           




        }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }
        finally { konekcija.Close(); }
    
    
    
    
    
    }

    protected void IspolniGvAnswer()
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;


        komanda.CommandText = "SELECT * FROM Answer";

        SqlDataAdapter adapter = new SqlDataAdapter(komanda);
        DataSet ds = new DataSet();

        try
        {
            konekcija.Open();
            adapter.Fill(ds, "Answer");

            gvAnswer.DataSource = ds;
            gvAnswer.DataBind();
            ViewState["datasetanswer"] = ds;

            //





        }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }
        finally { konekcija.Close(); }





    }




    protected void ddlTabeli_SelectedIndexChanged(object sender, EventArgs e)
    {
        ResetView();
        if (ddlTabeli.SelectedItem.Text.Equals("Person"))
        {
            IspolniGvPerson(); gvPerson.Visible = true; // reset na ostanatite
        }

        if (ddlTabeli.SelectedItem.Text.Equals("Answer"))
        {
            IspolniGvAnswer(); gvAnswer.Visible = true; // reset na ostanatite
        }

        if (ddlTabeli.SelectedItem.Text.Equals("Question"))
        {
            IspolniGvQuestion(); gvQuestion.Visible = true; // reset na ostanatite
        }
        if (ddlTabeli.SelectedItem.Text.Equals("Test"))
        {
            IspolniGvTest(); gvTest.Visible = true; // reset na ostanatite
        }
        if (ddlTabeli.SelectedItem.Text.Equals("Approve"))
        {
            IspolniGvApprove(); gvApprove.Visible = true; // reset na ostanatite
        }
      
    }
 
   
    
    protected void gvPerson_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["datasetperson"];
      
        gvPerson.EditIndex = e.NewEditIndex;
        gvPerson.DataSource = ds;
        gvPerson.DataBind();       


    }
    protected void gvPerson_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["datasetperson"];
        gvPerson.EditIndex = -1;
        gvPerson.DataSource = ds;
        gvPerson.DataBind();
    }
    protected void gvPerson_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "UPDATE Person SET Name=@name,Surname=@surname,Status=@status,Password=@password,Email=@email,Year=@year,Class=@class,Subjects=@subjects,ActiveTestID=@activetestid WHERE PID=@pid";


        string str = (string)gvPerson.Rows[e.RowIndex].Cells[0].Text;
        komanda.Parameters.AddWithValue("@pid", str.Trim());

       TextBox tb = (TextBox)gvPerson.Rows[e.RowIndex].Cells[1].Controls[0];
        komanda.Parameters.AddWithValue("@name", tb.Text.Trim());

        tb = (TextBox)gvPerson.Rows[e.RowIndex].Cells[2].Controls[0];
        komanda.Parameters.AddWithValue("@surname", tb.Text.Trim());

        tb = (TextBox)gvPerson.Rows[e.RowIndex].Cells[3].Controls[0];
        komanda.Parameters.AddWithValue("@status", tb.Text.Trim());

        tb = (TextBox)gvPerson.Rows[e.RowIndex].Cells[4].Controls[0];
        komanda.Parameters.AddWithValue("@password", tb.Text.Trim());

        tb = (TextBox)gvPerson.Rows[e.RowIndex].Cells[5].Controls[0];
        komanda.Parameters.AddWithValue("@email", tb.Text.Trim());

        tb = (TextBox)gvPerson.Rows[e.RowIndex].Cells[6].Controls[0];
        komanda.Parameters.AddWithValue("@year", tb.Text.Trim());

        tb = (TextBox)gvPerson.Rows[e.RowIndex].Cells[7].Controls[0];
        komanda.Parameters.AddWithValue("@class", tb.Text.Trim());

        tb = (TextBox)gvPerson.Rows[e.RowIndex].Cells[8].Controls[0];  
        
        komanda.Parameters.AddWithValue("@subjects", tb.Text.Trim());

        tb = (TextBox)gvPerson.Rows[e.RowIndex].Cells[9].Controls[0];

        komanda.Parameters.AddWithValue("@activetestid", tb.Text.Trim());

        int efekt = 0;
        try
        {

            konekcija.Open();
            efekt = komanda.ExecuteNonQuery();

        }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }

        finally { konekcija.Close(); }

        if (efekt != 0)
        {
            IspolniGvPerson();
        }
    }
    protected void gvPerson_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "DELETE FROM Person WHERE PID=@pid";

        string str = (string)gvPerson.Rows[e.RowIndex].Cells[0].Text;
        komanda.Parameters.AddWithValue("@pid", str.Trim());

        int efekt = 0;
        try
        {

            konekcija.Open();
            efekt = komanda.ExecuteNonQuery();

        }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }

        finally { konekcija.Close(); }

        if (efekt != 0)
        {
            IspolniGvPerson();
        }

    }
    protected void gvAnswer_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["datasetanswer"];
        gvAnswer.EditIndex = -1;
        gvAnswer.DataSource = ds;
        gvAnswer.DataBind();
    }
    protected void gvAnswer_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "UPDATE Answer SET AnswerType=@answertype,Answer=@answer,Points=@points WHERE (TestID=@testid AND Email=@email) AND AnswerID=@answerid";


        string str = (string)gvAnswer.Rows[e.RowIndex].Cells[0].Text;
        komanda.Parameters.AddWithValue("@testid", str.Trim());

        str = (string)gvAnswer.Rows[e.RowIndex].Cells[1].Text;
        komanda.Parameters.AddWithValue("@email", str.Trim());

        str = (string)gvAnswer.Rows[e.RowIndex].Cells[2].Text;
        komanda.Parameters.AddWithValue("@answerid", Int16.Parse(str));


        TextBox tb = (TextBox)gvAnswer.Rows[e.RowIndex].Cells[3].Controls[0];
        komanda.Parameters.AddWithValue("@answertype", tb.Text.Trim());

        tb = (TextBox)gvAnswer.Rows[e.RowIndex].Cells[4].Controls[0];
        komanda.Parameters.AddWithValue("@answer", tb.Text.Trim());

        tb = (TextBox)gvAnswer.Rows[e.RowIndex].Cells[5].Controls[0];
        komanda.Parameters.AddWithValue("@points", tb.Text.Trim());      

        int efekt = 0;
        try
        {

            konekcija.Open();
            efekt = komanda.ExecuteNonQuery();

        }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }

        finally { konekcija.Close(); }

        if (efekt != 0)
        {
            IspolniGvAnswer();
        }

    }
    protected void gvAnswer_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["datasetanswer"];
      
        gvAnswer.EditIndex = e.NewEditIndex;
        gvAnswer.DataSource = ds;
        gvAnswer.DataBind();   

          
    }
    protected void gvAnswer_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "DELETE FROM Answer WHERE (TestID=@testid AND Email=@email) AND AnswerID=@answerid";

        string str = (string)gvAnswer.Rows[e.RowIndex].Cells[0].Text;
        komanda.Parameters.AddWithValue("@testid", str.Trim());

        str = (string)gvAnswer.Rows[e.RowIndex].Cells[1].Text;
        komanda.Parameters.AddWithValue("@email", str.Trim());

        str = (string)gvAnswer.Rows[e.RowIndex].Cells[2].Text;
        komanda.Parameters.AddWithValue("@answerid", str.Trim());

        int efekt = 0;
        try
        {

            konekcija.Open();
            efekt = komanda.ExecuteNonQuery();

        }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }

        finally { konekcija.Close(); }

        if (efekt != 0)
        {
            IspolniGvAnswer();
        }
    }
    protected void gvQuestion_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["datasetquestion"];
        gvQuestion.EditIndex = -1;
        gvQuestion.DataSource = ds;
        gvQuestion.DataBind();

    }
    protected void gvQuestion_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "UPDATE Question SET QuestionType=@questiontype,QuestionContent=@questioncontent,PossibleOptions=@possibleoptions,Points=@points,Image=@image WHERE (TestID=@testid AND Email=@email) AND QuestionID=@questionid";


        string str = (string)gvQuestion.Rows[e.RowIndex].Cells[0].Text;
        komanda.Parameters.AddWithValue("@testid", str.Trim());

        str = gvQuestion.Rows[e.RowIndex].Cells[1].Text;
        komanda.Parameters.AddWithValue("@email", str.Trim());

        str = gvQuestion.Rows[e.RowIndex].Cells[2].Text;
        komanda.Parameters.AddWithValue("@questionid", str.Trim());

       TextBox tb = (TextBox)gvQuestion.Rows[e.RowIndex].Cells[3].Controls[0];
        komanda.Parameters.AddWithValue("@questiontype", tb.Text.Trim());

        tb = (TextBox)gvQuestion.Rows[e.RowIndex].Cells[4].Controls[0];
        komanda.Parameters.AddWithValue("@questioncontent", tb.Text.Trim());

        tb = (TextBox)gvQuestion.Rows[e.RowIndex].Cells[5].Controls[0];
        komanda.Parameters.AddWithValue("@possibleoptions", tb.Text.Trim());

        tb = (TextBox)gvQuestion.Rows[e.RowIndex].Cells[6].Controls[0];
        komanda.Parameters.AddWithValue("@points", tb.Text.Trim());

        tb = (TextBox)gvQuestion.Rows[e.RowIndex].Cells[7].Controls[0];
        komanda.Parameters.AddWithValue("@image", tb.Text.Trim());
        

        int efekt = 0;
        try
        {

            konekcija.Open();
            efekt = komanda.ExecuteNonQuery();

        }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }

        finally { konekcija.Close(); }

        if (efekt != 0)
        {
            IspolniGvQuestion();
        }
    }
    protected void gvQuestion_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["datasetquestion"];

        gvQuestion.EditIndex = e.NewEditIndex;
        gvQuestion.DataSource = ds;
        gvQuestion.DataBind();

    }
    protected void gvQuestion_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "DELETE FROM Question WHERE (TestID=@testid AND Email=@email) AND QuestionID=@questionid";

        string str = (string)gvQuestion.Rows[e.RowIndex].Cells[0].Text;
        komanda.Parameters.AddWithValue("@testid", str.Trim());

        str = (string)gvQuestion.Rows[e.RowIndex].Cells[1].Text;
        komanda.Parameters.AddWithValue("@email", str.Trim());

        str = (string)gvQuestion.Rows[e.RowIndex].Cells[2].Text;
        komanda.Parameters.AddWithValue("@questionid", str.Trim());

        int efekt = 0;
        try
        {

            konekcija.Open();
            efekt = komanda.ExecuteNonQuery();

        }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }

        finally { konekcija.Close(); }

        if (efekt != 0)
        {
            IspolniGvQuestion();
        }
    }
    protected void gvTest_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "UPDATE Test SET Email=@email,Subject=@subject,Description=@description,StudentsList=@studentslist,Date=@date,Start=@start,Finished=@finished,Class=@class WHERE TestID=@testid";


        string str = (string)gvTest.Rows[e.RowIndex].Cells[0].Text;
        komanda.Parameters.AddWithValue("@testid", str.Trim());


        TextBox tb = (TextBox)gvTest.Rows[e.RowIndex].Cells[1].Controls[0];
        komanda.Parameters.AddWithValue("@email", tb.Text.Trim());

        tb = (TextBox)gvTest.Rows[e.RowIndex].Cells[2].Controls[0];
        komanda.Parameters.AddWithValue("@subject", tb.Text.Trim());

        tb = (TextBox)gvTest.Rows[e.RowIndex].Cells[3].Controls[0];
        komanda.Parameters.AddWithValue("@description", tb.Text.Trim());

        tb = (TextBox)gvTest.Rows[e.RowIndex].Cells[4].Controls[0];
        komanda.Parameters.AddWithValue("@studentslist", tb.Text.Trim());

        tb = (TextBox)gvTest.Rows[e.RowIndex].Cells[5].Controls[0];
        komanda.Parameters.AddWithValue("@date", tb.Text.Trim());

        tb = (TextBox)gvTest.Rows[e.RowIndex].Cells[6].Controls[0];
        komanda.Parameters.AddWithValue("@start", tb.Text.Trim());

        tb = (TextBox)gvTest.Rows[e.RowIndex].Cells[7].Controls[0];
        komanda.Parameters.AddWithValue("@finished", tb.Text.Trim());

        tb = (TextBox)gvTest.Rows[e.RowIndex].Cells[8].Controls[0];
        komanda.Parameters.AddWithValue("@class", tb.Text.Trim());


        int efekt = 0;
        try
        {

            konekcija.Open();
            efekt = komanda.ExecuteNonQuery();

        }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }

        finally { konekcija.Close(); }

        if (efekt != 0)
        {
            IspolniGvTest();
        }

    }
    protected void gvTest_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["datasettest"];

        gvTest.EditIndex = e.NewEditIndex;
        gvTest.DataSource = ds;
        gvTest.DataBind();  
    }
    protected void gvTest_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "DELETE FROM Test WHERE TestID=@testid";

        string str = (string)gvTest.Rows[e.RowIndex].Cells[0].Text;
        komanda.Parameters.AddWithValue("@testid", str.Trim());

        

        int efekt = 0;
        try
        {

            konekcija.Open();
            efekt = komanda.ExecuteNonQuery();

        }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }

        finally { konekcija.Close(); }

        if (efekt != 0)
        {
            IspolniGvTest();
        }
    }
    protected void gvTest_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["datasettest"];
        gvTest.EditIndex = -1;
        gvTest.DataSource = ds;
        gvTest.DataBind();
    }
    protected void gvApprove_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "UPDATE Approve SET Name=@name,Surname=@surname,Status=@status,Password=@password,Email=@email,Year=@year,Class=@class,Subjects=@subjects WHERE PID=@pid";


        string str = (string)gvApprove.Rows[e.RowIndex].Cells[1].Text;
        komanda.Parameters.AddWithValue("@pid", str.Trim());

        TextBox tb = (TextBox)gvApprove.Rows[e.RowIndex].Cells[2].Controls[0];
        komanda.Parameters.AddWithValue("@name", tb.Text.Trim());

        tb = (TextBox)gvApprove.Rows[e.RowIndex].Cells[3].Controls[0];
        komanda.Parameters.AddWithValue("@surname", tb.Text.Trim());

        tb = (TextBox)gvApprove.Rows[e.RowIndex].Cells[4].Controls[0];
        komanda.Parameters.AddWithValue("@status", tb.Text.Trim());

        tb = (TextBox)gvApprove.Rows[e.RowIndex].Cells[5].Controls[0];
        komanda.Parameters.AddWithValue("@password", tb.Text.Trim());

        tb = (TextBox)gvApprove.Rows[e.RowIndex].Cells[6].Controls[0];
        komanda.Parameters.AddWithValue("@email", tb.Text.Trim());

        tb = (TextBox)gvApprove.Rows[e.RowIndex].Cells[7].Controls[0];
        komanda.Parameters.AddWithValue("@year", tb.Text.Trim());

        tb = (TextBox)gvApprove.Rows[e.RowIndex].Cells[8].Controls[0];
        komanda.Parameters.AddWithValue("@class", tb.Text.Trim());

        tb = (TextBox)gvApprove.Rows[e.RowIndex].Cells[9].Controls[0];

        komanda.Parameters.AddWithValue("@subjects", tb.Text.Trim());
       

        int efekt = 0;
        try
        {

            konekcija.Open();
            efekt = komanda.ExecuteNonQuery();

        }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }

        finally { konekcija.Close(); }

        if (efekt != 0)
        {
            IspolniGvApprove();
        }






    }
    protected void gvApprove_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["datasetapprove"];

        gvApprove.EditIndex = e.NewEditIndex;
        gvApprove.DataSource = ds;
       gvApprove.DataBind(); 
    }
    protected void gvApprove_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;

        komanda.CommandText = "DELETE FROM Approve WHERE PID=@pid";

        string str = (string)gvApprove.Rows[e.RowIndex].Cells[1].Text;
        komanda.Parameters.AddWithValue("@pid", Int16.Parse(str));

        int efekt = 0;
        try
        {

            konekcija.Open();
            efekt = komanda.ExecuteNonQuery();

        }
        catch (Exception ex) { lblInformacii.Text = ex.Message; }

        finally { konekcija.Close(); }

        if (efekt != 0)
        {
            IspolniGvApprove();
        }

    }
    protected void gvApprove_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["datasetapprove"];
        gvApprove.EditIndex = -1;
        gvApprove.DataSource = ds;
        gvApprove.DataBind();
    }
    protected void gvApprove_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection konekcija = new SqlConnection();
        konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

        SqlCommand komanda = new SqlCommand();
        komanda.Connection = konekcija;
        string name=gvApprove.SelectedRow.Cells[2].Text;
            string surname=gvApprove.SelectedRow.Cells[3].Text;
                string stats=gvApprove.SelectedRow.Cells[4].Text;
                    string Passs=gvApprove.SelectedRow.Cells[5].Text;
                        string email=gvApprove.SelectedRow.Cells[6].Text;
                            string year=gvApprove.SelectedRow.Cells[7].Text;
                            string klas=gvApprove.SelectedRow.Cells[8].Text;
                                string subjects=gvApprove.SelectedRow.Cells[9].Text;
                  /// pid
                                string pid = gvApprove.SelectedRow.Cells[1].Text;
                                   
        
            //zapisi vo baza   
            komanda.CommandText = "INSERT INTO Person (Name,Surname,Status,Password,Email,Year,Class,Subjects,ActiveTestID) VALUES(@name,@surname,@status,@password,@email,@year,@class,@subjects,@activeTestID)";
            komanda.Parameters.Add("@email",email.Trim() );
            komanda.Parameters.Add("@password", Passs.Trim());
            komanda.Parameters.Add("@name", name.Trim());
            komanda.Parameters.Add("@surname", surname.Trim());
            komanda.Parameters.Add("@status", stats.Trim());
            komanda.Parameters.Add("@activeTestID", "");

            if (stats.Equals("profesor"))
            {
                komanda.Parameters.Add("@year", "");
                komanda.Parameters.Add("@class", "");
            }
            else
            {
                komanda.Parameters.Add("@year", year.Trim());
                komanda.Parameters.Add("@class", klas.Trim());
            }

            komanda.Parameters.Add("@subjects", "");
            int count = 0;
            try
            {
                konekcija.Open();
               count=komanda.ExecuteNonQuery();
            }
            catch (Exception ex) { lblInformacii.Text = ex.ToString(); }
            finally { konekcija.Close(); if (count != 0) { lblInformacii.Text = "Successful Approve !!!"; 
            
            // zapocni brisenje na stavkata vo approve
                          

            komanda.CommandText = "DELETE FROM Approve WHERE PID=@pid";

          
            komanda.Parameters.AddWithValue("@pid", Int16.Parse(pid));

            int efekt = 0;
            try
            {

                konekcija.Open();
                efekt = komanda.ExecuteNonQuery();

            }
            catch (Exception ex) { lblInformacii.Text = ex.Message; }

            finally { konekcija.Close(); }

            if (efekt != 0)
            {
                IspolniGvApprove();
            }
            
            
            
            
            
            
            
            
            
            
            } }
      
        


    }
    protected void btnOdjaviSe_Click(object sender, EventArgs e)
    {
        Session["KorisnikMаil"] = null;

        Session["Korisnik"] = null;
        Session["Status"] = null;
        Response.Redirect("Najava_Registracija.aspx");
    }
}