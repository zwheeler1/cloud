<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TnFees.aspx.cs" Inherits="TnFees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">



<table>
<tr><td><asp:GridView ID="grvFees" runat="server" AutoGenerateColumns="False"
            HorizontalAlign="Left" Caption="Fees" 
			datakeynames="pk_id" onselectedindexchanged="grvFees_SelectedIndexChanged1">
            <AlternatingRowStyle CssClass="gvAlternatingRowStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <FooterStyle CssClass="FooterStyle" />
      <Columns>
      <asp:ButtonField HeaderText="Fee Id" CommandName="Select"
                DataTextField="pk_id"/>
            <asp:BoundField datafield="fk_AppNumber" HeaderText="AppNumber"/>           
            <asp:BoundField datafield="mtr_fee" Headertext="Fee Amount" />
            <asp:BoundField datafield="tag_fee_description" Headertext="Fee Description" />
            <asp:BoundField datafield="cat_fee_status" Headertext="Status (Paid/Unpaid)" />
            <asp:BoundField datafield="dateAdded" Headertext="Date Added" />
            
    </Columns>
    </asp:GridView>
</td><td></td></tr>

<tr>
<td>
<asp:Button ID="btnSubmit" runat="server" Text="Submit" />
<asp:Button ID="btnUpdate" runat="server" Text="Update" Enabled="false" />
<asp:Button ID="btnPrint" runat="server" Text="Print Invoice" onclick="btnPrint_Click" OnClientClick="window.open('Invoice.aspx', 'Invoice');" />



</td>



<td></td></tr></table>
</asp:Content>

