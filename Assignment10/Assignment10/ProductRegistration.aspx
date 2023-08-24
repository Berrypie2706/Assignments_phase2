<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductRegistration.aspx.cs" Inherits="Assignment10.ProductRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 426px;
        }
        .auto-style3 {
            width: 426px;
            height: 39px;
        }
        .auto-style4 {
            height: 39px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <div class="col-md-4"><asp:Image runat ="server" ID ="Image3" ImageUrl ="~/Images/product1.jpg" 
                     Width = "300" Height ="250" CssClass ="img-fluid" /></div>
        <h2 style ="text-align:left" width="300">Product Registration</h2>
         <table class="auto-style1">
             <tr>
                 <td class="auto-style2">Product Name</td>
                 <td>
                     <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtName" ErrorMessage="Name is Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style2">Category</td>
                 <td>
                     <asp:DropDownList ID="DdlCategory" runat="server">
                     </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlCategory" ErrorMessage="Category Required" ForeColor="Red"></asp:RequiredFieldValidator>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style3">Price</td>
                 <td class="auto-style4">
                     <asp:TextBox ID="TxtPrice" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtPrice" ErrorMessage="Price Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                     <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TxtPrice" ErrorMessage="Price must be integer only" ForeColor="#FF3300" MaximumValue="92345678" MinimumValue="0"></asp:RangeValidator>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style2">Description</td>
                 <td>
                     <asp:TextBox ID="TxtDes" runat="server" Height="129px" Width="276px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtDes" ErrorMessage="Description Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style2">Release Date</td>
                 <td>
                     <asp:Calendar ID="CalDate" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" SelectedDate="08/24/2023 15:52:15" VisibleDate="2023-08-24" Width="220px">
                         <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                         <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                         <OtherMonthDayStyle ForeColor="#999999" />
                         <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                         <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                         <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                         <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                         <WeekendDayStyle BackColor="#CCCCFF" />
                     </asp:Calendar>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style2">&nbsp;</td>
                 <td>
                     <asp:Button ID="BtnRegister" runat="server" OnClick="BtnRegister_Click" Text="Register" />
                 </td>
             </tr>
             <tr>
                 <td class="auto-style2">
                     <asp:Label ID="LblMsg" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>&nbsp;</td>
             </tr>
             <tr>
                 <td class="auto-style2">
                     <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                 </td>
                 <td>&nbsp;</td>
             </tr>
         </table>
    </form>
</body>
</html>
