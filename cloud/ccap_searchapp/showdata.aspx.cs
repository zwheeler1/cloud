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



public partial class showdata : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dtSearchData = (DataTable)Session["griddata"];
      
        if (!Page.IsPostBack)
        {
            dgvQueryResults.DataSource = dtSearchData;
            dgvQueryResults.DataBind();
            //
            //Add Column Names to Drop Downlist
            
            

            for (int i = 0; i < dtSearchData.Columns.Count; i++)
            {
                string temp2 = dtSearchData.Columns[i].ColumnName.ToString();
                ddlFilterByColumnName.Items.Add(new ListItem(temp2));
            }
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

    protected void btnFilter_Click(object sender, EventArgs e)
    {

         DataTable dtSearchData = (DataTable)Session["griddata"];
         //
         DataView dataView = dtSearchData.DefaultView;
         dataView.RowFilter = ddlFilterByColumnName.Text + " Like '" + txtFilter.Text + "%'"; 
        //
        //Clear GridView
        dgvQueryResults.DataSource = null;
        //rebind to gridview
        dgvQueryResults.DataBind();
        //
         dgvQueryResults.DataSource = dataView;
         dgvQueryResults.DataBind();
    }
    protected void btnViewAllData_Click(object sender, EventArgs e)
    {
        DataTable dtSearchData = (DataTable)Session["griddata"];
        //
        dgvQueryResults.DataSource = null;
        //rebind to gridview
        dgvQueryResults.DataBind();
        //
        dgvQueryResults.DataSource = dtSearchData;
        dgvQueryResults.DataBind();
    }
}