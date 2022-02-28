<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="RideNow.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="home" class="section-home scrollspy">
        <div class="slider">
            <asp:Repeater ID="rpt" runat="server">
                <HeaderTemplate>
                    <ul class="slides">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <img src="<%#Eval("PhotoPath") %>" />
                        <div class="caption left-align">
                            <h3><%#Eval("ShortDescr") %></h3>
                            <h5><%#Eval("LongDescr") %></h5>
                            <p>
                                <a href="brandcars.aspx?id=<%#Eval("BrandName") %>" class="btn orange"><%#Eval("BrandName") %></a>
                            </p>
                        </div>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </section>
    <section class="section">
        <div class="container">
            <div class="row">
                <div class="col s12">
                    <blockquote style="border-left: solid 5px #009688">
                        Our Brands
                    </blockquote>
                    <p>
                        <a href="brandcars.aspx" class="btn black-text z-depth-0 white">All Cars 
                            <i class="material-icons right black-text">chevron_right</i>
                        </a>
                        <asp:Repeater ID="rptBrands" runat="server">
                            <ItemTemplate>
                                <a href="brandcars.aspx?id=<%#Eval("BrandName") %>" class="btn black-text z-depth-0 white">
                                    <%#Eval("BrandName") %>
                                    <i class="material-icons right black-text">chevron_right</i>
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </p>
                </div>
            </div>
        </div>
    </section>
    <div class="container">
        <p><asp:Label ID="lblError" runat="server"></asp:Label></p>
        <asp:Repeater ID="rpt1" runat="server" OnItemCommand="rpt1_ItemCommand">
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
                            <span class="red-text" runat="server" visible='<%#Eval("Amt").ToString()=="0" %>'>UNAVAILABLE</span>
                            <a runat="server" visible='<%#Eval("Amt").ToString()!="0" %>' href="login.aspx">Rent</a><br />
                            <a href="carinfo.aspx?id=<%#Eval("CarID") %>">Details</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
        <script type="text/javascript">
            document.addEventListener('DOMContentLoaded', function () {
                var ca = document.querySelectorAll('.card-action.center');
                var len = ca.length;
                for (var i = 0; i < len; i++) {
                    if (ca[i].firstElementChild.innerText == '') {
                        ca[i].firstElementChild.remove();
                    }
                }
            })
        </script>
</asp:Content>
