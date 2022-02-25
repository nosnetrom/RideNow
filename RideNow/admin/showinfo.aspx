<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="showinfo.aspx.cs" Inherits="RideNow.admin.showinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <section class="section">
        <asp:Repeater ID="rpt1" runat="server">
            <HeaderTemplate>
                <div class="unselectable row">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col s12">
                    <div class="card">
                        <div class="card-image">
                            <img src='<%#Eval("PhotoPath") %>' height="450" style="object-fit: cover" />
                            <strong>
                                <h1 class="card-title">
                                    <%#Eval("BrandName") %>
                                </h1>
                            </strong>
                        </div>
                        <div class="card-content">
                            <b><%#Eval("ShortDescr") %></b>
                            <p><%#Eval("LongDescr") %></p>
                        </div>
                        <div class="card-action center">
                            <a href="addshowcase.aspx">New showcase</a>
                            <a href='editshowcase.aspx?id=<%#Eval("ShowID") %>'>Edit showcase</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </section>
    </div>
</asp:Content>

