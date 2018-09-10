using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02Office读写
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 写入Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //创建一个person类
            //创建List集合
            List<Person> people = new List<Person>
            {
                new Person(){ Name="LUO" ,Age=20,Email="LUO@qq.com" },
                new Person(){ Name="鸡腿",Age=18,Email="jitui@163.com" },
                new Person(){ Name="可乐",Age=21,Email="kele@126.com"}
            };
            //把List集合中的内容导出到excel文件中
            //1.创建工作簿对象
            IWorkbook workbook = new HSSFWorkbook();
            //2.在该工作簿中创建工作表对象
            ISheet sheet = workbook.CreateSheet("Sheet1");
            //2.1向工作表中插入行和单元格
            for (int i = 0; i < people.Count; i++)
            {
                //在sheet中创建一行
                IRow row = sheet.CreateRow(i);//i是行号
                //设置单元格内容
                row.CreateCell(0).SetCellValue(people[i].Name);
                row.CreateCell(1).SetCellValue(people[i].Age);
                row.CreateCell(2).SetCellValue(people[i].Email);
            }
            //3.写入Excel文件
            using (FileStream fs = File.OpenWrite(@"C:\Users\LUO\Desktop\1.xls"))
            {
                workbook.Write(fs);
            }
            MessageBox.Show("写入成功！");
            
        }

        //读取excel并历遍输出里面的内容
        private void button2_Click(object sender, EventArgs e)
        {

        }


    }
}
