using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTLTMPro;
using UnityEngine.UI;
using NaughtyAttributes;

// TODO Change the name of this class
public class DailyMissionUI : MonoBehaviour {
public bool IsDone;
public Image ItemImage;
public RTLTextMeshPro RequiredText,ItemNameText;
public GameObject Tick;




// private void Start() {
// Initialize();
// }

// public void Initialize(){
// 	//DescriptionText.text = dailyMissionSC.Description.ToString();
// 	//ItemImage.sprite = dailyMissionSC.Item.Sprite;
// }
// // public void SetMissionInfo(string _name,int requiredNumber){

// // }

public void SetItemInfo(MissionInfoSC.Quest _quest,MissionInfoSC.Mission _mission){
	RequiredText.text = string.Format("{0}/{1}",PlayerResources.Instance.GetItemByName(_mission.ItemSC.Name).Number,_mission.requiredNumber.ToString());
	var _IsFinishedMission = PlayerResources.Instance.IsFinishRequired(_mission.ItemSC.Name,_mission.requiredNumber);
	if(_IsFinishedMission){
	GetComponent<Image>().color = Color.green;
	Tick.SetActive(true);
	IsDone = _IsFinishedMission;
	}
}

}
