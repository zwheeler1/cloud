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
public class clsFees
{
    #region "Private Members"
    private string m_feeType;
	private static int m_FeeId;
    private float m_AmountPaid;
	private float m_fee;
	private string m_feeStatus;
	private string m_finalFee;
	private System.DateTime m_dateFeePaid;
	private string m_sequence;
	private string m_FeeDescription;
	private string m_message;
	private int m_sequenceValue;
	private string m_nextValue;
	private string m_connString;
	private string m_seqName;
	private DataSet m_retrieveFeeDataSet;
    #endregion

    
	#region "Connection Properties"
	    private SqlConnection sqlConn = new SqlConnection();
        private SqlCommand sqlCmd = new SqlCommand();
	#endregion
	
	private DataSet m_retreiveDataSet = new DataSet();
	//define the constructor
	public clsFees()
	{

	}

	public string FeeStatus {
		get { return m_feeStatus; }
		set { m_feeStatus = value; }
	}
	public static int FeeId {
		get { return m_FeeId; }
		set { m_FeeId = value; }
	}
	public float Fee {
		get { return m_fee; }
		set { m_fee = value; }
	}
	public float AmountPaid {
		get { return m_AmountPaid; }
		set { m_AmountPaid = value; }
	}
	public string FinalFee {
		get { return m_finalFee; }
		set { m_finalFee = value; }
	}
	public string FeeDescription {
		get { return m_FeeDescription; }
		set { m_FeeDescription = value; }
	}
	public System.DateTime FeePaidDate()
	{
		m_dateFeePaid = DateTime.Now;
		return m_dateFeePaid;
	}

    #region "Public Method"

    public Boolean UpdateFee(clsFees oFees)
	{
		//Dim oMain As New clsMain
		clsLogon oLogon = new clsLogon();

		if (sqlConn.State == ConnectionState.Open) {
			sqlConn.Close();
		}
		sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
		sqlConn.Open();

		sqlCmd.Connection = sqlConn;
		sqlCmd.CommandText = "usp_AddFeePaidData";
		sqlCmd.CommandType = CommandType.StoredProcedure;
		//
		//***************************Define Deficiency Parameters**********************
		//

		try {
			System.Data.SqlClient.SqlParameter FeeId_Parameter = sqlCmd.Parameters.Add("@FeeId", SqlDbType.BigInt);
			FeeId_Parameter.Direction = ParameterDirection.Input;
			FeeId_Parameter.Value = clsFees.FeeId;
			//
            //System.Data.SqlClient.SqlParameter FeePaidDate_Parameter = sqlCmd.Parameters.Add("@FeePaidDate", SqlDbType.VarChar);
            //FeePaidDate_Parameter.Direction = ParameterDirection.Input;
            //FeePaidDate_Parameter.Value = oFees.FeePaidDate();
			//
			System.Data.SqlClient.SqlParameter FeeStatus_Parameter = sqlCmd.Parameters.Add("@FeeStatus", SqlDbType.VarChar);
			FeeStatus_Parameter.Direction = ParameterDirection.Input;
			FeeStatus_Parameter.Value = oFees.FeeStatus;
			//
            //System.Data.SqlClient.SqlParameter AmountPaid_Parameter = sqlCmd.Parameters.Add("@AmountPaid", SqlDbType.Decimal);
            //AmountPaid_Parameter.Direction = ParameterDirection.Input;
            //AmountPaid_Parameter.Value = oFees.AmountPaid;
			//
			System.Data.SqlClient.SqlParameter AddedBy_Parameter = sqlCmd.Parameters.Add("@AddedBy", SqlDbType.VarChar);
			AddedBy_Parameter.Direction = ParameterDirection.Input;
			AddedBy_Parameter.Value = clsLogon.UserName;
			//'
			//Execute Stored Procedure
			//
			int intRowsAffected = sqlCmd.ExecuteNonQuery();
			//
			return true;
		//Return the Id or AppNumber from the database
		} catch (Exception ex) {
			clsErrors oError = new clsErrors();
			clsMain oMain = new clsMain();
			oError.AppNumber = clsMain.AppNumber;
			oError.ErrorMessage = ex.Message;
			oError.ErrorSource = ex.Source;
			oError.ErrorStackTrace = ex.StackTrace.ToString();
			oError.LogErrors(oError);
			return false;
		} finally {
			sqlConn.Close();
			sqlCmd.Parameters.Clear();
			if ((sqlCmd != null)) {
				sqlCmd.Dispose();
			}
		}
	}

    public DataSet GetFees(string sqlSearch)
    {
        System.Data.DataSet dsFees = new System.Data.DataSet();
        clsMain oMain = new clsMain();
        // Create Search String
        // define the cache object
        // 

        //sqlSearch = "Select distinct StreetName from TBL_LKUP_STREETNAME order by StreetName";
        if ((sqlConn.State == System.Data.ConnectionState.Open))
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        // 
        try
        {
            sqlConn.Open();
            // Create a Data Adapter
            SqlDataAdapter daFees = new SqlDataAdapter(sqlSearch, sqlConn);
            // Fill the Data Set
            daFees.Fill(dsFees, "TBL_FEES");
            // 

            return dsFees;
        }
        catch (Exception ex)
        {
            clsErrors oError = new clsErrors();
            oError.AppNumber = 0;
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace;
            oError.LogErrors(oError);
            return dsFees;
        }
        finally
        {
            sqlConn.Close();
            sqlCmd.Dispose();
        }

    }

