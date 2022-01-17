<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="editcar.aspx.cs" Inherits="RideNow.admin.editcar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <section class="section">
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <div class="row">
                <div class="col s5">
                    <asp:Repeater ID="rpt1" runat="server">
                        <HeaderTemplate>
                            <div class="unselectable row">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="col s12">
                                <div class="card card-auto">
                                    <div class="card-image">
                                        <img src="<%#Eval("PhotoPath") %>" height="350" style="object-fit: cover;" />
                                        <strong>
                                            <span class="card-title">
                                                <%#Eval("BrandName") %> <%#Eval("ModelName") %>
                                            </span>
                                        </strong>
                                    </div>
                                    <div class="card-content">
                                        <dl>
                                            <dt>Info:</dt>
                                            <dd><%#Eval("Descr")%></dd>
                                        </dl>
                                        <dl>
                                            <dt>Year:</dt>
                                            <dd><%#Eval("Year")%></dd>
                                        </dl>
                                        <dl>
                                            <dt>Sales Type:</dt>
                                            <dd><%#Eval("ShowType").ToString()=="1"?"Advertised Special":"Normal"%></dd>
                                        </dl>
                                        <dl>
                                            <dt>Car Quantity:</dt>
                                            <dd><%#Eval("Amt")%></dd>
                                        </dl>
                                    </div>
                                    <div class="card-action center">
                                        <asp:LinkButton runat="server" ID="Delete" CssClass="btn orange center" OnClick="Delete_Click">Delete Car</asp:LinkButton>
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
                    <div class="card">
                        <div class="card-content">
                            <span class="card-title center">
                                Edit Car Info
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
                                <div class="input-field col s12">
                                    <input id="year" name="year" type="number" class="validate" required runat="server" />
                                    <label for="year">
                                        Year
                                    </label>
                                </div>
                                <div class="input-field col s12">
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
                            </div>
                            
                        </div>
                        <div class="card-action center">
                            <span class="chip" runat="server" visible="false">Unavailable</span>
                            <asp:LinkButton runat="server" ID="UpdateCar" OnClick="UpdateCar_Click">Update Car</asp:LinkButton>
                            <a href="addcar.aspx">Add New Car</a>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
