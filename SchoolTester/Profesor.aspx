<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Profesor.aspx.cs" Inherits="Profesor" %>

<%@ Register src="QuestionControl.ascx" tagname="QuestionControl" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
        .style1
        {
            
            width:230px;height:40px;-webkit-border-radius: 89px 93px 80px 99px;-moz-border-radius: 89px 93px 80px 99px;border-radius: 89px 93px 80px 99px;border:9px solid #BAC3D;background-color:#FFFFFF;-webkit-box-shadow: #ACADB0 53px 53px 53px;-moz-box-shadow: #ACADB0 7px 7px 7px;-moz-box-shadow: #ACADB0 7px 7px 7px; box-shadow: #ACADB0 7px 7px 7px
        }
          body 
        { background-image:url(Logo/brushed.png);
          background-repeat:repeat;
          font-family:Verdana;
                     
            }
        .prav
        {
            
            width:330px;height:100px;-webkit-border-radius: 0px;-moz-border-radius: 0px;border-radius: 0px;border:1px solid #BAC3D4;background-color:#FFFFFF;-webkit-box-shadow: #ACADB0 7px 7px 7px;-moz-box-shadow: #ACADB0 7px 7px 7px; box-shadow: #ACADB0 7px 7px 7px;
        }
         .ddl
        {
            
            width:250px;height:40px;-webkit-border-radius: 0px;-moz-border-radius: 0px;border-radius: 0px;border:1px solid #BAC3D4;background-color:#FFFFFF;-webkit-box-shadow: #ACADB0 7px 7px 7px;-moz-box-shadow: #ACADB0 7px 7px 7px; box-shadow: #ACADB0 7px 7px 7px;
        }
        .txt
        {
            
             width:180px;height:22px;-webkit-border-radius: 89px 93px 80px 99px;-moz-border-radius: 89px 93px 80px 99px;border-radius: 89px 93px 80px 99px;border:9px solid #BAC3D;background-color:#FFFFFF;-webkit-box-shadow: #FFFFFF 53px 53px 53px;-moz-box-shadow: #ACADB0 7px 7px 7px;-moz-box-shadow: #ACADB0 7px 7px 7px; box-shadow: #ACADB0 7px 7px 7px
        }
         .ddlsmall
        {
            
             width:45px;height:27px;-webkit-border-radius: 89px 93px 80px 99px;-moz-border-radius: 89px 93px 80px 99px;border-radius: 89px 93px 80px 99px;border:9px solid #BAC3D;background-color:#FFFFFF;-webkit-box-shadow: #ACADB0 53px 53px 53px;-moz-box-shadow: #ACADB0 7px 7px 7px;-moz-box-shadow: #ACADB0 7px 7px 7px; box-shadow: #ACADB0 7px 7px 7px
        }
           
          
         
    
        
        
        
            .novoKopce
                {
                    white-space: nowrap;
font-weight: 400;
position: relative;
font-size: 13px;
background-color: #239cd3;
background-image: -webkit-gradient(linear, top, color-stop(0, #2dace3), color-stop(1, #239cd3));
background-image: -webkit-linear-gradient(top, #2dace3, #239cd3);
background-image: -moz-linear-gradient(top, #2dace3, #239cd3);
background-image: -ms-linear-gradient(top, #2dace3, #239cd3);
background-image: -o-linear-gradient(top, #2dace3, #239cd3);
filter: progid:DXImageTransform.Microsoft.gradient(GradientType = 0, startColorStr = #2dace3, EndColorStr = #239cd3);
filter: none;
-moz-border-radius-topleft: 8px;
-moz-border-radius-topright: 8px;
-moz-border-radius-bottomleft: 8px;
-moz-border-radius-bottomright: 8px;
-webkit-border-top-left-radius: 8px;
-webkit-border-top-right-radius: 8px;
-webkit-border-bottom-right-radius: 8px;
-webkit-border-bottom-left-radius: 8px;
border-top-left-radius: 8px;
border-top-right-radius: 8px;
border-bottom-right-radius: 8px;
border-bottom-left-radius: 8px;
display: -moz-inline-box;
-moz-box-orient: vertical;
display: inline-block;
text-shadow: 1px 1px 3px rgba(0,0,0,0.6);
border-style: solid;
border-width: 1px;
border-top-color: #5ea5c3;
border-bottom-color: #3790b8;
border-left-color: #6aafcb;
border-right-color: #7bb4ca;
color: #fff;
padding: 6px 14px;
margin: 0 5px;                    
                    
                    
                    }
                    
                    .novoKopce:hover
                    {
border-style: solid;
border-width: 1px;
border-top-color: #5ea5c3;
border-bottom-color: #5ea5c3;
border-left-color: #5ea5c3;
border-right-color: #5ea5c3;
-webkit-box-shadow: 0 1px 2px rgba(0,0,0,0.2);
-moz-box-shadow: 0 1px 2px rgba(0,0,0,0.2);
box-shadow: 0 1px 2px rgba(0,0,0,0.2);
background-color: #2992c3;
background-image: -webkit-gradient(linear, top, color-stop(0, #61b7de), color-stop(1, #2992c3));
background-image: -webkit-linear-gradient(top, #61b7de, #2992c3);
background-image: -moz-linear-gradient(top, #61b7de, #2992c3);
background-image: -ms-linear-gradient(top, #61b7de, #2992c3);
background-image: -o-linear-gradient(top, #61b7de, #2992c3);
filter: progid:DXImageTransform.Microsoft.gradient(GradientType = 0, startColorStr = #61b7de, EndColorStr = #2992c3);
filter: none;
color: #fff;
}
        
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table   align=center>
     <tr>
     <td align=right>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblLogin" runat="server"></asp:Label>
        <asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click" 
            Text="Одјави се"  CssClass=novoKopce/>   
           </td> </tr>
          
    <tr><td align=center>
    <asp:Button ID="btnSubjectsPreview" runat="server" Text="Види Мои Предмети" 
        onclick="btnSubjectsPreview_Click" CssClass=novoKopce/>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="btnNewTest" runat="server" onclick="btnNewTest_Click" 
            Text="Креирај Нов Тест"  CssClass=novoKopce/>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnMoiTestovi" runat="server" Text="Мои Тестови" 
        onclick="btnMoiTestovi_Click" CssClass=novoKopce/>
      </td>  </tr>
        </table>
        <table align=center>
        <tr>
        <td>
      
    <asp:Panel ID="pnlDodadiPredmeti" runat="server" Height="37px" >
   
       <table>
       <tr>
       <td>
       <p>
    </p>
    <p>
    </p>
       </td>
       </tr>
       <tr>
       <td> 
        Мои предмети:
        </td>
        <td>Предмет / Опис:
        </td>
        <td>
        Година:
        </td>
        </tr>
        <tr>
        <td>
         <asp:ListBox ID="lstPredmeti" runat="server" AutoPostBack="True" Height="98px" 
            onselectedindexchanged="lstPredmeti_SelectedIndexChanged"  CssClass=prav>
        </asp:ListBox>

        </td>
         <td>
         <asp:TextBox ID="txtPredmetDodadi" runat="server" AutoPostBack="True" 
            Width="321px" CssClass=txt></asp:TextBox>

          </td>
        <td>
         <asp:DropDownList ID="ddlYear" runat="server" CssClass=ddlsmall>
            <asp:ListItem Value="1">I</asp:ListItem>
            <asp:ListItem Value="2">II</asp:ListItem>
            <asp:ListItem Value="3">III</asp:ListItem>
            <asp:ListItem Value="4">IV</asp:ListItem>
        </asp:DropDownList>

        </td>
        <td>
         <asp:Button ID="btnDodadiPredmet" runat="server" 
            onclick="btnDodadiPredmet_Click" Text="Додади предмет во Листа" 
            CssClass=novoKopce/>

        </td>
        <td>
         <asp:Button ID="btnRemoveSubject" runat="server" 
            onclick="btnRemoveSubject_Click" Text="Избриши предмет од листа" 
            CssClass=novoKopce />
        </td>
        </tr> 
        <tr>
        <td>
        <p></p>
        </td>
        </tr>   
        <tr>      
        
        <td>
         <asp:Button ID="zacuvajListaPredmeti" runat="server" 
            onclick="zacuvajListaPredmeti_Click" Text="Зачувај Листа на Предмети" 
            CssClass=novoKopce />
        </td>
        <td>
       <asp:Label ID="lblInfoSubjects" runat="server"></asp:Label>
        </td>
        </tr>   
                
             

   
    </table>
     </asp:Panel>
   </td>
   <td>        
    
   
    <asp:Panel ID="pnlNewTest" runat="server" ForeColor="Black" Height="159px" 
        style="margin-top: 0px">
        <table>
        <tr>
        <td>
       <asp:Label ID="lblIzberiPredmet" runat="server" Text=" Избери Предмет:" 
            Visible="False" ForeColor="Black"></asp:Label>
            </td>
      <td>
        <asp:Label ID="lblDatum" runat="server" Text=" Датум на Тестот " 
            Visible="False" ForeColor="Black"></asp:Label>
            </td>
    <td>
        <asp:Label ID="lblOpisTest" runat="server" Text=" Опис на Тестот " 
            Visible="False" ForeColor="Black"></asp:Label>
            </td>
                <td>        
        <asp:Label ID="lblBrojNaPrasanja" runat="server" Text="Внеси број на прашања: " 
            Visible="False" ForeColor="Black"></asp:Label>
       </td>
            </tr>
            <tr>
            <td>        
        <asp:DropDownList ID="ddlChooseSubject" runat="server" Height="38px" 
            Visible="False" Width="300px" 
            onselectedindexchanged="ddlChooseSubject_SelectedIndexChanged" CssClass=ddl>
        </asp:DropDownList>
        </td>
        <td>
        <asp:TextBox ID="txtDatum" runat="server" Visible="False" Width="144px" CssClass=txt></asp:TextBox>
       </td>
       <td>
        <asp:TextBox ID="txtOpisTest" runat="server" Height="40px" TextMode="MultiLine" 
            Visible="False" Width="250px" CssClass=txt></asp:TextBox>
            </td>
            <td>
        <asp:TextBox ID="txtBrojNaPrasanja" runat="server" Height="22px" 
            Visible="False" Width="102px" CssClass=txt></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td>
            <p></p>
            </td>
            </tr>
            <tr>
        
       
            <td>    
        <asp:Button ID="btnZacuvajKarakteristiki" runat="server" 
            onclick="btnZacuvajKarakteristiki_Click" Text="Зачувај Карактеристики" 
            Visible="False" CssClass=novoKopce />
       </td>
       <td>
        <asp:Label ID="lblZacuvajKarakteristiki" runat="server"></asp:Label>
        </td>
        </tr>
        </table>
    </asp:Panel>
    </td>
   
      
    <td>
    <asp:Panel ID="pnlMoiTestovi" runat="server" Height="399px" Width="1000px">
          <table   align=center>
     <tr>
     <td>Избери Предмет:</td> 
     <td> Избери Тест: </td>
    <td> <asp:Label ID="lblClassSelect" runat="server" 
            Text="Избери клас: "></asp:Label> </td>
     </tr>
     <tr>
     <td>
       
        <asp:DropDownList ID="ddlTestoviPredmet" runat="server" AutoPostBack="True" 
            Height="38px" onselectedindexchanged="ddlTestoviPredmet_SelectedIndexChanged" 
            style="margin-bottom: 0px" Width="300px" CssClass=ddl>
        </asp:DropDownList>
        </td>
        <td>
      
        <asp:DropDownList ID="ddlTestoviTest" runat="server" AutoPostBack="True" 
            Height="40px" onselectedindexchanged="ddlTestoviTest_SelectedIndexChanged" 
            Width="250px" CssClass=ddl>
        </asp:DropDownList>
        </td>
        <td>

          <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlClass_SelectedIndexChanged" CssClass=ddlsmall>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
        </asp:DropDownList>

        </td>
        <td>
        
        <asp:Label ID="lblInformacii" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td>
 <asp:Label ID="lblDescription" runat="server"></asp:Label>

        </td>
        </tr>
        <tr>
        <td>
          
 <p>
 </p>
      
        </td>
        </tr>
        <tr>      
           <td>
       <asp:Button ID="btnobjavi" runat="server" Text="Објави тест" 
            onclick="btnobjavi_Click" CssClass=novoKopce/>
            
       <asp:Label ID="Info2" runat="server"></asp:Label>
        </td>
        <td>
        <asp:Button ID="btnsimniobjava" runat="server" Enabled="False" 
            onclick="btnsimniobjava_Click" Text="Симни го од објава тестот" CssClass=novoKopce/>
      </td>
      <td>
       
        <asp:Button ID="btnPregledajRezultati" runat="server" 
            Text="Прегледај Резултати" onclick="btnPregledajRezultati_Click" CssClass=novoKopce/>
      </td>
      </tr>
        </table>


        <table align=center>
        <tr>
        <td>
        <asp:ListBox ID="lstUcenici" runat="server" AutoPostBack="True" 
            onselectedindexchanged="lstUcenici_SelectedIndexChanged" Width="349px">
        </asp:ListBox>
        </td>
        </tr>
        
        <tr>
        <td>

        <asp:GridView ID="gvUcenici" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Vertical" 
            onselectedindexchanged="gvUcenici_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Име" />
                <asp:BoundField DataField="Surname" HeaderText="Презиме" />
                <asp:BoundField DataField="Email" HeaderText="Е-маил" />
                <asp:CommandField HeaderText="Додади" SelectText="Додади" 
                    ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>        
        </td>
        </tr>
        </asp:Panel>
         </td>
   </tr>
   <tr>
   <td>
   <!--
   <table align=left>
   <tr>
   <td align=center> ---->
  
          <asp:Panel ID="pnlPrasanjaTest" runat="server" >
          <p>
          </p>
        <asp:GridView ID="gvPrasanjaTest" runat="server" AutoGenerateColumns="False" 
            BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
            CellPadding="4" CellSpacing="2" ForeColor="Black" 
            onrowcancelingedit="gvPrasanjaTest_RowCancelingEdit" 
            onrowediting="gvPrasanjaTest_RowEditing" 
            onrowupdating="gvPrasanjaTest_RowUpdating" 
            onselectedindexchanged="gvPrasanjaTest_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="QuestionID" HeaderText="Прашање" ReadOnly="True">
                <FooterStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="QuestionType" HeaderText="Тип на прашање">
                <FooterStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="QuestionContent" HeaderText="Содржина на Прашање">
                <FooterStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="PossibleOptions" 
                    HeaderText="Можни одговори (избор, дополнување)">
                <FooterStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Points" HeaderText="Поени">
                </asp:BoundField>
                <asp:BoundField DataField="TestID" HeaderText="Тест" ReadOnly="True">
                <FooterStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField CancelText="Откажи" EditText="Уреди" SelectText="Селектирај" 
                    ShowEditButton="True" UpdateText="Промени" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </asp:Panel>
<!--
     </td>
   </tr>
   <tr>
   <td>
   -->

   </td>
   <td>

   


   

    <asp:Panel ID="pnlOcenkiPoeni" runat="server">
        <asp:Label ID="lblizberiucenikprasanje" runat="server" Text="Избери ученик :"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="ddlTestedStudents" runat="server" AutoPostBack="True" 
            Height="38px" onselectedindexchanged="ddlTestedStudents_SelectedIndexChanged" 
            Width="250px" CssClass=ddl>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblUcenikInformacii" runat="server" Text=""></asp:Label>
        <br />
        <asp:GridView ID="gvPoeni" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" onrowcancelingedit="gvPoeni_RowCancelingEdit" 
            onrowediting="gvPoeni_RowEditing" onrowupdating="gvPoeni_RowUpdating" 
            onselectedindexchanged="gvPoeni_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="AnswerID" HeaderText="Реден број" ReadOnly="True" />
                <asp:BoundField DataField="QuestionContent" HeaderText="Прашање" 
                    ReadOnly="True" />
                <asp:BoundField DataField="Answer" HeaderText="Одговор" ReadOnly="True" />
                <asp:BoundField DataField="QP" HeaderText="Мах. Поени" ReadOnly="True" />
                <asp:BoundField DataField="AP" HeaderText="Поени" />
                <asp:CommandField CancelText="Откажи" EditText="Оцени" ShowEditButton="True" 
                    UpdateText="Додади поени" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
        </asp:Panel>
        <!--
</td>
   </tr>
   </table>
   -->
   </td>
   </tr>
   
   </table>

    </form>
   
    <p>
        &nbsp;</p>
   
    </body>
</html>
