<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="profiel.aspx.cs" Inherits="Netflix.profiel" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <p>
        <asp:ListBox ID="lbProfiles" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lbProfiles_SelectedIndexChanged"></asp:ListBox>
    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCategorie" runat="server"></asp:Label>
        <asp:Button ID="btnProfiel" runat="server" OnClick="btnProfiel_Click" Text="Kies!" />
    </p>
    
</asp:Content>
