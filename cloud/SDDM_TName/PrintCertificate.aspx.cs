using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Configuration;

public partial class PrintCertificate : System.Web.UI.Page
{
    public partial class ReportViewerCredentials : IReportServerCredentials
    {
        private string _userName;
        private string _password;
        private string _domain;

        public ReportViewerCredentials(string userName, string password, string domain)
        {
            _userName = userName;
            _password = password;
            _domain = domain;
        }

        public WindowsIdentity ImpersonationUser
        {
            get
            {
                return null;
            }
        }

        public ICredentials NetworkCredentials
        {
            get
            {
                return new NetworkCredential(_userName, _password, _domain);
            }
        }

        public bool GetFormsCredentials(out Cookie authCookie,
                out string userName, out string password,
                out string authority)
        {
            authCookie = null;
            userName = null;
            password = null;
            authority = null;
            // Not using form credentials
            return false;
        }

    }



    protected void Page_Load(object sender, System.EventArgs e)
    {
        Session["AppNumber"] = "3550";
        Session["ReportPath"] = "/reports/Permits/InvoiceFees";
        if (!Page.IsPostBack)
        {
            try
            {
                ReportParameter p1 = new ReportParameter();
                p1.Name = "APPNUMBER";
                string strAppnumber = Session["AppNumber"].ToString();
                p1.Values.Add(strAppnumber);
                //Set the report parameters for the report
                ReportParameter[] parameters = new ReportParameter[1];
                parameters[0] = p1;

                rvPrintCertificate.ServerReport.ReportPath = Session["ReportPath"].ToString();
                this.rvPrintCertificate.ServerReport.ReportServerCredentials = new ReportViewerCredentials("sddreportuser", "Ze6PaqU9", "reports");
                try
                {
                    this.rvPrintCertificate.ServerReport.SetParameters(parameters);
                }
                catch (Exception ex)
                {
                    string strM = ex.Message;
                }
                finally
                {
                    Session["AppNumber"] = strAppnumber;
                }

                this.rvPrintCertificate.ServerReport.Refresh();
            }
            catch (Exception ex)
            {
                string strM1 = ex.Message;
            }
        }
    }
}