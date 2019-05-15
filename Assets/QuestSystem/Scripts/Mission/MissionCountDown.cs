using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCountDown : CountDown
{
public bool IsPreesedButton;
public bool IsStopTimer;


public override void CheckTime(){
    if(!IsPreesedButton || IsStopTimer){
        return;
    }
    base.CheckTime();
}
public override void OnLateDelivery(){
if(!IsFinishedTimer){
    RewardManager.Instance.ReduceAllRewards();
   IsFinishedTimer = true;
   }
}
/// <summary>
/// متوقف کردن تایمر
/// </summary>
public void StopTimer(){
 IsStopTimer = true;   
}
}
