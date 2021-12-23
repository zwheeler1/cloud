using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.IO;
using System.Configuration;
using System.Web.SessionState;

public partial class wfrmSearch : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            LoadData();
            LoadTest();
        }

      


        //

        //var _with1 = this.dgvTableNames;
        //_with1.DefaultCellStyle.BackColor = Color.White;
        //_with1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
        //var _with2 = this.dgvAFSTableColumns;
        //_with2.DefaultCellStyle.BackColor = Color.White;
        //_with2.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;


    

    }
    public void LoadTest()
    {
    //{   txtBasicInformation.Text = "Welcome to the OPIIS Query Building Tool:";
    //    txtBasicInformation.Text = txtBasicInformation.Text + Environment.NewLine + "Tip 1: Always try to narrow your search (make it as specific as possible) ";
    //    txtBasicInformation.Text = txtBasicInformation.Text + Environment.NewLine + "Tip 2: Use % for Wild Card Search and Search for everything similar: Ex. select * from mf_insured_loan where cat_soa_name like '%221%'";
    //    txtBasicInformation.Text = txtBasicInformation.Text + Environment.NewLine + "Tip 3: Use Joins(where appropiate) and WHERE CLAUSE: Ex. Select * from mf_property, mf_insured_loan WHERE pk_property_id = fk_property_id and cat_soa_name like '%221%'  ";
    //    txtBasicInformation.Text = txtBasicInformation.Text + Environment.NewLine + "Tip 4: Use Distinct to get a list of values for a particular field and to help remove duplicates: Ex. select DISTINCT cat_major_program_type from mf_insured_loan ";
    //    txtBasicInformation.Text = txtBasicInformation.Text + Environment.NewLine + "Tip 5: To get call the fields in a table just copy and paste the following in the SELECT text box (make sure you include the comma): * , ";
          
        txtJoinInformation.Text = "The following tables can be directly joined with the Property Table:";
        txtJoinInformation.Text = txtJoinInformation.Text + Environment.NewLine + " DIRECT LOAN";
        txtJoinInformation.Text = txtJoinInformation.Text + Environment.NewLine + " FELXIBLE SUBSIDY";
        txtJoinInformation.Text = txtJoinInformation.Text + Environment.NewLine + " GRANT CAPITAL ADVANCE";
        txtJoinInformation.Text = txtJoinInformation.Text + Environment.NewLine + " HEADER TABLE";
        txtJoinInformation.Text = txtJoinInformation.Text + Environment.NewLine + " HUD HELD";
        txtJoinInformation.Text = txtJoinInformation.Text + Environment.NewLine + " INSURED";

         txtCrosswalk.Text = " USE THE HEADER TABLE AS A CROSSWALK BETWEEN OTHER TABLES AND FASS TABLES: LINK ON PROPERTY_ID";

        txtInfo2.Text = "The following tables are financial tables (Join using PK_AFS_ID):";
        txtInfo2.Text = txtInfo2.Text + Environment.NewLine + " HEADER";
        txtInfo2.Text = txtInfo2.Text + Environment.NewLine + " BALANCE SHEET";
        txtInfo2.Text = txtInfo2.Text + Environment.NewLine + " CASH FLOW";
        txtInfo2.Text = txtInfo2.Text + Environment.NewLine + " NURSING HOMES";
        txtInfo2.Text = txtInfo2.Text + Environment.NewLine + " PROFIT AND LOSS";
        txtInfo2.Text = txtInfo2.Text + Environment.NewLine + " RESERVES";
        txtInfo2.Text = txtInfo2.Text + Environment.NewLine + " SURPLUS CASH";

       // txtInfo3.Text = txtInfo3.Text + Environment.NewLine + " USE THE HEADER TABLE AS A CROSSWALK BETWEEN OTHER TABLES AND FASS TABLES: LINK ON PROPERTY_ID";

    }

    public void LoadData()
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        clsData getdata = new clsData();
        //
        string strSQL = null;
        strSQL = "select TABLE_NAME, 'Table Description' as Table_Description from information_schema.tables";
        strSQL = strSQL + " where TABLE_CATALOG = 'OE_MF_DM_MIRROR'";
        strSQL = strSQL + " AND TABLE_NAME IN";
        strSQL = strSQL + " ('mf_property','mf_afs_balance_sheet','mf_afs_cash_flow','mf_afs_header','mf_afs_nursing_home','mf_afs_owner_equity','mf_afs_profit_and_loss','mf_afs_reserve','mf_afs_surplus_cash','REF_SOA_OPIIS',";
        strSQL = strSQL + "'mf_a1_pipe_snapshot' , 'mf_a2_pipeline_actions' , 'mf_a3_firm_commit' , 'mf_a4_initial_endorse' , ";
        strSQL = strSQL + "'mf_assistance_contract' , 'mf_direct_loan' , 'mf_fha_claim' , 'mf_flexible_subsidy' , ";
        strSQL = strSQL + "'mf_fy' , 'mf_grant_capital_advance' , 'mf_hud_held_loan' , 'mf_insured_loan' , ";
        strSQL = strSQL + "'mf_loans_mods' , 'mf_mddr_del_def' , 'mf_mip_activity' , 'mf_non_insured_loan' , ";
        strSQL = strSQL + "'mf_pfy' , 'mf_physical_inspection' , 'mf_request_fund' , 'mf_service_coordinator_cntrct' , ";
        strSQL = strSQL + "'mf_service_coordinator_grant' , 'mf_use_restriction')";

        //
        try
        {
            //dt = getdata.GetList(strSQL).Tables[0];
            //dgvTableNames.DataSource = dt;
            //dgvTableNames.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;

        }
        finally
        {
        }



    }

    protected void btnRunQuery_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        clsData getData = new clsData();
        string strSQL;
        string strWhere;
        string strGroupBy;
        int l;
        //
        strSQL = txtSelect.Text;
        strSQL = strSQL + txtFrom.Text;
        //
        strWhere = txtWhere.Text.Trim();
        //
         if (strWhere.Length > 5)
        {
              strSQL = strSQL + txtWhere.Text;
        }
        //
         strGroupBy = txtGroupBy.Text.Trim();
         if (strGroupBy.Length > 8)
        {
              strSQL = strSQL + txtGroupBy.Text;
        }
       //
        try
        {
            

            dt = getData.GetList(strSQL).Tables[0];
            //dgvQueryResults.DataSource = dt;
            //dgvQueryResults.DataBind();
            Session["griddata"] = dt;
            Response.Redirect("~/showdata.aspx");
        }
        catch (Exception ex)
        //catch (System.Threading.ThreadAbortException lException)
        {
            string strErr = ex.Message;
            throw ex;

        }
        finally
        {
        }
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {

        if (dgvQueryResults.Rows.Count > 0)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
            Response.Charset = "";

            // If you want the option to open the Excel file without saving then
            // comment out the line below
            // Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            dgvQueryResults.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    protected void cbkActiveInsuredLoan_CheckedChanged(object sender, EventArgs e)
    {
        txtFrom.Text = txtFrom.Text + " " + "mf_insured_loan " ;
        txtWhere.Text = txtWhere.Text + " " + " cat_financing_current_status = 'Active' and (ind_is_ppc_claim = 'Y' or ind_is_hud_held_loan = 'N')";
    }
    protected void cbkJoinWithProperty_CheckedChanged(object sender, EventArgs e)
    {
        txtFrom.Text = txtFrom.Text + " " + "mf_property " ;
        txtWhere.Text = txtWhere.Text + " " + " pk_property_id = fk_property_id ";
         
    }

protected void  cbkSpecificProperties_CheckedChanged(object sender, EventArgs e)
{
     if (cbkSpecificProperties.Checked == true )
    {
            txtPropertyIds.Visible = true;
            lblPropertyIds.Visible = true;
            chkAddProperties.Visible = true;
    }
     else
    {
            txtPropertyIds.Visible = false;
            lblPropertyIds.Visible = false;
            chkAddProperties.Visible = false;
    }
}
protected void chkAddProperties_CheckedChanged(object sender, EventArgs e)
{
     if (chkAddProperties.Checked == true )
            if (cbkJoinWithProperty.Checked == true)
                txtWhere.Text = txtWhere.Text + " AND pk_property_id in ( " + txtPropertyIds.Text + " )";
            else
                txtWhere.Text = txtWhere.Text  + " fk_property_id in ( " + txtPropertyIds.Text + " )";
        }
}

