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
    }
}
