<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="Invoice" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
Invoice Goes Here

 <rsweb:ReportViewer ID="rvInvoice" ShowParameterPrompts="true" runat="server" 
            Width="1028px" Height="90%" ProcessingMode="Remote" AsyncRendering="false" 
            Font-Names="Verdana" Font-Size="10pt" ShowBackButton="True" 
            SizeToReportContent="True">
         <ServerReport 
       ReportServerUrl="http://ssrs2008.outsourceis.com/ReportServer" 
        ReportPath="/reports/Permits/" />

        </rsweb:reportviewer>

</asp:Content>

