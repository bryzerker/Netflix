<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="lijst.aspx.cs" Inherits="Netflix.lijst" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    
    



    <asp:ListBox ID="lbListShows" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lbListShows_SelectedIndexChanged"></asp:ListBox>
<asp:TextBox ID="tbShowInfo" runat="server" Height="56px" ReadOnly="True" TextMode="MultiLine" Width="467px"></asp:TextBox>
    
    



</asp:Content>
