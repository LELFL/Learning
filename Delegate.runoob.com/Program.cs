using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate.runoob.com
{
    #region 声明委托
    //public delegate void printString(string s);

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //委托:是存有对某个方法的引用的一种引用类型变量。引用可以在运行时改变
    //        //

    //        printString ps1 = new printString(WritePs1);
    //        printString ps2 = new printString(WritePs2);

    //        ps1("你好");
    //        ps2("世界");
    //        Console.ReadKey();
    //    }

    //    private static void WritePs2(string s)
    //    {
    //        Console.WriteLine("ps2" + s);
    //        Console.ReadKey();
    //    }

    //    private static void WritePs1(string s)
    //    {
    //        Console.WriteLine("Ps1" + s);
    //        Console.ReadKey();
    //    }
    //}
    #endregion

    #region 委托练习
    //public delegate int GetNum(int num);

    //public static class Numbers
    //{
    //    static int num = 10;

    //    public static int Add(int i)
    //    {
    //        num += i;
    //        return num;
    //    }

    //    public static int Qu(int i)
    //    {
    //        num *= i;
    //        return num;
    //    }

    //    public static int GetNumber()
    //    {
    //        return num;
    //    }

    //    static void Main(string[] args)
    //    {
    //        //GetNum num1 = new GetNum(Add);
    //        //GetNum num2 = new GetNum(Qu);
    //        //num1(10);
    //        //Console.WriteLine(num);
    //        //num2(10);
    //        //Console.WriteLine(num);
    //        //Console.ReadKey();

    //        Add(10);
    //        Console.WriteLine(num);
    //        Qu(10);
    //        Console.WriteLine(num);
    //        Console.ReadKey();
    //    }
    #endregion

    #region 多播委托
    //delegate int NumberChanger(int n);
    //class TestDelegate
    //{
    //    static int num = 10;
    //    public static int AddNum(int p)
    //    {
    //        num += p;
    //        return num;
    //    }

    //    public static int MultNum(int q)
    //    {
    //        num *= q;
    //        return num;
    //    }
    //    public static int getNum()
    //    {
    //        return num;
    //    }
    //    static void Main(string[] args)
    //    {
    //        NumberChanger nc;
    //        NumberChanger nc1 = new NumberChanger(AddNum);
    //        NumberChanger nc2 = new NumberChanger(MultNum);
    //        nc = nc1;
    //        nc += nc2;
    //        //调用多播
    //        nc(10);
    //        Console.WriteLine(getNum().ToString());
    //        Console.ReadKey();  
    //    }
    //}
    #endregion

    #region 委托的用途 
    class PrintStrings
    {
        static FileStream fs;
        static StreamWriter sw;

        //委托声明
        public delegate void printString(string s);

        //该方法打印到控制台
        public static void WtiteToScreen(string str)
        {
            Console.WriteLine("The String is :{0}",str);
        }

        //打印到文件
        public static void WriteToFile(string str)
        {
            fs = new FileStream(@"F:\\message.txt",FileMode.Append,FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(str);
            sw.Flush();
            sw.Close();
        }
        //该方法将委托作为参数，并使用它调用方法
        public static void sendString(printString ps)
        {
            ps("Hello World");
        }
        static void Main(string[] vs)
        {
            printString ps1 = new printString(WtiteToScreen);
            printString ps2 = new printString(WriteToFile);
            sendString(ps1);
            sendString(ps2);
            Console.ReadKey();
        }
    }
    #endregion
}



