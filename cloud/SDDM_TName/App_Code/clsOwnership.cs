using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Diagnostics;
using System.Web.Script.Services;
using System.Web.Services;


/// <summary>
/// Summary description for clsOwnership
/// </summary>
public class clsOwnership
{
	public clsOwnership()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region Connection Properties
    SqlConnection sqlConn = new SqlConnection();
    SqlCommand sqlCmd = new SqlCommand();
    #endregion

    #region Private Properties
    private static int m_AppNumber;
    private string m_BusinessEntityType;
    private int m_BusinessName;
    private string m_BusinessTaxId;
    private string m_BusinessTradeName;
    private string m_DateAppSubmitted;
    #endregion

    #region Public Properties
    public static int AppNumber
    {
        get
        {
            return m_AppNumber;
        }
        set
        {
            m_AppNumber = value;
        }
    }
    public string BusinessEntityType
    {
        get
        {
            return m_BusinessEntityType;
        }
        set
        {
            m_BusinessEntityType = value;
        }
    }
    public int BusinessName
    {
        get
        {
            return m_BusinessName;
        }
        set
        {
            m_BusinessName = value;
        }
    }
    private string BusinessTaxId
    {
        get
        {
            return m_BusinessTaxId;
        }
        set
        {
            m_BusinessTaxId = value;
        }
    }
    private string BusinessTradeName
    {
        get
        {
            return m_BusinessTradeName;
        }
        set
        {
            m_BusinessTradeName = value;
        }
    }
    private string DateAppSubmitted
    {
        get
        {
            return m_DateAppSubmitted;
        }
        set
        {
            m_DateAppSubmitted = value;
        }
    }
    #endregion
    #region Public Methods
    #endregion
}
