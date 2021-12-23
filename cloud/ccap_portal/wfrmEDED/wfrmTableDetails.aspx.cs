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

public partial class wfrmEDED_wfrmTableDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
          

           lblCaption.Text = HttpUtility.UrlDecode(Request.QueryString["TName"]);
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

        if (HttpUtility.UrlDecode(Request.QueryString["BName"]) == "Table_Name_1")
        {
         strSQL = "select fk_table_name , tag_business_column_name,tag_definition,tag_physical_column_name,cat_data_source_system,cat_data_type,cat_section ";
        strSQL = strSQL + " from mf_ded_table_attributes_new";
        strSQL = strSQL + " where fk_table_name ='" + HttpUtility.UrlDecode(Request.QueryString["TName"]) + "'" ;
        strSQL = strSQL +  " Order by cat_section ";
        }
        else
        {
        strSQL = "select fk_table_name , tag_business_column_name,tag_definition,tag_physical_column_name,cat_data_source_system,cat_data_type,cat_section ";
        strSQL = strSQL + " from mf_ded_table_attributes_new";
        strSQL = strSQL + " where fk_table_name ='" + HttpUtility.UrlDecode(Request.QueryString["TName"]) + "'" ;
        strSQL = strSQL + " and tag_business_column_name like '%" + HttpUtility.UrlDecode(Request.QueryString["BName"]) + "%'" ;
        strSQL = strSQL +  " Order by cat_section ";
        }
        
        //
        try
        {
            dt = getdata.GetList(strSQL).Tables[0];
            grvTableDetails.DataSource = dt;
            grvTableDetails.DataBind();
            
        }
        catch (Exception ex)
        {
            throw ex;

        }
        finally
        {
        }
    }

}