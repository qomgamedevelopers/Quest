using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionInfoSC", menuName = "DailyRequest/MissionInfoSC", order = 0)]
public class MissionInfo : ScriptableObject {
//public GameObject misionPrefab;
[System.Serializable]
public class Mission{
public ItemSC ItemSC;

public int requiredNumber;

/// <summary>
/// کلاس سازنده ی مأموریت
/// </summary>
/// <param name="_ItemSC"> آیتم</param>
/// <param name="_requireNumber">تعداد مورد نیاز</param>
public Mission(ItemSC _ItemSC,int _requireNumber){
    ItemSC = _ItemSC;
    requiredNumber = _requireNumber;
}
}
[System.Serializable]
public class Reward{
public ItemSC ItemSC;
public int Score;

/// <summary>
/// کلاس سازنده ی جایزه
/// </summary>
/// <param name="_ItemSC">آیتم</param>
/// <param name="_score">امتیاز</param>
public Reward(ItemSC _ItemSC,int _score){
ItemSC = _ItemSC;
Score = _score;
}
}
[System.Serializable]
public class Quest{
public List<Mission> Missions = new List<Mission>();
public List<Reward> Rewards = new List<Reward>();



}

[ReorderableList]
public List<Quest> questList;    

[Button]
public void AddQuest(){
    questList.Add(new Quest());
}

[Button]
public void Clear(){
    questList.Clear();
}

// public void AddMission(){
// questList.Add(new Quest());
// }

// /// <summary>
// /// اضافه کردن کوئست
// /// </summary>
// /// <param name="_questIndex"></param>
// /// <param name="_mission"></param>
// /// <param name="_reward"></param>
// public void AddMission(int _questIndex,Mission _mission,Reward _reward){
// questList[_questIndex].Missions.Add(_mission);
// questList[_questIndex].Rewards.Add(_reward);
// }
public void AddMission(int _questIndex,Mission _mission){
questList[_questIndex].Missions.Add(_mission);
}

public void AddReward(int _questIndex,Reward _reward){
questList[_questIndex].Rewards.Add(_reward);
}

public void UpdateQuestInfo(int _questIndex,int _missionIndex,int _number){
    questList[_questIndex].Missions[_missionIndex].requiredNumber = _number;
}

public void UpdateRewardInfo(int _questIndex,int _rewardIndex,int _number){
    questList[_questIndex].Rewards[_rewardIndex].Score = _number;
}


public int GetQuestInfo(int _questIndex,int _missionIndex){
    return questList[_questIndex].Missions[_missionIndex].requiredNumber;
}

public int GetRewardInfo(int _questIndex,int _rewardIndex){
    return questList[_questIndex].Rewards[_rewardIndex].Score;
}

	private void Update() {
	UnityEditor.EditorUtility.SetDirty(this);
	}

}