<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="RideNow.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <section class="section">
            <div class="row">
                <div class="col s10 offset-s1">
                    <div class="card">
                        <div class="card-content">
                            <span class="card-title center">
                                Log In to RideNow
                            </span>
                            <div class="row">
                                <div class="input-field col s12">
                                    <i class="material-icons prefix">email</i>
                                    <input id="email" name="email" type="text" class="validate" required runat="server" />
                                    <label for="email">
                                        Email
                                    </label>
                                </div>
                                <div class="input-field col s12">
                                    <i class="material-icons prefix">vpn_key</i>
                                    <input id="pass" name="pass" type="password" class="validate" required runat="server" />
                                    <label for="pass">
                                        Password
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="card-action">
                            <span class="right">
                                <asp:LinkButton ID="LogIn" runat="server" OnClick="LogIn_Click" CssClass="btn">
                                    Log In
                                </asp:LinkButton>
                            </span>
                            <asp:Label ID="lblError" runat="server" Text="" CssClass="red-text"></asp:Label>
                            <asp:Label ID="lblSuccess" runat="server" Text="" CssClass="green-text"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
