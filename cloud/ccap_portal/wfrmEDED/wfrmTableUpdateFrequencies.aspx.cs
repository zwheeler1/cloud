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


public partial class wfrmEDED_wfrmTableUpdateFrequencies : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadData();
        }

    }

   
 public void LoadData()
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        clsData getdata = new clsData();
        //
        string strSQL = null;
        strSQL = "select TABLE_NAME , tag_table_definition,cat_refresh_frequency ";
        strSQL = strSQL + " from mf_ded_table_data_status f,mf_ded_table_name_new d";
        strSQL = strSQL + " where f.fk_table_name = d.table_name ";


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
                string Tname = drv["Table_Name"].ToString();
                hl.NavigateUrl = "~/wfrmEDED/wfrmTableDetails.aspx?Tname=" + Server.UrlEncode(Tname.ToString());
                //    }

            }
        }
    }
}