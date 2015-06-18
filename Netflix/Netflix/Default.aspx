<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Netflix._Default" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <p>
        
        <asp:Label ID="lblLogin" runat="server" Font-Size="XX-Large" Text="Login"></asp:Label>

    </p>
    <p>
        
        <asp:Label ID="lblEmail" runat="server" Text="Emailadres :" Width="100px"></asp:Label>
        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
        
    </p>
    <p>
        
        <asp:Label ID="lblPassword" runat="server" Text="Wachtwoord:" Width="100px"></asp:Label>
        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Log in!" />
        
        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Log uit!" />
        
    </p>
</asp:Content>
