<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="carinfo.aspx.cs" Inherits="RideNow.user.carinfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <p><asp:Label ID="lblError" runat="server" CssClass="red-text"></asp:Label></p>
        <asp:Repeater ID="rpt1" runat="server" OnItemCommand="rpt1_ItemCommand">
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
                            <a runat="server" visible='<%#Eval("Amt").ToString()!="0" %>'><asp:LinkButton ID="Rent" runat="server" CommandName="Rent" CommandArgument='<%#Eval("CarID") %>'>Rent</asp:LinkButton></a><br />
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
