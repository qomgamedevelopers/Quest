using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class UpgradeEditorWindowManager : Singleton<UpgradeEditorWindowManager>
{
[OnValueChanged("LoadAllMission")]
public UpgradeInfoSC upgradeInfoSC;
public GameObject upgradePrefab;
public Transform upgradePos;
//TODO fix Types
public GameObject currentSelection;//جعبه ی انتخاب شده
// public ItemSC currentItem;//آیتم انتخاب شده
public UnityEvent OnSelect;
public UnityEvent OnSelectItem;
public int questIndexCounter = -1;

private void Start() {
LoadAllUpgradeRewards();

}


#if UNITY_EDITOR
public  void CreateMyAsset()
{
    MissionInfoSC asset = ScriptableObject.CreateInstance<MissionInfoSC>();

    UnityEditor.AssetDatabase.CreateAsset(asset, "Assets/Resources/UpgradeLevelRewards/" + "Level" + ".asset");
    UnityEditor.AssetDatabase.SaveAssets();
}
#endif
    
public void CreateNewLevel(){
   CreateMyAsset();
  //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

}

public void SetLevel(int index){

    questIndexCounter = -1;
    foreach (Transform item in upgradePos.transform)
    {
        
        Destroy(item.gameObject);
    }
// upgradeInfo = missionList[index];
    // if(missionInfo.questList != null){

    // foreach (var item in missionInfo.questList)
    // {
    // AddMission(false);    
    // }
    // }
}

/// <summary>
/// لود کردن مأموریت ها
/// </summary>
public void LoadAllUpgradeRewards(){
    questIndexCounter = -1;
    foreach (Transform item in upgradePos.transform)
    {
        
        Destroy(item.gameObject);
    }

    if(upgradeInfoSC.questList != null){

    foreach (var item in upgradeInfoSC.questList)
    {
    AddMission(false);    
    }
    }
}

/// <summary>
/// اعمال کردن انتخاب کنونی
/// </summary>
/// <param name="selection"></param>
public void SetSelection(GameObject selection){
currentSelection = selection;
OnSelect.Invoke();
}

/// <summary>
/// اعمال کردن آیتم کنونی
/// </summary>
/// <param name="Item"></param>
public void SetItemSelection(ItemSC Item){
currentSelection.GetComponent<UpgradeEditorBox>().SetItemInfo(Item); 
OnSelectItem.Invoke();
}


/// <summary>
/// اضافه کردن مأموریت
/// </summary>
/// <param name="_saveAsset"></param>
public void AddMission(bool _saveAsset){
var spawn = Instantiate(upgradePrefab,upgradePos.transform);
questIndexCounter++;
spawn.GetComponent<UpgradeRewardDesign>().upgradeIndex = questIndexCounter;
if(_saveAsset){
upgradeInfoSC.AddLevel();
}

}

}
