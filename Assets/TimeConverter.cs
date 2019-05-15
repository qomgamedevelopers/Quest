using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    
public class TimeConverter 
{
public static string GetClockTime(float Timer){
       TimeSpan t = TimeSpan.FromSeconds( Timer );
       string clockTime = string.Empty;
             if (t.Hours > 0)
        {
            clockTime += string.Format("{0}h ", t.Hours.ToString());
        }
        if (t.Minutes > 0)
        {
            clockTime += string.Format("{0}m ", t.Minutes.ToString());
        }
        if (t.Seconds > 0)
        {
            clockTime += string.Format("{0}s ", t.Seconds.ToString());
        }

        return clockTime;
}
}
}
