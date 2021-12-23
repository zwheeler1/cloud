<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfrmShowData.aspx.cs" Inherits="wfrmShowData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:Button ID="btnExportToExcel" runat="server" Text="Export to Excel" onclick="btnExportToExcel_Click"  />
</br>
      <asp:GridView ID="dgvQueryResults" runat="server">
      </asp:GridView>
</asp:Content>

