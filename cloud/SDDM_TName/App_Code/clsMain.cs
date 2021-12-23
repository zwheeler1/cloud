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
/// Summary description for clsMain
/// </summary>
public class clsMain
{
	public clsMain()
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
        private static bool m_RetrieveTrue = false;
        private string m_Action;
        private string m_BusinessEntityType;
        private string m_BusinessName;
        private string m_BusinessTaxId;
        private string m_BusinessTradeName;
        private string m_DateAppSubmitted;
        private string m_ClientId;
        private string m_LicenseToDoBusiness;
        private string m_SubmittedBy;
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

        public static bool RetrieveTrue
        {
            get
            {
                return m_RetrieveTrue;
            }
            set
            {
                m_RetrieveTrue = value;
            }
        }

        public string Action
        {
            get
            {
                return m_Action;
            }
            set
            {
                m_Action = value;
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
        public string BusinessName
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
        public string BusinessTaxId
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
        public string BusinessTradeName
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
        public string DateAppSubmitted
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
        public string ClientId
        {
            get
            {
                return m_ClientId;
            }
            set
            {
                m_ClientId = value;
            }
        }


        public string LicenseBusiness
        {
            get
            {
                return m_LicenseToDoBusiness;
            }
            set
            {
                m_LicenseToDoBusiness = value;
            }
        }

        public string SubmittedBy
        {
            get
            {
                return m_SubmittedBy;
            }
            set
            {
                m_SubmittedBy = value;
            }
        }
    #endregion

    #region Public Methods
    
    public bool AddMainTradeName(clsMain oMain)
    {
        clsLogon oLogon = new clsLogon();

        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }

        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_AddMainTradeName";
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
            System.Data.SqlClient.SqlParameter P1 = sqlCmd.Parameters.Add("@AddressKey", SqlDbType.BigInt);
            P1.Direction = ParameterDirection.Input;
            P1.Value = clsAddress.AddressKey;
            //
            System.Data.SqlClient.SqlParameter P2 = sqlCmd.Parameters.Add("@ClientId", SqlDbType.VarChar);
            P2.Direction = ParameterDirection.Input;
            P2.Value = oMain.ClientId;
            //
            System.Data.SqlClient.SqlParameter P3 = sqlCmd.Parameters.Add("@BusinessEntityType", SqlDbType.VarChar);
            P3.Direction = ParameterDirection.Input;
            P3.Value = oMain.BusinessEntityType;
            //
            System.Data.SqlClient.SqlParameter P4 = sqlCmd.Parameters.Add("@BusinessName", SqlDbType.VarChar);
            P4.Direction = ParameterDirection.Input;
            P4.Value = oMain.BusinessName;
            //
            System.Data.SqlClient.SqlParameter P5 = sqlCmd.Parameters.Add("@BusinessTaxId", SqlDbType.VarChar);
            P5.Direction = ParameterDirection.Input;
            P5.Value = oMain.BusinessTaxId;
            //
            System.Data.SqlClient.SqlParameter P6 = sqlCmd.Parameters.Add("@BusinessTradeName", SqlDbType.VarChar);
            P6.Direction = ParameterDirection.Input;
            P6.Value = oMain.BusinessTradeName;
            //
            System.Data.SqlClient.SqlParameter P7 = sqlCmd.Parameters.Add("@DateAppSubmitted", SqlDbType.VarChar);
            P7.Direction = ParameterDirection.Input;
            P7.Value = oMain.DateAppSubmitted;
            //
            System.Data.SqlClient.SqlParameter P8 = sqlCmd.Parameters.Add("@LicenseBusiness", SqlDbType.VarChar);
            P8.Direction = ParameterDirection.Input;
            P8.Value = oMain.LicenseBusiness;
            //
            System.Data.SqlClient.SqlParameter P9 = sqlCmd.Parameters.Add("@SubmittedBy", SqlDbType.VarChar);
            P9.Direction = ParameterDirection.Input;
            P9.Value = oMain.SubmittedBy;
            //
            System.Data.SqlClient.SqlParameter P10 = sqlCmd.Parameters.Add("@AddedBy", SqlDbType.VarChar);
            P10.Direction = ParameterDirection.Input;
            P10.Value = clsLogon.UserName;
            //'
            //Execute Stored Procedure
            //
            int intRowsAffected = sqlCmd.ExecuteNonQuery();
            clsMain.AppNumber = (int)seq_next_value_Parameter.Value;



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

    public bool UpdateMainTradeName(clsMain oMain)
    {
        clsLogon oLogon = new clsLogon();

        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }

        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_UpdateMainTradeName";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //

        try
        {
            System.Data.SqlClient.SqlParameter P0 = sqlCmd.Parameters.Add("@AppNumber", SqlDbType.BigInt);
            P0.Direction = ParameterDirection.Input;
            P0.Value = clsMain.AppNumber;
            //
            System.Data.SqlClient.SqlParameter P1 = sqlCmd.Parameters.Add("@AddressKey", SqlDbType.BigInt);
            P1.Direction = ParameterDirection.Input;
            P1.Value = clsAddress.AddressKey;
            //
            System.Data.SqlClient.SqlParameter P2 = sqlCmd.Parameters.Add("@ClientId", SqlDbType.VarChar);
            P2.Direction = ParameterDirection.Input;
            P2.Value = oMain.ClientId;
            //
            System.Data.SqlClient.SqlParameter P3 = sqlCmd.Parameters.Add("@BusinessEntityType", SqlDbType.VarChar);
            P3.Direction = ParameterDirection.Input;
            P3.Value = oMain.BusinessEntityType;
            //
            System.Data.SqlClient.SqlParameter P4 = sqlCmd.Parameters.Add("@BusinessName", SqlDbType.VarChar);
            P4.Direction = ParameterDirection.Input;
            P4.Value = oMain.BusinessName;
            //
            System.Data.SqlClient.SqlParameter P5 = sqlCmd.Parameters.Add("@BusinessTaxId", SqlDbType.VarChar);
            P5.Direction = ParameterDirection.Input;
            P5.Value = oMain.BusinessTaxId;
            //
            System.Data.SqlClient.SqlParameter P6 = sqlCmd.Parameters.Add("@BusinessTradeName", SqlDbType.VarChar);
            P6.Direction = ParameterDirection.Input;
            P6.Value = oMain.BusinessTradeName;
            //
            System.Data.SqlClient.SqlParameter P7 = sqlCmd.Parameters.Add("@DateAppSubmitted", SqlDbType.VarChar);
            P7.Direction = ParameterDirection.Input;
            P7.Value = oMain.DateAppSubmitted;
            //
            System.Data.SqlClient.SqlParameter P8 = sqlCmd.Parameters.Add("@LicenseBusiness", SqlDbType.VarChar);
            P8.Direction = ParameterDirection.Input;
            P8.Value = oMain.LicenseBusiness;
            //
            System.Data.SqlClient.SqlParameter P9 = sqlCmd.Parameters.Add("@SubmittedBy", SqlDbType.VarChar);
            P9.Direction = ParameterDirection.Input;
            P9.Value = oMain.SubmittedBy;
            //
            System.Data.SqlClient.SqlParameter P10 = sqlCmd.Parameters.Add("@AddedBy", SqlDbType.VarChar);
            P10.Direction = ParameterDirection.Input;
            P10.Value = clsLogon.UserName;
            //'
            //Execute Stored Procedure
            //
            int intRowsAffected = sqlCmd.ExecuteNonQuery();
            //
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

