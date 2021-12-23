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

public class clsAddAddress
{
    private System.Data.DataSet m_retreiveDataSet = new System.Data.DataSet();
    private static int m_newaddress;
    private static string m_stno;
    private static string m_stName;
    private static string m_stType;
    private static string m_quad;
    private static string m_suite = "  ";
    private string m_city;
    private string m_state;
    private string m_zip;
    private string m_status;
    private string m_square;
    private string m_suffix;
    private string m_lot;
    private string m_ownerfname;
    private string m_ownerlname;
    private string m_ownerstno;
    private string m_ownerstName;
    private string m_ownersttype;
    private string m_ownerquad;
    private string m_ownersuite;
    private string m_ownercity;
    private string m_ownerstate;
    private string m_ownerzip;
    //
    #region "Properties Connection"
    private System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection();
    #endregion
    private System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
    //
    public static int AddNewAddress
    {
        get { return m_newaddress; }
        set { m_newaddress = value; }
    }
    public static string ststno
    {
        get { return m_stno; }
        set { m_stno = value; }
    }
    public static string ststname
    {
        get { return m_stName; }
        set { m_stName = value; }
    }
    public static string sttype
    {
        get { return m_stType; }
        set { m_stType = value; }
    }
    public static string stquad
    {
        get { return m_quad; }
        set { m_quad = value; }
    }
    public static string stsuite
    {
        get { return m_suite; }
        set { m_suite = value; }
    }
    public string stCity
    {
        get { return m_city; }
        set { m_city = value; }
    }
    public string stState
    {
        get { return m_state; }
        set { m_state = value; }
    }
    public string stZip
    {
        get { return m_zip; }
        set { m_zip = value; }
    }
    public string stStatus
    {
        get { return m_status; }
        set { m_status = value; }
    }
    public string parcelSquare
    {
        get { return m_square; }
        set { m_square = value; }
    }
    public string parcelSuffix
    {
        get { return m_suffix; }
        set { m_suffix = value; }
    }
    public string parcelLot
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
    public string OwnerStno
    {
        get { return m_ownerstno; }
        set { m_ownerstno = value; }
    }
    public string OwnerStName
    {
        get { return m_ownerstName; }
        set { m_ownerstName = value; }
    }
    public string OwnerSttype
    {
        get { return m_ownersttype; }
        set { m_ownersttype = value; }
    }
    public string OwnerQuad
    {
        get { return m_ownerquad; }
        set { m_ownerquad = value; }
    }
    public string OwnerSuite
    {
        get { return m_ownersuite; }
        set { m_ownersuite = value; }
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
    public Boolean AddAddressRecord(clsAddAddress oAddAddress)
    {
        clsLogon oLogon = new clsLogon();
        int i = 0;
        if (sqlConn.State == System.Data.ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_AddAddress";
        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
        //
        //***************************Define Inspection Parameters**********************
        //
        try
        {
            //
            SqlParameter seq_next_value_Parameter = sqlCmd.Parameters.Add("Return_Value", System.Data.SqlDbType.BigInt);
            seq_next_value_Parameter.Direction = System.Data.ParameterDirection.ReturnValue;
            //
            SqlParameter ststno_Parameter = sqlCmd.Parameters.Add("@stno", System.Data.SqlDbType.VarChar);
            ststno_Parameter.Direction = System.Data.ParameterDirection.Input;
            ststno_Parameter.Value = clsAddAddress.ststno;
            //
            SqlParameter stname_Parameter = sqlCmd.Parameters.Add("@stname", System.Data.SqlDbType.VarChar);
            stname_Parameter.Direction = System.Data.ParameterDirection.Input;
            stname_Parameter.Value = clsAddAddress.ststname;
            //
            SqlParameter stsuite_Parameter = sqlCmd.Parameters.Add("@suite", System.Data.SqlDbType.VarChar);
            stsuite_Parameter.Direction = System.Data.ParameterDirection.Input;
            stsuite_Parameter.Value = clsAddAddress.stsuite;
            //
            SqlParameter suffix_Parameter = sqlCmd.Parameters.Add("@suffix", System.Data.SqlDbType.VarChar);
            suffix_Parameter.Direction = System.Data.ParameterDirection.Input;
            suffix_Parameter.Value = clsAddAddress.sttype;
            //
            SqlParameter postdir_Parameter = sqlCmd.Parameters.Add("@postdir", System.Data.SqlDbType.VarChar);
            postdir_Parameter.Direction = System.Data.ParameterDirection.Input;
            postdir_Parameter.Value = clsAddAddress.stquad;

            //
            SqlParameter city_Parameter = sqlCmd.Parameters.Add("@city", System.Data.SqlDbType.VarChar);
            city_Parameter.Direction = System.Data.ParameterDirection.Input;
            city_Parameter.Value = oAddAddress.stCity;
            //
            SqlParameter state_Parameter = sqlCmd.Parameters.Add("@state", System.Data.SqlDbType.VarChar);
            state_Parameter.Direction = System.Data.ParameterDirection.Input;
            state_Parameter.Value = oAddAddress.stState;
            //
            SqlParameter zip_Parameter = sqlCmd.Parameters.Add("@zip", System.Data.SqlDbType.VarChar);
            zip_Parameter.Direction = System.Data.ParameterDirection.Input;
            zip_Parameter.Value = oAddAddress.stZip;
            //
            SqlParameter verifyaddress_Parameter = sqlCmd.Parameters.Add("@verifyaddress", System.Data.SqlDbType.VarChar);
            verifyaddress_Parameter.Direction = System.Data.ParameterDirection.Input;
            verifyaddress_Parameter.Value = "YES";

            //
            SqlParameter AddedBy_Parameter = sqlCmd.Parameters.Add("@AddedBy", System.Data.SqlDbType.VarChar);
            AddedBy_Parameter.Direction = System.Data.ParameterDirection.Input;
            AddedBy_Parameter.Value = clsLogon.UserName;
            //
            //Execute Stored Procedure
            //
            int intRowsAffected = sqlCmd.ExecuteNonQuery();
            clsAddress.AddressKey =  (int)seq_next_value_Parameter.Value;

            sqlCmd.Parameters.Clear();
            return true;
            //
            //Return the Id or AppNumber from the database
        }
        catch (Exception ex)
        {
            clsErrors oError = new clsErrors();
            oError.AppNumber = clsMain.AppNumber;
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.LogErrors(oError);
            return false;
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