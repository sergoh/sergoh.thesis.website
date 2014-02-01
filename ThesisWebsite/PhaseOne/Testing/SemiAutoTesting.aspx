<%@ Page Title="Service: SemiAutoTesting" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SemiAutoTesting.aspx.cs" Inherits="SemiAutoTesting" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Description: Given a WSDL address call the given service operation of each service using the given list of parameters. These services are supposed to implement the function.</h2>
    </hgroup>

    <article>
        <div>
        <asp:Label ID="Label1" runat="server" Text="Enter WSDL:"></asp:Label>
        <asp:TextBox ID="txtWSDL" runat="server" Width="510px">http://www.html2xml.nl/Services/Calculator/Version1/Calculator.asmx?WSDL</asp:TextBox>
        <asp:Button ID="btnGo" runat="server" onclick="ScanFocus_Click" Text="Test Web Service" />

        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:TextBox  Wrap="true" TextMode="MultiLine" ID="ScanResults" runat="server" Height="466px" Width="745px"></asp:TextBox>
    
       </div>

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
