using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NaughtyAttributes;
using RTLTMPro;

public class UpgradeRewardDesign : MonoBehaviour
{
public Transform rewardPos;
public Button rewardAddButton;
public TextMeshProUGUI levelNumber;

public InputField descriptionText;
public GameObject Prefab;
public int rewardIndexCounter;

public int upgradeIndex;

private void Start() {
levelNumber.text += " " + upgradeIndex.ToString();
UpgradeEditorWindowManager.Instance.upgradeInfoSC.questList[upgradeIndex].Index = upgradeIndex;  
descriptionText.text = UpgradeEditorWindowManager.Instance.upgradeInfoSC.questList[upgradeIndex].Description;

    foreach (var item in UpgradeEditorWindowManager.Instance.upgradeInfoSC.questList[upgradeIndex].Rewards)
    {
        AddReward(item.ItemSC);
    }
}

private void Update() {
UpgradeEditorWindowManager.Instance.upgradeInfoSC.questList[upgradeIndex].Description = descriptionText.text;
}





public void AddReward(){
var rewardSpawn = Instantiate(Prefab,rewardPos.transform);
var rewardEditorBox = rewardSpawn.GetComponent<UpgradeEditorBox>();
rewardEditorBox.Type = "Reward";
rewardEditorBox.upgradeRewardDesign = this;
rewardEditorBox.Index = rewardIndexCounter;
UpgradeEditorWindowManager.Instance.SetSelection(rewardSpawn);
rewardIndexCounter++;

rewardAddButton.transform.SetAsLastSibling();

}





public void AddReward(ItemSC _ItemSC){
var rewardSpawn = Instantiate(Prefab,rewardPos.transform);
var rewardEditorBox = rewardSpawn.GetComponent<UpgradeEditorBox>();
//rewardEditorBox.Type = "Reward";
rewardEditorBox.upgradeRewardDesign = this;
rewardEditorBox.Index = rewardIndexCounter;
rewardEditorBox.LoadItemInfo(_ItemSC);
rewardIndexCounter++;

rewardAddButton.transform.SetAsLastSibling();
}

}
