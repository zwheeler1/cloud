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


public class clsErrors
    {
        #region Connection Properties
            SqlConnection sqlConn = new SqlConnection();
            SqlCommand sqlCmd = new SqlCommand();
        #endregion

        #region Private Members

        private string m_ErrorSource;
        private string m_ErrorMessage;
        private string m_ErrorStackTrace;
        private int m_AppNumber;
        private string m_ErrorResolvedDate;
        private string m_ErrorResolution;
        private string m_MethodName;

        #endregion

        #region Public Properties

        public string MethodName
        {
            get
            {
                return this.m_MethodName;
            }
            set
            {
                this.m_MethodName = value;
            }
        }

        public string ErrorSource
        {
            get { return this.m_ErrorSource; }
            set { this.m_ErrorSource = value; }
        }
        public string ErrorMessage
        {
            get { return this.m_ErrorMessage; }
            set { this.m_ErrorMessage = value; }
        }
        public string ErrorStackTrace
        {
            get { return this.m_ErrorStackTrace; }
            set { this.m_ErrorStackTrace = value; }
        }
        public int AppNumber
        {
            get { return this.m_AppNumber; }
            set { this.m_AppNumber = value; }
        }
        public string ErrorResolvedDate
        {
            get { return this.m_ErrorResolvedDate; }
            set { this.m_ErrorResolvedDate = value; }

        }
        public string ErrorResolution
        {
            get { return this.ErrorResolution; }
            set { this.ErrorResolution = value; }
        }

        #endregion

        #region Public Methods

        public void LogErrors(clsErrors  oErrors)
        {

            if (sqlConn.State == ConnectionState.Open)
            {
                sqlConn.Close();
            }


            sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
            sqlConn.Open();
            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = "usp_AddError";
            sqlCmd.CommandType = CommandType.StoredProcedure;

            //***************************Define Parameters**********************

            try
            {
                SqlParameter P0 = new SqlParameter();
                sqlCmd.Parameters.AddWithValue("@AppNumber", SqlDbType.BigInt);
                P0.Direction = ParameterDirection.Input;
                P0.Value = oErrors.AppNumber;
                //
                SqlParameter P1 = new SqlParameter();
                sqlCmd.Parameters.AddWithValue("@ErrorSource", SqlDbType.VarChar);
                P1.Direction = ParameterDirection.Input;
                P1.Value = oErrors.ErrorSource;
                //
                SqlParameter P2 = new SqlParameter();
                sqlCmd.Parameters.Add("@ErrorMessage", SqlDbType.VarChar);
                P2.Direction = ParameterDirection.Input;
                P2.Value = oErrors.ErrorMessage;
                //
                SqlParameter P3 = new SqlParameter();
                sqlCmd.Parameters.Add("@ErrorStackTrace", SqlDbType.VarChar);
                P3.Direction = ParameterDirection.Input;
                P3.Value = oErrors.ErrorStackTrace;
                //
                SqlParameter P4 = new SqlParameter();
                sqlCmd.Parameters.Add("@ERRMETHOD", SqlDbType.VarChar);
                P4.Direction = ParameterDirection.Input;
                P4.Value = oErrors.MethodName;
                //
                SqlParameter P5 = new SqlParameter();
                sqlCmd.Parameters.Add("@AddedBy", SqlDbType.VarChar);
                P5.Direction = ParameterDirection.Input;
                P5.Value = clsLogon.UserName;
                //Execute Stored Procedure and write to the database
                int intRowsAffected = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            finally { }

        }




        #endregion




















    }

