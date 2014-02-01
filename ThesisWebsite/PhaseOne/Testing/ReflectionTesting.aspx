<%@ Page Title="Service: ReflectionTesting" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ReflectionTesting.aspx.cs" Inherits="ReflectionTesting" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Description: Given a WSDL address, operation name, and parameter list, call the given service operation using the given list of parameters. The code used for Reflection testing is code given to me by Dr. Chen. That I have modified some to ensure that invoking a webservice is possible, its not all of my work therefore credit is not mine. </h2>
    </hgroup>

    <article>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Enter WSDL:"></asp:Label>
        <asp:TextBox ID="txtWSDL" runat="server" Width="510px">http://www.html2xml.nl/Services/Calculator/Version1/Calculator.asmx?WSDL</asp:TextBox>
        <asp:Button ID="btnGo" runat="server" OnClick="btnGo_Click" Text="Get Operations" />
        <h2>
            <asp:ListBox ID="lbMethods" runat="server" Height="152px" Width="341px"
                OnSelectedIndexChanged="lbMethods_SelectedIndexChanged"
                OnTextChanged="lbMethods_SelectedIndexChanged" ViewStateMode="Enabled"></asp:ListBox>
            <asp:Button ID="btnMethods" runat="server" OnClick="btnOperations_Click" Text="Continue" Visible="False" />
        </h2>

        <p>
            <asp:Repeater ID="parametersSet" runat="server"
                OnItemDataBound="parametersSet_ItemDataBound" ViewStateMode="Enabled">
                <ItemTemplate>
                    <asp:Label runat="server" ID="label">Null</asp:Label>
                    <asp:TextBox runat="server" ID="text"></asp:TextBox>
                    <br />
                </ItemTemplate>

            </asp:Repeater>
            <asp:Button ID="btnInvoke" runat="server" OnClick="btnTest_Click" Text="Test" Visible="False" />
        </p>
        <p>
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </p>
    </article>
</asp:Content>
