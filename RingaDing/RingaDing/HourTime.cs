using System;

public class HourTime
{
    public static int SECONDS_IN_MINUTE = 60;
    public static int MINUTES_IN_HOUR = 60;
    public static int HOURS_IN_DAY = 24;
    
    private int second;
    private int minute;
    private int hour;


    public HourTime()
    {
        Hour = 0;
        Minute = 0;
        Second = 0;
    }

    public HourTime(int seconds)
    {
        Hour   = seconds / SECONDS_IN_MINUTE / MINUTES_IN_HOUR % HOURS_IN_DAY;
        Minute = seconds / SECONDS_IN_MINUTE % MINUTES_IN_HOUR;
        Second = seconds % SECONDS_IN_MINUTE;
    }

    public HourTime(int minute, int second)
    {
        Hour = 0;
        Minute = minute;
        Second = second;
    }

    public HourTime(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
    }

    public int Second
    {
        get
        {
            return second;
        }

        set
        {
            if (value < SECONDS_IN_MINUTE && value >= 0)
                second = value;
            else
                throw new ArgumentOutOfRangeException("there are 0 to " + (SECONDS_IN_MINUTE - 1) + " seconds in a minute", (Exception)null);
        }
    }

    public int Minute
    {
        get
        {
            return minute;
        }

        set
        {
            if (value < MINUTES_IN_HOUR && value >= 0)
                minute = value;
            else
                throw new ArgumentOutOfRangeException("there are 0 to " + (MINUTES_IN_HOUR - 1) + " minuts in an hour", (Exception)null);
        }
    }

    public int Hour
    {
        get
        {
            return hour;
        }

        set
        {
            if (value < HOURS_IN_DAY && value >= 0)
                hour = value;
            else
                throw new ArgumentOutOfRangeException("there are 0 to " + (HOURS_IN_DAY - 1) + " hours in a day", (Exception)null);
        }
    }

    public int getTotalSeconds()
    {
        return Hour * MINUTES_IN_HOUR * SECONDS_IN_MINUTE + Minute * SECONDS_IN_MINUTE + Second;
    }

    public bool isNow()
    {
        DateTime now = DateTime.Now;
        return now.Hour == Hour && now.Minute == Minute && now.Second == Second;
    }

    public static HourTime Parse(string str)
    {
        string[] arg = str.Split(':');

        if (arg.Length != 3)
            throw new Exception("The string is not in the format \"HH:MM:SS\"");

        return new HourTime(int.Parse(arg[0]), int.Parse(arg[1]), int.Parse(arg[2]));
    }

    public static HourTime Add(HourTime ht1, HourTime ht2)
    {
        return new HourTime(ht1.getTotalSeconds() + ht2.getTotalSeconds());
    }

    public static HourTime Decrease(HourTime ht1, HourTime ht2)
    {
        int sec = ht1.getTotalSeconds() - ht2.getTotalSeconds();

        if (sec < 0)
            sec = HOURS_IN_DAY * MINUTES_IN_HOUR * SECONDS_IN_MINUTE + sec;

        return new HourTime(sec);
    }

    public static bool isParsable(string str)
    {
        try
        {
            Parse(str);
        }
        catch
        {
            return false;
        }
        return true;
    }

    #region operators overload

    public static HourTime operator +(HourTime ht1, HourTime ht2)
    {
        return HourTime.Add(ht1, ht2);
    }

    public static HourTime operator +(HourTime ht1, int sec)
    {
        return ht1 + new HourTime(sec);
    }

    public static HourTime operator -(HourTime ht1, HourTime ht2)
    {
        return HourTime.Decrease(ht1, ht2);
    }

    public static HourTime operator -(HourTime ht1, int sec)
    {
        return ht1 + new HourTime(sec);
    }

    public static bool operator >(HourTime ht1, HourTime ht2)
    {
        return ht1.getTotalSeconds() > ht2.getTotalSeconds();
    }

    public static bool operator >(HourTime ht, int sec)
    {
        return ht.getTotalSeconds() > sec;
    }

    public static bool operator >(int sec, HourTime ht1)
    {
        return sec > ht1.getTotalSeconds();
    }

    public static bool operator <(HourTime ht1, HourTime ht2)
    {
        return ht1.getTotalSeconds() < ht2.getTotalSeconds();
    }

    public static bool operator <(HourTime ht, int sec)
    {
        return ht.getTotalSeconds() < sec;
    }

    public static bool operator <(int sec, HourTime ht)
    {
        return sec < ht.getTotalSeconds();
    }
    #endregion

    public override bool Equals(object obj)
    {
        return getTotalSeconds() == ((HourTime)obj).getTotalSeconds();
    }

    public override string ToString()
    {
        return (Hour   < 10 ? "0" : "") + Hour.ToString()   + ':' +
               (Minute < 10 ? "0" : "") + Minute.ToString() + ':' +
               (Second < 10 ? "0" : "") + Second.ToString();
    }
}