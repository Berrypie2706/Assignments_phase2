<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddArcticle_1.aspx.cs" Inherits="Assignment11.AddArcticle_1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
    <tr>
        <td class="auto-style1">Article Id</td>
        <td>
            <asp:TextBox ID="TxtId" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">Title</td>
        <td>
            <asp:TextBox ID="TxtTitle" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">Content</td>
        <td>
            <asp:TextBox ID="TxtContent" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">Publish Date</td>
        <td>
            <asp:TextBox ID="TxtDate" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="BtnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Label ID="LblMsg" runat="server"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
