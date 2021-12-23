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

public partial class ManagePortfolios_wfrmSearchLoans : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetData();
    }
    public void GetData()
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        clsData getdata = new clsData();
        //
        string strSQL = null;

        strSQL = " select distinct fk_property_id,tag_property_name,fk_fha_number,tag_branch_chief,tag_project_manager,";
		 strSQL = strSQL + " mtr_unpaid_principal_balance,mtr_rating, mtr_rating_override, mtr_rating_final,";
		 strSQL = strSQL + " date_final_rating, date_ext_date";
		 strSQL = strSQL + " from mf_am_portfolio_ranking ";
         strSQL = strSQL + " where fk_property_id  = '" + txtIREMSPropertyId.Text + "'"; 
        strSQL = strSQL + " order by date_final_rating desc" ;

        //
        try
        {
            dt = getdata.GetList(strSQL).Tables[0];
            grvTableNames.DataSource = dt;
            grvTableNames.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;

        }
        finally
        {
        }
    }
    protected void grvTableNames_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hl = (HyperLink)e.Row.FindControl("hlDetails1");
            if (hl != null)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                string Tname = drv["fk_property_id"].ToString();
                hl.NavigateUrl = "~/managepofoliosrt/wfrmTableDetails.aspx?Tname=" + Server.UrlEncode(Tname.ToString());
                //    }

            }
        }
    }
}