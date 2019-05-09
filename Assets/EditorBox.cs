﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTLTMPro;
using NaughtyAttributes;
public class EditorBox : MonoBehaviour
{
public RTLTextMeshPro Text;
public Image Image;
// [OnValueChanged("UpdateTextValue")]

public MissionDesign missionDesign;
public int Index;

public int Number;
public ItemSC ItemInfo;

public string Type;


private void Start() {
    GetComponent<Button>().onClick.AddListener(()=>EditorWindowManager.Instance.SetSelection(gameObject));

        if(ItemInfo != null){
    if(Type == "Mission"){
    Number = EditorWindowManager.Instance.missionInfo.GetQuestInfo(missionDesign.missionIndex,Index);
    }else if(Type == "Reward"){
    Number = EditorWindowManager.Instance.missionInfo.GetRewardInfo(missionDesign.missionIndex,Index);
    }
    UpdateTextValue();
}
}

/// <summary>
/// اعمال کردن اطلاعات آیتم
/// </summary>
/// <param name="ItemInfo"></param>
public void SetItemInfo(ItemSC ItemSC){
    ItemInfo = ItemSC;
    Image.sprite = ItemInfo.Sprite;
    if(Type == "Mission"){
    MissionInfo.Mission _mission = new MissionInfo.Mission(ItemInfo,Number);
    EditorWindowManager.Instance.missionInfo.AddMission(missionDesign.missionIndex,_mission);
    }else if(Type == "Reward"){
    MissionInfo.Reward _reward = new MissionInfo.Reward(ItemInfo,Number);
    EditorWindowManager.Instance.missionInfo.AddReward(missionDesign.missionIndex,_reward);    
    }
    Image.SetNativeSize();
}


public void LoadItemInfo(ItemSC ItemSC){
    ItemInfo = ItemSC;
    Image.sprite = ItemInfo.Sprite;
    Image.SetNativeSize();
    }
private void Update() {

    if(ItemInfo != null){
    if(Type == "Mission"){
    EditorWindowManager.Instance.missionInfo.UpdateQuestInfo(missionDesign.missionIndex,Index,Number);
    }else if(Type == "Reward"){
    EditorWindowManager.Instance.missionInfo.UpdateRewardInfo(missionDesign.missionIndex,Index,Number);
    }
    }
    


}
public void AddNumber(int _number){
Number += _number;
UpdateTextValue();

}
public void SubNumber(int _number){
Number -= _number;
UpdateTextValue();
}

public void UpdateTextValue(){
Number = Mathf.Max(0,Number);
Text.text = Number.ToString();
}
}
