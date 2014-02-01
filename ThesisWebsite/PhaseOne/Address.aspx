<%@ Page Title="Service: Address" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Address.aspx.cs" Inherits="Address" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1> <br/>
        <h2>Description: Analyze a webpage and return all WSDL addresses in that webpage in an array of strings. The WSDL address can have these formats: xxx.wsdl (e.g. developed Java), or ?wsdl (e.g., .php?wsdl,  .svc?wsdl and .asmx?wsdl)</h2>
    </hgroup>

    <article>
        <div>
            <asp:Button ID="scanButton" runat="server" Text="Search" OnClick="ScanFocus_Click" />
            <asp:TextBox ID="websiteUrl" runat="server" Width="486px">http://venus.eas.asu.edu/WSRepository/repository.html</asp:TextBox>
            <br />
            <asp:Label ID="lblError" runat="server"></asp:Label>

            <asp:TextBox Wrap="true" TextMode="MultiLine" ID="ScanResults" runat="server" Height="466px" Width="745px"></asp:TextBox>

        </div>
        <asp:Label ID="lblResults" Visible="false" runat="server">Below are the results of the search</asp:Label>
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
    </article>
</asp:Content>
