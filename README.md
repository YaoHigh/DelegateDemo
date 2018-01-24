1、委托是什么

　　委托是一个类，它定义了方法的类型，使得可以将方法当作另一个方法的参数来进行传递，这种将方法动态地赋给参数的做法，可以避免在程序中大量使用If-Else(Switch)语句，同时使得程序具有更好的可扩展性。

   1.2 委托分类：

　　1.单播委托：绑定单个方法

　　2.多播委托：绑定多个方法

2、为什么使用委托

　　开发人员可以把方法的引用封装在委托对象中（把过程的调用转化为对象的调用，充分体现了委托加强了面向对象编程的思想），然后把委托对象传递给需要引用方法的代码，这样在编译的过程中我们并不知道调用了哪个方法，这样一来，C#引入委托机制后，使得方法声明和方法实现的分离，充分体现了面向对象的编程思想。

3、委托怎么用

    3.1  委托的定义其实很简单：如下，首先新建一个控制台程序，然后进行如下操作，

   （1）、新建了一个类用来 定义委托以及进行委托声明

　         我们应该注意一点：委托的形参类型，形参个数和委托的返回值必须与将要绑定的方法的形参类型，形参个数和返回值一致；

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
　　（2）、委托的方法绑定以及调用

                   在控制台程序 Program.cs中添加如下代码：

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
            gm.delegate1 = new Program().Write1; //先给委托类型的变量赋值
            gm.delegate1 += Program.Write2; //给此委托变量再绑定一个静态方法
            gm.SayHello(1, 2);  // 将先后调用 Write1 与 Write2 方法
            Console.ReadKey();
        }
    }
运行，输出结果如下：



3.2   如上操作我们进行了委托的操作，主要两步操作：声明委托和注册方法(也叫绑定方法)

　　1.声明委托   用delegate声明；

       2.绑定方法    绑定具体方法，传递方法名称；

3.3  如上操作我们知道了委托可以进行方法绑定，同样的委托也可以进行方法解绑：如下我们只修改 Program.cs中的main方法。

      在原有的基础上添加解绑方法 -= 

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
运行结果如下：委托仅仅执行了Write1。



 3.4 什么是委托链

　　换言之就是多播委托就可以产生委托链，以+= 和-=操作符分别进行绑定和解除绑定的操作，多个方法绑定到委托变量就形成了一个委托链。对其进行调用的时，将依次调用所有回调的方法。

4、总结

      委托就是一个类，他的好处非常多，比如避免核心方法中存在大量的if....else....语句(或swich开关语句)；满足程序设计的OCP原则；使程序具有扩展性；结合Lambda表达式，简化代码，高效编程；实现程序的松耦合(解耦)，这个在事件(event)中体现比较明显等等。

委托扩展了我们的认知面，让我们进一步了解c#的博大精深。
