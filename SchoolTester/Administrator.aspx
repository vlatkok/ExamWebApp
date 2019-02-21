<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Administrator.aspx.cs" Inherits="Administrator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
         .style1
        {
            
           width:230px;height:40px; -webkit-border-radius: 89px 93px 80px 99px;-moz-border-radius: 89px 93px 80px 99px;border-radius: 89px 93px 80px 99px;background-color:#FFFFFF;-webkit-box-shadow: #ACADB0 53px 53px 53px;-moz-box-shadow: #ACADB0 7px 7px 7px;-moz-box-shadow: #ACADB0 7px 7px 7px; box-shadow: #ACADB0 7px 7px 7px
         }
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
<body >
    <form id="form1" runat="server">
    <table align=right style="height: 176px">
    <tr><td align=right>
        <asp:Label ID="lblLogin" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="btnOdjaviSe" runat="server" Text="Одјави се"  CssClass=novoKopce 
            onclick="btnOdjaviSe_Click"/>
    </td>
    </tr>
    </table>
    </br>
    <table align=center style="height: 176px">
    <tr>
    <td>
        Избери табела:<br />
    <asp:DropDownList ID="ddlTabeli" runat="server" Height="50px" Width="203px" 
            onselectedindexchanged="ddlTabeli_SelectedIndexChanged" CssClass=style1 
            AutoPostBack="True">
        <asp:ListItem> </asp:ListItem>
        <asp:ListItem>Approve</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Person</asp:ListItem>
        <asp:ListItem>Question</asp:ListItem>
        <asp:ListItem>Test</asp:ListItem>
        </asp:DropDownList>

        <br />

    </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="lblInformacii" runat="server" ForeColor="White"></asp:Label>
    </td>
    </tr>
    <tr>
    <td>

        <asp:GridView ID="gvPerson" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Vertical" 
            onrowcancelingedit="gvPerson_RowCancelingEdit" 
            onrowdeleting="gvPerson_RowDeleting" onrowediting="gvPerson_RowEditing" 
            onrowupdating="gvPerson_RowUpdating">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="PID" HeaderText="PID" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="Password" HeaderText="Password" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Year" HeaderText="Year" />
                <asp:BoundField DataField="Class" HeaderText="Class" />
                <asp:BoundField DataField="Subjects" HeaderText="Subjects" />
                <asp:BoundField DataField="ActiveTestID" HeaderText="ActiveTestID" />
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
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



        <asp:GridView ID="gvAnswer" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Vertical" 
            onrowcancelingedit="gvAnswer_RowCancelingEdit" 
            onrowdeleting="gvAnswer_RowDeleting" onrowediting="gvAnswer_RowEditing" 
            onrowupdating="gvAnswer_RowUpdating" >
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="TestID" HeaderText="TestID" ReadOnly="True" />
                <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" />
                <asp:BoundField DataField="AnswerID" HeaderText="AnswerID" ReadOnly="True" />
                <asp:BoundField DataField="AnswerType" HeaderText="AnswerType" />
                <asp:BoundField DataField="Answer" HeaderText="Answer" />
                <asp:BoundField DataField="Points" HeaderText="Points" />
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
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
        <asp:GridView ID="gvQuestion" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Vertical" 
            onrowcancelingedit="gvQuestion_RowCancelingEdit" 
            onrowdeleting="gvQuestion_RowDeleting" onrowediting="gvQuestion_RowEditing" 
            onrowupdating="gvQuestion_RowUpdating">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="TestID" HeaderText="TestID" ReadOnly="True" />
                <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" />
                <asp:BoundField DataField="QuestionID" HeaderText="QuestionID" 
                    ReadOnly="True" />
                <asp:BoundField DataField="QuestionType" HeaderText="QuestionType" />
                <asp:BoundField DataField="QuestionContent" HeaderText="QuestionContent" />
                <asp:BoundField DataField="PossibleOptions" HeaderText="PossibleOptions" />
                <asp:BoundField DataField="Points" HeaderText="Points" />
                <asp:BoundField DataField="Image" HeaderText="Image" />
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
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

        <asp:GridView ID="gvTest" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Vertical" 
            onrowcancelingedit="gvTest_RowCancelingEdit" onrowdeleting="gvTest_RowDeleting" 
            onrowediting="gvTest_RowEditing" onrowupdating="gvTest_RowUpdating" >
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="TestID" HeaderText="TestID" ReadOnly="True" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Subject" HeaderText="Subject" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="StudentsList" HeaderText="StudentsList" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="Start" HeaderText="Start" />
                <asp:BoundField DataField="Finished" HeaderText="Finished" />
                <asp:BoundField DataField="Class" HeaderText="Class" />
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
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
        <asp:GridView ID="gvApprove" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" 
            onrowcancelingedit="gvApprove_RowCancelingEdit" 
            onrowdeleting="gvApprove_RowDeleting" onrowediting="gvApprove_RowEditing" 
            onrowupdating="gvApprove_RowUpdating" 
            onselectedindexchanged="gvApprove_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField SelectText="Approve" ShowSelectButton="True" />
                <asp:BoundField DataField="PID" HeaderText="PID" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="Password" HeaderText="Password" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Year" HeaderText="Year" />
                <asp:BoundField DataField="Class" HeaderText="Class" />
                <asp:BoundField DataField="Subjects" HeaderText="Subjects" />
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>

    </td>
    </tr>
     </table>
    </form>
</body>
</html>
