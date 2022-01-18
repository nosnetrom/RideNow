<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="RideNow.admin.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <p><asp:Label ID="lblError" runat="server"></asp:Label></p>
        <asp:Repeater ID="rpt1" runat="server">
            <HeaderTemplate>
                <div class="unselectable row">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col s12 m4">
                    <div class="card">
                        <div class="card-image">
                            <img src="<%#Eval("PhotoPath") %>" height="150" style="object-fit: cover;" />
                            <strong>
                                <span class="card-title">
                                    <%#Eval("BrandName") %> <%#Eval("ModelName") %>
                                </span>
                            </strong>
                        </div>
                        <div class="card-content">
                            <p class="truncate">
                                <%#Eval("Descr") %>
                            </p>
                        </div>
                        <div class="card-action center">
                            <span class="chip orange-text" runat="server" visible='<%#Eval("Amt").ToString()=="0" %>'>UNAVAILABLE</span>
                            <a runat="server" visible='<%#Eval("Amt").ToString()!="0" %>'>Rent</a>
                            <a href="carinfo.aspx?id=<%#Eval("CarID") %>">Details</a>
                            <a href="editcar.aspx?id=<%#Eval("CarID") %>">Edit Car</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>"
</asp:Content>