	public bool AddFee(clsFees oFee)
	{
		//
		clsMain oMain = new clsMain();
		clsLogon oLogon = new clsLogon();
		//Actually Here we simply pass the data to the web service and the 
		//web service will call the function

		if (sqlConn.State == ConnectionState.Open) {
			sqlConn.Close();
		}
		sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
		sqlConn.Open();

		sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_AddFeeData";
		sqlCmd.CommandType = CommandType.StoredProcedure;
		//
		//***************************Define Deficiency Parameters**********************
		//
		try {
			//TODO: Add return value
			//
			System.Data.SqlClient.SqlParameter seq_next_value_Parameter = sqlCmd.Parameters.Add("Return_Value", SqlDbType.BigInt);
			seq_next_value_Parameter.Direction = ParameterDirection.ReturnValue;
			//
			System.Data.SqlClient.SqlParameter P1 = sqlCmd.Parameters.Add("@AppNumber", SqlDbType.BigInt);
            P1.Direction = ParameterDirection.Input;
            P1.Value = clsMain.AppNumber;

			System.Data.SqlClient.SqlParameter P2 = sqlCmd.Parameters.Add("@FeeDescription", SqlDbType.VarChar);
            P2.Direction = ParameterDirection.Input;
            P2.Value = oFee.FeeDescription;
			//
			System.Data.SqlClient.SqlParameter P3 = sqlCmd.Parameters.Add("@FeeAmount", SqlDbType.Decimal);
            P3.Direction = ParameterDirection.Input;
            P3.Value = oFee.Fee;
			//s
			System.Data.SqlClient.SqlParameter AddedBy_Parameter = sqlCmd.Parameters.Add("@AddedBy", SqlDbType.VarChar);
			AddedBy_Parameter.Direction = ParameterDirection.Input;
            AddedBy_Parameter.Value = "zwheeler";//clsLogon.UserName;
			//
			//Execute Stored Procedure
			//
			int intRowsAffected = sqlCmd.ExecuteNonQuery();
			clsFees.FeeId = (int)seq_next_value_Parameter.Value;
			//
			sqlCmd.Parameters.Clear();
			//
			return true;
		//Return the Id or AppNumber from the database
		} catch (Exception ex) {
			clsErrors oError = new clsErrors();
			oError.AppNumber = clsMain.AppNumber;
			oError.ErrorMessage = ex.Message;
			oError.ErrorSource = ex.Source;
			oError.ErrorStackTrace = ex.StackTrace.ToString();
			oError.LogErrors(oError);
			return false;

		} finally {
			sqlConn.Close();
			sqlCmd.Parameters.Clear();
			if ((sqlCmd != null)) {
				sqlCmd.Dispose();
			}
		}
	}

	public bool DeleteFees(int intFeeId, int intAppnumber)
	{

		string strDelete = null;
		clsLogon oLogon = new clsLogon();
		//

		if (sqlConn.State == ConnectionState.Open) {
			sqlConn.Close();
		}
		sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
		sqlConn.Open();
		SqlCommand sqlCmd = new SqlCommand();

		try {
			//
			//Delete row from fee table
			sqlCmd.Connection = sqlConn;
			strDelete = "delete from tbl_fees where id = " + intFeeId + " and appnumber =" + intAppnumber;
			//Create Command Object
			sqlCmd.CommandText = strDelete;
			sqlCmd.CommandType = CommandType.Text;
			sqlCmd.Connection = sqlConn;
			//execute command
			int intRowsAffected1d = sqlCmd.ExecuteNonQuery();
			//
			m_message = "Fee Deleted Successfully";
			return true;


		} catch (Exception ex) {
			clsErrors oError = new clsErrors();
            string strEx = ex.Message;
			// oError.LogErrors(ex.Message, ex.Source, ex.StackTrace.ToString, clsLogon.UserName, intAppnumber)
			return false;
		} finally {
			sqlConn.Close();
		}

	}

	public bool DeleteFeePayment(int intFeeId)
	{

		string strDelete = null;
		clsLogon oLogon = new clsLogon();
		//

		if (sqlConn.State == ConnectionState.Open) {
			sqlConn.Close();
		}
		sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
		sqlConn.Open();
		SqlCommand sqlCmd = new SqlCommand();

		try {
			//
			//Delete row from fee table
			sqlCmd.Connection = sqlConn;
			strDelete = "delete from TBL_FEEPAYMENT where FeePaymentId = " + intFeeId;
			//Create Command Object
			sqlCmd.CommandText = strDelete;
			sqlCmd.CommandType = CommandType.Text;
			sqlCmd.Connection = sqlConn;
			//execute command
			int intRowsAffected1d = sqlCmd.ExecuteNonQuery();
			//

			return true;


		} catch (Exception ex) {
			clsErrors oError = new clsErrors();
			// oError.LogErrors(ex.Message, ex.Source, ex.StackTrace.ToString, clsLogon.UserName, intAppnumber)
			return false;
		} finally {
			sqlConn.Close();
		}

    }

    #endregion
}
