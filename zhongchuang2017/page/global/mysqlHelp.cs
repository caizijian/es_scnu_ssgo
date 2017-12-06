using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class mysqlHelp
{
   // public string connectionstr = "Server=localhost;User ID=root;Password=GNzhengxun11;Database=zhongchuang;CharSet=utf8;";
    public mysqlHelp()
    {
        
    }

    private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans,  string cmdText, MySqlParameter[] cmdParms)
    {//参数化
        if (conn.State != ConnectionState.Open)
            conn.Open();

        cmd.Connection = conn;
        cmd.CommandText = cmdText;
       

        if (trans != null)
            cmd.Transaction = trans;

        cmd.CommandType = CommandType.Text;

        if (cmdParms != null)     //填入参数
        {
            foreach (MySqlParameter parm in cmdParms)
                cmd.Parameters.Add(parm);
        }
    }

    

    
    public static int ExecuteNonQuery(string SQLString)
    {//无需插入参数；增删改；返回影响行数
        using (MySqlConnection connection = new MySqlConnection("Server=118.89.38.11;User ID=root;Password=sightzgo1110/*-;Database=zhongchuang;CharSet=utf8;"))
        {
            using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (MySqlException e)
                {
                    connection.Close();
                    throw e;
                }
            }
        }
    }


    
    public static int ExecuteNonQuery(string SQLString, params MySqlParameter[] cmdParms)
    {//需要插入参数；增删改；返回影响行数
        using (MySqlConnection connection = new MySqlConnection("Server=118.89.38.11;User ID=root;Password=sightzgo1110/*-;Database=zhongchuang;CharSet=utf8;"))
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return rows;
                }
                catch (MySqlException e)
                {
                    throw e;
                }
            }
        }
    }




  
    public static object ExecuteScalar(string SQLString)
    {//查询，返回第一行第一例
        using (MySqlConnection connection = new MySqlConnection("Server=118.89.38.11;User ID=root;Password=sightzgo1110/*-;Database=zhongchuang;CharSet=utf8;"))
        {
            using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (MySqlException e)
                {
                    connection.Close();
                    throw e;
                }
            }
        }
    }


    public static object ExecuteScalar(string SQLString, params MySqlParameter[] cmdParms)
    {
        using (MySqlConnection connection = new MySqlConnection("Server=118.89.38.11;User ID=root;Password=sightzgo1110/*-;Database=zhongchuang;CharSet=utf8;"))
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (MySqlException e)
                {
                    throw e;
                }
            }
        }
    }




    public static MySqlDataReader ExecuteReader(string strSQL)
    {//查询，返回第一行
        MySqlConnection connection = new MySqlConnection("Server=118.89.38.11;User ID=root;Password=sightzgo1110/*-;Database=zhongchuang;CharSet=utf8;");
        MySqlCommand cmd = new MySqlCommand(strSQL, connection);
        MySqlDataReader myReader = null;
        try
        {
            connection.Open();           
            myReader = cmd.ExecuteReader();

            return myReader;
        }
        catch (MySqlException e)
        {
            throw e;
        }
        finally
        {
            myReader.Close();
        }
    }
    public static MySqlDataReader ExecuteReader(string SQLString, params MySqlParameter[] cmdParms)
    {
        MySqlConnection connection = new MySqlConnection("Server=118.89.38.11;User ID=root;Password=sightzgo1110/*-;Database=zhongchuang;CharSet=utf8;");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader myReader = null;
      
            PrepareCommand(cmd, connection, null, SQLString, cmdParms);
            myReader = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            return myReader;
        
       /* catch (MySqlException e)
        {
            throw e;
        }
        finally
        {
            
            myReader.Close();
            cmd.Dispose();
            connection.Close();

        }*/
    }

    public static DataTable ExecuteDataTable(string SQLString)
    {//查询，返回一个表
        using (MySqlConnection connection = new MySqlConnection("Server=118.89.38.11;User ID=root;Password=sightzgo1110/*-;Database=zhongchuang;CharSet=utf8;"))
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection);
                command.Fill(ds, "ds");
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return ds.Tables[0];
        }
        
    }


    public static DataTable ExecuteDataTable(string SQLString, params MySqlParameter[] cmdParms)
    {
        using (MySqlConnection connection = new MySqlConnection("Server=118.89.38.11;User ID=root;Password=sightzgo1110/*-;Database=zhongchuang;CharSet=utf8;"))
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, connection, null, SQLString, cmdParms);
            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds, "ds");
                    cmd.Parameters.Clear();
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds.Tables[0];
            }
        }
    }




}