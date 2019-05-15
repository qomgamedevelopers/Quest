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
public Number QueueNumber;
public GameObject Prefab;
public PersonList personList;
public int questIndexCounter;
public int rewardIndexCounter;


public int missionIndex;

private void Start() {
questText.text += " " + missionIndex.ToString();
rewardText.text += " " + missionIndex.ToString();
QueueNumber.number = EditorWindowManager.Instance.missionInfo.questList[missionIndex].groupID;
// print(EditorWindowManager.Instance.missionInfo.questList[missionIndex].groupID.ToString());
personList.SetSelection(EditorWindowManager.Instance.missionInfo.questList[missionIndex].personSC);  
EditorWindowManager.Instance.missionInfo.questList[missionIndex].Index = missionIndex;  
titleText.text = EditorWindowManager.Instance.missionInfo.questList[missionIndex].Title;
descriptionText.text = EditorWindowManager.Instance.missionInfo.questList[missionIndex].Description;

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
EditorWindowManager.Instance.missionInfo.questList[missionIndex].Title = titleText.text;
EditorWindowManager.Instance.missionInfo.questList[missionIndex].Description = descriptionText.text;
EditorWindowManager.Instance.missionInfo.questList[missionIndex].groupID = QueueNumber.number;
EditorWindowManager.Instance.missionInfo.questList[missionIndex].personSC = personList.currentPerson;  

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
