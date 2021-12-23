<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">





<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0">
    <ProgressTemplate>

    <link href="~/Styles/CalendarControl.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="~/Javascript/CalendarControl.js" language="javascript"></script>
    
    <div class="UpdateProgess1">
    <h5> One Moment.  Please Wait..................
    <img  alt="" src="../Images/progressCircle.gif" /></h5>
    </div>
    </ProgressTemplate>
    
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<div>
<table style="border:0px solid black;" align="center">
    
    <tr>
        <td colspan="4">
            <asp:Label ID="lblInformation" runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="ModuleSectionFont" colspan="4">
            <asp:Label ID="Label8" runat="server" Text="App Number: "></asp:Label>
            <asp:Label ID="lblAppNumber" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="ModuleSectionFont" colspan="4">
            <asp:Label ID="Label7" runat="server" Text="Action Information"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>Action</td>
        <td>Date Submitted</td>
        <td>Fee</td>
        <td></td>
    </tr>
<tr><td><asp:DropDownList  runat="server"  ID="ddlAction" AutoPostBack="True" 
        onselectedindexchanged="ddlAction_SelectedIndexChanged"><asp:ListItem>Select</asp:ListItem>
                                                        <asp:ListItem>New</asp:ListItem>
                                                        <asp:ListItem>Renewal</asp:ListItem>
                                                        <asp:ListItem>Cancellation</asp:ListItem>
                                                        <asp:ListItem>Amendment</asp:ListItem>
                                                        <asp:ListItem>Duplicate Certificate</asp:ListItem>
                                                        <asp:ListItem>Certificate of Fact</asp:ListItem>
                                                        <asp:ListItem>Deficeny Notice</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                        
     <td><asp:TextBox  runat="server"  ID="dteSubmitted"  Enabled="false" ></asp:TextBox></td>
     
     <td colspan="2"><asp:TextBox  runat="server"  ID="txtFee" BackColor="Yellow" Enabled="false" ></asp:TextBox></td>
     </tr>
<tr><td class="ModuleSectionFont" colspan="4">
    <asp:Label ID="Label1" runat="server" Text="Date Information"></asp:Label>
    </td></tr>
<tr><td>Date Issued</td><td>Date Renewed</td><td>Date Expires</td></tr>
<tr><td><asp:TextBox  runat="server"  Enabled="false" ID="dteIssued"></asp:TextBox></td><td><asp:TextBox  Enabled="false"  runat="server"  ID="dteRenewed"></asp:TextBox></td><td><asp:TextBox  runat="server"  Enabled="false" ID="dteExpired"></asp:TextBox></td></tr>
<tr><td class="ModuleSectionFont" colspan="4">
    <asp:Label ID="Label2" runat="server" Text="Business Information"></asp:Label>
    </td></tr>
    <tr><td>
    
    </td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td>
    Name of person submitting form</td><td></td><td colspan="2">Do you have a vaild Business License?</td></tr>
<tr><td colspan="2"><asp:TextBox  runat="server"  ID="txtSubmittedBy" Width="310px" 
        ontextchanged="txtSubmittedBy_TextChanged"></asp:TextBox></td>
    <td><asp:DropDownList runat="server" ID="ddlLicense"><asp:ListItem>Select</asp:ListItem>
                                                        <asp:ListItem>Y</asp:ListItem>
                                                        <asp:ListItem>N</asp:ListItem></asp:DropDownList></td><td></td></tr>
<tr><td>Business Name</td><td></td><td>Entity</td></tr>

<tr><td colspan="2">
    <asp:TextBox  runat="server"  ID="txtBusinessName" Height="25px" 
        Width="310px"></asp:TextBox></td><td colspan="2"><asp:DropDownList runat="server" 
            ID="ddlBusinessEntity">
                                                        <asp:ListItem>Select</asp:ListItem>
                                                        <asp:ListItem>Sole Properietor</asp:ListItem>
                                                        <asp:ListItem>Corporation</asp:ListItem>
                                                        <asp:ListItem>Limited Liability Company</asp:ListItem>
                                                        <asp:ListItem>Limited Liability Partnership</asp:ListItem>
                                                        <asp:ListItem>Limited Partnership</asp:ListItem>
                                                        <asp:ListItem>General Partnership</asp:ListItem>
                                                        
                                                 </asp:DropDownList></td></tr>
<tr><td>Trade Name</td><td></td><td>Tax Id</td></tr>
<tr><td colspan="2">
    <asp:TextBox ID="txtTradeName" runat="server" Height="21px" 
        Width="310px"></asp:TextBox></td><td><asp:TextBox ID="txtTaxId" runat="server"></asp:TextBox></td></tr>
<tr><td colspan="4" class="ModuleSectionFont">
    <asp:Label ID="Label3" runat="server" Text="Business Address"></asp:Label>
    </td></tr>
<tr><td>Street No</td><td>Street Name</td><td>Street Type</td><td>Quadrant</td></tr>
<tr>

