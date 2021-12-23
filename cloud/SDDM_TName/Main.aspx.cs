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


public partial class Main : System.Web.UI.Page
{
    #region Connection Properties
        SqlConnection sqlConn = new SqlConnection();
        SqlCommand sqlCmd = new SqlCommand();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        //clsLogon.UserName = "zwheeler";
        
        if (!IsPostBack)
        {
            LoadData();
            dteSubmitted.Text = DateTime.Now.ToShortDateString();
            GetSessionData();
        }
        
    }


   
    protected void btnRetrieveAddress_Click(object sender, EventArgs e)
    {
        clsAddress oAddress = new clsAddress();
        clsAddAddress oNewAddress = new clsAddAddress();
        //  Assign Search Variables and Perform Validation Check Behind Form note you can use a constructor here
        // 
        if ((txtStNo.Text.Length > 0))
        {
            oAddress.StreetNumber = txtStNo.Text;
        }
        // 
        if ((txtStreetName.Text.Length > 0))
        {
            oAddress.StreetName = txtStreetName.Text;
        }
        // 
        if ((txtStType.Text.Length > 0))
        {
            oAddress.StreetType = txtStType.Text;
        }
        // 
        if ((txtQuad.Text.Length > 0))
        {
            oAddress.Quadrant = txtQuad.Text;
        }
        // 
        if ((txtSuite.Text.Length > 0))
        {
            oAddress.SuiteNumber = txtSuite.Text;
            
        }
        else
        {
            oAddress.SuiteNumber = null;
        }
        // Retrieve the address
        try
        {
            DataSet ds = new DataSet();
            ds = oAddress.getAddress(oAddress);
            if ((ds.Tables[0].Rows.Count > 0))
            {
                lblMainAddress.Text = "Address  Found - Scroll Down";
                grvAddress.DataSource = ds.Tables[0].DefaultView;
                grvAddress.DataBind();
            }
            else
            {
                lblMainAddress.Text = "Address Not Found";
            }
        }
        catch (Exception ex)
        {
            clsErrors oError = new clsErrors();
            oError.AppNumber = clsMain.AppNumber;
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace;
            oError.LogErrors(oError);
        }
           }



    protected void grvAddress_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        // Gridview column containing link button defined on ASPX page
        const int LINK_BUTTON_COLUMN = 0;
        // index of link button control in the link button column
        const int LINK_BUTTON_CONTROL = 0;
        LinkButton button;
        // check the type of item that was databound and only take action if it was a row in the GridView
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            button = ((LinkButton)(e.Row.Cells[LINK_BUTTON_COLUMN].Controls[LINK_BUTTON_CONTROL]));
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(button, ""));
        }
    }

    // '' <summary>
    // '' Is fired last in the click event
    // '' </summary>
    // '' <param name="sender"></param>
    // '' <param name="e"></param>
    // '' <remarks></remarks>
    protected void grvAddress_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        clsAddress oAddress = new clsAddress();
        int s = grvAddress.SelectedIndex;
        GridViewRow row = grvAddress.SelectedRow;
        // Set the session variables
        Session["AddressKey"] = grvAddress.SelectedDataKey.Value.ToString();
        // Address Information
        txtStNo.Text = row.Cells[1].Text;
        txtStreetName.Text = row.Cells[2].Text;
        txtStType.Text = row.Cells[3].Text;
        txtQuad.Text = row.Cells[4].Text;
        txtSuite.Text = row.Cells[5].Text;
        txtCity.Text = row.Cells[6].Text;
        txtState.Text = row.Cells[7].Text;
        txtZip.Text = row.Cells[8].Text;
        // Parcel Information
        txtLot.Text = row.Cells[9].Text;
        txtSuffix.Text = row.Cells[10].Text;
        txtSquare.Text = row.Cells[11].Text;
        // Owner Information
        //Session["ownerFname"] = row.Cells[10].Text;
        //Session["ownerLname"] = row.Cells[11].Text;
        //Session["owneraddr"] = row.Cells[14].Text;
        //Session["ownerstate"] = row.Cells[15].Text;
        //Session["ownercity"] = row.Cells[16].Text;
        //Session["ownerzip"] = row.Cells[17].Text;
        // Populate the Review Controls
        clsAddress.AddressKey = Convert.ToInt32(Session["AddressKey"]); //grvAddress.SelectedDataKey.Value.ToString();
        // Owner Information
        txtOwner.Text = row.Cells[12].Text + " " + row.Cells[13].Text;
        // Clear the gridview
        grvAddress.DataSource = null;
        grvAddress.DataBind();
        lblMainAddress.Text = "";
    }



    protected void txtStreetName_TextChanged(object sender, EventArgs e)
    {
        
        int intUpper;
        clsAddress oAddress = new clsAddress();
        string[] strStreetNameParse = txtStreetName.Text.Split(' ');
        //string[] words = s.Split(' ');
        intUpper = strStreetNameParse.GetUpperBound(0);
        if ((intUpper == 2))
        {
            // ddlStreetName.Items.Add(strStreetNameParse(0))
            txtStreetName.Text = strStreetNameParse[0];
            txtStType.Text = strStreetNameParse[1];
            txtQuad.Text = strStreetNameParse[2];
            // 
            oAddress.StreetNumber = txtStNo.Text;
            oAddress.StreetName = txtStreetName.Text;
            oAddress.StreetType = txtStType.Text;
            oAddress.Quadrant = txtQuad.Text;
        }
        // 
        if ((intUpper == 3))
        {
            // ddlStreetName.Items.Add(strStreetNameParse(0) & " " & strStreetNameParse(1))
            txtStreetName.Text = (strStreetNameParse[0] + (" " + strStreetNameParse[1]));
            txtStType.Text = strStreetNameParse[2];
            txtQuad.Text = strStreetNameParse[3];
            // 
            oAddress.StreetNumber = txtStNo.Text;
            oAddress.StreetName = txtStreetName.Text;
            oAddress.StreetType = txtStType.Text;
            oAddress.Quadrant = txtQuad.Text;
        }
        // 
        if ((intUpper == 4))
        {
            // .Items.Add(strStreetNameParse(0) & " " & strStreetNameParse(1) & " " & strStreetNameParse(2))
            txtStreetName.Text = (strStreetNameParse[0] + (" "
                        + (strStreetNameParse[1] + (" " + strStreetNameParse[2]))));
            txtStType.Text = strStreetNameParse[3];
            txtQuad.Text = strStreetNameParse[4];
            // 
            oAddress.StreetNumber = txtStNo.Text;
            oAddress.StreetName = txtStreetName.Text;
            oAddress.StreetType = txtStType.Text;
            oAddress.Quadrant = txtQuad.Text;
        }
        // 
        if ((intUpper == 5))
        {
            // ddlStreetName.Items.Add(strStreetNameParse(0) & " " & strStreetNameParse(1) & " " & strStreetNameParse(2) & " " & strStreetNameParse(3))
            txtStreetName.Text = (strStreetNameParse[0] + (" "
                        + (strStreetNameParse[1] + (" "
                        + (strStreetNameParse[2] + (" " + strStreetNameParse[3]))))));
            txtStType.Text = strStreetNameParse[4];
            txtQuad.Text = strStreetNameParse[5];
            // 
            oAddress.StreetNumber = txtStNo.Text;
            oAddress.StreetName = txtStreetName.Text;
            oAddress.StreetType = txtStType.Text;
            oAddress.Quadrant = txtQuad.Text;
        }
        // 
        if ((intUpper == 6))
        {
            // ddlStreetName.Items.Add(strStreetNameParse(0) & " " & strStreetNameParse(1) & " " & strStreetNameParse(2) & " " & strStreetNameParse(3) & " " & strStreetNameParse(4))
            txtStreetName.Text = (strStreetNameParse[0] + (" "
                        + (strStreetNameParse[1] + (" "
                        + (strStreetNameParse[2] + (" "
                        + (strStreetNameParse[3] + (" " + strStreetNameParse[4]))))))));
            txtStType.Text = strStreetNameParse[5];
            txtQuad.Text = strStreetNameParse[6];
            // 
            oAddress.StreetNumber = txtStNo.Text;
            oAddress.StreetName = txtStreetName.Text;
            oAddress.StreetType = txtStType.Text;
            oAddress.Quadrant = txtQuad.Text;
        }
        // 
        // 
        if ((intUpper == 7))
        {
            // ddlStreetName.Items.Add(strStreetNameParse(0) & " " & strStreetNameParse(1) & " " & strStreetNameParse(2) & " " & strStreetNameParse(3) & " " & strStreetNameParse(4) & " " & strStreetNameParse(5))
            txtStreetName.Text = (strStreetNameParse[0] + (" "
                        + (strStreetNameParse[1] + (" "
                        + (strStreetNameParse[2] + (" "
                        + (strStreetNameParse[3] + (" "
                        + (strStreetNameParse[4] + (" " + strStreetNameParse[5]))))))))));
            txtStType.Text = strStreetNameParse[6];
            txtQuad.Text = strStreetNameParse[7];
            // 
            oAddress.StreetNumber = txtStNo.Text;
            oAddress.StreetName = txtStreetName.Text;
            oAddress.StreetType = txtStType.Text;
            oAddress.Quadrant = txtQuad.Text;
        }
        // 
        // 
        if ((intUpper == 7))
        {
            // ddlStreetName.Items.Add(strStreetNameParse(0) & " " & strStreetNameParse(1) & " " & strStreetNameParse(2) & " " & strStreetNameParse(3) & " " & strStreetNameParse(4) & " " & strStreetNameParse(5) & " " & strStreetNameParse(6))
            txtStreetName.Text = (strStreetNameParse[0] + (" "
                        + (strStreetNameParse[1] + (" "
                        + (strStreetNameParse[2] + (" "
                        + (strStreetNameParse[3] + (" "
                        + (strStreetNameParse[4] + (" "
                        + (strStreetNameParse[5] + (" " + strStreetNameParse[6]))))))))))));
            txtStType.Text = strStreetNameParse[7];
            txtQuad.Text = strStreetNameParse[8];
            // 
            oAddress.StreetNumber = txtStNo.Text;
            oAddress.StreetName = txtStreetName.Text;
            oAddress.StreetType = txtStType.Text;
            oAddress.Quadrant = txtQuad.Text;
        }
        lblInformation.Text = "You may Enter the Suite or Apartment Number.  Then click on the RETRIEVE ADDRESS BUTTON to Search for Address" +
        "";
    }

    protected void txtStreetName_TextChanged1(object sender, EventArgs e)
    {
        lblInformation.Text = "Enter the Suite or Apartment Number.  Then click on the RETRIEVE ADDRESS BUTTON to Search for Address" +
                "";
    }
    protected void grvAddress_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }

    protected void btnAddRecord_Click(object sender, EventArgs e)
    {
        clsMain oMain = new clsMain();
        clsFees oFees = new clsFees();

            //@AddressKey				,
            //oMain.ClientId		= "U";
            oMain.BusinessEntityType = ddlBusinessEntity.SelectedItem.Text;
            oMain.BusinessName= txtBusinessName.Text;
            oMain.BusinessTaxId = txtTaxId.Text;
            oMain.BusinessTradeName = txtTradeName.Text;
            oMain.DateAppSubmitted = dteSubmitted.Text;
            oMain.LicenseBusiness = ddlLicense.SelectedItem.Text;
            oMain.SubmittedBy= txtSubmittedBy.Text;
            oMain.Action = ddlAction.SelectedItem.Text;
        //Add A POPUP Box Here showing fee amount
            oFees.Fee = Convert.ToInt32(txtFee.Text);
            oFees.FeeDescription = oMain.Action;

            if (oMain.AddMainTradeName(oMain))
            {
                //Note placce a message here
                //Fees are notupateable unless by staff
                if (oFees.AddFee(oFees))
                {
                    lblInformation.Text = "Record Added Successfully";
                    lblAppNumber.Text = clsMain.AppNumber.ToString();
                }
            }
            else
            {
                lblInformation.Text = "Record Not Added Successfully";
            }
    }



    protected void btnUpdateRecord_Click(object sender, EventArgs e)
    {
        clsMain oMain = new clsMain();
        clsFees oFees = new clsFees();

        //@AddressKey				,
        oMain.ClientId = "U";
        oMain.BusinessEntityType = ddlBusinessEntity.SelectedItem.Text;
        oMain.BusinessName = txtBusinessName.Text;
        oMain.BusinessTaxId = txtTaxId.Text;
        oMain.BusinessTradeName = txtTradeName.Text;
        oMain.DateAppSubmitted = dteSubmitted.Text;
        oMain.LicenseBusiness = ddlLicense.SelectedItem.Text;
        oMain.SubmittedBy = txtSubmittedBy.Text;
        oMain.Action = ddlAction.SelectedItem.Text;
        //Add A POPUP Box Here showing fee amount
        //oFees.Fee = Convert.ToInt32(txtFee.Text);
        //oFees.FeeDescription = oMain.Action;

        if (oMain.UpdateMainTradeName(oMain))
        {
            //msgbox - fees are not updateable unlessby staff
            //if (oFees.AddFee(oFees))
            
                lblInformation.Text = "Record Updated Successfully";
                lblAppNumber.Text = clsMain.AppNumber.ToString();
            
        }
        else
        {
            lblInformation.Text = "Record Not Updated Successfully";
        }
    }


    public void LoadData()
    {
            GetStreetNames();
            dteSubmitted.Attributes.Add("onfocus", "showCalendarControl(this);");
           
    }

    public void GetSessionData()
    {
        if (Session["AppNumber"] == null)
        {
        }
            else
        {
            if (clsMain.RetrieveTrue == true)
            {
                clsMain.AppNumber = Int32.Parse(Session["AppNumber"].ToString());
                lblAppNumber.Text = clsMain.AppNumber.ToString();
                //Address Information
                clsAddress.AddressKey = Int32.Parse(Session["Addresskey"].ToString());
                txtBusinessName.Text = Session["BusinessName"].ToString();
                ddlBusinessEntity.SelectedItem.Text = Session["BussinessEntity"].ToString();
                txtTradeName.Text = Session["BusinessTradename"].ToString();
                txtTaxId.Text = Session["TaxId"].ToString();
                txtSubmittedBy.Text = Session["SubmittedBy"].ToString();
                dteSubmitted.Text = Convert.ToDateTime(Session["DateSubmitted"].ToString()).ToShortDateString();
                //Action and Fee Data
                ddlAction.SelectedItem.Text = Session["feeDescription"].ToString();
                txtFee.Text = Session["feeAmount"].ToString();
                //ind_LicenseBusiness
                ddlLicense.SelectedItem.Text = Session["validLicense"].ToString();
                //ToShortDateString();
                //Populate the address and address related fields
                txtStNo.Text = Session["stno"].ToString();
                txtStreetName.Text = Session["stname"].ToString();
                txtStType.Text = Session["sttype"].ToString();
                //txtSuffix.Text = Session["suffix"].ToString();
                txtQuad.Text = Session["postdir"].ToString();
                txtSuite.Text = Session["suite"].ToString();
                txtCity.Text = Session["city"].ToString();
                txtState.Text = Session["state"].ToString();
                txtZip.Text = Session["zip"].ToString();
                txtLot.Text = Session["lot"].ToString();
                txtSuffix.Text = Session["range"].ToString();
                txtSquare.Text = Session["square"].ToString();
                txtOwner.Text = Session["ownerLname"].ToString() + " " + Session["ownerFname"].ToString();
            }
        }
    }
     [System.Web.Services.WebMethod()]
    public static string[] GetStreetNames1(string prefixText, int count)
    {
        Main gnames = new Main();
        int i = 0;
        
        try
        {
            DataTable dt = gnames.GetStreetNames().Tables["TBL_LKUP_STREETNAME"];
            //  Create Data View
            DataView dv = new DataView(dt);
            // 
            dv.RowFilter = string.Format("streetname like \'{0}%\'", prefixText);
            //  Display Data In Data View
            string[] Snames = new string[dt.Rows.Count];
            foreach (DataRowView row in dv)
            {
                Snames.SetValue(row["streetname"].ToString(), i);
                i++;
            }
            return Snames;
        }
        catch (Exception ex)
        {
            string[] Error1 = new string[4];
            Error1[0] = "";
            Error1[1] = ex.Message;
            Error1[2] = ex.Source;
            Error1[3] = ex.StackTrace;
            return Error1 ;
        }
    }

    private DataSet GetStreetNames()
    {
        System.Data.DataSet dsStreetName = new System.Data.DataSet();
        string sqlSearch;
        clsMain oMain = new clsMain();
        // Create Search String
        // define the cache object
        // 
        // check to see id it exist if so use it other wise create it
        if ((System.Web.HttpContext.Current.Cache["StreetNames"] == null))
        {
            sqlSearch = "Select distinct StreetName from TBL_LKUP_STREETNAME order by StreetName";
            if ((sqlConn.State == System.Data.ConnectionState.Open))
            {
                sqlConn.Close();
            }
            sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
            // 
            try
            {
                sqlConn.Open();
                // Create a Data Adapter
                SqlDataAdapter daStreetName = new SqlDataAdapter(sqlSearch, sqlConn);
                // Fill the Data Set
                daStreetName.Fill(dsStreetName, "TBL_LKUP_STREETNAME");
                // 
                System.Web.HttpContext.Current.Cache.Insert("StreetNames", dsStreetName);
                //  
                return dsStreetName;
            }
            catch (Exception ex)
            {
                clsErrors oError = new clsErrors();
                oError.AppNumber = 0;
                oError.ErrorMessage = ex.Message;
                oError.ErrorSource = ex.Source;
                oError.ErrorStackTrace = ex.StackTrace;
                oError.LogErrors(oError);
                return dsStreetName;
            }
            finally
            {
                sqlConn.Close();
                sqlCmd.Dispose();
            }
        }
        else
        {
            try
            {
                dsStreetName = (DataSet)System.Web.HttpContext.Current.Cache["StreetNames"];
                return dsStreetName;
            }
            catch (Exception ex)
            {
                string strMessage = ex.Message;
                return dsStreetName;
            }
        }
    }

    protected void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strFees = ddlAction.SelectedValue;
       switch(strFees)
       {
           case "New":
            txtFee.Text = "250";
            break;
           case "Renewal":
            txtFee.Text = "125";
            break;
           case "Cancellation":
            txtFee.Text = "100";
            break;
           case "Amendment":
            txtFee.Text = "150";
            break;
           case "Duplicate Certificate":
            txtFee.Text = "75";
            break;
           default:
            break;
    }
        
    }
    protected void btnClearRecord_Click(object sender, EventArgs e)
    {
        //Clear Controls
        dteExpired.Text = "";
        dteIssued.Text = "";
        dteRenewed.Text = "";
        dteSubmitted.Text = DateTime.Now.ToShortDateString();
        //
        txtBusinessName.Text = "";
        txtSubmittedBy.Text = "";
        txtCity.Text = "";
        txtFee.Text = "";
        txtLot.Text = "";
        txtOwner.Text = "";
        txtQuad.Text = "";
        txtSquare.Text = "";
        txtState.Text = "";
        txtStNo.Text = "";
        txtStreetName.Text = "";
        txtStType.Text = "";
        txtTaxId.Text = "";
        txtZip.Text = "";
        txtLot.Text = "";
        ddlAction.Items[0].Value ="Select";
        ddlAction.Items[0].Text = "Select";
        ddlBusinessEntity.Items[0].Value = "Select";
        ddlBusinessEntity.Items[0].Text = "Select";
        ddlLicense.Items[0].Value = "Select";
        ddlLicense.Items[0].Text = "Select";

        //ddlMyDropDownList.items(0).value 
        //
        //Clear all static members and session variables
        clsMain.AppNumber = 0;
        

        Session["AppNumber"] = null;
        lblAppNumber.Text = null;
        //lblContactNumber.Text = null;
        //Address Information
        clsAddress.AddressKey = 0;
        Session["Addresskey"] =null;
        Session["BusinessName"]=null;
        Session["BussinessEntity"] = null;
        Session["BusinessTradename"]=null;
        Session["TaxId"]=null;
        Session["SubmittedBy"]=null;
        Session["DateSubmitted"]= null;
        //Action and Fee Data
        Session["feeDescription"]=null;
        Session["feeAmount"] = null;
        Session["validLicense"] = null;
        //ToShortDateString();
        //Populate the address and address related fields
        Session["stno"] = null;
        Session["stname"] = null;
        Session["sttype"] = null;
        Session["suffix"] = null;
        Session["postdir"] = null;
        Session["suite"] = null;
        Session["city"] = null;
        Session["state"] = null;
        Session["zip"] = null;
        Session["lot"] = null;
        Session["range"] = null;
        Session["square"] = null;
        Session["ownerLname"] = null;
        Session["ownerFname"] = null;
        //
        Session["ContactId"] = null;

        
    }
    protected void txtSubmittedBy_TextChanged(object sender, EventArgs e)
    {

    }
}
