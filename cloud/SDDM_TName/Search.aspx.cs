using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Diagnostics;
using System.Web.Script.Services;
using System.Web.Services;


public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    
        protected void btnFind_Click(object sender, EventArgs e)
    {
        clsDataAccess oData = new clsDataAccess();
        string sqlSearch;// = txtSearchBy.Text;
        if (rbByAppNumber.Checked == true)
        {
           // sqlSearch = "Select pk_AppNumber ,fk_AddressKey ,tag_BusinessName ,tag_BusinessEntityType,tag_BusinessTradeName ,tag_BusinessTaxId,tag_SubmittedBy ,	date_AppSubmitted  from tbl_main where pk_appnumber = ";
            grvSearch.DataSource = oData.getDataSet(txtSearchBy.Text,4,0);
            grvSearch.DataBind();
            rbByAppNumber.Checked = false;
            txtSearchBy.Text = "";
        }
        //Tax Id
        if (rbByTaxId.Checked == true)
        {
            //sqlSearch = "Select pk_AppNumber ,fk_AddressKey ,tag_BusinessName ,tag_BusinessEntityType,tag_BusinessTradeName ,tag_BusinessTaxId,tag_SubmittedBy ,	date_AppSubmitted  from tbl_main where tag_BusinessTaxId = '" + txtSearchBy.Text + "'";
            grvSearch.DataSource = oData.getDataSet(txtSearchBy.Text, 3, 0);
            grvSearch.DataBind();
            rbByTaxId.Checked = false;
            txtSearchBy.Text = "";
        }
        //Tradename
        if (rbByTradeName.Checked == true)
        {
           // sqlSearch = "Select pk_AppNumber ,fk_AddressKey ,tag_BusinessName ,tag_BusinessEntityType,tag_BusinessTradeName ,tag_BusinessTaxId,tag_SubmittedBy ,	date_AppSubmitted  from tbl_main where tag_BusinessTradeName like '" + txtSearchBy.Text + "%'";
            grvSearch.DataSource = oData.getDataSet(txtSearchBy.Text, 2, 0);
            grvSearch.DataBind();
            rbByTradeName.Checked = false;
            txtSearchBy.Text = "";
        }
        //Business Name
        if (rbByEntityName.Checked == true)
        {
           // sqlSearch = "Select pk_AppNumber ,fk_AddressKey ,tag_BusinessName ,tag_BusinessEntityType,tag_BusinessTradeName ,tag_BusinessTaxId,tag_SubmittedBy ,	date_AppSubmitted  from tbl_main where tag_BusinessName like '" + txtSearchBy.Text + "%'";
            grvSearch.DataSource = oData.getDataSet(txtSearchBy.Text, 1, 0);
            grvSearch.DataBind();
            rbByEntityName.Checked= false;
            txtSearchBy.Text = "";

        }
        
    }
   
    protected void grvSearch_SelectedIndexChanged1(object sender, EventArgs e)
    {

        clsAddress oAddress = new clsAddress();
       // string s = grvSearch.SelectedIndex;
        GridViewRow row = grvSearch.SelectedRow;
        //Set the session variables
        Session["AppNumber"] = grvSearch.SelectedDataKey.Value.ToString();
        //Address Information
        Session["Addresskey"] = row.Cells[1].Text;
        Session["BusinessName"] = row.Cells[2].Text;
        Session["BussinessEntity"] = row.Cells[3].Text;
        Session["BusinessTradename"] = row.Cells[4].Text;
        Session["TaxId"] = row.Cells[5].Text;
        Session["SubmittedBy"] = row.Cells[6].Text;
        Session["DateSubmitted"] = row.Cells[7].Text;
        Session["validLicense"] = row.Cells[8].Text;
        clsMain.AppNumber = Int32.Parse(Session["AppNumber"].ToString());
        clsMain.RetrieveTrue = true;
        //Get data from address
        //oAddress.getAddress(Session["AppNumber"].ToString());
        //assign data
        foreach (DataRow dr in oAddress.getAddress(Session["Addresskey"].ToString()).Tables["tblAddress"].Rows)
        {
            Session["stno"] = dr["stno"].ToString();
            //Session["validLicense"] = dr["ind_LicenseBusiness,"].ToString();
            Session["stname"] = dr["stname"].ToString();
            Session["sttype"] = dr["suffix"].ToString();
            Session["postdir"] = dr["postdir"].ToString();
            Session["suite"] = dr["suite"].ToString();
            Session["city"] = dr["city"].ToString();
            Session["state"] = dr["state"].ToString();
            Session["zip"] = dr["zip"].ToString();
            Session["lot"] = dr["lot"].ToString();
            Session["range"] = dr["range"].ToString();
            Session["square"] = dr["square"].ToString();
            Session["ownerLname"] = dr["ownerLname"].ToString();
            Session["ownerFname"] = dr["ownerFname"].ToString();
            Session["owneraddr"] = dr["owneraddr"].ToString();
            Session["ownerstate"] = dr["ownerstate"].ToString();
            Session["ownercity"] = dr["ownercity"].ToString();
            Session["ownerzip"] = dr["ownerzip"].ToString();
            Session["feeAmount"] = dr["mtr_fee"].ToString();
            Session["feeDescription"] = dr["tag_Fee_Description"].ToString();
       
        }
        //Clear the gridview
        grvSearch.DataSource = null;
        grvSearch.DataBind();
        
    }

    
    protected void grvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Gridview column containing link button defined on ASPX page
        const int LINK_BUTTON_COLUMN = 0;
        //index of link button control in the link button column
        const int LINK_BUTTON_CONTROL = 0;
        LinkButton button = default(LinkButton);

        //check the type of item that was databound and only take action if it was a row in the GridView
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            button = (LinkButton)e.Row.Cells[LINK_BUTTON_COLUMN].Controls[LINK_BUTTON_CONTROL];
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(button, ""));
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        grvSearch.DataSource = null;
        grvSearch.DataBind();
    }
   
}

//pk_AppNumber as 'AppNumber',fk_AddressKey as 'Addresskey',tag_BusinessEntityType as 'Business Entity'	,tag_BusinessName as 'Business Name',	tag_BusinessTaxId as 'Tax Id'	,tag_BusinessTradeName as 'Trade Name'	,tag_SubmittedBy as 'Submitted By',	date_AppSubmitte as 'Date Submitted'