<td><asp:TextBox  runat="server"  ID="txtStNo" Width="75px"></asp:TextBox></td>
<td>
               
                <asp:TextBox ID="txtStreetName" runat="server" AutoPostBack="True" 
                    ontextchanged="txtStreetName_TextChanged"></asp:TextBox>
                <asp:AutoCompleteExtender ID="txtStreetName_AutoCompleteExtender" 
                    runat="server" DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1" 
                    ServiceMethod="GetStreetNames1" ServicePath="" TargetControlID="txtStreetName" 
                    UseContextKey="True"></asp:AutoCompleteExtender>
            </td>
<td><asp:TextBox  runat="server"  ID="txtStType" Width="75px" ReadOnly="True"></asp:TextBox></td>
<td><asp:TextBox  runat="server"  ID="txtQuad" Width="75px" ReadOnly="True"></asp:TextBox></td>

</tr>
<tr><td colspan="4">
    <asp:Button ID="btnRetrieveAddress" runat="server" Text="Get Address" 
        onclick="btnRetrieveAddress_Click" />
    <asp:Label ID="lblMainAddress" runat="server" ForeColor="Red"></asp:Label>
    </td></tr>
<tr><td>Suite</td><td>City</td><td>State</td><td>Zip</td></tr>

<tr><td><asp:TextBox  runat="server"  ID="txtSuite" Width="75px" ReadOnly="True"></asp:TextBox></td><td>
    <asp:TextBox  runat="server"  ID="txtCity" ReadOnly="True"></asp:TextBox></td><td>
    <asp:TextBox  runat="server"  ID="txtState" Width="75px" ReadOnly="True"></asp:TextBox></td><td>
        <asp:TextBox  runat="server"  ID="txtZip" Width="75px" ReadOnly="True"></asp:TextBox></td></tr>

<tr><td class="ModuleSectionFont" colspan="4">
    <asp:Label ID="Label4" runat="server" Text="Parcel Information"></asp:Label>
    </td></tr>

<tr><td>Square</td><td>Suffix</td><td>Lot</td></tr>

<tr><td><asp:TextBox  runat="server"  ID="txtSquare" Width="75px" ReadOnly="True"></asp:TextBox></td><td>
    <asp:TextBox  runat="server"  ID="txtSuffix" Width="75px" ReadOnly="True"></asp:TextBox></td><td>
        <asp:TextBox  runat="server"  ID="txtLot" Width="75px" ReadOnly="True"></asp:TextBox></td><td></td></tr>

<tr><td class="ModuleSectionFont" colspan="4">
    <asp:Label ID="Label5" runat="server" Text="Owner Information"></asp:Label>
    </td></tr>
    <tr>
        <td>
            Property Owner</td>
        <td>
        </td>
        <td>
        </td>
    </tr>
<tr><td colspan="3">
    <asp:TextBox  runat="server"  ID="txtOwner" Height="24px" 
        Width="524px" ReadOnly="True"></asp:TextBox></td><td></td></tr>

    <tr>
        <td colspan="2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnAddRecord" runat="server" onclick="btnAddRecord_Click" 
                Text="Submit" />
            <asp:Button ID="btnUpdateRecord" runat="server" onclick="btnUpdateRecord_Click" 
                Text="Update"  />

                 <asp:Button ID="btnClear" runat="server" onclick="btnClearRecord_Click" 
                Text="Clear"  />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>

    <tr><td> &nbsp;</td></tr>
</table>
</div>
 <div>
                       <asp:GridView ID="grvAddress" runat="server" AutoGenerateColumns="False" 
                           Caption="Address" datakeynames="AddressKey" HorizontalAlign="Left" 
                           onselectedindexchanged="grvAddress_SelectedIndexChanged">
                           <AlternatingRowStyle CssClass="gvAlternatingRowStyle" />
                           <HeaderStyle CssClass="HeaderStyle" />
                           <FooterStyle CssClass="FooterStyle" />
                           <Columns>
                               <asp:ButtonField CommandName="Select" DataTextField="AddressKey" 
                                   HeaderText="Key" />
                               <asp:BoundField datafield="stno" Headertext="Number" />
                               <asp:BoundField datafield="stname" Headertext="Name" />
                               <asp:BoundField datafield="suffix" Headertext="Type" />
                               <asp:BoundField datafield="postdir" Headertext="Quad" />
                               <asp:BoundField datafield="suite" Headertext="suite" />
                               <asp:BoundField datafield="city" Headertext="City" />
                               <asp:BoundField datafield="state" Headertext="State" />
                               <asp:BoundField datafield="zip" Headertext="zip" />
                               <asp:BoundField datafield="lot" Headertext="Lot" visible="False" />
                               <asp:BoundField datafield="range" Headertext="Suffix" visible="False" />
                               <asp:BoundField datafield="square" Headertext="Square" visible="False" />
                               <asp:BoundField datafield="ownerFname" Headertext="City" visible="True" />
                               <asp:BoundField datafield="ownerLname" Headertext="State" visible="True" />
                               <asp:BoundField datafield="owneraddr" Headertext="zip" visible="False" />
                               <asp:BoundField datafield="ownerstate" Headertext="City" visible="False" />
                               <asp:BoundField datafield="ownercity" Headertext="State" visible="False" />
                               <asp:BoundField datafield="ownerzip" Headertext="zip" visible="False" />
                           </Columns>
                       </asp:GridView>
                       </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

