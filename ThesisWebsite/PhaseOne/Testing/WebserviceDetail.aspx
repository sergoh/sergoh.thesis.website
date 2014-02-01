<%@ Page Title="Service: ReflectionTesting" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="WebserviceDetail.aspx.cs" Inherits="WebserviceDetail" %>


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
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>

                                       
                    <div class="commissionsDataWrap" >
                        <asp:GridView ID="dvOperationList"  runat="server" AutoGenerateColumns="False" ShowHeader="true" AlternatingRowStyle-BackColor = "#C2D69B" Width = "850px" HeaderStyle-BackColor = "green" HeaderStyle-ForeColor = "white" OnRowDataBound="dgOperationList_ItemDataBound" SkinID="GridViewSkin">                        
                            <Columns>
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="50%"  >
                                    <ItemTemplate>
                                        <asp:HyperLink class="button" ID="scanLink" runat="server" Text='Select Operation' OnClick='scanLink_Click' NavigateUrl="~/OperationDetail.aspx" ></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="operation" HeaderText="Operation"/>
                                <asp:BoundField DataField="protocol" HeaderText="Protocol"/>
                                <asp:BoundField DataField="documentation" ItemStyle-Width="100%" HeaderText="Documentation"/>
                                <asp:BoundField DataField="input" HeaderText="Input"/>
                                <asp:BoundField DataField="inputType" HeaderText="InputType"/>
                                <asp:BoundField DataField="output" HeaderText="Output"/>
                                <asp:BoundField DataField="outputType" HeaderText="OutputType"/>


                            </Columns>
                        </asp:GridView>
                    </div>




                    <asp:Label ID="lblResult" runat="server"></asp:Label>
    </article>
</asp:Content>
