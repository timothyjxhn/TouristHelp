﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPageAddAttraction.aspx.cs" Inherits="TouristHelp.AdminPageAddAttraction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div style="background-color: lightcyan">
        <h1 class="mb-3 bread" data-scrollax="properties: { translateY: '30%', opacity: 1.6 }" style="text-align: center; transform: translateZ(0px) translateY(10.929%);">Guidebook</h1>
    </div>
    <div>
        <asp:Button ID="ButtonAdd" runat="server" Text="Add Attraction" Width="124px" />
        <br />
        <br />
        <asp:Repeater ID="RepeaterAttraction" runat="server">
            <ItemTemplate>
                <div class="col-sm col-md-6 col-lg-12" style="border-style: solid; border-width: 1px; margin-bottom: 10px">
                    <%-- Proto Box --%>

                    <a href="#" class="img img-2 d-flex justify-content-center align-items-center" style="background-image: url(images/destination-3.jpg);">
                        <div class="icon d-flex justify-content-center align-items-center">
                            <span class="icon-link"></span>
                        </div>
                    </a>
                    <div class="text p-3">
                        <asp:Label ID="LbId" runat="server" Visible="false" Text='<%#Eval("Id") %>'></asp:Label> <%--to put id for db retrieval--%>
                        <div class="one">
                            <h3 id="Name"><%#Eval("Name") %></h3>
                        </div>
                        <div class="two">
                            <span class="price" id="price">$<%#Eval("Price") %></span></div>
                        <div class="days"><span><%#Eval("DateTime") %></span></div>
                        <h4 id="desc"><%#Eval("Description") %></h4>
                        <hr>
                        <p class="bottom-area d-flex">
                            <span><i class="icon-map-o"></i><%#Eval("Location") %></span>
                        </p>
                        <asp:Button ID="ButtonSelect" runat="server" CssClass="btn btn-default" Text="More info" Style="float: right" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    </form>

</asp:Content>
