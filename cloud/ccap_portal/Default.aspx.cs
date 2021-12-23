using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net; 

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnViewTables_Click(object sender, EventArgs e)
    {

    }
    protected void btnSearchByName_Click(object sender, EventArgs e)
    {

    }
    protected void btnTableRefres_Click(object sender, EventArgs e)
    {

    }
    protected void btnOpenPDF_Click(object sender, EventArgs e)
    {
        string FilePath = Server.MapPath("~/DED_PDF/OPIIS_CCAP_DED.pdf");
        WebClient User = new WebClient();
        Byte[] FileBuffer = User.DownloadData(FilePath);
        if (FileBuffer != null)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", FileBuffer.Length.ToString());
            Response.BinaryWrite(FileBuffer);
        }  
    }
}
