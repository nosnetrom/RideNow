<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="myrent.aspx.cs" Inherits="RideNow.user.myrent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="container">
            <h3>Rentals: <%=Session["userName"] %></h3>
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <asp:Repeater ID="rpt1" runat="server" OnItemCommand="rpt1_ItemCommand">
                <HeaderTemplate>
                    <div class="unselectable row">
                        <div class="s12 col">
                            <table class="striped centered">
                                <thead>
                                    <tr>
                                        <th>Car Name</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("CarName") %></td>
                        <td>
                            <span runat="server" visible='<%#Convert.ToBoolean(Eval("IsReturned"))==true %>'>Returned</span>
                            <span runat="server" visible='<%#Convert.ToBoolean(Eval("IsReturned"))==false %>'>
                                <asp:LinkButton ID="Return" runat="server" CssClass="btn" CommandName="Return" CommandArgument='<%#Eval("CarID") %>'>
                                    Return
                                </asp:LinkButton>
                            </span>
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
