/*
 * 简单的委托
 */ 

using System;

namespace DelegateDemo
{
    public class Program
    {
        public void Write1(int x, int y)
        {
            Console.WriteLine("{0}+{1}={2}", x, y, x + y);
        }

        public static void Write2(int x, int y)
        {
            Console.WriteLine("{0}*{1}={2}", x, y, x * y);
        }

        static void Main(string[] args)
        {
            GManage gm = new GManage();
            gm.delegate1 += new Program().Write1; //先给委托类型的变量赋值
            gm.delegate1 += Program.Write2; //给此委托变量再绑定一个静态方法
            gm.SayHello(1, 2);  // 将先后调用 Write1 与 Write2 方法

            Console.WriteLine("******解绑方法Write2后******");
            gm.delegate1 -= Program.Write2; // 委托方法解绑
            gm.SayHello(1, 2);  // 解绑后只会调用 Write1
            Console.ReadKey();
        }
    }

    public class GManage
    {
        /// <summary>
        /// 1、定义委托，它定义了可以代表的方法的类型
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public delegate void GreetingDelegate(int x, int y);

        /// <summary>
        /// 2、声明delegate1变量
        /// </summary>
        public GreetingDelegate delegate1;

        /// <summary>
        /// 3、被调用委托的方法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SayHello(int x,int y)
        {
            if (delegate1 != null) //如果有方法注册委托变量
            {
                delegate1(x, y); //通过委托调用方法
            }
        }
    }
}
