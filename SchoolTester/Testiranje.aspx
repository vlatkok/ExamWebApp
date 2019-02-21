<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Testiranje.aspx.cs" Inherits="Testiranje" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">


          body 
        { background-image:url(Logo/brushed.png);
          background-repeat:repeat;
          font-family:Verdana;
                     
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

 .ddl
        {
            
            width:250px;height:40px;-webkit-border-radius: 0px;-moz-border-radius: 0px;border-radius: 0px;border:1px solid #BAC3D4;background-color:#FFFFFF;-webkit-box-shadow: #ACADB0 7px 7px 7px;-moz-box-shadow: #ACADB0 7px 7px 7px; box-shadow: #ACADB0 7px 7px 7px;
        }
         .txt
        {
            
             width:180px;height:22px;-webkit-border-radius: 89px 93px 80px 99px;-moz-border-radius: 89px 93px 80px 99px;border-radius: 89px 93px 80px 99px;border:9px solid #BAC3D;background-color:#FFFFFF;-webkit-box-shadow: #FFFFFF 53px 53px 53px;-moz-box-shadow: #ACADB0 7px 7px 7px;-moz-box-shadow: #ACADB0 7px 7px 7px; box-shadow: #ACADB0 7px 7px 7px
        }
          .txt2
        {
            
            -webkit-border-radius: 89px 93px 80px 99px;-moz-border-radius: 89px 93px 80px 99px;border-radius: 89px 93px 80px 99px;border:9px solid #BAC3D;background-color:#FFFFFF;-webkit-box-shadow: #FFFFFF 53px 53px 53px;-moz-box-shadow: #ACADB0 7px 7px 7px;-moz-box-shadow: #ACADB0 7px 7px 7px; box-shadow: #ACADB0 7px 7px 7px
        }

</style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 636px">
    
        <br />
        <br />
        <table style="width: 100%; height: auto;" align="center" >
        <tr><td align=left>
        Прашање брoj:<asp:Label ID="lblredbroj" runat="server"></asp:Label>
      </td><td align=right>Поени: <asp:Label ID="lblPoeni" runat="server"> </asp:Label></td> </tr>
       <tr>
       <td align=left>
        <asp:Label ID="lblPrasanje" runat="server" Font-Size="Large"></asp:Label>
       </td>
        
       <td align=right>
           <asp:Image ID="imgPreview" runat="server"  Width="300" Height="300"
               Visible="False" BorderColor="#426FAE" />
       </td>
       
       </tr>              
          <tr>
         <td align=left>
        <asp:TextBox ID="txtOdgovor" runat="server" TextMode="MultiLine" 
            Visible="False" Width="597px" CssClass=txt2></asp:TextBox>
       </td>
       </tr>
        <tr>
         <td align=left>
        <asp:RadioButtonList ID="rdbListOdgovori" runat="server" Visible="False">
        </asp:RadioButtonList>
        </td>
     </tr>
     <tr><td>
      <asp:Panel ID="panelFill" runat="server" HorizontalAlign="Left" 
            ViewStateMode="Enabled" >
          
       
            <asp:Label ID="lbltext1" runat="server"></asp:Label>
            <asp:TextBox ID="txt1" runat="server" Width="153px" Visible="False" CssClass=txt2></asp:TextBox>
            <asp:Label ID="lbltext2" runat="server"></asp:Label>
            <asp:TextBox ID="txt2" runat="server" Visible="False" CssClass=txt2></asp:TextBox>
            <asp:Label ID="lbltext3" runat="server"></asp:Label>
            <asp:TextBox ID="txt3" runat="server" Visible="False" CssClass=txt2></asp:TextBox>
            <asp:Label ID="lbltext4" runat="server"></asp:Label>
            <asp:TextBox ID="txt4" runat="server" Visible="False" CssClass=txt2></asp:TextBox>
            <asp:Label ID="lbltext5" runat="server"></asp:Label>
            <asp:TextBox ID="txt5" runat="server" Visible="False" CssClass=txt2></asp:TextBox>
         </asp:Panel>
        
     </td>
        </tr>
         
         </table>
         <table   align=center>
            <tr align=center>
            <td align=left >
               
                    <asp:Button ID="ptnPrethodno" runat="server" Text="Претходно" 
                        onclick="ptnPrethodno_Click"  CssClass=novoKopce/>
               
              <td align=center >
                   <asp:Panel ID="pnlButtons" runat="server" HorizontalAlign="Left" 
            ViewStateMode="Enabled" >
          
        </asp:Panel>
               </td>
               <td align=right>
                 <asp:Button ID="btnSledno" runat="server" Text="Следно" 
            onclick="btnSledno_Click"  CssClass=novoKopce/>
                <td align=right>
                <asp:Button ID="btnKraj" runat="server" Text="Крај" Width="126px"  CssClass=novoKopce OnClick="btnKraj_Click" OnClientClick="return confirm('Нема враќање по оваа акција! Дали сте сигурни дека го завршувате тестот?')"/>
                </td>
            </tr>            
        </table>

       

       

        

        
        <br />
        <asp:Label ID="lblInfo" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
