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
//Imports Permits_Scaled_Downed
public class clsFeePayment
{
    private static int m_FeePaymentId;
    private float m_AmountPaid;
    private string m_DatePaid;
    private string m_PaidBy = "";
    private string m_CheckNumber;
    private string m_AddedBY;
    private System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection();

    private System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
    private System.Data.DataSet m_retreiveDataSet = new System.Data.DataSet();
    //define the constructor
    public clsFeePayment()
    {

    }

    public static int FeePaymentId
    {
        get { return m_FeePaymentId; }
        set { m_FeePaymentId = value; }
    }

    public float AmountPaid
    {
        get { return m_AmountPaid; }
        set { m_AmountPaid = value; }
    }

    public string DatePaid
    {
        get { return m_DatePaid; }
        set { m_DatePaid = value; }
    }
    public string PaidBy
    {
        get { return m_PaidBy; }
        set { m_PaidBy = value; }
    }
    public string CheckNumber
    {
        get { return m_CheckNumber; }
        set { m_CheckNumber = value; }
    }

    public bool AddFeePayment(clsFeePayment oFeePayment)
    {
        //Dim oMain As New clsMain
        clsLogon oLogon = new clsLogon();

        if (sqlConn.State == System.Data.ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_AddFeePaymentData";
        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //

        try
        {
            SqlParameter seq_next_value_Parameter = sqlCmd.Parameters.Add("Return_Value", System.Data.SqlDbType.BigInt);
            seq_next_value_Parameter.Direction = System.Data.ParameterDirection.ReturnValue;
            //
            SqlParameter AmountPaid_Parameter = sqlCmd.Parameters.Add("@AmountPaid", System.Data.SqlDbType.Decimal);
            AmountPaid_Parameter.Direction = System.Data.ParameterDirection.Input;
            AmountPaid_Parameter.Value = oFeePayment.AmountPaid;
            //
            SqlParameter DatePaid_Parameter = sqlCmd.Parameters.Add("@DatePaid", System.Data.SqlDbType.VarChar);
            DatePaid_Parameter.Direction = System.Data.ParameterDirection.Input;
            DatePaid_Parameter.Value = oFeePayment.DatePaid;
            //
            SqlParameter PaidBy_Parameter = sqlCmd.Parameters.Add("@PaidBy", System.Data.SqlDbType.VarChar);
            PaidBy_Parameter.Direction = System.Data.ParameterDirection.Input;
            PaidBy_Parameter.Value = oFeePayment.PaidBy;
            //
            SqlParameter CheckNumber_Parameter = sqlCmd.Parameters.Add("@CheckNumber", System.Data.SqlDbType.VarChar);
            CheckNumber_Parameter.Direction = System.Data.ParameterDirection.Input;
            CheckNumber_Parameter.Value = oFeePayment.CheckNumber;
            //
            SqlParameter AddedBy_Parameter = sqlCmd.Parameters.Add("@AddedBy", System.Data.SqlDbType.VarChar);
            AddedBy_Parameter.Direction = System.Data.ParameterDirection.Input;
            AddedBy_Parameter.Value = clsLogon.UserName;
            //'
            //Execute Stored Procedure
            //
            int intRowsAffected = sqlCmd.ExecuteNonQuery();
            clsFeePayment.FeePaymentId = (int)seq_next_value_Parameter.Value;
            //
            sqlCmd.Parameters.Clear();

            //
            return true;
            //Return the Id or AppNumber from the database
        }
        catch (Exception ex)
        {
            clsErrors oError = new clsErrors();
            clsMain oMain = new clsMain();
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
    public bool AddFeesFeePayment()
    {
        //Dim oMain As New clsMain
        clsLogon oLogon = new clsLogon();

        if (sqlConn.State == System.Data.ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_AddFeesFeePaymentData";
        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //

        try
        {
            //
            SqlParameter AmountPaid_Parameter = sqlCmd.Parameters.Add("@FeePaymentId", System.Data.SqlDbType.Decimal);
            AmountPaid_Parameter.Direction = System.Data.ParameterDirection.Input;
            AmountPaid_Parameter.Value = clsFeePayment.FeePaymentId;
            //
            SqlParameter DatePaid_Parameter = sqlCmd.Parameters.Add("@AppNumber", System.Data.SqlDbType.BigInt);
            DatePaid_Parameter.Direction = System.Data.ParameterDirection.Input;
            DatePaid_Parameter.Value = clsMain.AppNumber;

            SqlParameter AddedBy_Parameter = sqlCmd.Parameters.Add("@AddedBy", System.Data.SqlDbType.VarChar);
            AddedBy_Parameter.Direction = System.Data.ParameterDirection.Input;
            AddedBy_Parameter.Value = clsLogon.UserName;
            //'
            //Execute Stored Procedure
            //
            int intRowsAffected = sqlCmd.ExecuteNonQuery();

            //
            sqlCmd.Parameters.Clear();

            //
            return true;
            //Return the Id or AppNumber from the database
        }
        catch (Exception ex)
        {
            clsErrors oError = new clsErrors();
            clsMain oMain = new clsMain();
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