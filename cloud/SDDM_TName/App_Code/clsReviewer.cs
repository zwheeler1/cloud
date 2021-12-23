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
/// Summary description for clsReviewer
/// </summary>
public class clsReviewer
{
  
  #region "Connection Properties"
        private System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection();
        private System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
    #endregion
    //
#region "private Member Variables"

    private static int m_id ;
    private static int  m_UBound ;
    private static int m_ReviewId;
    private int m_ReviewId1 ;
    private string m_Reviewer ;
    private string m_ReviewType;
    private string m_PermitRestrictions ;
    private string  m_ReviewStatus ;
    private string m_ReviewComments ;
    private string m_ReviewBegin ;
    private string m_ReviewEnd ;
    private string m_InitialReview ;
    private string m_ItemNumber ;
    private string m_Code ;

#endregion

#region "Public Propeties"

    public static int Id
    {
        get 
        { return m_id;}
       
        set {m_id = value;}
   }



    public string ItemNumber
    {
        get {
           return (m_ItemNumber);
       }
       set {
            m_ItemNumber = value;
       }
   }

    public string Code  
    {
        get {
           return (m_Code);
       }
       set {
            m_Code = value;
       }
   }
   // public static UBound  {
   //     get {
   //        return (m_UBound)
   //    }
   //    set {
   //         m_UBound = value;
   //    }
   //}
    
    public string ReviewStatus  
    {
        get {
           return (m_ReviewStatus);
       }
       set {
            m_ReviewStatus = value;
       }
   }

    public string Reviewer 
    {
        get {
           return (m_Reviewer);
       }
       set {
            m_Reviewer = value;
       }
   }

    public string ReviewerComments 
    {
        get {
           return (m_ReviewComments);
       }
       set {
            m_ReviewComments = value;
       }
   }

    public string ReviewType
    {
        get 
        {
           return m_ReviewType;
       }
       set {
            
            m_ReviewType = value.ToUpper();
       }
   }
   
//public string PermitRestrictions(ByVal index As Integer) As String
//        get {
//           return m_PermitRestrictions(index)
//       }
//       set {
//            ReDim Preserve m_PermitRestrictions(index)
//            m_PermitRestrictions(index) = value.ToUpper
//            index = index + 1
//       }
//   }

    public int ReviewId1  
    {
        get {
           return m_ReviewId1;
       }
       set {
            m_ReviewId1 = value;
       }
   }
    public static int ReviewId  
    {
        get {
           return (m_ReviewId);
       }
       set {
            m_ReviewId = value;
       }
   }

    public string ReviewBeginDate  {
        get {
           return (m_ReviewBegin);
       }
       set {
            m_ReviewBegin = value;
       }
   }
    public string InitialReview  {
        get {
           return (m_InitialReview);
       }
       set {
            m_InitialReview = value;
       }
   }
    public string ReviewEndDate  {
        get {
           return (m_ReviewEnd);
       }
       set {
            m_ReviewEnd = value;
       }
   }
#endregion

    #region "public Method"

