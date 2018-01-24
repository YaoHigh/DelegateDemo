/*
 * 6.3 实现范例的Observer设计模式
 */

using System;

namespace BoilDelegate
{
    class Program
    {
        public static void Show(int x)
        {
            Console.WriteLine("Show：嘀嘀嘀，水已经 {0} 度了：", x);
        }

        public static void Alert(int x)
        {
            Console.WriteLine("Alarm：嘀嘀嘀，水已经 {0} 度了：", x);
        }

        static void Main(string[] args)
        {
            Heater heater = new Heater();
            heater.boilHandler += Show; //注册方法
            heater.boilHandler += Alert; //注册方法

            heater.Boil();

            Console.ReadKey();
        }
    }

    public class Heater 
    {
        /// <summary>
        /// 1、定义一个委托
        /// </summary>
        /// <param name="x"></param>
        public delegate void BoilHandler(int x);

        /// <summary>
        /// 2、声明一个事件
        /// </summary>
        public event BoilHandler boilHandler;

        /// <summary>
        /// 3、定义一个调用委托的方法
        /// </summary>
        /// <param name="x"></param>
        public void Boil()
        {
            for (int i = 0; i <= 100; i++)
            {
                if (i > 95)
                {
                    if (boilHandler != null)//如果有对象注册
                    {
                        boilHandler(i); //调用所有注册对象的方法
                    }
                }
            }
        }
    }
}
