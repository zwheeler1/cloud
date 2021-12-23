<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfrmTableInformation.aspx.cs" Inherits="wfrmTableInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<H2>Basic Join and Query Information</H2>
</br>
<b>The following tables can be directly joined with the Property Table (Join Using PK_PROPERTY_ID and FK_PROPERTY_ID):</b>
        <asp:CheckBoxList ID="cbkNonFinancialTables" runat="server">
        <asp:ListItem>MF DIRECT LOAN</asp:ListItem>
        <asp:ListItem>MF FELXIBLE SUBSIDY"</asp:ListItem>
        <asp:ListItem>MF GRANT CAPITAL ADVANCE"</asp:ListItem>
        <asp:ListItem>MF AFS HEADER "</asp:ListItem>
        <asp:ListItem>MF HUD HELD"</asp:ListItem>
        <asp:ListItem>MF INSURED"</asp:ListItem>
        </asp:CheckBoxList>
</br>
        <b>The following tables are Financial tables (Join using PK_AFS_ID)</b>
        <asp:CheckBoxList ID="cbkFinancialTables" runat="server">
        <asp:ListItem>MF AFS HEADER</asp:ListItem>
        <asp:ListItem>MF AFS BALANCE SHEET"</asp:ListItem>
        <asp:ListItem>MF AFS CASH FLOW"</asp:ListItem>
        <asp:ListItem>MF AFS NURSING HOMES"</asp:ListItem>
        <asp:ListItem>MF AFS PROFIT AND LOSS"</asp:ListItem>
        <asp:ListItem>MF AFS RESERVES"</asp:ListItem>
        <asp:ListItem>MF AFS SURPLUS CASH"</asp:ListItem>
        </asp:CheckBoxList>
</br>    
         <b>USE THE HEADER TABLE AS A CROSSWALK BETWEEN OTHER TABLES AND FASS TABLES: LINK ON PROPERTY_ID</b>

</asp:Content>

