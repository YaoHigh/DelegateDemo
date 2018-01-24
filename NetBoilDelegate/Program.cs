/*
 * 7. .Net Framework中的委托与事件
 */
using System;

namespace NetBoilDelegate
{
    /// <summary>
    /// 定义BoiledEventArgs类，传递给Observer所感兴趣的信息
    /// </summary>
    public class BoiledEventArgs : EventArgs
    {
        public readonly int temp;
        public BoiledEventArgs(int temp)
        {
            this.temp = temp;
        }
    }

    public class Heater
    {
        public string type = "美的";
        public string area = "合肥";

        /// <summary>
        /// 1、定义一个委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DeaterDetegate(object sender, BoiledEventArgs e);

        /// <summary>
        /// 2、申明一个事件
        /// </summary>
        public event DeaterDetegate Boiled;

        // 可以供继承自 Heater 的类重写，以便继承类拒绝其他对象对它的监视
        protected virtual void OnBoiled(BoiledEventArgs e)
        {
            if (Boiled != null) // 如果有对象注册
            { 
                Boiled(this, e);  // 调用所有注册对象的方法
            }
        }

        public void OnBoied()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i > 95)
                {
                    BoiledEventArgs e = new BoiledEventArgs(i); //建立BoiledEventArgs 对象。
                    OnBoiled(e); // 调用 OnBolied方法
                }
            }
        }
    }

    public class Alert
    {
        public void MakeAlert(object sender,BoiledEventArgs e)
        {
            Heater heater = (Heater)sender;
            Console.WriteLine("Alert:品牌：{0},地区：{1},当前温度{2}", heater.type, heater.area, e.temp);
        }
    }

    public class Show
    {
        public static void MakeShow(object sender, BoiledEventArgs e)
        {
            Heater heater = (Heater)sender;
            Console.WriteLine("Show:品牌：{0},地区：{1},当前温度{2}", heater.type, heater.area, e.temp);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Heater heater = new Heater();
            Alert alert = new Alert();

            heater.Boiled += alert.MakeAlert; //注册方法
            heater.Boiled += (new Alert()).MakeAlert; //给匿名对象注册方法
            heater.Boiled += new Heater.DeaterDetegate(alert.MakeAlert);//也可以这么注册
            heater.Boiled += Show.MakeShow; //注册静态方法

            heater.OnBoied();
            Console.ReadKey();
        }
    }



}
