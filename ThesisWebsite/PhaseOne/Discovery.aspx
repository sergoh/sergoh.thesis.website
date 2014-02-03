<%@ Page Title="Service: Discovery" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Discovery.aspx.cs" Inherits="Discovery" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1><br/>
        <h2>Description: Call Bing search engine API to discover the Web pages that contain WSDL addresses, and follow the address to discover WSDL files.</h2>
    </hgroup>

    <article>
        <div>
            <%--<asp:Label ID="Label8" runat="server" Text="Search Topics sepereated by commas "></asp:Label>
            <asp:TextBox ID="txtTopic1" runat="server">.wsdl,.php?wsdl,.svc?wsdl,.asmx?wsdl</asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />--%>
            <center><asp:Button ID="btnWebFocus" runat="server" OnClick="btnWebFocus_Click" Text="Search Bing" /><asp:Button ID="btnGoogle"  runat="server"  Text="Search Google" /><asp:Button ID="btnYahoo"  runat="server" OnClick="btnYahoo_Click"  Text="Search Yahoo" /></center>
            <br />
            <asp:Label ID="lblWeb" runat="server"></asp:Label>
            <asp:Label ID="lblYahoo" runat="server"></asp:Label>
        </div>
    </article>
</asp:Content>
