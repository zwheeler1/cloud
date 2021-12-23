<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfrmSearchByBName.aspx.cs" Inherits="wfrmEDED_wfrmSearchByBName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


     <table border="1" >
     <tr>
          <td colspan="3" style="width: 67%">
                   Search for tables with key words in the definition of a field
                </td>
       </tr>
       <tr>
          <td colspan="3" style="width: 67%">
                  Enter the KeyWord, Click the Search Button and then View Results Below
                </td>
       </tr>
     <tr>
          <td width="33%">
                   <asp:Label ID="lblBname" runat="server" Font-Bold="True" Text="Enter Key Word:"></asp:Label>
                </td>
                <td width="33%">
                    <asp:TextBox ID="txtBusinessName" runat="server" Height="22px" Width="302px"></asp:TextBox>
                </td>
                <td width="34%">
                  <asp:Label ID="lblBname0" runat="server"  Text="Ex. Claim, Insured, Construction, etc...."></asp:Label>
                </td>
       </tr>
     <tr>
          <td width="33%">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Click on Search Button:"></asp:Label></td>
                <td width="33%">
                    <asp:Button ID="btnSearch" runat="server" Font-Bold="True" Font-Size="Medium" 
                        onclick="btnSearch_Click" Text="Click to here to Search" />
          </td>
                <td width="34%">
                    &nbsp;</td>
       </tr>
        </table>
    
    

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

    <br />
    <br />
</asp:Content>

