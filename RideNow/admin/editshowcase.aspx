<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="editshowcase.aspx.cs" Inherits="RideNow.admin.editshowcase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <section class="section">
        <asp:Label ID="lblError" CssClass="center red white-text" runat="server"></asp:Label>
        <div class="row">
            <div class="col s5">
                <asp:Repeater ID="rpt1" runat="server">
                    <HeaderTemplate>
                        <div class="unselectable row">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="col s12">
                            <div class="card">
                                <div class="card-image">
                                    <img src='<%#Eval("PhotoPath") %>' height="350" style="object-fit: cover;" />
                                    <strong>
                                        <span class="card-title">
                                            <%#Eval("BrandName") %>
                                        </span>
                                    </strong>
                                </div>
                                <div class="card-content">
                                    <dl>
                                        <dt>Short Description:</dt>
                                        <dd><%#Eval("ShortDescr") %></dd>
                                        <dt>Long Description:</dt>
                                        <dd><%#Eval("LongDescr") %></dd>
                                        <dt>Sales Type:</dt>
                                        <dd><%#Eval("ShowType").ToString()=="1"?"Advertised Special":"Normal" %></dd>
                                    </dl>
                                </div>
                                <div class="card-action center">
                                    <a class="btn orange" href="addshowcase.aspx">New showcase</a>
                                    <asp:LinkButton ID="Delete" runat="server" CssClass="btn red" OnClick="Delete_Click">Delete this showcase</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="col s7">
                <div class="row"">
                    <div class="col s10 offset-s1">
                        <div class="card">
                            <div class="card-content">
                                <span class="card-title center">
                                    Update Showcase
                                </span>                            
                            <div class="row">
                                <div class="row">
                                    <div class="input-field col s12">
                                        <input id="brandname" name="brandname" type="text" class="validate" required runat="server" />
                                        <label for="brandname">Brand Name</label>
                                    </div>
                                    <div class="input-field col s12">
                                        <input id="shortdescr" name="shortdesc" type="text" class="validate" required runat="server" />
                                        <label for="shortdescr">Short Description</label>
                                    </div>
                                    <div class="input-field col s12">
                                        <textarea class="materialize-textarea" id="longdescr" runat="server"></textarea>
                                        <label for="longdescr">Long Description</label>
                                    </div>
                                    <div class="input-field col s12">
                                        <select id="showtype" name="showtype" runat="server">
                                            <option value="" disabled>Select sales type</option>
                                            <option value="0">Normal</option>
                                            <option value="1">Advertised special</option>
                                        </select>
                                        <label for="showtype">Sales type</label>
                                    </div>
                                </div>
                            </div>
                            </div>
                            <div class="card-action">
                                <span class="right">
                                    <asp:LinkButton ID="UpdateShowcase" runat="server" OnClick="UpdateShowcase_Click" CssClass="btn orange">
                                        Update showcase
                                    </asp:LinkButton>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</div>
</asp:Content>
