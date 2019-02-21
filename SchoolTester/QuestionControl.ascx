<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuestionControl.ascx.cs" Inherits="QuestionControl" %>
 <style type="text/css">
        .style1
        {
            
            width:230px;height:40px;-webkit-border-radius: 89px 93px 80px 99px;-moz-border-radius: 89px 93px 80px 99px;border-radius: 89px 93px 80px 99px;border:9px solid #BAC3D;background-color:#FFFFFF;-webkit-box-shadow: #ACADB0 53px 53px 53px;-moz-box-shadow: #ACADB0 7px 7px 7px;-moz-box-shadow: #ACADB0 7px 7px 7px; box-shadow: #ACADB0 7px 7px 7px
        }
         .style2
        {
            
            width:100px;height:20px;-webkit-border-radius: 89px 93px 80px 99px;-moz-border-radius: 89px 93px 80px 99px;border-radius: 89px 93px 80px 99px;border:9px solid #BAC3D;background-color:#FFFFFF;-webkit-box-shadow: #ACADB0 53px 53px 53px;-moz-box-shadow: #ACADB0 7px 7px 7px;-moz-box-shadow: #ACADB0 7px 7px 7px; box-shadow: #ACADB0 7px 7px 7px
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


<p>
    &nbsp;</p>
<p>
    Прашање бр:
    <asp:Label ID="lblPrasanjeBr" runat="server" Font-Bold="True" 
        Font-Size="Larger"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    Поени:&nbsp;
    <asp:TextBox ID="txtPoeni" runat="server" CssClass=style2></asp:TextBox>
</p>


<table style="width:100%;" border="5" style="border:3px solid black;"  align=center>
    <tr>
    <td align="center">
      Тип на прашање:<br />
<asp:RadioButton ID="rdb1" runat="server" GroupName="Tip" 
    oncheckedchanged="rdb1_CheckedChanged" Text="Прашање+Одговор " 
    AutoPostBack="True" />
<asp:RadioButton ID="rdb2" runat="server" GroupName="Tip" 
    oncheckedchanged="rdb2_CheckedChanged" Text="Прашање+ избор на одговор" 
    AutoPostBack="True" />
<asp:RadioButton ID="rdb3" runat="server" GroupName="Tip" 
    oncheckedchanged="rdb3_CheckedChanged" Text="Прашање со празни места" 
    AutoPostBack="True" />       
    </td></tr>
    <tr>
        <td align="center">
     <asp:TextBox ID="txtPrasanje" runat="server" Height="31px" TextMode="MultiLine" 
    Width="555px" Visible="False" CssClass=style1></asp:TextBox>           
  </td>  </tr>
    <tr>                
      <td align="center">
    <asp:TextBox ID="txtMozen1" runat="server" Width="121px" Visible="False" CssClass=txt></asp:TextBox>
    <asp:Label ID="lblPraznoPole1" runat="server" Text="&lt;Празно Поле&gt;" 
        Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="txtMozen2" runat="server" Width="121px" Visible="False" CssClass=txt></asp:TextBox>
    <asp:Label ID="lblPraznoPole2" runat="server" Text="&lt;Празно Поле&gt;" 
        Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="txtMozen3" runat="server" Width="121px" Visible="False" CssClass=txt></asp:TextBox>
    <asp:Label ID="lblPraznoPole3" runat="server" Text="&lt;Празно Поле&gt;" 
        Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="txtMozen4" runat="server" Width="121px" Visible="False" CssClass=txt></asp:TextBox>
&nbsp;<asp:Label ID="lblPraznoPole4" runat="server" Text="&lt;Празно Поле&gt;" 
        Visible="False"></asp:Label>
    <asp:TextBox ID="txtMozen5" runat="server" Width="121px" Visible="False" CssClass=txt></asp:TextBox>
   </td> </tr>
   <tr>
   <td>
   Додади Слика:  <asp:FileUpload ID="file" runat="server"/>
       <asp:Button ID="btnUpload" runat="server" Text="Upload" 
           onclick="btnUpload_Click" CssClass=style2/>
   &nbsp;<asp:Label ID="lblSlika" runat="server"></asp:Label>
   </td>
   </tr>
     <tr>  <td align=center>              
       <asp:Label ID="lblMessage" runat="server"></asp:Label>

<asp:Button ID="btnDodadiPrasanje" runat="server" 
    onclick="btnDodadiPrasanje_Click" Text="Додади во тестот" Visible="False" CssClass=style1/>    
   </td> </tr>
   </table> 
   
    