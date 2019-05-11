using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class EditorWindowManager : Singleton<EditorWindowManager>
{
[OnValueChanged("LoadAllMission")]
public MissionInfoSC missionInfo;
public GameObject missionPrefab;
public Transform missionPos;
//TODO fix Types
public GameObject currentSelection;//جعبه ی انتخاب شده
// public ItemSC currentItem;//آیتم انتخاب شده
public UnityEvent OnSelect;
public UnityEvent OnSelectItem;
public int questIndexCounter = -1;
public List<MissionInfoSC> missionList;

private void Start() {
LoadAllMission();

}

private void Update() {
    missionList = Resources.LoadAll<MissionInfoSC>("Missions").ToList();
    missionList = missionList.OrderBy(x=>x.name).ToList();
}

#if UNITY_EDITOR
public  void CreateMyAsset()
{
    MissionInfoSC asset = ScriptableObject.CreateInstance<MissionInfoSC>();

    var _name = missionList.Count < 10 ? "0"+(missionList.Count+ 1).ToString() : (missionList.Count+ 1).ToString();
        
    UnityEditor.AssetDatabase.CreateAsset(asset, "Assets/Resources/Missions/" + "Level"+ _name + ".asset");
    UnityEditor.AssetDatabase.SaveAssets();
}
#endif
    
public void CreateNewLevel(){
   CreateMyAsset();
  //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

}

public void SetLevel(int index){

    questIndexCounter = -1;
    foreach (Transform item in missionPos.transform)
    {
        
        Destroy(item.gameObject);
    }
missionInfo = missionList[index];
    if(missionInfo.questList != null){

    foreach (var item in missionInfo.questList)
    {
    AddMission(false);    
    }
    }
}

/// <summary>
/// لود کردن مأموریت ها
/// </summary>
public void LoadAllMission(){
    questIndexCounter = -1;
    foreach (Transform item in missionPos.transform)
    {
        
        Destroy(item.gameObject);
    }

    if(missionInfo.questList != null){

    foreach (var item in missionInfo.questList)
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
currentSelection.GetComponent<EditorBox>().SetItemInfo(Item); 
OnSelectItem.Invoke();
}


/// <summary>
/// اضافه کردن مأموریت
/// </summary>
/// <param name="_saveAsset"></param>
public void AddMission(bool _saveAsset){
var spawn = Instantiate(missionPrefab,missionPos.transform);
questIndexCounter++;
spawn.GetComponent<MissionDesign>().missionIndex = questIndexCounter;
if(_saveAsset){
missionInfo.AddQuest();
}

}

}
