<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="addcar.aspx.cs" Inherits="RideNow.admin.addcar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <section class="section">
            <div class="row">
                <div class="col s10 offset-s1">
                    <div class="card">
                        <div class="card-content">
                            <span class="card-title center">
                                Add Car To Inventory
                            </span>
                            <div class="row">
                                <div class="input-field col s12">
                                    <input id="modelname" name="modelname" type="text" class="validate" required runat="server" />
                                    <label for="modelname">
                                        Model Name
                                    </label>
                                </div>
                                <div class="input-field col s12">
                                    <input id="brandname" name="brandname" type="text" class="validate" required runat="server" />
                                    <label for="brandname">
                                        Brand Name
                                    </label>
                                </div>
                                <div class="input-field col s12 m6">
                                    <input id="year" name="year" type="number" class="validate" required runat="server" />
                                    <label for="year">
                                        Year
                                    </label>
                                </div>
                                <div class="input-field col s12 m6">
                                    <input id="numInStock" name="numInStock" type="number" class="validate" required runat="server" />
                                    <label for="amount">
                                        Number in stock
                                    </label>
                                </div>
                                <div class="input-field col s12">
                                    <select id="salestype" name="salestype" runat="server">
                                        <option value="0" disabled selected>Choose sales type</option>
                                        <option value="0">Normal</option>
                                        <option value="1">Advertised special</option>
                                    </select>
                                    <label for="salestype">
                                        Sales Type
                                    </label>
                                </div>
                                <div class="input-field col s12">
                                    <textarea class="materialize-textarea" id="description" name="description" runat="server"></textarea>
                                    <label for="description">Description</label>
                                </div>
                                <div class="unselectable input-field col s12">
                                    <span class="btn teal">
                                        <asp:FileUpload ID="FileUpload" runat="server" CssClass="file-path-wrapper" />
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="card-action">
                            <span class="right">
                                <asp:LinkButton ID="AddCar" runat="server" OnClick="AddCar_Click" CssClass="btn">
                                    Add car to inventory
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
