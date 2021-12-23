<%@ Page Language="C#" AutoEventWireup="true" CodeFile="showdata.aspx.cs" Inherits="showdata" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <div>
   Filter By Column Name:<br />
&nbsp;<asp:DropDownList ID="ddlFilterByColumnName" runat="server">
           
    </asp:DropDownList>
       <br />
       Enter Value to Filter By:</div>
    
     <div>
    <asp:TextBox ID="txtFilter" runat="server"></asp:TextBox>
    </br>
    <asp:Button ID="btnFilter" runat="server" Text="Filter Data" onclick="btnFilter_Click"  />   
         <br />
    <asp:Button ID="btnViewAllData" runat="server" Text="View All Data" 
             onclick="btnViewAllData_Click"  />   
         <br />
    </div>
     <div>
    <asp:Button ID="btnExportToExcel" runat="server" Text="Export to Excel" onclick="btnExportToExcel_Click"  />   
    </div>
     <div>
    
       <asp:GridView ID="dgvQueryResults" runat="server">
           <AlternatingRowStyle BackColor="#0066FF" BorderColor="Black" 
               BorderStyle="Solid" />
      </asp:GridView>
      </div>
    </form>
</body>
</html>
