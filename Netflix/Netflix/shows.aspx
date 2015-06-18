<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="shows.aspx.cs" Inherits="Netflix.shows" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <p>
        <asp:ListBox ID="lbShows" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lbShows_SelectedIndexChanged"></asp:ListBox>
        <asp:TextBox ID="tbShowInfo" runat="server" Height="61px" ReadOnly="True" TextMode="MultiLine" Width="498px"></asp:TextBox>
    </p>
</asp:Content>
