<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="RideNow.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <section class="section">
            <div class="row">
                <div class="col s10 offset-s1">
                    <div class="card">
                        <div class="card-content">
                            <span class="card-title center">
                                Register An Account
                            </span>
                            <div class="row">
                                <div class="input-field col s12">
                                    <i class="material-icons prefix">account_circle</i>
                                    <input id="fullname" name="fullname" type="text" class="validate" required runat="server" />
                                    <label for="fullname">
                                        Full Name
                                    </label>
                                </div>
                                <div class="input-field col s12">
                                    <i class="material-icons prefix">email</i>
                                    <input id="email" name="email" type="text" class="validate" required runat="server" />
                                    <label for="email">
                                        Email
                                    </label>
                                </div>
                                <div class="input-field col s12 m6">
                                    <i class="material-icons prefix">vpn_key</i>
                                    <input id="pass" name="pass" type="password" class="validate" required runat="server" />
                                    <label for="pass">
                                        Password
                                    </label>
                                </div>
                                <div class="input-field col s12 m6">
                                    <i class="material-icons prefix">vpn_key</i>
                                    <input id="cpass" name="cpass" type="password" class="validate" required runat="server" />
                                    <label for="cpass">
                                        Confirm Password
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="card-action">
                            <span class="right">
                                <asp:LinkButton ID="Register" runat="server" OnClick="Register_Click" CssClass="btn">
                                    Register
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
