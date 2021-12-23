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
/// Summary description for clsDataAccess
/// </summary>
public class clsDataAccess
{
	public clsDataAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Connection Properties
       
            SqlConnection sqlConn = new SqlConnection();
            SqlCommand sqlCmd = new SqlCommand();
    #endregion

            #region Private Members
            DataSet ds = new DataSet();
            #endregion

            #region Public Methods
            
        public DataSet getDataSet(int intValue, string strStoredProcedureName)
          {
        
             
            if (sqlConn.State == ConnectionState.Open)
            {
                sqlConn.Close();
            }
            sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
            sqlConn.Open();
            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = strStoredProcedureName;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            clsMain.AppNumber = intValue;
          //
          try
          {
              SqlParameter P0 = sqlCmd.Parameters.Add("@AppNumber", System.Data.SqlDbType.VarChar);
              P0.Direction = System.Data.ParameterDirection.Input;
              P0.Value = intValue;
          //
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(ds,"tblDataSet");
            return ds;
          }
          catch (SqlException e)
          {
              string strMessage = e.Message;
              return ds;
          }
          finally
          {
          }
        }

        public DataSet getDataSet(string strValue,int intValue,int intKey)
        {


            if (sqlConn.State == ConnectionState.Open)
            {
                sqlConn.Close();
            }
            sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
            sqlConn.Open();
            sqlCmd.Connection = sqlConn;

            int intAppNumber = 0;

            switch (intValue)
            {
                case 1:
                    //Get using business name
                    sqlCmd.CommandText = "usp_GetMainDataByBName";
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    strValue = strValue + "%";
                    break;
                case 2:
                    //Get using trade name
                    sqlCmd.CommandText = "usp_GetMainDataByTName";
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    strValue = strValue + "%";
                    break;
                case 3:
                    //Get using Tax Id
                    sqlCmd.CommandText = "usp_GetMainDataByTaxId";
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    break;
                case 4:
                    //Get using AppNumber
                    sqlCmd.CommandText = "usp_GetMainDataByAppNumber";
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    intAppNumber = Int32.Parse(strValue);
                    clsMain.AppNumber = intAppNumber;
                     
                    break;
               
            }
            
           
            //
            try
            {
                if (intValue == 4)
                {

                    SqlParameter P0 = sqlCmd.Parameters.Add("@AppNumber", System.Data.SqlDbType.VarChar);
                    P0.Direction = System.Data.ParameterDirection.Input;
                    P0.Value = intAppNumber;
                    clsMain.AppNumber = intAppNumber;
                    
                }
                else
                {
                    SqlParameter P0 = sqlCmd.Parameters.Add("@ParameterValue", System.Data.SqlDbType.VarChar);
                    P0.Direction = System.Data.ParameterDirection.Input;
                    P0.Value = strValue;
                    
                }
                //
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(ds, "tbl_main");
                return ds;
            }
            catch (SqlException e)
            {
                string strMessage = e.Message;
                return ds;
            }
            finally
            {
            }
        }



        public DataSet getDataSet1(string strValue, int intValue, int intKey)
        {


            if (sqlConn.State == ConnectionState.Open)
            {
                sqlConn.Close();
            }
            sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
            sqlConn.Open();
            sqlCmd.Connection = sqlConn;

            int intAppNumber = 0;

                    //Get using AppNumber
                    sqlCmd.CommandText = "usp_GetMainDataByAppNumber";
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                   
                    intAppNumber = Int32.Parse(strValue);
                    clsMain.AppNumber = intAppNumber;
            //
            try
            {
                    
                    SqlParameter P0 = sqlCmd.Parameters.Add("@AppNumber", System.Data.SqlDbType.VarChar);
                    P0.Direction = System.Data.ParameterDirection.Input;
                    P0.Value = intAppNumber;

                 SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(ds, "tbl_main");
                return ds;
            }
           
            catch (SqlException e)
            {
                string strMessage = e.Message;
                return ds;
            }
            finally
            {
            }
        }

            //
     public DataSet getDataSet(string strSearch)
          {
        
             
            if (sqlConn.State == ConnectionState.Open)
            {
                sqlConn.Close();
            }
            sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
            sqlConn.Open();
            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = strSearch;
           sqlCmd.CommandType = CommandType.Text;
          //
          try
          {
         
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            da.Fill(ds,"tblDataSet");
            return ds;
          }
          catch (SqlException e)
          {
              return ds;
          }
          finally
          {
          }  
    }

     //
     public DataSet getDataSet(string sqlSearch, int intAppNumber)
     {
         string strSearch;

         strSearch = sqlSearch + intAppNumber;
         if (sqlConn.State == ConnectionState.Open)
         {
             sqlConn.Close();
         }
         sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
         sqlConn.Open();
         sqlCmd.Connection = sqlConn;
         sqlCmd.CommandText = strSearch;
         sqlCmd.CommandType = CommandType.Text;
         //
         try
         {

             SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
             da.Fill(ds, "tbl_main");
             return ds;
         }
         catch (SqlException e)
         {
             return ds;
         }
         finally
         {
         }


     }


            #endregion

}
           
       
    

