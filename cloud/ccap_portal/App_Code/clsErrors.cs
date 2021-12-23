using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;

public class Errors
{
    private System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection();
    private System.Data.SqlClient.SqlCommand sqlCMD = new System.Data.SqlClient.SqlCommand();
    //
    private string m_ErrorSource;
    private string m_ErrorMethod;
    private string m_ErrorMessage;
    private string m_ErrorStackTrace;
    private int m_AppNumber;
    private string m_ErrorResolvedDate;

    private string m_ErrorResolution;
    public Errors()
    {
    }
    public string ErrorMethod
    {
        get { return m_ErrorMethod; }
        set { m_ErrorMethod = value; }
    }
    public string ErrorSource
    {
        get { return m_ErrorSource; }
        set { m_ErrorSource = value; }
    }
    public string ErrorMessage
    {
        get { return m_ErrorMessage; }
        set { m_ErrorMessage = value; }
    }

    public string ErrorStackTrace
    {
        get { return m_ErrorStackTrace; }
        set { m_ErrorStackTrace = value; }
    }
    public int AppNumber
    {
        get { return m_AppNumber; }
        set { m_AppNumber = value; }
    }
    public string ErrorResolvedDate
    {
        get { return m_ErrorResolvedDate; }
        set { m_ErrorResolvedDate = value; }
    }
    public string ErrorResolution
    {
        get { return m_ErrorResolution; }
        set { m_ErrorResolution = value; }
    }
    public void LogErrors(Errors oErrors)
    {
        //Dim oLogon As New clsLogon
        //'clsLogon.UserName = "ZWHEELER"

        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        // sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"]

        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();
        sqlCMD.Connection = sqlConn;
        sqlCMD.CommandText = "usp_AddError";
        sqlCMD.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //

        try
        {
            SqlParameter AppNumber_Parameter = sqlCMD.Parameters.Add("@AppNumber", SqlDbType.BigInt);
            AppNumber_Parameter.Direction = ParameterDirection.Input;
            AppNumber_Parameter.Value = clsDataSets.Property_Id;
            //
            SqlParameter ErrorSource_Parameter = sqlCMD.Parameters.Add("@ErrorSource", SqlDbType.VarChar);
            ErrorSource_Parameter.Direction = ParameterDirection.Input;
            ErrorSource_Parameter.Value = oErrors.ErrorSource;
            //
            SqlParameter ErrorMessage_Parameter = sqlCMD.Parameters.Add("@ErrorMessage", SqlDbType.VarChar);
            ErrorMessage_Parameter.Direction = ParameterDirection.Input;
            ErrorMessage_Parameter.Value = oErrors.ErrorMessage;
            //
            SqlParameter ErrorStackTrace_Parameter = sqlCMD.Parameters.Add("@ErrorStackTrace", SqlDbType.VarChar);
            ErrorStackTrace_Parameter.Direction = ParameterDirection.Input;
            ErrorStackTrace_Parameter.Value = oErrors.ErrorStackTrace.ToString();
            //m_ErrorMethod
            //
            SqlParameter ErrorMethod_Parameter = sqlCMD.Parameters.Add("@ErrorMethod", SqlDbType.VarChar);
            ErrorStackTrace_Parameter.Direction = ParameterDirection.Input;
            ErrorStackTrace_Parameter.Value = oErrors.ErrorMethod;
            //
            //SqlParameter AddedBy_Parameter = sqlCMD.Parameters.Add("@AddedBy", SqlDbType.VarChar);
            //AddedBy_Parameter.Direction = ParameterDirection.Input;
            //AddedBy_Parameter.Value = clsLogon.UserName;
            //'
            //Execute Stored Procedure and write to the database
            //
            int intRowsAffected = sqlCMD.ExecuteNonQuery();
            //

        }
        catch (Exception ex)
        {
            //(ex.Source, "SOURCE")
            string strMessage = ex.Message;

        }
        finally
        {
            sqlConn.Close();
            sqlCMD.Parameters.Clear();
            if ((sqlCMD != null))
            {
                sqlCMD.Dispose();
            }
        }
    }

}

