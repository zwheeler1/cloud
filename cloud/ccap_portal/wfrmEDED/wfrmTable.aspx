<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfrmTable.aspx.cs" Inherits="wfrmEDED_wfrmTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">



    <asp:Label ID="lblCaption" runat="server" Text="CCAP Tables" Font-Bold="True" 
        Font-Names="Times New Roman" Font-Size="X-Large"></asp:Label>
    <br />
    <br />

  <asp:GridView ID="grvTableNames" runat="server" AutoGenerateColumns="false" DataKeyNames="TABLE_NAME"  onrowdatabound="grvTableNames_RowDataBound"  AlternatingRowStyle-BackColor="#66ccff" >
    <Columns>
    
     <asp:TemplateField HeaderText = "TABLE_NAME" ItemStyle-Width="30">
            <ItemTemplate>
                <asp:HyperLink ID="hlDetails1" runat="server" NavigateUrl='<%# Eval("TABLE_NAME", "~/wfrmEDED/wfrmTableDetails.aspx?TABLE_NAME={0}") %>'
                    Text='<%# Eval("TABLE_NAME") %>' />
            </ItemTemplate>
        </asp:TemplateField>


   
    <asp:BoundField DataField="tag_table_definition" HeaderText="Definition" ReadOnly="True"   /> 
    <asp:BoundField DataField="cat_refresh_frequency" HeaderText="Refresh Frequency" ReadOnly="True"   /> 
    
    
   
    </Columns>
    </asp:GridView>
</asp:Content>
