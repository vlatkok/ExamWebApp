<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ucenik.aspx.cs" Inherits="Ucenik" %>

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
         
                       .novoKopce
                {
                    border-left: 1px solid #6aafcb;
             border-right: 1px solid #7bb4ca;
             border-top: 1px solid #5ea5c3;
             border-bottom: 1px solid #3790b8;
             white-space: nowrap;
             font-weight: 400;
             position: relative;
             font-size: 13px;
             background-color: #239cd3;
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
             border-right-color: #7bb4ca;
             color: #fff;
             padding: 6px 14px;
             background-image: -o-linear-gradient(top, #2dace3, #239cd3);
         }
                    
                    .novoKopce:hover
                    {
         border: 1px solid #5ea5c3;
             -webkit-box-shadow: 0 1px 2px rgba(0,0,0,0.2);
             -moz-box-shadow: 0 1px 2px rgba(0,0,0,0.2);
             box-shadow: 0 1px 2px rgba(0,0,0,0.2);
             background-color: #2992c3;
background-image: -o-linear-gradient(top, #61b7de, #2992c3);
             filter: progid:DXImageTransform.Microsoft.gradient(GradientType = 0, startColorStr = #61b7de, EndColorStr = #2992c3);
             filter: none;
             background-image: -o-linear-gradient(top, #61b7de, #2992c3);
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
            
            width:50px;height:40px;-webkit-border-radius: 0px;-moz-border-radius: 0px;border-radius: 0px;border:1px solid #BAC3D4;background-color:#FFFFFF;-webkit-box-shadow: #ACADB0 7px 7px 7px;-moz-box-shadow: #ACADB0 7px 7px 7px; box-shadow: #ACADB0 7px 7px 7px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table align=right>
    <tr>
    <td align=right>    
    <asp:Label ID="lblLogin" runat="server"></asp:Label>

        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Одјави се" CssClass=novoKopce/>
            </td>
            </tr>
            </table>
    <table align=center>
   <tr>
   <td>
   
   
        <asp:Label ID="lblinfo" runat="server"></asp:Label>
        </td>
        </tr>
    <tr>
    <td>
    
    <asp:Panel ID="pnlAktivenTest" runat="server" Height="112px" Width="697px">
        Активен Тест:<br />&nbsp;&nbsp;<asp:Label ID="lblAktivenTest" runat="server" 
            ForeColor="#CC0000"></asp:Label>
        &nbsp;<br />
        <br />
        <asp:Button ID="btnStartTest" runat="server" onclick="btnStartTest_Click" 
            Text="Старт на тестот"  CssClass=novoKopce/>
        <br />
        <br />
    </asp:Panel>
    </td>
    </tr>
    <tr>
    <td align=left>
    <asp:Panel ID="pnlMoiTestovi" runat="server" Height="139px"  >
        Мои тестови:<br />
        <br />
        <asp:DropDownList ID="ddlTestoviList" runat="server" AutoPostBack="True" 
            Height="40px" onselectedindexchanged="ddlTestoviList_SelectedIndexChanged" 
            Width="188px" CssClass=ddl>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblTestInformacii" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnOdgovori" runat="server" Text="Види Одговори/Резултати" 
            Enabled="False" onclick="btnOdgovori_Click"  CssClass=novoKopce/>
    </asp:Panel>

   </td>
   <td align=right>
   <table align=left>
   <tr>
   
 
   
   
   <td>
      Промени лозинка:<br /></td></tr>
      <tr><td>    Внеси ја старата лозинка:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtOldPassword" runat="server"  CssClass=txt TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtOldPassword" 
            ErrorMessage="Задолжително внесете ја старата лозинка" 
            ValidationGroup="novaloz"></asp:RequiredFieldValidator>
        </td></tr>
        <tr><td>
        Внеси ја новата лозинка:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNewPassword" runat="server" CssClass=txt TextMode="Password"></asp:TextBox>
      
         </td></tr>
        <tr><td>
        Потврди ја новата лозинка:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPotvrdiNovPass" runat="server" CssClass=txt TextMode="Password"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToCompare="txtNewPassword" ControlToValidate="txtPotvrdiNovPass" 
            ErrorMessage="Лозинките не се совпаѓаат" ValidationGroup="novaloz"></asp:CompareValidator>
        </td></tr>
        <tr><td>

        <asp:Button ID="btnSaveNewPass" runat="server" onclick="btnSaveNewPass_Click" 
            Text="Зачувај лозинка" ValidationGroup="novaloz" CssClass=novoKopce />
        <asp:Label ID="lblInfoSave" runat="server"></asp:Label>
      </td></tr>
        

</table>
   </td>
   </tr>
   <tr>
   <td>
    <asp:Panel ID="pnlOdgovoriPrikaz" runat="server">
        <asp:Label ID="lblInformacii123" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="gvOdgovoriUcenici" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="AnswerID" HeaderText="Ред. бр." />
                <asp:BoundField DataField="QuestionContent" HeaderText="Прашање" />
                <asp:BoundField DataField="Answer" HeaderText="Одговор" />
                <asp:BoundField DataField="QP" HeaderText="Макс. Поени" />
                <asp:BoundField DataField="AP" HeaderText="Поени" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>

    </asp:Panel>
    </td>
    </tr>
    <tr>
    <td>

      </td>
    </tr>
    </table>
    </form>
    
</body>
</html>
