<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Najava_Registracija.aspx.cs" Inherits="Najava_Registracija" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .kopce
        {
            
            width:120px;height:40px;-webkit-border-radius: 89px 93px 80px 99px;-moz-border-radius: 89px 93px 80px 99px;border-radius: 89px 93px 80px 99px;border:9px solid #BAC3D;background-color:#FFFFFF;-webkit-box-shadow: #ACADB0 53px 53px 53px;-moz-box-shadow: #ACADB0 7px 7px 7px;-moz-box-shadow: #ACADB0 7px 7px 7px; box-shadow: #ACADB0 7px 7px 7px
        }
        body 
        { background-image:url(Logo/brushed.png);
          background-repeat:repeat;
          font-family:Verdana;
                     
            }
            #wrapper
            { width:1000px;
              margin: 0 auto;
              position:relative;
                
                }
                  #wleft
            { width:600px;
              margin: 0;
              float:left;
              position:relative;
                
                }
                  #wright
            { width:400px;
              margin: 0;
              float:right;
              position:relative;
                
                }
                
                td 
                {
                    padding-bottom:5px;
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
                
                
        
        .prav
        {
            width:180px;height:22px;-webkit-border-radius: 89px 93px 80px 99px;-moz-border-radius: 89px 93px 80px 99px;border-radius: 89px 93px 80px 99px;border:9px solid #BAC3D;background-color:#FFFFFF;-webkit-box-shadow: #ACADB0 53px 53px 53px;-moz-box-shadow: #ACADB0 7px 7px 7px;-moz-box-shadow: #ACADB0 7px 7px 7px; box-shadow: #ACADB0 7px 7px 7px
         
        }
        .txt
        {
            
             width:180px;height:22px;-webkit-border-radius: 89px 93px 80px 99px;-moz-border-radius: 89px 93px 80px 99px;border-radius: 89px 93px 80px 99px;border:9px solid #BAC3D;background-color:#FFFFFF;-webkit-box-shadow: #FFFFFF 53px 53px 53px;-moz-box-shadow: #ACADB0 7px 7px 7px;-moz-box-shadow: #ACADB0 7px 7px 7px; box-shadow: #ACADB0 7px 7px 7px
        }
        .prav1
        {
              width:330px;height:80px;-webkit-border-radius: 0px;-moz-border-radius: 0px;border-radius: 0px;border:1px solid #BAC3D4;background-color:#FFFFFF;-webkit-box-shadow: #ACADB0 2px 2px 2px;-moz-box-shadow: #ACADB0 2px 2px 2px; box-shadow: #ACADB0 2px 2px 2px;
         }
           .smallprav
        {
            width:45px;height:27px;-webkit-border-radius: 89px 93px 80px 99px;-moz-border-radius: 89px 93px 80px 99px;border-radius: 89px 93px 80px 99px;border:9px solid #BAC3D;background-color:#FFFFFF;-webkit-box-shadow: #ACADB0 53px 53px 53px;-moz-box-shadow: #ACADB0 7px 7px 7px;-moz-box-shadow: #ACADB0 7px 7px 7px; box-shadow: #ACADB0 7px 7px 7px
         
        }
    </style>

    
</head>

<body>
<div id="wrapper">



    <form id="forma1" runat="server">
   
   <table align=center ><tr><td>
       <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Logo/bground.png"  Width=400 Height=100/>
   
   </td></tr></table>
    
     
      <div id="wleft">   
      
            
            
               <table><tr>
       
       <td> Име:</td>
        <td><asp:TextBox ID="txtRegName" runat="server" Height="22px" 
            style="margin-left: 0px" CssClass=txt></asp:TextBox></td><td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtRegName" ErrorMessage="Задолжително поле" 
            validationgroup="RegisterValGr" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        </td></tr>
        <tr>
        <td>
        Презиме: </td><td>
        <asp:TextBox ID="txtRegSurname" runat="server" Height="22px" 
            style="margin-left: 0px" Width="181px" CssClass=prav></asp:TextBox> </td>
            <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtRegSurname" ErrorMessage="Задолжително поле" 
            validationgroup="RegisterValGr" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        <td></tr>
        <tr><td>
        Email:</td>
        <td><asp:TextBox ID="txtRegMail" runat="server" Height="24px" Width="177px" CssClass=prav></asp:TextBox> </td><td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="txtRegMail" ErrorMessage="Задолжително поле" 
            validationgroup="RegisterValGr" ForeColor="#CC0000"></asp:RequiredFieldValidator> </td>
       </tr>
       <tr>
       <td>
        Лозинка:</td><td>
        <asp:TextBox ID="txtRegPassword" runat="server" Height="22px" 
            style="margin-left: 0px" Width="181px" CssClass=prav TextMode="Password"></asp:TextBox> </td>
            <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="txtRegPassword" ErrorMessage="Задолжително поле" 
            validationgroup="RegisterValGr" ForeColor="Red"></asp:RequiredFieldValidator> </td>
       </tr>
       <tr><td>
        Потврди Лозинка:</td>
        <td>
        <asp:TextBox ID="txtPasswordReenter" runat="server" Height="22px" 
            style="margin-left: 0px" Width="181px" CssClass=prav TextMode="Password"></asp:TextBox> </td>
            <td>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToCompare="txtRegPassword" ControlToValidate="txtPasswordReenter" 
            ErrorMessage="Лозинките не се совпаѓаат" validationgroup="RegisterValGr" 
            ForeColor="#CC0000"></asp:CompareValidator></td></tr>
       <tr>
       <td>
        Ученик/Професор:</td><td>
        <asp:DropDownList ID="ddlRole" runat="server" 
            AutoPostBack="True" onselectedindexchanged="ddlRole_SelectedIndexChanged" CssClass=prav1 Width="180" Height="25"> 
            <asp:ListItem>-Избери-</asp:ListItem>
            <asp:ListItem Value="profesor">Професор</asp:ListItem>
            <asp:ListItem Value="ucenik">Ученик</asp:ListItem>
        </asp:DropDownList>
        </td>
       </tr>
       <tr><td>
        <asp:Label ID="lblYear" runat="server" Text="Година"></asp:Label>
       
        <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" CssClass=smallprav>
            <asp:ListItem Value="1">I</asp:ListItem>
            <asp:ListItem Value="2">II</asp:ListItem>
            <asp:ListItem Value="3">III</asp:ListItem>
            <asp:ListItem Value="4">IV</asp:ListItem>
        </asp:DropDownList>
       </td>
       <td>
        <asp:Label ID="lblClass" runat="server" Text="Клас"></asp:Label>
        
        <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" 
             CssClass=smallprav>
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
      </tr>
      <tr><td>
        <asp:Button ID="btnRegister" runat="server" onclick="btnRegister_Click" 
            Text="Регистрирај се" validationgroup="RegisterValGr"  CssClass=novoKopce/>
       </td>
       <td>
        <asp:Label ID="lblRegMessage" runat="server"></asp:Label></td>
        </tr>
        </table>
            
            
            </div>
        
   
      <div id="wright">   
    <table><tr>
       
       <td>
        Најава:
        </td>
        </tr>
        <tr>
        <td>
        Корисничко Име (Email):</td>
        <td>
        <asp:TextBox ID="txtMail" runat="server"  CssClass=txt></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
        Лозинка:</td>
        <td>
        <asp:TextBox ID="txtPass" runat="server"  CssClass=txt TextMode="Password"></asp:TextBox></td>
        <td>        
        <asp:Label ID="lblInfo" runat="server"></asp:Label></td>
        </tr>
        <tr>
        <td>       
        <asp:Button ID="btnNajava" runat="server" onclick="btnNajava_Click" 
            Text="Најави се"  CssClass=novoKopce/>
            </td></tr>
            </table>
     
    
    </div>
    
    </form>
  
        </div>
</body>
</html>
