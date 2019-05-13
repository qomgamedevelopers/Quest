using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeReward", menuName = "Quest/UpgradeReward", order = 0)]
public class UpgradeInfoSC : ScriptableObject {
//public GameObject misionPrefab;


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
public int Index;

public string Description;
public List<Reward> Rewards = new List<Reward>();

}

[ReorderableList]
public List<Quest> questList = new List<Quest>();    

public void Clear(){
    questList.Clear();
}


public void AddReward(int _questIndex,Reward _reward){
questList[_questIndex].Rewards.Add(_reward);
}

public void AddLevel(){
    questList.Add(new Quest());
}
public void UpdateRewardInfo(int _questIndex,int _rewardIndex,int _number,ItemSC ItemSC){
    questList[_questIndex].Rewards[_rewardIndex].Score = _number;
    questList[_questIndex].Rewards[_rewardIndex].ItemSC = ItemSC;
}



public int GetRewardInfo(int _questIndex,int _rewardIndex){
    return questList[_questIndex].Rewards[_rewardIndex].Score;
}

	private void Update() {
	UnityEditor.EditorUtility.SetDirty(this);
	}

}