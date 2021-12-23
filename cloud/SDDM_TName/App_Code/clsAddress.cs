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

public class clsAddress
{
    private System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection();
    private System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
    // Public frmRetrieveAddress As New frmRetrieveAddress
    private static int m_addresskey;
    private static string m_occupancy;
    private static string m_dcAddress;
    private static string m_streetNumber;
    private static string m_streetName;
    private static string m_streetType;
    private static string m_quadrant;
    private static string m_suiteNumber;
    private static string m_zip;
    //Parcel Information
    private static string m_square;
    private static string m_suffix;
    private static string m_lot;
    //Owner Information
    private static string m_ownerfname;
    private static string m_ownerlname;
    private static string m_owneraddress;
    private static string m_ownerstate;
    private static string m_ownercity;

    private static string m_ownerzip;

    public static int AddressKey
    {
        get { return m_addresskey; }
        set { m_addresskey = value; }
    }
    public string Occupancy
    {
        get { return m_occupancy; }
        set
        {
            if (value.Length == 0)
            {
                value = " ";
            }
            m_occupancy = value;
        }
    }

    public string StreetNumber
    {
        get { return m_streetNumber; }
        set { m_streetNumber = value; }
    }
    public string StreetName
    {
        get { return m_streetName; }
        set { m_streetName = value; }
    }

    public string StreetType
    {
        get { return m_streetType; }
        set { m_streetType = value; }
    }
    public string Quadrant
    {
        get { return m_quadrant; }
        set { m_quadrant = value; }
    }
    public string SuiteNumber
    {
        get { return m_suiteNumber; }
        set
        {
            //if (Information.IsDBNull(value) | Strings.Len(value) == 0)
            //{
            //    m_suiteNumber = "-99999";
            //}
            //else
            //{
            //    m_suiteNumber = Strings.Trim(value);
            //}
        }
    }
    public string zip
    {
        get { return m_zip; }
        set { m_zip = value; }
    }
    public string ParcelSquare
    {
        get { return m_square; }
        set { m_square = value; }
    }
    public string ParcelSuffix
    {
        get { return m_suffix; }
        set { m_suffix = value; }
    }
    public string ParcelLot
    {
        get { return m_lot; }
        set { m_lot = value; }
    }
    public string OwnerFName
    {
        get { return m_ownerfname; }
        set { m_ownerfname = value; }
    }
    public string OwnerLName
    {
        get { return m_ownerlname; }
        set { m_ownerlname = value; }
    }
    public string OwnerAddress
    {
        get { return m_owneraddress; }
        set { m_owneraddress = value; }
    }
    public string OwnerCity
    {
        get { return m_ownercity; }
        set { m_ownercity = value; }
    }
    public string OwnerState
    {
        get { return m_ownerstate; }
        set { m_ownerstate = value; }
    }
    public string OwnerZip
    {
        get { return m_ownerzip; }
        set { m_ownerzip = value; }
    }
    public void getAddress1()
    {
        //This function retrieves the address if the address exists in the database
        try
        {
            //Dim frmRetrieveAddress As New frmRetrieveAddress
            //frmRetrieveAddress.ShowDialog()
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
            //Close connection
        }
    }

    public DataSet getAddress(clsAddress oAddress)
    {
        System.Data.DataSet dsRetrievedata = new System.Data.DataSet();

        //Actually Here we simply pass the data to the web service and the 
        //web service will call the function

        if (sqlConn.State == System.Data.ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();


        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetAddress";
        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //
            SqlParameter STREETNUMBER_Parameter = sqlCmd.Parameters.Add("@STNO", System.Data.SqlDbType.VarChar);
            STREETNUMBER_Parameter.Direction = System.Data.ParameterDirection.Input;
            STREETNUMBER_Parameter.Value = oAddress.StreetNumber;
            //
            SqlParameter STREETNAME_Parameter = sqlCmd.Parameters.Add("@STNAME", System.Data.SqlDbType.VarChar);
            STREETNAME_Parameter.Direction = System.Data.ParameterDirection.Input;
            STREETNAME_Parameter.Value = oAddress.StreetName;
            //
            SqlParameter STREETTYPE_Parameter = sqlCmd.Parameters.Add("@STTYPE", System.Data.SqlDbType.VarChar);
            STREETTYPE_Parameter.Direction = System.Data.ParameterDirection.Input;
            STREETTYPE_Parameter.Value = oAddress.StreetType;
            //
            SqlParameter QUAD_Parameter = sqlCmd.Parameters.Add("@QUAD", System.Data.SqlDbType.VarChar);
            QUAD_Parameter.Direction = System.Data.ParameterDirection.Input;
            QUAD_Parameter.Value = oAddress.Quadrant;

            //Create a Data Adapter
            SqlDataAdapter daRetrieveData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daRetrieveData.Fill(dsRetrievedata, "tblData");
            //Display in Datagrid

            return dsRetrievedata;

        }
        catch (Exception ex)
        {
            clsErrors oError = new clsErrors();
            oError.AppNumber = 0;
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.LogErrors(oError);
            return dsRetrievedata;
        }
        finally
        {
            sqlConn.Close();
            sqlCmd.Parameters.Clear();
            if ((sqlCmd != null))
            {
                sqlCmd.Dispose();
            }
        }
    }

    public DataSet getAddress(string strAddressKey )
    {
        System.Data.DataSet dsRetrievedata = new System.Data.DataSet();

        //Actually Here we simply pass the data to the web service and the 
        //web service will call the function

        if (sqlConn.State == System.Data.ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();


        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetAddress_By_Key_w_Fee";
        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //
            SqlParameter P0 = sqlCmd.Parameters.Add("@v_AddressKey", System.Data.SqlDbType.BigInt);
            P0.Direction = System.Data.ParameterDirection.Input;
            P0.Value =  Convert.ToInt32(strAddressKey);
            //
            //Create a Data Adapter
            SqlDataAdapter daRetrieveData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daRetrieveData.Fill(dsRetrievedata, "tblAddress");
            //Display in Datagrid

            return dsRetrievedata;

        }
        catch (Exception ex)
        {
            clsErrors oError = new clsErrors();
            oError.AppNumber = 0;
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.LogErrors(oError);
            return dsRetrievedata;
        }
        finally
        {
            sqlConn.Close();
            sqlCmd.Parameters.Clear();
            if ((sqlCmd != null))
            {
                sqlCmd.Dispose();
            }
        }
    }
}