<%@ Page Title="Service: ReflectionTesting" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="RepositoryTesting.aspx.cs" Inherits="RepositoryTesting" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <style type="text/css">
  .button {
    font: bold 11px Arial;
    text-decoration: none;
    background-color: #EEEEEE;
    color: #333333;
    padding: 2px 6px 2px 6px;
    border-top: 1px solid #CCCCCC;
    border-right: 1px solid #333333;
    border-bottom: 1px solid #333333;
    border-left: 1px solid #CCCCCC;
    text-align:center;
   }
  </style>
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Description: Given a WSDL address, operation name, and parameter list, call the given service operation using the given list of parameters. The code used for Reflection testing is code given to me by Dr. Chen. That I have modified some to ensure that invoking a webservice is possible, its not all of my work therefore credit is not mine. </h2>
    </hgroup>

    <article>
        <asp:Panel ID="ScanBtnPnl" runat="server">
            <div style="text-align: center">
                <asp:Button ID="btnScan" runat="server" OnClick="btnScan_Click" OnClientClick="toggleVisibility('scanresults')" Text="Begin Scan" Height="60px" />
            </div>
        </asp:Panel>
        <asp:Panel ID="scanresults" runat="server">

            <asp:Label ID="lblScan" runat="server" Text="Scanning the internet for webservices"></asp:Label>
            <br />

            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <div class="commissionsDataWrap">
                <asp:GridView ID="gvScanList" runat="server" Width="400px" AutoGenerateColumns="False" ShowHeader="true" AlternatingRowStyle-BackColor="#C2D69B" HeaderStyle-BackColor="green" HeaderStyle-ForeColor="white" OnRowDataBound="gvScanList_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Action" ControlStyle-Width="80px" ControlStyle-Height="20px">
                            <ItemTemplate>
                                <asp:HyperLink class="button" ID="scanLink" runat="server" Text='Scan Wsdl' OnClick='scanLink_Click' NavigateUrl="~/WsdlDetail.aspx"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="url" HeaderText="URL" ControlStyle-Width="100px" />
                        <asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-Font-Bold />
                        <asp:BoundField DataField="documentation" HeaderText="Description" ControlStyle-Width="100px" ItemStyle-Font-Bold />

                    </Columns>
                </asp:GridView>
            </div>

        </asp:Panel>
    </article>
</asp:Content>
