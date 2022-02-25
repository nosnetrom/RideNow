<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="showcase.aspx.cs" Inherits="RideNow.admin.showcase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <asp:Repeater ID="rpt1" runat="server">
        <HeaderTemplate>
            <div class="unselectable row">
                <div class="center" style="padding-top: 1rem;">
                    <strong>Advertising Showcases</strong>
                </div>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="col s12 m4">
                <div class="card">
                    <div class="card-image">
                        <img src='<%#Eval("PhotoPath") %>' height="150" style="object-fit: cover" />
                        <strong>
                            <span class="card-title">
                                <%#Eval("BrandName") %>
                            </span>
                        </strong>
                    </div>
                    <div class="card-content">
                        <p class="truncate">
                            <%#Eval("ShortDescr") %>
                        </p>
                    </div>
                    <div class="card-action center">
                        <a href="showinfo.aspx?id=<%#Eval("ShowID") %>">Details</a>
                        <a href="editshowcase.aspx?id=<%#Eval("ShowID") %>">Edit</a>
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="rpt2" runat="server">
        <HeaderTemplate>
            <div class="unselectable row">
                <div class="center">
                    <strong>Hidden Showcases</strong>
                </div>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="col s12 m4">
                <div class="card">
                    <div class="card-image">
                        <img src='<%#Eval("PhotoPath") %>' height="150" style="object-fit: cover" />
                        <strong>
                            <span class="card-title">
                                <%#Eval("BrandName") %>
                            </span>
                        </strong>
                    </div>
                    <div class="card-content">
                        <p class="truncate">
                            <%#Eval("ShortDescr") %>
                        </p>
                    </div>
                    <div class="card-action center">
                        <a href="showinfo.aspx?id=<%#Eval("ShowID") %>">Details</a>
                        <a href="editshowcase.aspx?id=<%#Eval("ShowID") %>">Edit</a>
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
