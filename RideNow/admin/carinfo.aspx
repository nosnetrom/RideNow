<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="carinfo.aspx.cs" Inherits="RideNow.admin.carinfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Label ID="lblError" runat="server" CssClass="red-text"></asp:Label>
        <asp:Repeater ID="rpt1" runat="server">
            <HeaderTemplate>
                <div class="unselectable row">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col s12">
                    <div class="card card-auto">
                        <div class="card-image">
                            <img src="<%# Eval("PhotoPath") %>" style="object-fit: cover;" height="450" />
                            <strong>
                                <span class="card-title">
                                    <%#Eval("BrandName") %> <%#Eval("ModelName") %>
                                </span>
                            </strong>
                        </div>
                        <div class="card-content">
                            <p><%#Eval("Descr") %></p>
                        </div>
                        <div class="card-action center">
                            <a href="#">Rent</a>
                            <a href="addcar.aspx">Add New Car</a>
                            <a href="editcar.aspx?id=<%#Eval("CarID") %>">Edit</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