    public DataSet GetDataSet(string sqlSearch)
    {
        System.Data.DataSet ds = new System.Data.DataSet();
        clsMain oMain = new clsMain();
        // Create Search String
        // define the cache object
        //
        if (sqlConn.State == System.Data.ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        // 
        try
        {
            sqlConn.Open();
            // Create a Data Adapter
            SqlDataAdapter da = new SqlDataAdapter(sqlSearch, sqlConn);
            // Fill the Dataset {
            da.Fill(ds, "TBL_DATA");
            // 
           return ds;
        }
        catch (Exception ex)
        {
            clsErrors oError = new clsErrors();
            oError.AppNumber = clsMain.AppNumber;
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.LogErrors(oError);
            return ds;
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



    
    protected bool Generate_Reviews(clsReviewer oReview) 
        {
        
        //dim oEmail as New email //TODO add functionality
        if (sqlConn.State == System.Data.ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_AddReviewData";
        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

        //
        //***************************Define Review Parameters**********************
        //
        try
           // = sqlCmd.Parameters.Add("@AppNumber", System.System.Data.SqlDbType.VarChar);
        {
                SqlParameter  AppNumber_Parameter = sqlCmd.Parameters.Add("@AppNumber", System.Data.SqlDbType.BigInt);
                AppNumber_Parameter.Direction = System.Data.ParameterDirection.Input;
                AppNumber_Parameter.Value = clsMain.AppNumber;
                //
                SqlParameter  ReviewType_Parameter = sqlCmd.Parameters.Add("@ReviewType", System.Data.SqlDbType.VarChar);
                ReviewType_Parameter.Direction = System.Data.ParameterDirection.Input;
                ReviewType_Parameter.Value = oReview.ReviewType;
                //
                SqlParameter  ReviewStatus_Parameter = sqlCmd.Parameters.Add("@ReviewStatus", System.Data.SqlDbType.VarChar);
                ReviewStatus_Parameter.Direction = System.Data.ParameterDirection.Input;
                ReviewStatus_Parameter.Value = oReview.ReviewStatus;
                //
                SqlParameter  InitialReview_Parameter = sqlCmd.Parameters.Add("@InitialReview", System.Data.SqlDbType.VarChar);
                InitialReview_Parameter.Direction = System.Data.ParameterDirection.Input;
                InitialReview_Parameter.Value = oReview.InitialReview;
                //
                SqlParameter  AddedBy_Parameter =  sqlCmd.Parameters.Add("@AddedBy", System.Data.SqlDbType.VarChar);
                AddedBy_Parameter.Direction = System.Data.ParameterDirection.Input;
                AddedBy_Parameter.Value = clsLogon.UserName;
                //
                //Execute Stored Procedure
                //
                int intRowsAffected  = sqlCmd.ExecuteNonQuery();
                //
                sqlCmd.Parameters.Clear();
            //
           return true;
            //Return the Id or AppNumber from the database
        }
        catch (Exception ex)
        {
            clsErrors oError = new clsErrors();
            oError.AppNumber = 0;
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace;
            oError.LogErrors(oError);
           return false;
        }
        finally 
        {   sqlConn.Close();
            sqlCmd.Parameters.Clear();
            if ((sqlCmd != null))
            {
                sqlCmd.Dispose();
            }
        }
}

    public bool AddReview(clsReviewer oReview)
{
        
        if (sqlConn.State == System.Data.ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_AddReview";
        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
        //
        //***************************Define Review Parameters**********************
        //
        try
        {
            ////
            SqlParameter seq_next_value_Parameter =  sqlCmd.Parameters.Add("Return_Value", System.Data.SqlDbType.BigInt);
            seq_next_value_Parameter.Direction = System.Data.ParameterDirection.ReturnValue;
            //
            SqlParameter  P0 = sqlCmd.Parameters.Add("@AppNumber", System.Data.SqlDbType.BigInt);
            P0.Direction = System.Data.ParameterDirection.Input;
            P0.Value = clsMain.AppNumber;
            //
            SqlParameter P1 = sqlCmd.Parameters.Add("@Reviewer", System.Data.SqlDbType.VarChar);
            P1.Direction = System.Data.ParameterDirection.Input;
            P1.Value = oReview.Reviewer;
            //
            SqlParameter P2 = sqlCmd.Parameters.Add("@ReviewType", System.Data.SqlDbType.VarChar);
            P2.Direction = System.Data.ParameterDirection.Input;
            P2.Value = oReview.ReviewType;
            //
            SqlParameter P3 = sqlCmd.Parameters.Add("@ReviewStatus", System.Data.SqlDbType.VarChar);
            P3.Direction = System.Data.ParameterDirection.Input;
            P3.Value = oReview.ReviewStatus;
            //
            SqlParameter P4 = sqlCmd.Parameters.Add("@DATEREVIEWBEGINS", System.Data.SqlDbType.VarChar);
            P4.Direction = System.Data.ParameterDirection.Input;
            P4.Value = oReview.ReviewBeginDate;
            //
            //
            SqlParameter P5 = sqlCmd.Parameters.Add("@DATEREVIEWENDS", System.Data.SqlDbType.VarChar);
            P5.Direction = System.Data.ParameterDirection.Input;
            P5.Value = oReview.ReviewBeginDate;
            //
            SqlParameter  AddedBy_Parameter = 
            sqlCmd.Parameters.Add("@AddedBy", System.Data.SqlDbType.VarChar);
            AddedBy_Parameter.Direction = System.Data.ParameterDirection.Input;
            AddedBy_Parameter.Value = clsLogon.UserName;
            //
            //Execute Stored Procedure

            int intRowsAffected  = sqlCmd.ExecuteNonQuery();

            clsReviewer.ReviewId = (int)seq_next_value_Parameter.Value;
            //
            sqlCmd.Parameters.Clear();
           

          return true;
        }
        catch (Exception ex)
        {
            clsErrors oError = new clsErrors();
            oError.AppNumber = 0;
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace;
            oError.LogErrors(oError);
           return true;
        }

        finally 
        {   sqlConn.Close();
            sqlCmd.Parameters.Clear();
            if ((sqlCmd != null))
            {
                sqlCmd.Dispose();
            }
        }
}


    protected bool Update_Review(clsReviewer oReview)
    {

        if (sqlConn.State == System.Data.ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_UpdateReviewData";
        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
        //
        //***************************Define Review Parameters**********************
        //
        try
        {
         
            ////
            SqlParameter seq_next_value_Parameter =  sqlCmd.Parameters.Add("Return_Value", System.Data.SqlDbType.BigInt);
            seq_next_value_Parameter.Direction = System.Data.ParameterDirection.ReturnValue;
            //
            SqlParameter  P0 = sqlCmd.Parameters.Add("@AppNumber", System.Data.SqlDbType.BigInt);
            P0.Direction = System.Data.ParameterDirection.Input;
            P0.Value = clsMain.AppNumber;
            //
            SqlParameter P1 = sqlCmd.Parameters.Add("@Reviewer", System.Data.SqlDbType.VarChar);
            P1.Direction = System.Data.ParameterDirection.Input;
            P1.Value = oReview.Reviewer;
            //
            SqlParameter P2 = sqlCmd.Parameters.Add("@ReviewType", System.Data.SqlDbType.VarChar);
            P2.Direction = System.Data.ParameterDirection.Input;
            P2.Value = oReview.ReviewType;
            //
            SqlParameter P3 = sqlCmd.Parameters.Add("@ReviewStatus", System.Data.SqlDbType.VarChar);
            P3.Direction = System.Data.ParameterDirection.Input;
            P3.Value = oReview.ReviewStatus;
            //
            SqlParameter P4 = sqlCmd.Parameters.Add("@DATEREVIEWBEGINS", System.Data.SqlDbType.VarChar);
            P4.Direction = System.Data.ParameterDirection.Input;
            P4.Value = oReview.ReviewBeginDate;
            //
            //
            SqlParameter P5 = sqlCmd.Parameters.Add("@DATEREVIEWENDS", System.Data.SqlDbType.VarChar);
            P5.Direction = System.Data.ParameterDirection.Input;
            P5.Value = oReview.ReviewBeginDate;
            //
            SqlParameter  AddedBy_Parameter = 
            sqlCmd.Parameters.Add("@AddedBy", System.Data.SqlDbType.VarChar);
            AddedBy_Parameter.Direction = System.Data.ParameterDirection.Input;
            AddedBy_Parameter.Value = clsLogon.UserName;
            //
            //Execute Stored Procedure

            int intRowsAffected  = sqlCmd.ExecuteNonQuery();

            //clsReviewer.ReviewId = (int)seq_next_value_Parameter.Value;
            //
            sqlCmd.Parameters.Clear();
           

          return true;
        }
        catch (Exception ex)
        {
            clsErrors oError = new clsErrors();
            oError.AppNumber = 0;
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace;
            oError.LogErrors(oError);
            return true;
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


    public bool AddReviewerComments(clsReviewer oReview)
    {

        if (sqlConn.State == System.Data.ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_AddReviewerComments";
        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
        //
        //***************************Define Review Parameters**********************
        //
        try
        {
            ////
            SqlParameter seq_next_value_Parameter = sqlCmd.Parameters.Add("Return_Value", System.Data.SqlDbType.BigInt);
            seq_next_value_Parameter.Direction = System.Data.ParameterDirection.ReturnValue;
            //
            SqlParameter P0 = sqlCmd.Parameters.Add("@ReviewId", System.Data.SqlDbType.VarChar);
            P0.Direction = System.Data.ParameterDirection.Input;
            P0.Value = clsReviewer.ReviewId;
            //
            SqlParameter P1 = sqlCmd.Parameters.Add("@AppNumber", System.Data.SqlDbType.BigInt);
            P1.Direction = System.Data.ParameterDirection.Input;
            P1.Value = clsMain.AppNumber;
            //
            SqlParameter P2 = sqlCmd.Parameters.Add("@Comments", System.Data.SqlDbType.VarChar);
            P2.Direction = System.Data.ParameterDirection.Input;
            P2.Value = oReview.ReviewerComments;
            //

            SqlParameter AddedBy_Parameter =
            sqlCmd.Parameters.Add("@AddedBy", System.Data.SqlDbType.VarChar);
            AddedBy_Parameter.Direction = System.Data.ParameterDirection.Input;
            AddedBy_Parameter.Value = clsLogon.UserName;
            //
            //Execute Stored Procedure

            int intRowsAffected = sqlCmd.ExecuteNonQuery();

            //clsReviewer.ReviewId = (int)seq_next_value_Parameter.Value;
            //
            sqlCmd.Parameters.Clear();


            return true;
        }
        catch (Exception ex)
        {
            clsErrors oError = new clsErrors();
            oError.AppNumber = 0;
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace;
            oError.LogErrors(oError);
            return true;
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
