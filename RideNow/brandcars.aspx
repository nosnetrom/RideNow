<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="brandcars.aspx.cs" Inherits="RideNow.brandcars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <asp:Repeater ID="rpt1" runat="server">
            <HeaderTemplate>
                <div class="unselectable row">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col s12 m4">
                    <div class="card">
                        <div class="card-image">
                            <img src="<%#Eval("PhotoPath") %>" height="150" style="object-fit: cover" />
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
                            <span class="red-text" style="display: inline-block; margin: 0 1rem;" runat="server" visible='<%#Eval("Amt").ToString()=="0" %>'>
                                UNAVAILABLE
                            </span>
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
    </div>
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
