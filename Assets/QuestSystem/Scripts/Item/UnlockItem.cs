using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "UnlockItem", menuName = "Quest/UnlockItem", order = 4)]
public class UnlockItem : ItemSC
{
public override void ItemAction(){
    Debug.Log("Test");
}
}
