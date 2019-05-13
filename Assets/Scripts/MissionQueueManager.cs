using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NaughtyAttributes;
public class MissionQueueManager : Singleton<MissionQueueManager>
{
private MissionInfoSC missionInfoSC;
public GameObject missionTabPrefab;
public int currentQueue;
public bool loadNextLevel;



[ReorderableList]
public List<List<MissionInfoSC.Quest>> questGroups;
private void Start() {
   missionInfoSC = RewardManager.Instance.currentMissionInfoSC();

   questGroups = missionInfoSC.questList
    .GroupBy(u => u.groupID)
    .Select(grp => grp.ToList()) .ToList();
    CreateMissionsTab();
}

public void CreateMissionsTab(){
    foreach (Transform child in transform)
    {
    Destroy(child.gameObject);    
    }
    for (int i = 0; i < missionInfoSC.questList.Count; i++)
   {
    var spawnMissionTab = Instantiate(missionTabPrefab,transform);
       
   }
}

private void Update() {
ActiveCurrentQueue();
if(IsAllMisssionComplete() && !loadNextLevel){
    Debug.Log("<color=green>Mission OComplete</color>");
    RewardManager.Instance.LoadNextMission();
    loadNextLevel = true;
    missionInfoSC = RewardManager.Instance.currentMissionInfoSC();
    CreateMissionsTab();
    currentQueue = 0;
}
}

public void ActiveCurrentQueue(){
    foreach (var item in questGroups[currentQueue])
   {
       if(IsMissionsComplete() && currentQueue < questGroups[currentQueue].Count){
       currentQueue++;    
       }
       transform.GetChild(item.Index).gameObject.SetActive(true);
   }
}

public bool IsMissionsComplete(){
    foreach (var item in questGroups[currentQueue])
   {
    if(!transform.GetChild(item.Index).GetComponent<MissionTab>().IsComplete){
        return false;
    }
   }
    return true;
}

/// <summary>
/// آیا تمام مأموریت ها انجام شده است؟
/// </summary>
/// <returns></returns>
public bool IsAllMisssionComplete(){
    foreach (Transform mission in transform)
    {
    if(!mission.GetComponent<MissionTab>().IsComplete){
        return false;
    }
    }
    return true;
}


/// <summary>
/// انجام مأموریت
/// </summary>
/// <param name="index"></param>
public void SetCompleteMission(int index){
transform.GetChild(index).GetComponent<MissionTab>().IsComplete = true;
}
}
