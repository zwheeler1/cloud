<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Review.aspx.cs" Inherits="Review" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 271px;
        }
        .style3
        {
            width: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<table>

<tr><td class="ModuleSectionFont" colspan="3">AppNumber: <asp:Label ID="lblReviewNumber" runat="server" ForeColor="#CC0000"></asp:Label>
    </td></tr>

<tr><td class="style2">Reviewer</td><td>Review Type</td><td class="style3"></td></tr>
<tr><td class="style2"><asp:DropDownList ID="ddlReviewer" runat="server">
    </asp:DropDownList></td><td><asp:DropDownList ID="ddlReviewType" runat="server" 
            AutoPostBack="True">
    </asp:DropDownList></td><td class="style3"></td></tr>
<tr><td class="style2">Date Begin</td><td>Date End</td><td class="style3">Review Status</td></tr>
<tr><td class="style2"><asp:TextBox ID="txtDateReviewBegins" runat="server"></asp:TextBox></td>
<td><asp:TextBox ID="txtDateReviewEnds" runat="server"></asp:TextBox></td>
<td class="style3"><asp:DropDownList ID="ddlReviewStatus" runat="server">
    </asp:DropDownList></td></tr>
<tr><td class="style2">Reviewer Comments</td><td></td><td class="style3"></td></tr>
<tr><td class="style1" colspan="3"><asp:TextBox ID="txtReviewComments" runat="server" 
        Height="275px" TextMode="MultiLine" Width="393px"></asp:TextBox></td></tr>
<tr><td colspan="3">&nbsp;</td></tr>
<tr><td colspan="3"></td></tr>
<tr><td colspan="3"><asp:Label ID="lblReviewInformation" runat="server" ForeColor="Red" Text=""></asp:Label></td></tr>
<tr><td colspan="3">
<asp:Button ID="btnSubmitReview" runat="server" Text="Submit Review" 
        onclick="btnSubmitReview_Click" />
<asp:Button ID="btnUpdateReview" runat="server" Text="Update Review" 
        onclick="btnUpdateReview_Click" />
<asp:Button ID="btnAddComments" runat="server" Text="Add Comment" 
        onclick="btnAddComments_Click" />
</td></tr>
<tr><td class="style2">
    </td></tr>
    

    
</table>
<asp:GridView ID="grvReviewHistory" runat="server" AutoGenerateColumns="False"
            HorizontalAlign="Left" Caption="Reviews" 
			datakeynames="pk_review_Id" 
        onselectedindexchanged="grvReviewHistory_SelectedIndexChanged" >
            <AlternatingRowStyle CssClass="gvAlternatingRowStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <FooterStyle CssClass="FooterStyle" />
      <Columns>
            <asp:ButtonField HeaderText="Review Id" CommandName="Select" DataTextField="pk_review_Id"/> 
            <asp:BoundField datafield="fk_AppNumber" HeaderText="AppNumber" /> 
            <asp:BoundField datafield="date_start_review" Headertext="Date Review Begin" />
            <asp:BoundField datafield="date_end_review" Headertext="Date Review End" />
            <asp:BoundField datafield="tag_Comments" Headertext="Comments"/>
           
             
     </Columns>
    </asp:GridView>
 
    

</asp:Content>


