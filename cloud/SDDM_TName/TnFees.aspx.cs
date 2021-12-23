using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TnFees : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetFees();
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }

    protected void GetFees()
    {
        clsFees oFees = new clsFees();
        string sqlSearch = "select * from tbl_fees where fk_appnumber = " + clsMain.AppNumber;
       
        grvFees.DataSource = oFees.GetFees(sqlSearch).Tables[0].DefaultView;
        grvFees.DataBind();

    }
    protected void grvFees_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }


    protected void grvFees_RowDataBound(object sender, GridViewRowEventArgs e)
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
        grvFees.DataSource = null;
        grvFees.DataBind();
    }

}
