<%@ Page Title="Service: Operations" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Operations.aspx.cs" Inherits="Operations" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Description: Analyze a WSDL file in XML format and return operation names and their corresponding input parameter and return types.</h2>
    </hgroup>

    <article>
        <div>

            <br />
            <asp:Label ID="Label5" runat="server" Text="Input URL of an wsdl (?wsdl) file:  "></asp:Label>
            <asp:TextBox ID="txtURL2" runat="server" Width="350">http://www.dneonline.com/calculator.asmx?wsdl</asp:TextBox>
            <br />
            <asp:Button ID="btnXPath" runat="server" OnClick="btnXPath_Click" Text="Scan" />
            <br />
            <asp:Label ID="lblValue" runat="server"></asp:Label>

            <asp:ListView ID="lvOperations" runat="server">
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
