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


public class clsContact
{
    #region "Connection Properties"
    private System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection();
    private System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
    #endregion
    //
    #region "Private Members"
    private static int m_ContactId;
    private static string m_ContactName;
    private string m_ContactFName;
    private string m_ContactLName;
    private string m_ContactStNo;
    private string m_ContactStName;
    private string m_ContactStType;
    private string m_ContactStQuad;
    private string m_ContactCity;
    private string m_ContactState;
    private string m_ContactZip;
    private string m_ContactPhone;
    private string m_ContactEMail;
    private string m_ContactType;
    private string m_AddedBy;
    private string m_ContactCompanyName;
    private string m_Current_Record;
    #endregion

    #region "Public Properties"

    public static int ContactID
    {
        get { return m_ContactId; }
        set { m_ContactId = value; }
    }
    public static string ContactName
    {
        get { return m_ContactName; }
        set { m_ContactName = value; }
    }

    public string ContactFName
    {
        get { return m_ContactFName; }
        set { m_ContactFName = value.ToUpper().Trim(); }
    }
    public string ContactLName
    {
        //walk thru/filejob
        get { return m_ContactLName; }
        set { m_ContactLName = value.ToUpper().Trim(); }
    }
    public string ContactStNo
    {
        get { return m_ContactStNo; }
        set { m_ContactStNo = value.ToUpper().Trim(); }
    }
    public string ContactStName
    {
        get { return m_ContactStName; }
        set { m_ContactStName = value; }
    }
    public string ContactStType
    {
        get { return m_ContactStType; }
        set { m_ContactStType = value; }
    }
    public string ContactStQuad
    {
        get { return m_ContactStQuad; }
        set { m_ContactStQuad = value; }
    }

    public string ContactCity
    {
        get { return m_ContactCity; }
        set { m_ContactCity = value.ToUpper().Trim(); }
    }

    public string ContactState
    {
        get { return m_ContactState; }
        set { m_ContactState = value.ToUpper().Trim(); }
    }
    public string ContactZip
    {
        get { return m_ContactZip; }
        set { m_ContactZip = value.ToUpper().Trim(); }
    }

    public string ContactPhone
    {
        get { return m_ContactPhone; }
        set { m_ContactPhone = value.ToUpper().Trim(); }
    }
    public string ContactEMail
    {
        get { return m_ContactEMail; }
        set { m_ContactEMail = value; }
    }
    //Contactcompanyname
    public string ContactType
    {
        get { return m_ContactType; }
        set { m_ContactType = value; }
    }
    public string ADDEDBY
    {
        get { return m_AddedBy; }
        set { m_AddedBy = value.ToUpper().Trim(); }
    }
    #endregion

    #region "Public Methods"

