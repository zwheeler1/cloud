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

public class clsData
{
    #region "Connection Properties"
    private System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection();
    private System.Data.SqlClient.SqlCommand sqlCMD = new System.Data.SqlClient.SqlCommand();
    #endregion
  
    #region "Private Members"
    //private  string m_fha_number
    //private  int m_property_id
    #endregion

    #region "Static Members"
    //private static int m_rating
    //private static bool m_ratingCalculated
    #endregion

    #region "Public Memebers"
    //private static string m_FirstYear
    //private static string m_LastYear
    #endregion


    #region "Public Properties"

    //public static int Rating 
    //       get  return m_rating 
    //       set  m_rating = value 


    //   public static bool RatingCalculated

    //       get  return m_ratingCalculated 
    //       set  m_ratingCalculated = value 

    #endregion



    #region "Public Functions"

    public DataSet GetList1(string sqlString)
    {
        DataSet dsDataSet = new DataSet();

        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }

        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCMD.Connection = sqlConn;
        sqlCMD.CommandText = sqlString;
        sqlCMD.CommandType = CommandType.Text;
        //
        //***************************Define Deficiency Parameters**********************
        //

        try
        {
            //
            SqlParameter getData_Parameter = new SqlParameter();
            getData_Parameter = sqlCMD.Parameters.Add("@sqlString", SqlDbType.VarChar);
            getData_Parameter.Direction = ParameterDirection.Input;
            getData_Parameter.Value = sqlString;
            //
            //Create a Data Adapter
            SqlDataAdapter da = new SqlDataAdapter(sqlCMD);
            //Fill the Data Set
            da.Fill(dsDataSet, "tbldata");

            return dsDataSet;


        }
        catch (Exception ex)
        {
            return dsDataSet;

        }

    }

    //



    public DataSet GetList(string sqlString)
    {
        DataSet dsDataSet = new DataSet();

        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }

        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCMD.Connection = sqlConn;
        sqlCMD.CommandText = sqlString;
        sqlCMD.CommandType = CommandType.Text;
        //
        //***************************Define Deficiency Parameters**********************
        //

        try
        {
            //
            SqlParameter getData_Parameter = new SqlParameter();
            getData_Parameter = sqlCMD.Parameters.Add("@sqlString", SqlDbType.VarChar);
            getData_Parameter.Direction = ParameterDirection.Input;
            getData_Parameter.Value = sqlString;
            //
            //Create a Data Adapter
            SqlDataAdapter da = new SqlDataAdapter(sqlCMD);
            //Fill the Data Set
            da.Fill(dsDataSet, "tbldata");

            return dsDataSet;


        }
        catch (Exception ex)
        {
            return dsDataSet;

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

    #endregion
    }

