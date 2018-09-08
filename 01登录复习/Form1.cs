using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01登录复习
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.ToString().Trim();
            string pwd = txtPwd.Text.ToString().Trim();
            string sql = "select count(*) from [Users] where loginId = @id and loginPwd = @pwd";
            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@id",SqlDbType.NVarChar,50){Value=user },
                new SqlParameter("@pwd",SqlDbType.NVarChar,50){Value=pwd}
            };
            int b = (int)SqlHelper.ExecuteScalar(sql, CommandType.Text, pms);
            if (b==1)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("error");
            }
        }
    }
}
