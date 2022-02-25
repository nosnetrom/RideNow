<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="addshowcase.aspx.cs" Inherits="RideNow.admin.addshowcase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="row">
            <div class="col s10 offset-s1">
                <asp:Label ID="lblError" runat="server"></asp:Label>
                <div class="card">
                    <div class="card-content">
                        <span class="card-title center">
                            Add Showcase
                        </span>
                        <div class="row">
                            <div class="row">
                                <div class="input-field col s12">
                                    <input id="brandname" name="brandname" type="text" class="validate" required runat="server" />
                                    <label for="brandname">Brand Name</label>
                                </div>
                        
                                <div class="input-field col s12">
                                    <input id="shortdescr" name="shortdescr" type="text" class="validate" runat="server" />
                                    <label for="shortdescr">Short Description</label>
                                </div>
                                <div class="input-field col s12">
                                    <textarea id="longdescr" name="longdescr" class="materialize-textarea" runat="server" />
                                    <label for="longdescr">Long Description</label>
                                </div>
                                <div class="input-field col s12">
                                    <select id="salestype" name="salestype" runat="server">
                                        <option value="0" disabled selected>Select type</option>
                                        <option value="0">Normal</option>
                                        <option value="1">Advertised special</option>
                                    </select>
                                    <label for="salestype">Sales Type</label>
                                </div>
                                <div class="unselectable input-field col s12">
                                    <span class="btn orange-text">
                                        <asp:FileUpload ID="FileUpload" runat="server" CssClass="file-path-wrapper" />
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-action">
                        <span class="right">
                            <asp:LinkButton ID="AddShowcase" runat="server" OnClick="AddShowcase_Click" CssClass="btn orange">
                                Add Showcase
                            </asp:LinkButton>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
