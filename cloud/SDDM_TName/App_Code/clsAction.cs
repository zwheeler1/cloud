using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

/// <summary>
/// Summary description for clsAction
/// </summary>
public class clsAction
{
	public clsAction()
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
    private string m_ActionType;
    private string m_ActionDate;
    private string m_IsCurrent;
    private string m_oldOwnerName =string.Empty;
    private string m_newOwnerName=string.Empty;
    #endregion

    #region Public Properties

    public  string ActionType
    {
        get
        {
            return m_ActionType;
        }
        set
        {
            m_ActionType = value;
        }
    }
    
    public string ActionDate
    {
        get
        {
            return m_ActionDate;
        }
        set
        {
            m_ActionDate = value;
        }
    }


    public string OldOwnerName
    {
        get
        {
            return m_oldOwnerName;
        }
        set
        {
            m_oldOwnerName = value;
        }
    }

    public string NewOwnerName
    {
        get
        {
            return m_newOwnerName;
        }
        set
        {
            m_newOwnerName = value;
        }
    }
    public string IsCurrent
    {
        get
        {
            return m_IsCurrent;
        }
        set
        {
            m_IsCurrent = value;
        }
    }
    #endregion

    #region Public Methods

    public bool AddTradeNameAction(clsAction oAction)
    {
        clsLogon oLogon = new clsLogon();
        clsLogon.UserName = "zwheeler";

        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }

        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_AddTradeNameAction";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //

        try
        {
            //
            SqlParameter seq_next_value_Parameter = sqlCmd.Parameters.Add("Return_Value", System.Data.SqlDbType.BigInt);
            seq_next_value_Parameter.Direction = System.Data.ParameterDirection.ReturnValue;
            //
            System.Data.SqlClient.SqlParameter P1 = sqlCmd.Parameters.Add("@AppNumber", SqlDbType.BigInt);
            P1.Direction = ParameterDirection.Input;
            P1.Value = clsMain.AppNumber;
            //
            System.Data.SqlClient.SqlParameter P2 = sqlCmd.Parameters.Add("@ActionType", SqlDbType.VarChar);
            P2.Direction = ParameterDirection.Input;
            P2.Value = oAction.ActionType;
            //
            System.Data.SqlClient.SqlParameter P3 = sqlCmd.Parameters.Add("@ActionDate", SqlDbType.VarChar);
            P3.Direction = ParameterDirection.Input;
            P3.Value = oAction.ActionDate;
            //
            System.Data.SqlClient.SqlParameter P4 = sqlCmd.Parameters.Add("@OldOwnerName", SqlDbType.VarChar);
            P4.Direction = ParameterDirection.Input;
            P4.Value = oAction.OldOwnerName;
            //
            System.Data.SqlClient.SqlParameter P5 = sqlCmd.Parameters.Add("@NewOwnerName", SqlDbType.VarChar);
            P5.Direction = ParameterDirection.Input;
            P5.Value = oAction.NewOwnerName;
            //
            System.Data.SqlClient.SqlParameter P6 = sqlCmd.Parameters.Add("@IsCurrent", SqlDbType.VarChar);
            P6.Direction = ParameterDirection.Input;
            P6.Value = oAction.IsCurrent;
            //
            System.Data.SqlClient.SqlParameter AddedBy = sqlCmd.Parameters.Add("@AddedBy", SqlDbType.VarChar);
            AddedBy.Direction = ParameterDirection.Input;
            AddedBy.Value = clsLogon.UserName;
            //Execute Stored Procedure
            //
            int intRowsAffected = sqlCmd.ExecuteNonQuery();
            
            sqlCmd.Parameters.Clear();
            return true;
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

    #endregion


}
