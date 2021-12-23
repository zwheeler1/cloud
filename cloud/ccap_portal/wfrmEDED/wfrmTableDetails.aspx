<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfrmTableDetails.aspx.cs" Inherits="wfrmEDED_wfrmTableDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">



    <asp:Label ID="lblCaption" runat="server" Text="Label" Font-Bold="True" 
        Font-Names="Times New Roman" Font-Size="X-Large"></asp:Label>
    <br />
    <br />

<asp:GridView ID="grvTableDetails" runat="server" AutoGenerateColumns="false"  BorderStyle="Solid"
        AlternatingRowStyle-BackColor="#66ccff" Width="800px"  
        Font-Names="Times New Roman" Font-Size="Small" Font-Bold="True">

    <Columns>
 
    <asp:BoundField DataField="tag_business_column_name" HeaderText="Business Name" ReadOnly="True"   /> 
    <asp:BoundField DataField="tag_definition" HeaderText="Definition" ReadOnly="True"   />    
    <asp:BoundField DataField="tag_physical_column_name" HeaderText="DB Name" ReadOnly="True"   /> 
    <asp:BoundField DataField="cat_data_source_system" HeaderText="Source" ReadOnly="True"   />    
    <asp:BoundField DataField="cat_data_type" HeaderText="Data" ReadOnly="True"   /> 
 
   
    </Columns>
    </asp:GridView>
</asp:Content>

