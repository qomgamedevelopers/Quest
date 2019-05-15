using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "UnlockItem", menuName = "DailyReward/UnlockItem", order = 0)]
public class UnlockItem : ItemSC
{
public override void ItemAction(){
    Debug.Log("Test");
}
}
