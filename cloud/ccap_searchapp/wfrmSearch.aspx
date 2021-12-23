<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfrmSearch.aspx.cs" Inherits="wfrmSearch" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style type ="text/css">
        .innerTableCell
        {
          text-align:center;
          width:450px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

 <asp:Table ID="Table5" runat="server" Width="900px" align = "center">
                   <asp:TableRow>
            <asp:TableCell Width="450px">
            <asp:Table ID="Table3" runat="server" Width="450px" Border ="1px" Height="505px">
            <asp:TableRow><asp:TableCell> FieldsTo Retrieve</asp:TableCell></asp:TableRow>   
             <asp:TableRow><asp:TableCell> <asp:TextBox ID="txtSelect" Height="75px" runat="server" TextMode="MultiLine"  Width="450px">Select * </asp:TextBox></asp:TableCell></asp:TableRow>
             <asp:TableRow><asp:TableCell> Enter Tables</asp:TableCell></asp:TableRow>
             <asp:TableRow><asp:TableCell> <asp:TextBox ID="txtFrom" Height="75px" runat="server" TextMode="MultiLine" Width="450px">From  </asp:TextBox></asp:TableCell></asp:TableRow>
             <asp:TableRow><asp:TableCell> Enter Conditions</asp:TableCell></asp:TableRow>
             <asp:TableRow><asp:TableCell> <asp:TextBox ID="txtWhere" Height="75px" runat="server" TextMode="MultiLine" Width="450px">Where </asp:TextBox></asp:TableCell></asp:TableRow>
             <asp:TableRow><asp:TableCell> Enter Group By</asp:TableCell></asp:TableRow>
             <asp:TableRow><asp:TableCell>  <asp:TextBox ID="txtGroupBy" Height="75px"  runat="server" TextMode="MultiLine" Width="450px">Group By  </asp:TextBox></asp:TableCell></asp:TableRow>
             <asp:TableRow><asp:TableCell> <asp:Button ID="btnRunQuery" runat="server" Text="Run Query" onclick="btnRunQuery_Click" /></asp:TableCell></asp:TableRow>
             <asp:TableRow><asp:TableCell> <asp:Button ID="btnExportToExcel" runat="server" Text="Export to Excel" onclick="btnExportToExcel_Click"  /></asp:TableCell></asp:TableRow>
             </asp:Table>
             </asp:TableCell>
                    
        <asp:TableCell>
        <asp:Table ID="Table4" runat="server" Width="450px" Border ="1px" Height="200 px">
        <asp:TableRow><asp:TableCell>Basic Joins and Conditions</asp:TableCell></asp:TableRow> 
        <asp:TableRow><asp:TableCell><asp:TextBox ID="txtJoinInformation" runat="server" Height="100px" TextMode="MultiLine" Width="450px"></asp:TextBox></asp:TableCell></asp:TableRow> 
         <asp:TableRow><asp:TableCell><asp:TextBox ID="txtCrosswalk" runat="server" Height="35px" TextMode="MultiLine" Width="450px"></asp:TextBox></asp:TableCell></asp:TableRow> 
       
        <asp:TableRow><asp:TableCell><asp:TextBox ID="txtInfo2" runat="server" Height="100px" TextMode="MultiLine" Width="450px"></asp:TextBox></asp:TableCell></asp:TableRow> 
        <asp:TableRow><asp:TableCell> <asp:CheckBox ID="cbkJoinWithProperty" runat="server" AutoPostBack="True" oncheckedchanged="cbkJoinWithProperty_CheckedChanged" Text="Join With Property Table" /></asp:TableCell></asp:TableRow> 
                  
        <asp:TableRow><asp:TableCell><asp:CheckBox ID="cbkSpecificProperties" runat="server" AutoPostBack="True" oncheckedchanged="cbkSpecificProperties_CheckedChanged" Text="Search for Specific Property(s)" /></asp:TableCell></asp:TableRow> 
        <asp:TableRow><asp:TableCell>B<asp:Label ID="lblPropertyIds" runat="server" Text="Enter iRems Property Id(s) Seperated by Commas"></asp:Label></asp:TableCell></asp:TableRow> 
        <asp:TableRow><asp:TableCell><asp:TextBox ID="txtPropertyIds" runat="server" Height="72px" TextMode="MultiLine" Width="450px"></asp:TextBox></asp:TableCell></asp:TableRow> 
        <asp:TableRow><asp:TableCell><asp:CheckBox ID="chkAddProperties" runat="server" AutoPostBack="True" oncheckedchanged="chkAddProperties_CheckedChanged" Text="Add Property(s) to Search" /></asp:TableCell></asp:TableRow> 
        <asp:TableRow><asp:TableCell><asp:CheckBox ID="cbkActiveInsuredLoan" runat="server" AutoPostBack="True" oncheckedchanged="cbkActiveInsuredLoan_CheckedChanged" Text="Get Active Insured Loans" /></asp:TableCell></asp:TableRow> 
                 
                  
                  
                  
                  
                  
                  
                   </asp:Table>
                    </asp:TableCell>
                   </asp:TableRow>
                   </asp:Table>

             
        
        
      <asp:GridView ID="dgvQueryResults" runat="server">
             </asp:GridView>
        
        
</asp:Content>


