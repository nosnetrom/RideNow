<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="RideNow.admin.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>Admin Home</p>
    <asp:HyperLink ID="toAddcar" NavigateUrl="~/admin/addcar.aspx" runat="server" Text="Go to add car" />
</asp:Content>
