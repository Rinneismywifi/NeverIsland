using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace program1
{
    public delegate void ClockControl(object sender, ClockControlArgs e);

    public class ClockControlArgs : EventArgs
    {
        public int rinneHour;
        public int rinneMin;
        public int rinneSec;
    }

    public class Clock
    {
        public event ClockControl ClockEvent;

        private int rinneHour;
        private int rinneMin;
        private int rinneSec;
        private bool ClockAwake;
        private ClockControlArgs rinneClock;
        private Timer rinneTimer;

        public Clock()
        {
            this.rinneHour = DateTime.Now.Hour;
            this.rinneMin = DateTime.Now.Minute;
            this.rinneSec = DateTime.Now.Second;

            rinneTimer = new Timer(1000);
            rinneTimer.Elapsed += new ElapsedEventHandler(Updata);
            rinneTimer.AutoReset = true;
            rinneTimer.Enabled = true;

            rinneClock = new ClockControlArgs();
            ClockEvent += Alarm;
            ClockAwake = false;
        }

        private void Updata(object source, ElapsedEventArgs e)
        {
            this.rinneSec += 1;
            if (this.rinneSec >= 60)
            {
                this.rinneSec -= 60;
                this.rinneMin += 1;
                if (this.rinneMin >= 60)
                {
                    this.rinneMin -= 60;
                    this.rinneHour += 1;
                    if (rinneHour >= 24)
                    {
                        this.rinneHour -= 24;
                    }
                }
            }
            if (rinneClock.rinneHour == this.rinneHour && rinneClock.rinneMin == this.rinneMin && rinneClock.rinneSec == this.rinneSec && ClockAwake == true)
            {
                ClockEvent(this, rinneClock);
            }
        }

        public void SetTime()
        {
            int rinneHour = 0;
            int rinneMin = 0;
            int rinneSec = 0;
            try
            {
                Console.Write("Input the hour you want to set：");
                rinneHour = int.Parse(Console.ReadLine());
                if (rinneHour >= 24)
                {
                    throw new Exception("some message");
                }
                Console.Write("Input the minute you want to set：");
                rinneMin = int.Parse(Console.ReadLine());
                if (rinneMin >= 60)
                {
                    throw new Exception("some message");
                }
                Console.Write("Input the second you want to set：");
                rinneSec = int.Parse(Console.ReadLine());
                if (rinneSec >= 60)
                {
                    throw new Exception("some message");
                }
            }
            catch
            {
                Console.WriteLine("Input error!!");
                SetTime();
            }
            this.rinneHour = rinneHour;
            this.rinneMin = rinneMin;
            this.rinneSec = rinneSec;
        }

        public void ClockOff()
        {
            ClockAwake = false;
        }

        public void ClockOn()
        {
            ClockAwake = true;
        }

        public void ClockSettings()
        {
            int rinneHour = 0;
            int rinneMin = 0;
            int rinneSec = 0;
            try
            {
                Console.Write("Input the hour of alarm you want to set：");
                rinneHour = int.Parse(Console.ReadLine());
                if (rinneHour >= 24)
                {
                    throw new Exception("some message");
                }
                Console.Write("Input the minute of alarm you want to set：");
                rinneMin = int.Parse(Console.ReadLine());
                if (rinneMin >= 60)
                {
                    throw new Exception("some message");
                }
                Console.Write("Input the second of alarm you want to set：");
                rinneSec = int.Parse(Console.ReadLine());
                if (rinneSec >= 60)
                {
                    throw new Exception("some message");
                }
            }
            catch
            {
                Console.WriteLine("Input error!!");
                ClockSettings();
            }
            this.rinneClock.rinneHour = rinneHour;
            this.rinneClock.rinneMin = rinneMin;
            this.rinneClock.rinneSec = rinneSec;
        }

        private void Alarm(object sender, ClockControlArgs e)
        {
            Console.WriteLine("Alarm Now!!!");
            ShowTime();
        }

        public void ShowTime()
        {
            Console.WriteLine("The current time is：" + this.rinneHour + ":" + this.rinneMin + ":" + this.rinneSec);
        }
    }
}