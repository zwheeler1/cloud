<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfrmSearchLoans.aspx.cs" Inherits="ManagePortfolios_wfrmSearchLoans" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

     <table border="1" >
     <tr>
          <td colspan="3" style="width: 67%">
                   Search for loans by IREMS Property Id
                </td>
       </tr>
       <tr>
          <td colspan="3" style="width: 67%">
                  Enter the IREMS Property Id, Click the Search Button and then View Results Below
                </td>
       </tr>
     <tr>
          <td width="33%">
                   <asp:Label ID="lblBname" runat="server" Font-Bold="True" Text="Enter IREMS Property Id:"></asp:Label>
                </td>
                <td width="33%">
                    <asp:TextBox ID="txtIREMSPropertyId" runat="server" Height="22px" Width="302px"></asp:TextBox>
                </td>
                <td width="34%">
                  <asp:Label ID="lblBname0" runat="server"  Text="Ex. 800000001,800004236...."></asp:Label>
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
    
    

    <asp:GridView ID="grvTableNames" runat="server" AutoGenerateColumns="false" DataKeyNames="fk_property_id"  onrowdatabound="grvTableNames_RowDataBound"  AlternatingRowStyle-BackColor="#66ccff" >
    <Columns>
    
     <asp:TemplateField HeaderText = "IREMS Property Id" ItemStyle-Width="30">
            <ItemTemplate>
                <asp:HyperLink ID="hlDetails1" runat="server" NavigateUrl='<%# Eval("fk_property_id", "~/ManagePortfolios/wfrmTableDetails.aspx?fk_property_id={0}") %>'
                    Text='<%# Eval("fk_property_id") %>' />
            </ItemTemplate>
        </asp:TemplateField>


     <asp:BoundField DataField="tag_property_name" HeaderText="Property Name" ReadOnly="True"   />
    <asp:BoundField DataField="fk_fha_number" HeaderText="FHA Number" ReadOnly="True"   /> 
     <asp:BoundField DataField="tag_project_manager" HeaderText="Project Manager" ReadOnly="True"   /> 
    <asp:BoundField DataField="mtr_unpaid_principal_balance" HeaderText="UPB" ReadOnly="True"   /> 

    <asp:BoundField DataField="mtr_rating" HeaderText="Initial Rating" ReadOnly="True"   /> 
    <asp:BoundField DataField="mtr_rating_override" HeaderText="Rating Override" ReadOnly="True"   /> 
     <asp:BoundField DataField="mtr_rating_final" HeaderText="Final Rating" ReadOnly="True"   />     
    <asp:BoundField DataField="date_final_rating" HeaderText="Date Final Rating" ReadOnly="True"   /> 

    <asp:BoundField DataField="date_ext_date" HeaderText="Download Date" ReadOnly="True"   /> 
    
    
   
    </Columns>
    </asp:GridView>

    <br />
    <br />
</asp:Content>

