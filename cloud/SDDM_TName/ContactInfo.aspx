<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ContactInfo.aspx.cs" Inherits="ContactInfo" %>


 


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

<style type="text/css">
.Hide 
{ 
    display:none; 
  } 
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<table style="border:0px solid black;" align="center">

<tr><td class="ModuleSectionFont" colspan="3">
    AppNumber:<asp:Label ID="lblContactNumber" runat="server" ForeColor="Red"></asp:Label>
    </td><td>&nbsp;</td></tr>

<tr><td class="ModuleSectionFont" colspan="3">
    &nbsp;</td><td>&nbsp;</td></tr>

<tr><td class="ModuleSectionFont" colspan="3">
    <asp:Label ID="Label1" runat="server" Text="Contact Information"></asp:Label>
    </td><td>&nbsp;</td></tr>
    <tr><td>
    <asp:RadioButton ID="rbSameAsPremise" runat="server" Text="Same As Business Address" />
    </td><td>&nbsp;</td><td>&nbsp;</td><td></td></tr>
<tr><td>Select Contact Type</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td>
    <asp:DropDownList ID="ddlApplicantType" runat="server">
    <asp:ListItem>Select</asp:ListItem>
    <asp:ListItem>Applicant</asp:ListItem>
    <asp:ListItem>Billing</asp:ListItem>
    <asp:ListItem>Agent</asp:ListItem>
    </asp:DropDownList>
    </td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td>First Name</td>
                                                        
     <td>MI</td><td>Last Name</td></tr>
<tr><td><asp:TextBox  runat="server"  ID="txtApplicantFName"></asp:TextBox></td><td>
    <asp:TextBox  runat="server"  ID="txtApplicantMI"></asp:TextBox></td><td>
        <asp:TextBox  runat="server"  ID="txtApplicantLName"></asp:TextBox></td></tr>
<tr><td>Street No</td><td>Street Name</td><td>Street Type</td><td>Quadrant</td></tr>
<tr><td><asp:TextBox  runat="server"  ID="txtStNo" Width="75px"></asp:TextBox></td><td><asp:TextBox  runat="server"  ID="txtStName"></asp:TextBox></td><td>
    <asp:TextBox  runat="server"  ID="txtStType" Width="75px"></asp:TextBox></td><td>
        <asp:TextBox  runat="server"  ID="txtQuad" Width="75px"></asp:TextBox></td></tr>
<tr><td>Suite</td><td>City</td><td>State</td><td>Zip</td></tr>

<tr><td><asp:TextBox  runat="server"  ID="txtSuite" Width="75px"></asp:TextBox></td><td><asp:TextBox  runat="server"  ID="txtCity"></asp:TextBox></td><td>
    <asp:TextBox  runat="server"  ID="txtState" Width="75px"></asp:TextBox></td><td>
        <asp:TextBox  runat="server"  ID="txtZip" Width="75px"></asp:TextBox></td></tr>

<tr><td>Phone Number</td><td>Email</td><td>
    &nbsp;</td><td>
        &nbsp;</td></tr>

<tr><td><asp:TextBox  runat="server"  ID="txtPhone" Width="100px"></asp:TextBox></td>
    <td colspan="3"><asp:TextBox  runat="server"  ID="txtEmail" Width="250px"></asp:TextBox></td></tr>

<tr><td colspan="4">
    <asp:Label ID="lblInformation" runat="server" ForeColor="Red"></asp:Label>
    </td></tr>

<tr><td colspan="4">
    <asp:Button ID="btnAddContact" runat="server" Text="Add Contact" 
        onclick="btnAddContact_Click" />

        <asp:Button ID="btnUpdateContact" runat="server" Text="Update Contact" 
        onclick="btnUpdateContact_Click" />
    </td></tr>

<tr><td colspan="4">
    &nbsp;</td></tr>

<tr><td colspan="4">
 <asp:GridView ID="grvContacts" runat="server" AutoGenerateColumns="False"
            HorizontalAlign="Left" Caption="Contacts" 
			datakeynames="pk_Contact_Id" 
        onselectedindexchanged="grvContacts_SelectedIndexChanged" >
            <AlternatingRowStyle CssClass="gvAlternatingRowStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <FooterStyle CssClass="FooterStyle" />
      <Columns>
            <asp:ButtonField HeaderText="Contact Id" CommandName="Select" DataTextField="pk_Contact_Id"/> 
            <asp:BoundField datafield="fk_AppNumber" HeaderText="AppNumber" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide"/> 
            <asp:BoundField datafield="cat_ContactType" Headertext="Type" />          
            <asp:BoundField datafield="tag_FirstName" Headertext="First Name" />
            <asp:BoundField datafield="tag_MiddleName" Headertext="MI" />
            <asp:BoundField datafield="tag_LastName" Headertext="Last Name" />
            <asp:BoundField datafield="tag_STNO" Headertext="Stno" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide"/>
            <asp:BoundField datafield="tag_STNAME"  Headertext="StName"   HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide"/>
            <asp:BoundField datafield="tag_STQUAD" Headertext="Quad"   HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide"/>
            <asp:BoundField datafield="tag_STTYPE" Headertext="StType"   HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide"/>
            <asp:BoundField datafield="tag_STSUITE" Headertext="Suite"   HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide"/>
            <asp:BoundField datafield="tag_CITY"  Headertext="City"   HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide"/>
            <asp:BoundField datafield="tag_STATE" Headertext="State"   HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide"/>
            <asp:BoundField datafield="tag_ZIP" Headertext="Zip"   HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide"/>
            <asp:BoundField datafield="tag_PHONE" Headertext="Phone" />
            <asp:BoundField datafield="tag_EMAIL"  Headertext="Email" />
            <asp:BoundField datafield="cat_ContactOffice" Headertext="Office" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide"/>
    </Columns>
    </asp:GridView>
    </td></tr>

</table>
 </asp:Content>

