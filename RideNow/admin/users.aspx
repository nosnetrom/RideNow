<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="RideNow.admin.users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="container">
            <asp:Repeater ID="rpt1" runat="server" OnItemCommand="rpt1_ItemCommand">
                <HeaderTemplate>
                    <div class="col s12">
                        <h2>System Users</h2>
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                        <table class="striped centered">
                            <thead>
                                <tr>
                                    <th>Full Name></th>
                                    <th>Email</th>
                                    <th>Role</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                                <tr>
                                    <td><%#Eval("FullName") %></td>
                                    <td><%#Eval("Email") %></td>
                                    <td><%#Eval("Role") %></td>
                                    <td>
                                        <asp:LinkButton ID="RoleChange" runat="server" CssClass="btn" CommandName="RoleChange" CommandArgument='<%#Eval("UserID") %>'>Change role</asp:LinkButton>
                                    </td>
                                </tr>
                </ItemTemplate>
                <FooterTemplate>
                            </tbody>
                        </table>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </section>
</asp:Content>
