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


/// <summary>
/// Summary description for clsDataSets
/// </summary>
public class clsDataSets
{
    #region "Private Members"
    private static string m_fha_number;
    private static int m_property_id;
    private static string m_SelectedYear;
    //
    private static string m_SelectedYear1;
    #endregion
    private static string m_SelectedYea2r;

    #region "Public Properties"

    public static string FHA_Number
    {
        get { return m_fha_number; }
        set { m_fha_number = value; }
    }

    public static int Property_Id
    {
        get { return m_property_id; }
        set { m_property_id = value; }
    }

    public static string SelectedYear
    {
        get { return m_SelectedYear; }
        set { m_SelectedYear = value; }
    }

    public static string SelectedYear1
    {
        get { return m_SelectedYear1; }
        set { m_SelectedYear1 = value; }
    }

    public static string SelectedYear2
    {
        get { return m_SelectedYea2r; }
        set { m_SelectedYea2r = value; }
    }

    #endregion


    #region "Connection Properties"
    private SqlConnection sqlConn = new SqlConnection();
    private SqlConnection sqlConnStg = new SqlConnection();
    #endregion
    private SqlCommand sqlCmd = new SqlCommand();

    //
    // TODO: Add constructor logic here
    //
    public clsDataSets()
    {
    }
    #region ""

