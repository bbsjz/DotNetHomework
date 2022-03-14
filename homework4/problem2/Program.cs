using System;
using System.Threading;

namespace problem2
{
    class Program
    {
        public delegate void ClockHandler(Object sender,ClockArgs args);
        class Clock 
        {
            //滴答事件
            public event ClockHandler Tick;
            //响铃事件
            public event ClockHandler Alarm;
            
            //当前时间
            ClockArgs currentTime;
            //滴答间隔（单位：秒）
            int tickSpace;
            //是否设置了闹钟
            public bool ifSet = false;
            //开启按钮
            bool ifWork = false;

            //响铃时间
            public ClockArgs ringTime { get; set; }

            //构造函数
            public Clock(int tickSpace)
            {
                this.tickSpace = tickSpace;
                currentTime = new ClockArgs(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, "initial");
            }
            //定闹钟
            public void setRingTime(int hour,int minute,int second,string msg)
            {
                ifSet = true;
                ringTime = new ClockArgs(hour, minute, second, msg);
            }

            //关闭所定闹钟
            public void stopRing()
            {
                ifSet = false;
            }

            //开启闹钟
            public void start()
            {
                ifWork = true;
                while(ifWork)
                {
                    Thread.Sleep(1000*tickSpace);
                    currentTime.hour = DateTime.Now.Hour;
                    currentTime.minute = DateTime.Now.Minute;
                    currentTime.second = DateTime.Now.Second;
                    Tick(this,currentTime);
                    Alarm(this, currentTime);
                }
            }

            //关闭闹钟
            public void stop()
            {
                ifWork = false;
            }
        }

        public class ClockArgs : EventArgs
        {
            public int hour { get; set; }
            public int minute { get; set; }
            public int second { get; set; }
            public string msg { get; set; } 

            public ClockArgs(int hour,int minute,int second,string msg)
            {
                this.hour = hour;
                this.minute = minute;
                this.second = second;
                this.msg = msg;
            }
        }

        class MyClock
        {
            public Clock myClock;
            public MyClock(int tickSpace)
            {
                myClock = new Clock(tickSpace);
                myClock.Alarm += AlarmEventHandler;
                myClock.Tick += TickEventHandler;
            }
            //滴答函数
            public void TickEventHandler(Object sender, ClockArgs args)
            {
                Console.Write("the clock is ticking,the time now is:" + args.hour + ":" + args.minute + ":" + args.second+"\n");
            }

            //响铃函数
            public void AlarmEventHandler(Object sender, ClockArgs args)
            {
                if (myClock.ifSet&&DateTime.Now.Hour == myClock.ringTime.hour && DateTime.Now.Minute == myClock.ringTime.minute && DateTime.Now.Second == myClock.ringTime.second)
                    Console.Write(args.msg + "the time now is " + args.hour + ":" + args.minute + ":" + args.second);
            }
        }

        static void Main(string[] args)
        {
            //初始化闹钟
            MyClock clock = new MyClock(1);
            
            //定闹钟
            clock.myClock.setRingTime(7, 30, 0, "大懒狗起床了");
            
            Console.WriteLine("请键入start以模拟开启闹钟，键入stop以模拟关闭闹钟");
            
            while (true)
            {
                if(Console.ReadLine()=="start")//开启闹钟
                {
                    Thread threadStart = new Thread(new ThreadStart(clock.myClock.start));
                    threadStart.Start();
                }
                if(Console.ReadLine()=="stop")//停止闹钟
                {
                    Thread threadStop = new Thread(new ThreadStart(clock.myClock.stop));
                    threadStop.Start();
                }
            }
        }
    }
}
