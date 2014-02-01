<%@ Page Title="Service: SiteCrawler" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SiteCrawler.aspx.cs" Inherits="Operations" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Description: Call a Simple Web Crawler to discover  all the visible addresses of a particular website.</h2>
    </hgroup>

    <article>
        <div>
            <asp:Label ID="Label8" runat="server" Text="Crawel Website URI "></asp:Label>
            <asp:TextBox ID="txtURI" Text="http://www.webservicex.net" Width="400px" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
            <asp:Label ID="lblWeb" runat="server"></asp:Label>
            <asp:Button ID="btnWebFocus" runat="server" OnClick="btnWebFocus_Click" Text="Begin Crawl" />
            <br />

            <asp:ListView ID="lvLinks" runat="server">
                <LayoutTemplate>
                    <ul>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </ul>
                </LayoutTemplate>

                <ItemTemplate>
                    <li>
                        <%# Container.DataItem %>
                    </li>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </article>
</asp:Content>
