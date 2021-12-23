<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table style="border:0px solid black;" align="center">
<tr><td class="ModuleSectionFont" colspan="4">
    <asp:Label ID="Label1" runat="server" Text="Search Options"></asp:Label>
    </td></tr>
<tr><td>
    <asp:RadioButton ID="rbByAppNumber" runat="server" Text="By App Number" />
    </td><td>
    <asp:RadioButton ID="rbByTaxId" runat="server" Text="By Tax Id" />
    </td><td>
    <asp:RadioButton ID="rbByEntityName" runat="server" Text="By Business Name" />
    </td><td>
    <asp:RadioButton ID="rbByTradeName" runat="server" Text="By TradeName" />
    </td></tr>
<tr><td>
    &nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td>Enter Search Criteria</td>
                                                        
     <td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td colspan="2">
    <asp:TextBox  runat="server"  ID="txtSearchBy" 
        Width="200px"></asp:TextBox></td><td>
        &nbsp;</td></tr>
<tr><td>
    <asp:Button ID="btnFind" runat="server" Text="Find" onclick="btnFind_Click" />
    </td><td>
    <asp:Button ID="btnClear" runat="server" Text="Clear" onclick="btnClear_Click" />
    </td><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td>&nbsp;</td><td>&nbsp;</td><td>
    &nbsp;</td><td>
        &nbsp;</td></tr>
<tr><td class="ModuleSectionFont" colspan="4">
    View Search Results</td></tr>

<tr><td colspan="4"><div>
        
            
             <asp:GridView ID="grvSearch" runat="server" AutoGenerateColumns="False"
            HorizontalAlign="Left" Caption="Trade Name" 
			datakeynames="pk_AppNumber" onselectedindexchanged="grvSearch_SelectedIndexChanged1">
            <AlternatingRowStyle CssClass="gvAlternatingRowStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <FooterStyle CssClass="FooterStyle" />
      <Columns>
            <asp:ButtonField HeaderText="AppNumber" CommandName="Select"
                DataTextField="pk_AppNumber"/>           
            <asp:BoundField datafield="fk_AddressKey" Headertext="Addresskey" />
            <asp:BoundField datafield="tag_BusinessName" Headertext="Business Name" />
            <asp:BoundField datafield="tag_BusinessEntityType" Headertext="Business Entity" />
            <asp:BoundField datafield="tag_BusinessTradeName" Headertext="Trade Name" />
            <asp:BoundField datafield="tag_BusinessTaxId"  Headertext="Tax Id" />
            <asp:BoundField datafield="tag_SubmittedBy" Headertext="Submitted By" />
            <asp:BoundField datafield="date_AppSubmitted" Headertext="Date Submitted" />
             <asp:BoundField datafield="ind_LicenseBusiness" Headertext="Valid License" />
            
    </Columns>
    </asp:GridView>
	
        
            
             </div>       
            <div>
            </div>

    </td></tr>

<tr><td>
    &nbsp;</td><td></td><td></td></tr>

</table>

</asp:Content>