    public DataSet GetData(string strSQL, bool blnStaging)
    {
        DataSet ds = new DataSet();

        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQLStaging"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = strSQL;
        sqlCmd.CommandType = CommandType.Text;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //

            //
            //Create a Data Adapter
            SqlDataAdapter daData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daData.Fill(ds, "tbldata");

            return ds;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "Get data tbldata";
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

    public int GetDataScalarValue(string strSQL)
    {
        DataSet ds = new DataSet();

        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = strSQL;
        sqlCmd.CommandType = CommandType.Text;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //
            int rowcount = sqlCmd.ExecuteNonQuery();
            return rowcount;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "Get data GetDataScalarValue";
            oError.LogErrors(oError);
            return -1;
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
    public DataSet GetData(string strSQL)
    {
        DataSet ds = new DataSet();

        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = strSQL;
        sqlCmd.CommandType = CommandType.Text;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //

            //
            //Create a Data Adapter
            SqlDataAdapter daData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daData.Fill(ds, "tbldata");

            return ds;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "Get data GetData";
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


    public DataSet GetData(string strSQL, string strOEDM)
    {
        DataSet ds = new DataSet();

        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = strSQL;
        sqlCmd.CommandType = CommandType.Text;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //
            //Create a Data Adapter
            SqlDataAdapter daData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daData.Fill(ds, "tblDataPeerSelection");
            //
            return ds;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "Get data tblDataPeerSelection";
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

    public bool GetData(string strSQL, string strOEDM, bool blProp)
    {
        DataSet ds = new DataSet();

        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = strSQL;
        sqlCmd.CommandType = CommandType.Text;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //

            //
            //Create a Data Adapter
            SqlDataAdapter daData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daData.Fill(ds, "tblPeerData");

            return true;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "Get data tblPeerData";
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


    public bool DropTable(string strSQL)
    {
        DataSet ds = new DataSet();

        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        //***************************Define Deficiency Parameters**********************
        //
        strSQL = "drop table " + "  OE_MF_DM_MIRROR.dbo.temp_prt1 ";
        try
        {
            SqlCommand cmd = new SqlCommand(strSQL, sqlConn);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "Drop Table";
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



    public bool InsertTable(string strSQL)
    {
        DataSet ds = new DataSet();

        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = strSQL;
        sqlCmd.CommandType = CommandType.Text;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            sqlCmd.ExecuteNonQuery();
            sqlConn.Close();
            return true;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "Insert Table";
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



    public DataSet GetMaxMin_Year(string strPropertyId)
    {
        DataSet dsDataSet = new DataSet();
        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetMinMaxYear_PRT";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //
            System.Data.SqlClient.SqlParameter getData_Parameter = sqlCmd.Parameters.Add("@remsId", SqlDbType.BigInt);
            getData_Parameter.Direction = ParameterDirection.Input;
            getData_Parameter.Value = Convert.ToInt32(strPropertyId);
            //
            //Create a Data Adapter
            SqlDataAdapter daData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daData.Fill(dsDataSet, "tblMaxMin_Year");

            return dsDataSet;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "usp_GetMinMaxYear_PRT";
            oError.LogErrors(oError);
            return dsDataSet;
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


    public DataSet GetMin_Year(string strPropertyId)
    {
        DataSet dsDataSet = new DataSet();
        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetMinYear_PRT";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //
            System.Data.SqlClient.SqlParameter getData_Parameter = sqlCmd.Parameters.Add("@remsId", SqlDbType.BigInt);
            getData_Parameter.Direction = ParameterDirection.Input;
            getData_Parameter.Value = Convert.ToInt32(strPropertyId);
            //
            //Create a Data Adapter
            SqlDataAdapter daData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daData.Fill(dsDataSet, "tblMin_Year");

            return dsDataSet;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "usp_GetMinYear_PRT";
            oError.LogErrors(oError);
            return dsDataSet;
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

    public DataSet GetMax_Year(string strPropertyId)
    {
        DataSet dsDataSet = new DataSet();
        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetMaxYear_PRT";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //
            System.Data.SqlClient.SqlParameter getData_Parameter = sqlCmd.Parameters.Add("@remsId", SqlDbType.BigInt);
            getData_Parameter.Direction = ParameterDirection.Input;
            getData_Parameter.Value = Convert.ToInt32(strPropertyId);
            //
            //Create a Data Adapter
            SqlDataAdapter daData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daData.Fill(dsDataSet, "tblMax_Year");

            return dsDataSet;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "usp_GetMaxYear_PRT";
            oError.LogErrors(oError);
            return dsDataSet;
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



    public DataSet GetPropertyDataSet(string strPropertyId)
    {
        DataSet dsDataSet = new DataSet();
        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetPropertyData_PRT";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //
            System.Data.SqlClient.SqlParameter getData_Parameter = sqlCmd.Parameters.Add("@remsId", SqlDbType.BigInt);
            getData_Parameter.Direction = ParameterDirection.Input;
            getData_Parameter.Value = Convert.ToInt32(strPropertyId);
            //
            //Create a Data Adapter
            SqlDataAdapter daData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daData.Fill(dsDataSet, "tbldata");

            return dsDataSet;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "usp_GetPropertyData_PRT";
            oError.LogErrors(oError);
            return dsDataSet;
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

    public DataSet GetPropertyAllDataSet(string strPropertyId)
    {
        DataSet dsDataSet = new DataSet();
        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetPropertyDataAll_PRT";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //
            System.Data.SqlClient.SqlParameter getData_Parameter = sqlCmd.Parameters.Add("@remsId", SqlDbType.BigInt);
            getData_Parameter.Direction = ParameterDirection.Input;
            getData_Parameter.Value = Convert.ToInt32(strPropertyId);
            //
            //Create a Data Adapter
            SqlDataAdapter daData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daData.Fill(dsDataSet, "tbldata");

            return dsDataSet;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "usp_GetPropertyDataAll_PRT";
            oError.LogErrors(oError);
            return dsDataSet;
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




    public bool GetStatistics()
    {
        DataSet ds1 = new DataSet();
        SqlCommand cmd1 = new SqlCommand();
        

        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "OE_MF_DM_MIRROR.dbo.usp_prt_create_stats_table";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //

        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //
            //Truncate the table mf_prt_mertrics
            SqlCommand cmd = new SqlCommand(" truncate table OE_MF_DM_MIRROR.dbo.mf_prt_metrics ", sqlConn);
            cmd.ExecuteNonQuery();
            //
            //Execute stored procedure for the cursor to generate the metrics
            sqlCmd.ExecuteNonQuery();
            //
            //Create a Data Adapter
            //SqlDataAdapter daData = new SqlDataAdapter(cmd1);
            ////Fill the Data Set
            //daData.Fill(ds1, "table1");

            return true;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "usp_prt_create_stats_table";
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


    public SqlDataReader GetPropertyAllDataSet(string strPropertyId, bool blnTrue)
    {
        DataSet dsDataSet = new DataSet();
        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetPropertyDataAll_PRT";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        sqlCmd.Parameters.Clear();
        //
        System.Data.SqlClient.SqlParameter getData_Parameter = sqlCmd.Parameters.Add("@remsId", SqlDbType.BigInt);
        getData_Parameter.Direction = ParameterDirection.Input;
        getData_Parameter.Value = Convert.ToInt32(strPropertyId);
        //
        SqlDataReader dr = sqlCmd.ExecuteReader();

        try
        {
            //
            return dr;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "usp_GetPropertyDataAll_PRT";
            oError.LogErrors(oError);
            return dr;

        }
        finally
        {
        }


    }

    public SqlDataReader GetStatistics(bool blnReader)
    {
        DataSet ds1 = new DataSet();
        SqlCommand cmd1 = new SqlCommand();
        string sqlMetric = "";
        //SqlDataReader dr = new SqlDataReader();

        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        //
        sqlMetric = " select rtrim(ltrim(rev.tag_account_numbers)) as tag_account_numbers,p.mtr_min,p.mtr_max,";
        sqlMetric = sqlMetric + Convert.ToString(" p.mtr_median,p.mtr_avg ");
        sqlMetric = sqlMetric + Convert.ToString(" from OE_MF_DM_MIRROR.dbo.mf_prt_metrics p, OE_MF_DM_MIRROR.dbo.ref_prt_revenue_accounts rev");
        sqlMetric = sqlMetric + Convert.ToString(" where p.tag_column_name = rev.tag_account_numbers ");
        sqlMetric = sqlMetric + Convert.ToString(" order by rev.tag_account_numbers2");

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = sqlMetric;
        sqlCmd.CommandType = CommandType.Text;
        //
        //***************************Define Deficiency Parameters**********************
        //
        SqlDataReader dr = sqlCmd.ExecuteReader();
        try
        {
            return dr;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "GetStatistics";
            oError.LogErrors(oError);
            return dr;
            //sqlConn.Close();
            //sqlCmd.Parameters.Clear();
            //if ((sqlCmd != null))
            //{
            //    sqlCmd.Dispose();
            //}
        }
        finally
        {
        }


    }

    public DataSet GetStatistics(bool blnReader, int intOne)
    {
        DataSet dsDataSet = new DataSet();
        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetStats";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //

        try
        {
            //
            //Create a Data Adapter
            SqlDataAdapter daData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daData.Fill(dsDataSet, "tblStats");

            return dsDataSet;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "GetStatistics tblStats";
            oError.LogErrors(oError);
            return dsDataSet;
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


    public string GetSingleValue(string strSearch)
    {
        DataSet dsDataSet = new DataSet();
        int i = 0;
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
        //***************************Define Deficiency Parameters**********************
        string strMaxId = "F";
        SqlDataReader dr = sqlCmd.ExecuteReader();

        try
        {
            while (dr.Read())
            {
                if (i == 0)
                {
                    strMaxId = dr["max_id"].ToString();
                    i = i + 1;
                }
            }

            return strMaxId;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "GetSingleValue";
            oError.LogErrors(oError);
            return "F";
            //sqlConn.Close();
            //sqlCmd.Parameters.Clear();
            //if ((sqlCmd != null))
            //{
            //    sqlCmd.Dispose();
            //}
        }
        finally
        {
        }


    }

    public string[] GetDataReader(string strPropertyId, bool strBool)
    {
        DataSet dsDataSet = new DataSet();
        DataTable dt = new DataTable();
        string[] a1 = null;


        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetPropertyData_PRT";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //

        try
        {
            //800236924
            System.Data.SqlClient.SqlParameter getData_Parameter = sqlCmd.Parameters.Add("@remsId", SqlDbType.BigInt);
            getData_Parameter.Direction = ParameterDirection.Input;
            getData_Parameter.Value = Convert.ToInt32(strPropertyId);
            //
            //Create a Data Adapter
            SqlDataAdapter daData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daData.Fill(dsDataSet, "tbldata");
            //
            StringBuilder output = new StringBuilder();
            //string output1 ;
            foreach (DataRow rows in dsDataSet.Tables[0].Rows)
            {
                foreach (DataColumn col in dsDataSet.Tables[0].Columns)
                {
                    output.AppendFormat("{0} ", rows[col]);
                }
                output.AppendLine();
            }


            a1 = dsDataSet.Tables[0].Rows[0].ItemArray.Cast<string>().ToArray();


            return a1;

        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "usp_GetPropertyData_PRT";
            oError.LogErrors(oError);
            return null;
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




    public SqlDataReader GetDataReader(string strPropertyId)
    {
        DataSet dsDataSet = new DataSet();
        DataTable dt = new DataTable();



        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetPropertyData_PRT";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            sqlCmd.Parameters.Clear();
            //800236924
            System.Data.SqlClient.SqlParameter getData_Parameter = sqlCmd.Parameters.Add("@remsId", SqlDbType.BigInt);
            getData_Parameter.Direction = ParameterDirection.Input;
            getData_Parameter.Value = Convert.ToInt32(strPropertyId);
            //
            SqlDataReader dr = sqlCmd.ExecuteReader();


            return dr;

        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "usp_GetPropertyData_PRT";
            oError.LogErrors(oError);
            return null;
        }
        finally
        {
            //sqlConn.Close()
            //sqlCmd.Parameters.Clear()
            //If (sqlCmd IsNot Nothing) Then
            //    sqlCmd.Dispose()
            //End If
        }


    }


    public DataSet GetDataSet(string sqlString)
    {
        DataSet dsDataSet = new DataSet();
        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetDataSet_PRT";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //
            System.Data.SqlClient.SqlParameter getData_Parameter = sqlCmd.Parameters.Add("@sqlString", SqlDbType.VarChar);
            getData_Parameter.Direction = ParameterDirection.Input;
            getData_Parameter.Value = sqlString;
            //
            //Create a Data Adapter
            SqlDataAdapter daData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daData.Fill(dsDataSet, "tbldata");

            return dsDataSet;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "usp_GetDataSet_PRT";
            oError.LogErrors(oError);
            return dsDataSet;
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

    public DataSet GetReisDataSet(string strPropertyId, string strFirstCashFlowYear, string strMaxReisYear)
    {
        DataSet dsDataSet = new DataSet();
        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetReisData_PRT";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //
            System.Data.SqlClient.SqlParameter P0 = sqlCmd.Parameters.Add("@intReisId", SqlDbType.BigInt);
            P0.Direction = ParameterDirection.Input;
            P0.Value = Convert.ToInt32(strPropertyId);
            //
            System.Data.SqlClient.SqlParameter P1 = sqlCmd.Parameters.Add("@lngLReisYr", SqlDbType.BigInt);
            P1.Direction = ParameterDirection.Input;
            P1.Value = Convert.ToInt32(strMaxReisYear);
            //
            System.Data.SqlClient.SqlParameter P2 = sqlCmd.Parameters.Add("@lngFirstYr", SqlDbType.BigInt);
            P2.Direction = ParameterDirection.Input;
            P2.Value = Convert.ToInt32(strFirstCashFlowYear);
            //
            //Create a Data Adapter
            SqlDataAdapter daData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daData.Fill(dsDataSet, "tblreisdata");

            return dsDataSet;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "usp_GetReisData_PRT";
            oError.LogErrors(oError);
            return dsDataSet;
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
    public DataSet GetFinancialDataSetSubjectProperty(string strPropertyId, string strYearofInterest)
    {
        DataSet dsDataSet = new DataSet();
        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlCmd.Parameters.Clear();
        if ((sqlCmd != null))
        {
            sqlCmd.Dispose();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetSubjectPropertyFinancialData_PRT";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //
            System.Data.SqlClient.SqlParameter P0 = sqlCmd.Parameters.Add("@remsId", SqlDbType.BigInt);
            P0.Direction = ParameterDirection.Input;
            P0.Value = Convert.ToInt32(strPropertyId);
            //
            System.Data.SqlClient.SqlParameter P1 = sqlCmd.Parameters.Add("@hudfiscalyear_begin", SqlDbType.BigInt);
            P1.Direction = ParameterDirection.Input;
            P1.Value = Convert.ToInt32(strYearofInterest);
            //

            //
            //Create a Data Adapter
            SqlDataAdapter daData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daData.Fill(dsDataSet, "tblFinData");

            return dsDataSet;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "usp_GetSubjectPropertyFinancialData_PRT";
            oError.LogErrors(oError);
            return dsDataSet;
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
    public DataSet GetFinancialDataSet(string strPropertyId, string strFirstYear, string strLastYear)
    {
        DataSet dsDataSet = new DataSet();
        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlCmd.Parameters.Clear();
        if ((sqlCmd != null))
        {
            sqlCmd.Dispose();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetFinancialData_PRT";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //
            System.Data.SqlClient.SqlParameter P0 = sqlCmd.Parameters.Add("@remsId", SqlDbType.BigInt);
            P0.Direction = ParameterDirection.Input;
            P0.Value = Convert.ToInt32(strPropertyId);
            //
            System.Data.SqlClient.SqlParameter P1 = sqlCmd.Parameters.Add("@hudfiscalyear_begin", SqlDbType.BigInt);
            P1.Direction = ParameterDirection.Input;
            P1.Value = Convert.ToInt32(strFirstYear);
            //
            System.Data.SqlClient.SqlParameter P2 = sqlCmd.Parameters.Add("@hudfiscalyear_end", SqlDbType.BigInt);
            P2.Direction = ParameterDirection.Input;
            P2.Value = Convert.ToInt32(strLastYear);
            //
            //Create a Data Adapter
            SqlDataAdapter daData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daData.Fill(dsDataSet, "tblFinData");

            return dsDataSet;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "usp_GetFinancialData_PRT";
            oError.LogErrors(oError);
            return dsDataSet;
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

    public SqlDataReader GetLoanDataSet(string strPropertyId)
    {
        DataSet dsDataSet = new DataSet();
        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlCmd.Parameters.Clear();
        if ((sqlCmd != null))
        {
            sqlCmd.Dispose();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetLoanData_PRT";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        System.Data.SqlClient.SqlParameter getData_Parameter = sqlCmd.Parameters.Add("@remsId", SqlDbType.BigInt);
        getData_Parameter.Direction = ParameterDirection.Input;
        getData_Parameter.Value = Convert.ToInt32(strPropertyId);
        //
        //***************************Define Deficiency Parameters**********************
        //
        SqlDataReader dr = sqlCmd.ExecuteReader();
        try
        {
            return dr;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "usp_GetLoanData_PRT";
            oError.LogErrors(oError);
            return dr;
            //sqlConn.Close();
            //sqlCmd.Parameters.Clear();
            //if ((sqlCmd != null)) {
            //    sqlCmd.Dispose();
        }
        finally
        {
        }
    }





    public SqlDataReader GetDataReader1(string strPropertyId)
    {
        DataSet dsDataSet = new DataSet();
        DataTable dt = new DataTable();



        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.CommandText = strPropertyId;
        sqlCmd.CommandType = CommandType.Text;
        sqlCmd.Connection = sqlConn;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            sqlCmd.Parameters.Clear();
            //
            SqlDataReader dr = sqlCmd.ExecuteReader();

            return dr;

        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "GetDataReader1";
            oError.LogErrors(oError);
            return null;
        }
        finally
        {
            //sqlConn.Close()
            //sqlCmd.Parameters.Clear()
            //If (sqlCmd IsNot Nothing) Then
            //    sqlCmd.Dispose()
            //End If
        }


    }


    public DataSet GetReisDataSet_BC(string strPropertyId, string strFirstCashFlowYear, string strMaxReisYear)
    {
        DataSet dsDataSet = new DataSet();
        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetReisData_PRT_BC";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //
            System.Data.SqlClient.SqlParameter P0 = sqlCmd.Parameters.Add("@intReisId", SqlDbType.BigInt);
            P0.Direction = ParameterDirection.Input;
            P0.Value = Convert.ToInt32(strPropertyId);
            //
            System.Data.SqlClient.SqlParameter P1 = sqlCmd.Parameters.Add("@lngLReisYr", SqlDbType.BigInt);
            P1.Direction = ParameterDirection.Input;
            P1.Value = Convert.ToInt32(strMaxReisYear);
            //
            System.Data.SqlClient.SqlParameter P2 = sqlCmd.Parameters.Add("@lngFirstYr", SqlDbType.BigInt);
            P2.Direction = ParameterDirection.Input;
            P2.Value = Convert.ToInt32(strFirstCashFlowYear);
            //
            //Create a Data Adapter
            SqlDataAdapter daData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daData.Fill(dsDataSet, "tblreisdata2");

            return dsDataSet;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "usp_GetReisData_PRT_BC";
            oError.LogErrors(oError);
            return dsDataSet;
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

    public DataSet GetReisDataSet_A(string strPropertyId, string strFirstCashFlowYear, string strMaxReisYear)
    {
        DataSet dsDataSet = new DataSet();
        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
        sqlConn.ConnectionString = ConfigurationManager.AppSettings["strConnSQL"];
        sqlConn.Open();

        sqlCmd.Connection = sqlConn;
        sqlCmd.CommandText = "usp_GetReisData_PRT_a";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //
        //***************************Define Deficiency Parameters**********************
        //
        try
        {
            //
            System.Data.SqlClient.SqlParameter P0 = sqlCmd.Parameters.Add("@intReisId", SqlDbType.BigInt);
            P0.Direction = ParameterDirection.Input;
            P0.Value = Convert.ToInt32(strPropertyId);
            //
            System.Data.SqlClient.SqlParameter P1 = sqlCmd.Parameters.Add("@lngLReisYr", SqlDbType.BigInt);
            P1.Direction = ParameterDirection.Input;
            P1.Value = Convert.ToInt32(strMaxReisYear);
            //
            System.Data.SqlClient.SqlParameter P2 = sqlCmd.Parameters.Add("@lngFirstYr", SqlDbType.BigInt);
            P2.Direction = ParameterDirection.Input;
            P2.Value = Convert.ToInt32(strFirstCashFlowYear);
            //
            //Create a Data Adapter
            SqlDataAdapter daData = new SqlDataAdapter(sqlCmd);
            //Fill the Data Set
            daData.Fill(dsDataSet, "tblreisdata3");

            return dsDataSet;
        }
        catch (Exception ex)
        {
            Errors oError = new Errors();
            //oError.AppNumber = 0
            oError.ErrorMessage = ex.Message;
            oError.ErrorSource = ex.Source;
            oError.ErrorStackTrace = ex.StackTrace.ToString();
            oError.ErrorMethod = "usp_GetReisData_PRT_a";
            oError.LogErrors(oError);
            return dsDataSet;
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



