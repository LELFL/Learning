using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LambdaAndLambdaTree
{

    http://www.cnblogs.com/yunfeifei/p/3844814.html
    #region lambda学习
    //Lambda运算符的左边是输入参数(如果有)，右边是表达式或语句块。
    //Lambda表达式x => x * x读作"x goes to x times x"。可以将此表达式分配给委托类型

    //delegate int del(int i);
    //delegate bool Leng(int i, string s);
    //delegate int GetTwo();

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        del mydel = x => x * x;
    //        int j = mydel(5);
    //        //有时，编译器难以或无法推断输入类型,可以给参数设置类型
    //        Leng mydel2 = (int x, string s) => s.Length > x;
    //        //使用空括号指定零个参数
    //        GetTwo getTwo = () => 2;
    //        Console.WriteLine(j);
    //        //lambda表达式有多个语句时
    //        Leng mydel3 = (int x, string s) => { x += 2; return s.Length > x; };
    //        Console.ReadKey();

    //    }
    //}
    #endregion

    #region 示例
    //class Program
    //{
    //    static void Main()
    //    {

    //        List<string> cityList = new List<string>()
    //        {
    //            "BeiJing",
    //            "ShangHai",
    //            "TianJin",
    //            "GuangDong"
    //        };
    //        var result = cityList.First(c => c.Length > 7);



    //    }
    //}
    #endregion

    #region 自己定义和调用lambda表达式
    //class Program
    //{
    //    static void Main()
    //    {
    //        LambdaFun("BeiJing 2013", s =>
    //        {
    //            if (s.Contains("2013"))
    //            {
    //                s = s.Replace("2013", "2014");
    //            }
    //            return s;
    //        });
    //        Console.ReadKey();
    //    }

    //    public static void LambdaFun(string str,Func<string,string> func)
    //    {
    //        Console.WriteLine(func(str));
    //    }
    //}
    #endregion

    #region lambda表达式树动态创建方法 
    class Program
    {
        static void Main(string[] vs)
        {
            //i*j+w*x
            ParameterExpression a = Expression.Parameter(typeof(int), "i");//创建一个表达式树中的参数，作为一个节点，这里是最下层的节点

            ParameterExpression b = Expression.Parameter(typeof(int), "j");

            BinaryExpression r1 = Expression.Multiply(a, b);//这里i*j,生成表达式树中的一个节点，比上面节点高一级

            ParameterExpression c = Expression.Parameter(typeof(int), "w");
            ParameterExpression d = Expression.Parameter(typeof(int), "x");
            BinaryExpression r2 = Expression.Multiply(c, d);

            BinaryExpression result = Expression.Add(r1, r2);   //运算两个中级节点，产生终结点

            Expression<Func<int, int, int, int, int>> lambda = Expression.Lambda<Func<int, int, int, int, int>>(result, a, b, c, d);

            Console.WriteLine(lambda + "");   //输出‘(i,j,w,x)=>((i*j)+(w*x))’，z对应参数b，p对应参数a

            Func<int, int, int, int, int> f = lambda.Compile();  //将表达式树描述的lambda表达式，编译为可执行代码，并生成该lambda表达式的委托；

            Console.WriteLine(f(1, 1, 1, 1) + "");  //输出结果2
            Console.ReadKey();
        }
    }
    #endregion
}
