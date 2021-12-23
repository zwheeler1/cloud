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
using System.Web.Caching;


public partial class Review : System.Web.UI.Page
{

     #region Connection Properties
        SqlConnection sqlConn = new SqlConnection();
        SqlCommand sqlCmd = new SqlCommand();
    #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
        
                if (!IsPostBack)
        {
            LoadData();
            if (clsMain.AppNumber > 0)
            {
                GetReviews();
                lblReviewNumber.Text = clsMain.AppNumber.ToString();
                
            }
        }
        }

    protected void LoadData()
    {       
        GetReviewTypes();
        GetReviewer();
        GetReviewStatus();
        GetReviews();

    }

    public void GetReviews()
    {
        DataSet ds = new DataSet();
        clsDataAccess oData = new clsDataAccess();
        ds = oData.getDataSet(clsMain.AppNumber, "usp_GetReviews");
        grvReviewHistory.DataSource = ds;
        grvReviewHistory.DataBind();
        //
        // rpContacts.DataSource = ds;
        // rpContacts.DataBind();

    }
    protected void GetReviewer()
    {
        System.Data.DataSet dsReviewer = new System.Data.DataSet();
        string sqlSearch = null;
        clsMain oMain = new clsMain();
        //Create Search String
        //define the cache object
        //
        //check to see id it exist if so use it other wise create it
        try
        {

            if (Cache["Reviewer"] == null)
            {
                sqlSearch = "Select fk_EmployeeId, cat_Reviewer from TBL_LKUP_REVIEWER order by cat_Reviewer";
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }

                sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
                //
                sqlConn.Open();
                //Create a Data Adapter
                SqlDataAdapter daReviewer = new SqlDataAdapter(sqlSearch, sqlConn);
                //Fill the Data Set
                daReviewer.Fill(dsReviewer, "TBL_LKUP_REVIEWER");
                //Display in DDL
                //
                ddlReviewer.DataSource = dsReviewer;
                ddlReviewer.DataSource = dsReviewer.Tables["TBL_LKUP_REVIEWER"].DefaultView;
                ddlReviewer.DataTextField = "cat_Reviewer";
                ddlReviewer.DataValueField = "fk_EmployeeId";
                ddlReviewer.DataBind();
                //
                Cache.Insert("Reviewer", dsReviewer);
            }
            else
            {
                dsReviewer = (System.Data.DataSet)Cache["Reviewer"];
                ddlReviewer.DataSource = dsReviewer.Tables["TBL_LKUP_REVIEWER"].DefaultView;
                ddlReviewer.DataTextField = "cat_Reviewer";
                ddlReviewer.DataValueField = "fk_EmployeeId";
                ddlReviewer.DataBind();

            }


        }
        catch (Exception ex)
        {
            clsErrors oError = new clsErrors();
            oError.AppNumber = 0;
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.LogErrors(oError);
        }
        finally
        {
            sqlConn.Close();
            sqlCmd.Dispose();
        }
    }

    protected void GetReviewTypes()
    {
        System.Data.DataSet dsReviewType = new System.Data.DataSet();
        string sqlSearch = null;
        clsMain oMain = new clsMain();
        //Create Search String
        //define the cache object
        //
        //check to see id it exist if so use it other wise create it
        try
        {

            if (Cache["ReviewType"] == null)
            {
                sqlSearch = "Select pk_reviewtype_id, cat_ReviewType from TBL_LKUP_REVIEWTYPE order by cat_ReviewType";
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }

                sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
                //
                sqlConn.Open();
                //Create a Data Adapter
                SqlDataAdapter daReviewType = new SqlDataAdapter(sqlSearch, sqlConn);
                //Fill the Data Set
                daReviewType.Fill(dsReviewType, "TBL_LKUP_REVIEWTYPE");
                //Display in DDL
                //
                ddlReviewType.DataSource = dsReviewType;
                ddlReviewType.DataSource = dsReviewType.Tables["TBL_LKUP_REVIEWTYPE"].DefaultView;
                ddlReviewType.DataTextField = "cat_ReviewType";
                ddlReviewType.DataValueField = "pk_reviewtype_id";
                ddlReviewType.DataBind();
                //
                Cache.Insert("ReviewType", dsReviewType);
            }
            else
            {
                dsReviewType = (System.Data.DataSet)Cache["ReviewType"];
                ddlReviewType.DataSource = dsReviewType.Tables["TBL_LKUP_REVIEWTYPE"].DefaultView;
                ddlReviewType.DataTextField = "cat_ReviewType";
                ddlReviewType.DataValueField = "pk_reviewtype_id";
                ddlReviewType.DataBind();

            }


        }
        catch (Exception ex)
        {
            clsErrors oError = new clsErrors();
            oError.AppNumber = 0;
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.LogErrors(oError);
        }
        finally
        {
            sqlConn.Close();
            sqlCmd.Dispose();
        }
    }


    protected void GetReviewStatus()
    {
        System.Data.DataSet dsReviewStatus = new System.Data.DataSet();
        string sqlSearch = null;
        clsMain oMain = new clsMain();
        //Create Search String
        //define the cache object
        //
        //check to see id it exist if so use it other wise create it
        try
        {

            if (Cache["ReviewStatus"] == null)
            {
                sqlSearch = "Select pk_reviewstatus_id, cat_ReviewStatus from TBL_LKUP_REVIEWSTATUS order by cat_ReviewStatus";
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }

                sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
                //
                sqlConn.Open();
                //Create a Data Adapter
                SqlDataAdapter daReviewStatus = new SqlDataAdapter(sqlSearch, sqlConn);
                //Fill the Data Set
                daReviewStatus.Fill(dsReviewStatus, "TBL_LKUP_REVIEWSTATUS");
                //Display in DDL
                //
                ddlReviewStatus.DataSource = dsReviewStatus;
                ddlReviewStatus.DataSource = dsReviewStatus.Tables["TBL_LKUP_REVIEWSTATUS"].DefaultView;
                ddlReviewStatus.DataTextField = "cat_ReviewStatus";
                ddlReviewStatus.DataValueField = "pk_reviewstatus_id";
                ddlReviewStatus.DataBind();
                //
                Cache.Insert("ReviewStatus", dsReviewStatus);
            }
            else
            {
                dsReviewStatus = (System.Data.DataSet)Cache["ReviewStatus"];
                ddlReviewStatus.DataSource = dsReviewStatus.Tables["TBL_LKUP_REVIEWSTATUS"].DefaultView;
                ddlReviewStatus.DataTextField = "cat_ReviewStatus";
                ddlReviewStatus.DataValueField = "pk_reviewstatus_id";
                ddlReviewStatus.DataBind();

            }


        }
        catch (Exception ex)
        {
            clsErrors oError = new clsErrors();
            oError.AppNumber = 0;
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.LogErrors(oError);
        }
        finally
        {
            sqlConn.Close();
            sqlCmd.Dispose();
        }
    }


    protected void btnSubmitReview_Click(object sender, EventArgs e)
    {
        if (clsMain.AppNumber == 0)
        {
            return;
        }
        clsReviewer oReviewer = new clsReviewer();
        oReviewer.ReviewBeginDate = txtDateReviewBegins.Text;
        oReviewer.ReviewEndDate = txtDateReviewEnds.Text;
        oReviewer.ReviewerComments = txtReviewComments.Text;
        oReviewer.Reviewer = ddlReviewer.SelectedValue.ToString();
        oReviewer.ReviewType = ddlReviewType.SelectedValue.ToString();
        oReviewer.ReviewStatus = ddlReviewStatus.SelectedValue.ToString();
        if (oReviewer.AddReview(oReviewer) == true)
        {
            if (oReviewer.AddReviewerComments(oReviewer)==true)
            {
                lblReviewInformation.Text = "Record Added Successfully";
            }
        }
        else
        {
        
            lblReviewInformation.Text = "Record Not Added Successfully";
        }

    }


    protected void btnUpdateReview_Click(object sender, EventArgs e)
    {

    if (clsMain.AppNumber == 0)
        {
            return;
        }
        clsReviewer oReviewer = new clsReviewer();
        oReviewer.ReviewBeginDate = txtDateReviewBegins.Text;
        oReviewer.ReviewEndDate = txtDateReviewEnds.Text;
        oReviewer.ReviewerComments = txtReviewComments.Text;
        oReviewer.Reviewer = ddlReviewer.SelectedValue.ToString();
        oReviewer.ReviewType = ddlReviewType.SelectedValue.ToString();
        oReviewer.ReviewStatus = ddlReviewStatus.SelectedValue.ToString();
        if (oReviewer.AddReview(oReviewer) == true)
        {
            if (oReviewer.AddReviewerComments(oReviewer)==true)
            {
                lblReviewInformation.Text = "Record Added Successfully";
            }
        }
        else
        {
            lblReviewInformation.Text = "Record Not Added Successfully";
        }

    }
    protected void btnAddComments_Click(object sender, EventArgs e)
    {

    if (clsMain.AppNumber == 0)
        {
            return;
        }
        clsReviewer oReviewer = new clsReviewer();
            oReviewer.ReviewerComments = txtReviewComments.Text;
            oReviewer.ReviewType = ddlReviewType.SelectedValue.ToString();
         
            if (oReviewer.AddReviewerComments(oReviewer)==true)
            {
                lblReviewInformation.Text = "Record Added Successfully";
            }
            else
            {
        
            lblReviewInformation.Text = "Record Not Added Successfully";
             }

    }


    protected void grvReviewHistory_SelectedIndexChanged(object sender, EventArgs e)
    {
        //clsAddress oAddress = new clsAddress();
        //int s = grvContacts.SelectedIndex;
        //GridViewRow row = grvContacts.SelectedRow;
        //// Set the session variables
        //Session["ContactId"] = grvContacts.SelectedDataKey.Value.ToString();
        // Address Information
        //Contains AppNumber  ----> row.Cells[1].Text;
    }

    //protected void GetReviews()
    //{
    //    clsDataAccess oData = new clsDataAccess();
    //    string strSql;
    //    strSql = " select * from TBL_REVIEW r join TBL_REVIEWERCOMMENTS rc on (r.pk_review_Id = rc.fk_Review_Id) where r.fk_Appnumber = " + clsMain.AppNumber;
    //    //Get records
    //    grvReviewHistory.DataSource = oData.getDataSet(strSql).Tables[0].DefaultView;
    //    grvReviewHistory.DataBind();

    //}
}