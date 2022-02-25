<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="RideNow.admin.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="section">
    <div class="container">
        <h3>My Dashboard</h3>
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <asp:Repeater ID="rpt1" runat="server">
            <HeaderTemplate>
                <div class="unselectable row">
                    <div class="col s12">
                        <table class="striped centered">
                            <thead>
                                <tr>
                                    <th>Full Name</th>
                                    <th>Email</th>
                                    <th>Car Name</th>
                                    <th>Rental Status</th>
                                </tr>
                            </thead>
                            <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("FullName") %></td>
                                    <td><%#Eval("UserName") %></td>
                                    <td><%#Eval("CarName") %></td>
                                    <td>
                                        <%#Convert.ToBoolean(Eval("isReturned"))?"Returned":"Not Returned" %>
                                    </td>
                                </tr>
            </ItemTemplate>
            <FooterTemplate>
                            </tbody>
                        </table>
                    </div>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</section>
</asp:Content>
