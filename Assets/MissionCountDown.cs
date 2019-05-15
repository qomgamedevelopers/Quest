using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCountDown : CountDown
{
public bool IsPreesedButton;
public override void OnFinishTimer(){
RewardManager.Instance.ReduceAllRewards();
}

public override void CheckTime(){
    if(!IsPreesedButton){
        return;
    }
    base.CheckTime();
}
}