    public bool Add_ContactData(clsContact oContactData)
    {
        clsMain oMain = new clsMain();
        clsLogon oLogon = new clsLogon();
        //Actually Here we simply pass the data to the web service and the 
        //web service will call the function

        if (sqlConn.State == System.Data.ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_AddContactData";
        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
           
            SqlParameter seq_next_value_Parameter = sqlCmd.Parameters.Add("Return_Value", System.Data.SqlDbType.BigInt);
            seq_next_value_Parameter.Direction = System.Data.ParameterDirection.ReturnValue;
            //
            SqlParameter P0 = sqlCmd.Parameters.Add("@AppNumber", System.Data.SqlDbType.VarChar);
            P0.Direction = System.Data.ParameterDirection.Input;
            P0.Value = clsMain.AppNumber;
            //
            SqlParameter P1 = sqlCmd.Parameters.Add("@ContactFName", System.Data.SqlDbType.VarChar);
            P1.Direction = System.Data.ParameterDirection.Input;
            P1.Value = oContactData.ContactFName;
            //
            SqlParameter P2 = sqlCmd.Parameters.Add("@ContactLName", System.Data.SqlDbType.VarChar);
            P2.Direction = System.Data.ParameterDirection.Input;
            P2.Value = oContactData.ContactLName;
            //
            SqlParameter P3 = sqlCmd.Parameters.Add("@ContactStNo", System.Data.SqlDbType.VarChar);
            P3.Direction = System.Data.ParameterDirection.Input;
            P3.Value = oContactData.ContactStNo;
            //
            SqlParameter P4 = sqlCmd.Parameters.Add("@ContactStName", System.Data.SqlDbType.VarChar);
            P4.Direction = System.Data.ParameterDirection.Input;
            P4.Value = oContactData.ContactStName;
            //
            SqlParameter P5 = sqlCmd.Parameters.Add("@ContactStType", System.Data.SqlDbType.VarChar);
            P5.Direction = System.Data.ParameterDirection.Input;
            P5.Value = oContactData.ContactStType;
            //
            SqlParameter P6 = sqlCmd.Parameters.Add("@@ContactSTQUAD", System.Data.SqlDbType.VarChar);
            P6.Direction = System.Data.ParameterDirection.Input;
            P6.Value = oContactData.ContactStQuad;
            //
            SqlParameter P7 = sqlCmd.Parameters.Add("@ContactCity", System.Data.SqlDbType.VarChar);
            P7.Direction = System.Data.ParameterDirection.Input;
            P7.Value = oContactData.ContactCity;
            //
            SqlParameter P8 = sqlCmd.Parameters.Add("@ContactState", System.Data.SqlDbType.VarChar);
            P8.Direction = System.Data.ParameterDirection.Input;
            P8.Value = oContactData.ContactState;
            //'
            SqlParameter P9 = sqlCmd.Parameters.Add("@ContactZip", System.Data.SqlDbType.VarChar);
            P9.Direction = System.Data.ParameterDirection.Input;
            P9.Value = oContactData.ContactZip;
            //
            SqlParameter P10 = sqlCmd.Parameters.Add("@ContactEMail", System.Data.SqlDbType.VarChar);
            P10.Direction = System.Data.ParameterDirection.Input;
            P10.Value = oContactData.ContactEMail;
            //
            SqlParameter P11 = sqlCmd.Parameters.Add("@ContactPhone", System.Data.SqlDbType.VarChar);
            P11.Direction = System.Data.ParameterDirection.Input;
            P11.Value = oContactData.ContactPhone;
            //
            SqlParameter P12 = sqlCmd.Parameters.Add("@ContactType", System.Data.SqlDbType.VarChar);
            P12.Direction = System.Data.ParameterDirection.Input;
            P12.Value = oContactData.ContactType;
            //
            System.Data.SqlClient.SqlParameter AddedBy = sqlCmd.Parameters.Add("@AddedBy", SqlDbType.VarChar);
            AddedBy.Direction = ParameterDirection.Input;
            AddedBy.Value = clsLogon.UserName;
            //Execute Stored Procedure
            //
            int intRowsAffected = sqlCmd.ExecuteNonQuery();
            //clsContact.ContactID

            clsContact.ContactID = (int)seq_next_value_Parameter.Value;
            clsContact.ContactName = clsContact.ContactID + " - " + oContactData.ContactFName + " " + oContactData.ContactLName;
            //Add relational table
            //Clear parameters
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



    public bool update_ContactData(clsContact oContactData)
    {
        clsMain oMain = new clsMain();
        clsLogon oLogon = new clsLogon();
        //Actually Here we simply pass the data to the web service and the 
        //web service will call the function

        if (sqlConn.State == System.Data.ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_UpdateContactData";
        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {

            SqlParameter seq_next_value_Parameter = sqlCmd.Parameters.Add("Return_Value", System.Data.SqlDbType.BigInt);
            seq_next_value_Parameter.Direction = System.Data.ParameterDirection.ReturnValue;
            //
            SqlParameter P = sqlCmd.Parameters.Add("@OldContactId", System.Data.SqlDbType.BigInt);
            P.Direction = System.Data.ParameterDirection.Input;
            P.Value = clsMain.AppNumber;
            //
            SqlParameter P0 = sqlCmd.Parameters.Add("@AppNumber", System.Data.SqlDbType.VarChar);
            P0.Direction = System.Data.ParameterDirection.Input;
            P0.Value = clsMain.AppNumber;
            //
            SqlParameter P1 = sqlCmd.Parameters.Add("@ContactFName", System.Data.SqlDbType.VarChar);
            P1.Direction = System.Data.ParameterDirection.Input;
            P1.Value = oContactData.ContactFName;
            //
            SqlParameter P2 = sqlCmd.Parameters.Add("@ContactLName", System.Data.SqlDbType.VarChar);
            P2.Direction = System.Data.ParameterDirection.Input;
            P2.Value = oContactData.ContactLName;
            //
            SqlParameter P3 = sqlCmd.Parameters.Add("@ContactStNo", System.Data.SqlDbType.VarChar);
            P3.Direction = System.Data.ParameterDirection.Input;
            P3.Value = oContactData.ContactStNo;
            //
            SqlParameter P4 = sqlCmd.Parameters.Add("@ContactStName", System.Data.SqlDbType.VarChar);
            P4.Direction = System.Data.ParameterDirection.Input;
            P4.Value = oContactData.ContactStName;
            //
            SqlParameter P5 = sqlCmd.Parameters.Add("@ContactStType", System.Data.SqlDbType.VarChar);
            P5.Direction = System.Data.ParameterDirection.Input;
            P5.Value = oContactData.ContactStType;
            //
            SqlParameter P6 = sqlCmd.Parameters.Add("@@ContactSTQUAD", System.Data.SqlDbType.VarChar);
            P6.Direction = System.Data.ParameterDirection.Input;
            P6.Value = oContactData.ContactStQuad;
            //
            SqlParameter P7 = sqlCmd.Parameters.Add("@ContactCity", System.Data.SqlDbType.VarChar);
            P7.Direction = System.Data.ParameterDirection.Input;
            P7.Value = oContactData.ContactCity;
            //
            SqlParameter P8 = sqlCmd.Parameters.Add("@ContactState", System.Data.SqlDbType.VarChar);
            P8.Direction = System.Data.ParameterDirection.Input;
            P8.Value = oContactData.ContactState;
            //'
            SqlParameter P9 = sqlCmd.Parameters.Add("@ContactZip", System.Data.SqlDbType.VarChar);
            P9.Direction = System.Data.ParameterDirection.Input;
            P9.Value = oContactData.ContactZip;
            //
            SqlParameter P10 = sqlCmd.Parameters.Add("@ContactEMail", System.Data.SqlDbType.VarChar);
            P10.Direction = System.Data.ParameterDirection.Input;
            P10.Value = oContactData.ContactEMail;
            //
            SqlParameter P11 = sqlCmd.Parameters.Add("@ContactPhone", System.Data.SqlDbType.VarChar);
            P11.Direction = System.Data.ParameterDirection.Input;
            P11.Value = oContactData.ContactPhone;
            //
            SqlParameter P12 = sqlCmd.Parameters.Add("@ContactType", System.Data.SqlDbType.VarChar);
            P12.Direction = System.Data.ParameterDirection.Input;
            P12.Value = oContactData.ContactType;
            //
            System.Data.SqlClient.SqlParameter AddedBy = sqlCmd.Parameters.Add("@AddedBy", SqlDbType.VarChar);
            AddedBy.Direction = ParameterDirection.Input;
            AddedBy.Value = clsLogon.UserName;
            //Execute Stored Procedure
            //
            int intRowsAffected = sqlCmd.ExecuteNonQuery();
            //clsContact.ContactID

            clsContact.ContactID = (int)seq_next_value_Parameter.Value;
            clsContact.ContactName = clsContact.ContactID + " - " + oContactData.ContactFName + " " + oContactData.ContactLName;
            //Add relational table
            //Clear parameters
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
   
#endregion

}


