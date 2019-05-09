using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EditorWindowManager : Singleton<EditorWindowManager>
{
public MissionInfo missionInfo;
public GameObject missionPrefab;
public Transform missionPos;
//TODO fix Types
public GameObject currentSelection;//جعبه ی انتخاب شده
// public ItemSC currentItem;//آیتم انتخاب شده
public UnityEvent OnSelect;
public UnityEvent OnSelectItem;
public int questIndexCounter = -1;


private void Start() {
    foreach (var item in missionInfo.questList)
    {
    AddMission(false);    
    }
}


public void SetSelection(GameObject selection){
currentSelection = selection;
OnSelect.Invoke();
}

public void SetItemSelection(ItemSC Item){
currentSelection.GetComponent<EditorBox>().SetItemInfo(Item); 
OnSelectItem.Invoke();
}



public void AddMission(bool _saveAsset){
var spawn = Instantiate(missionPrefab,missionPos.transform);
questIndexCounter++;
spawn.GetComponent<MissionDesign>().missionIndex = questIndexCounter;
if(_saveAsset){
missionInfo.AddQuest();
}

}

}
