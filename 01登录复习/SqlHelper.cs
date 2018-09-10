using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01登录复习
{
    public static class SqlHelper
    {
        private static string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        public static int ExecuteNonQuery(string sql, CommandType cmdType, SqlParameter[] pms)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = cmdType;
                    if (pms!=null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static Object ExecuteScalar(string sql, CommandType cmdType, SqlParameter[] pms)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    cmd.CommandType = cmdType;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();
                }

            }
        }

        public static SqlDataReader ExecuteReaer(string sql,CommandType cmdType,SqlParameter[] pms)
        {
            SqlConnection conn = new SqlConnection(conStr);
            using (SqlCommand cmd = new SqlCommand(sql,conn))
            {
                cmd.CommandType = cmdType;
                if (pms!=null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch
                {
                    conn.Close();
                    conn.Dispose();
                    throw;
                }

            }
        }

        public static DataTable ExecuteTable(string sql, CommandType cmdType, SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conStr))
            {
                adapter.SelectCommand.CommandType = cmdType;
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
