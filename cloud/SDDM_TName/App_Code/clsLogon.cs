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


    class clsLogon
    {

        #region Connection Properties

        SqlConnection sqlConn = new SqlConnection();
        SqlCommand sqlCmd = new SqlCommand();
        

        #endregion

        #region Private Methods

        private static string m_username ="zwheeler";
        private string m_password;
        private static string m_agency;
        private static string m_AccessRights;

        #endregion

        #region Public Properties
        public static string UserName
        {
            get { return m_username; }
            set { m_username = value; }
        }
        public string PassWord
        {
            get
            {
                return this.m_password;
            }

            set { this.m_password = value; }
        }
        public static string Agency
        {
            get { return m_agency; }
            set { m_agency = value; }
        }
        public static string AccessRights
        {
            get { return m_AccessRights; }
            set { m_AccessRights = value; }
        }
        #endregion

        #region Public Methods
        public bool ValidateUser(clsLogon oLogon)
        {

            bool intLogon = false;

            if (sqlConn.State == ConnectionState.Open)
            {
                sqlConn.Close();
            }

            sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
            try
            {

                sqlConn.Open();

                sqlCmd.CommandText = "select USERNAME,password,AccessRights from tblUsers_LkUp where USERNAME ='" + clsLogon.UserName + "'" + " and password = '" + oLogon.PassWord + "'";
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlConn;

                SqlDataReader drdr_Logon = sqlCmd.ExecuteReader();

                if (drdr_Logon.HasRows == true)
                {
                    while (drdr_Logon.Read())
                    {
                        clsLogon.AccessRights = drdr_Logon.GetValue(2).ToString();
                        intLogon = true;
                    }
                }
                else
                { intLogon = false; }
                return intLogon;
            }
            catch (SqlException e)
            {
                //Dim oError As New clsErrors
                //oError.AppNumber = 0
                //oError.ErrorMessage = ex.Message
                //oError.MethodName} = "Validate Users"
                //oError.ErrorSource = ex.Source
                //oError.ErrorStackTrace = ex.StackTrace.ToString
                //oError.LogErrors(oError)}
                return false;
            }
            finally { }
            //sqlConn.Close()
            //sqlCmd.Parameters.Clear()
            //If Not sqlCmd Is Nothing Then
            //    sqlCmd.Dispose()
            //End If


        }


        #endregion



    }

