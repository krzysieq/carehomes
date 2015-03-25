using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DBManager
{
    static string connstring = ConfigurationManager.ConnectionStrings["TelecareConnectionString"].ConnectionString;
    SqlConnection con = new SqlConnection(connstring);
    SqlCommand cmd;
    SqlDataAdapter adapter;

    public DBManager()
    {
        //con = new SqlConnection(connstring);
    }

    /// <summary>
    /// DML operation against database and return boolean type
    /// </summary>
    /// <param name="ProcedureName"></param>
    /// <param name="args"></param>
    /// <returns></returns>    
    public bool DMLOperation(string ProcedureName, params SqlParameter[] args)
    {
        try
        {
            con = new SqlConnection(connstring);
            cmd = new SqlCommand(ProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter p in args)
            {
                cmd.Parameters.Add(p);
            }

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch (SqlException sqlex)
        {
            throw sqlex;
        }
        finally
        {
            cmd.Dispose();
            con.Close();
            con.Dispose();
            cmd.Parameters.Clear();
            args = null;
        }
    }

    /// <summary>
    /// DML operation against database and return string which parameter are passed in Parameter(msg)
    /// </summary>
    /// <param name="ProcedureName"></param>
    /// <param name="msg"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public string DMLOperation(string ProcedureName, string msg, params SqlParameter[] args)
    {
        try
        {
            con = new SqlConnection(connstring);
            cmd = new SqlCommand(ProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter p in args)
            {
                cmd.Parameters.Add(p);
            }

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return msg;
        }
        catch (SqlException sqlex)
        {
            throw sqlex;
        }
        finally
        {
            cmd.Dispose();
            con.Close();
            con.Dispose();
            cmd.Parameters.Clear();
            args = null;
        }
    }

    /// <summary>
    /// return int the last identity inserted in database table
    /// </summary>
    /// <param name="ProcedureName"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public int Get_Last_Inserted_ID(string ProcedureName, params SqlParameter[] args)
    {
        try
        {
            con = new SqlConnection(connstring);
            cmd = new SqlCommand(ProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
            con.Open();

            int getlatest = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return getlatest;
        }
        catch (SqlException sqlex)
        {
            throw sqlex;
        }
        finally
        {
            cmd.Dispose();
            con.Close();
            con.Dispose();
            cmd.Parameters.Clear();
            args = null;
        }
    }

    /// <summary>
    /// return Dataset with specified parameter which are passed
    /// </summary>
    /// <param name="procName"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public DataSet RetrieveDataSet(string procName, params SqlParameter[] args)
    {
        con = new SqlConnection(connstring);
        cmd = new SqlCommand();
        try
        {
            con = new SqlConnection(connstring);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procName;
            cmd.Connection = con;
            foreach (SqlParameter p in args)
            {
                cmd.Parameters.Add(p);
            }

            adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            adapter.SelectCommand = cmd;

            ds.Clear();
            adapter.Fill(ds);
            return (ds);

        }
        catch (SqlException sqlex)
        {
            throw sqlex;
        }
        finally
        {
            cmd.Dispose();
            con.Close();
            con.Dispose();
            cmd.Parameters.Clear();
            args = null;
        }
    }

    /// <summary>
    /// return Dataset
    /// </summary>
    /// <param name="procName"></param>
    /// <returns></returns>
    public DataSet RetrieveDataSet(string procName)
    {
        SqlCommand cmd = new SqlCommand();
        try
        {
            con = new SqlConnection(connstring);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procName;
            cmd.Connection = con;

            adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            adapter.SelectCommand = cmd;

            ds.Clear();
            adapter.Fill(ds);
            return (ds);

        }
        catch (SqlException sqlex)
        {
            throw sqlex;
        }
        finally
        {
            cmd.Dispose();
            con.Close();
            con.Dispose();
            cmd.Parameters.Clear();
        }
    }

    /// <summary>
    /// Retrive dataset from database 
    /// </summary>
    /// <param name="query">inline query for retriving dataset</param>
    /// <returns>returns DataSet</returns>
    public DataSet RetrieveDataSetIL(string query)
    {
        con = new SqlConnection(connstring);
        DataSet ds = new DataSet();
        cmd = new SqlCommand(query, con);
        adapter = new SqlDataAdapter(cmd);
        con.Open();
        adapter.Fill(ds);
        con.Close();
        return ds;
    }

    /// <summary>
    /// return DataTable with specified parameter which are passed
    /// </summary>
    /// <param name="procName"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public DataTable RetrieveDatatable(string procName, params SqlParameter[] args)
    {
        con = new SqlConnection(connstring);
        cmd = new SqlCommand();
        try
        {
            con = new SqlConnection(connstring);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procName;
            cmd.Connection = con;
            foreach (SqlParameter p in args)
            {
                cmd.Parameters.Add(p);
            }
            adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            adapter.SelectCommand = cmd;

            dt.Clear();
            adapter.Fill(dt);
            return (dt);

        }
        catch (SqlException sqlex)
        {
            throw sqlex;
        }
        finally
        {
            cmd.Dispose();
            con.Close();
            con.Dispose();
            cmd.Parameters.Clear();
            args = null;
        }
    }

    /// <summary>
    /// return DataTable
    /// </summary>
    /// <param name="procName"></param>
    /// <returns></returns>
    public DataTable RetrieveDatatable(string procName)
    {
        SqlCommand cmd = new SqlCommand();
        try
        {
            con = new SqlConnection(connstring);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procName;
            cmd.Connection = con;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable verveDs = new DataTable();

            adapter.SelectCommand = cmd;

            verveDs.Clear();
            adapter.Fill(verveDs);
            return (verveDs);

        }
        catch (SqlException sqlex)
        {
            throw sqlex;
        }
        finally
        {
            cmd.Dispose();
            con.Close();
            con.Dispose();
            cmd.Parameters.Clear();
        }
    }

    /// <summary>
    /// Retrive dataset from datatable
    /// </summary>
    /// <param name="query">inline query for retriving datatable</param>
    /// <returns>returns DataTable</returns>
    public DataTable RetrieveDatatableIL(string query)
    {
        con = new SqlConnection(connstring);
        DataTable ds = new DataTable();
        cmd = new SqlCommand(query, con);
        adapter = new SqlDataAdapter(cmd);
        con.Open();
        adapter.Fill(ds);
        con.Close();
        return ds;
    }

    /// <summary>
    /// Insert Update Delete against database inline query
    /// </summary>
    /// <param name="query">inline query for insert, update, delete</param>
    /// <returns>returns nothing because it's an dml operation</returns>
    public bool InlineQuery(string query)
    {
        con = new SqlConnection(connstring);
        cmd = new SqlCommand(query, con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        return true;
    }
}

