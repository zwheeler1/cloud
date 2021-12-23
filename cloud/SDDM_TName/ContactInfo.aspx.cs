using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Diagnostics;
using System.Web.Script.Services;
using System.Web.Services;

public partial class ContactInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (clsMain.AppNumber > 0)
            {
                GetContacts();
                lblContactNumber.Text = clsMain.AppNumber.ToString();
            }
        }
        else
        {
           // GetContacts();
        }

    }
    protected void btnAddContact_Click(object sender, EventArgs e)
    {
        clsContact oContact = new clsContact();
        oContact.ContactCity = txtCity.Text;
        oContact.ContactEMail = txtEmail.Text;
        oContact.ContactFName = txtApplicantFName.Text;
        oContact.ContactLName = txtApplicantLName.Text;
        oContact.ContactPhone = txtPhone.Text;
        oContact.ContactState = txtState.Text;
        oContact.ContactStName = txtStName.Text;
        oContact.ContactStNo = txtStNo.Text;
        oContact.ContactStQuad = txtQuad.Text;
        oContact.ContactStType = txtStType.Text;
        oContact.ContactType = ddlApplicantType.SelectedItem.Text;
        oContact.ContactZip = txtZip.Text;
       if (oContact.Add_ContactData(oContact))
       {
           lblInformation.Text = "Contact Added Successfully";
           GetContacts();
       }
       else
       {
           lblInformation.Text = "Contact Not Added Successfully - Check Fields and Retry";
       }
    }

    public void GetContacts()
    {
        DataSet ds = new DataSet();
        clsDataAccess oData = new clsDataAccess();
        ds = oData.getDataSet(clsMain.AppNumber, "usp_GetContactData");
        grvContacts.DataSource = ds;
        grvContacts.DataBind();
        //
       // rpContacts.DataSource = ds;
       // rpContacts.DataBind();

    }

    protected void grvContacts_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsAddress oAddress = new clsAddress();
        int s = grvContacts.SelectedIndex;
        GridViewRow row = grvContacts.SelectedRow;
        // Set the session variables
        Session["ContactId"] = grvContacts.SelectedDataKey.Value.ToString();
        // Address Information
        //Contains AppNumber  ----> row.Cells[1].Text;
        ddlApplicantType.SelectedItem.Text = row.Cells[2].Text;
        txtApplicantFName.Text = row.Cells[3].Text;
        txtApplicantMI.Text = row.Cells[4].Text;
        txtApplicantLName.Text = row.Cells[5].Text;
        txtStNo.Text = row.Cells[6].Text;
        txtStName.Text = row.Cells[7].Text;
        txtQuad.Text = row.Cells[8].Text;
        txtStType.Text = row.Cells[9].Text;
        txtSuite.Text = row.Cells[10].Text;
        txtCity.Text = row.Cells[11].Text;
         txtState.Text = row.Cells[12].Text;
        txtZip.Text = row.Cells[13].Text;
        txtPhone.Text = row.Cells[14].Text;
        txtEmail.Text = row.Cells[15].Text;
        clsContact.ContactID = Int32.Parse(Session["ContactId"].ToString());
        // <asp:BoundField datafield="fk_AppNumber" HeaderText="AppNumber"  "/> 
    }
    protected void btnUpdateContact_Click(object sender, EventArgs e)
    {
        clsContact oContact = new clsContact();
        oContact.ContactCity = txtCity.Text;
        oContact.ContactEMail = txtEmail.Text;
        oContact.ContactFName = txtApplicantFName.Text;
        oContact.ContactLName = txtApplicantLName.Text;
        oContact.ContactPhone = txtPhone.Text;
        oContact.ContactState = txtState.Text;
        oContact.ContactStName = txtStName.Text;
        oContact.ContactStNo = txtStNo.Text;
        oContact.ContactStQuad = txtQuad.Text;
        oContact.ContactStType = txtStType.Text;
        oContact.ContactType = ddlApplicantType.SelectedItem.Text;
        oContact.ContactZip = txtZip.Text;
        if (oContact.update_ContactData(oContact))
        {
            lblInformation.Text = "Contact Updated Successfully";
            GetContacts();
        }
        else
        {
            lblInformation.Text = "Contact Not Update Successfully - Check Fields and Retry";
        }
    }
}