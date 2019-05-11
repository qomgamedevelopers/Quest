using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NaughtyAttributes;
using RTLTMPro;

public class MissionDesign : MonoBehaviour
{
public Transform questPos,rewardPos;
public Button questAddButton,rewardAddButton;
public TextMeshProUGUI questText,rewardText;

public InputField titleText,descriptionText;
public GameObject Prefab;
public int questIndexCounter;
public int rewardIndexCounter;

public int missionIndex;

private void Start() {
    questText.text += " " + missionIndex.ToString();
    rewardText.text += " " + missionIndex.ToString();

titleText.text = EditorWindowManager.Instance.missionInfo.questList[missionIndex].Missions[0].Title;
descriptionText.text = EditorWindowManager.Instance.missionInfo.questList[missionIndex].Missions[0].Description;

    foreach (var item in EditorWindowManager.Instance.missionInfo.questList[missionIndex].Missions)
    {
        AddQuest(item.ItemSC);
    }

    foreach (var item in EditorWindowManager.Instance.missionInfo.questList[missionIndex].Rewards)
    {
        AddReward(item.ItemSC);
    }
}

private void Update() {
EditorWindowManager.Instance.missionInfo.questList[missionIndex].Missions[0].Title = titleText.text;
EditorWindowManager.Instance.missionInfo.questList[missionIndex].Missions[0].Description = descriptionText.text;
}

public void AddQuest(){

var questSpawn = Instantiate(Prefab,questPos.transform);
var questEditorBox = questSpawn.GetComponent<EditorBox>();
questEditorBox.Type = "Mission";
questEditorBox.missionDesign = this;
questEditorBox.Index = questIndexCounter;
EditorWindowManager.Instance.SetSelection(questSpawn);
questIndexCounter++;

questAddButton.transform.SetAsLastSibling();
}




public void AddReward(){
var rewardSpawn = Instantiate(Prefab,rewardPos.transform);
var rewardEditorBox = rewardSpawn.GetComponent<EditorBox>();
rewardEditorBox.Type = "Reward";
rewardEditorBox.missionDesign = this;
rewardEditorBox.Index = rewardIndexCounter;
EditorWindowManager.Instance.SetSelection(rewardSpawn);
rewardIndexCounter++;

rewardAddButton.transform.SetAsLastSibling();

}




public void AddQuest(ItemSC _ItemSC){

var questSpawn = Instantiate(Prefab,questPos.transform);
var questEditorBox = questSpawn.GetComponent<EditorBox>();
questEditorBox.Type = "Mission";
questEditorBox.missionDesign = this;
questEditorBox.Index = questIndexCounter;
questEditorBox.LoadItemInfo(_ItemSC);
questIndexCounter++;

questAddButton.transform.SetAsLastSibling();
}

public void AddReward(ItemSC _ItemSC){
var rewardSpawn = Instantiate(Prefab,rewardPos.transform);
var rewardEditorBox = rewardSpawn.GetComponent<EditorBox>();
rewardEditorBox.Type = "Reward";
rewardEditorBox.missionDesign = this;
rewardEditorBox.Index = rewardIndexCounter;
rewardEditorBox.LoadItemInfo(_ItemSC);
rewardIndexCounter++;

rewardAddButton.transform.SetAsLastSibling();
}

}
