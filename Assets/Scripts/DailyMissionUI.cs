using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTLTMPro;
using UnityEngine.UI;
public class DailyMissionUI : MonoBehaviour {
public int requiredNumber;
public Image ItemImage;
public DailyMissionSC dailyMissionSC;
public RTLTextMeshPro RequiredText,DescriptionText;
public GameObject Tick;



private void Start() {
Initialize();
}

public void Initialize(){
	GenerateRequiredNumber();
	DescriptionText.text = dailyMissionSC.Description.ToString();
	ItemImage.sprite = dailyMissionSC.Item.Sprite;
}
private void Update() {
	RequiredText.text = string.Format("{0}/{1}",PlayerResources.Instance.GetItemByName(dailyMissionSC.Item.Name).Number,requiredNumber.ToString());
	var _IsFinishedMission = PlayerResources.Instance.IsFinishRequired(dailyMissionSC.Item.Name,requiredNumber);
	if(_IsFinishedMission){
	GetComponent<Image>().color = Color.green;
	Tick.SetActive(true);
	}
}

    public void GenerateRequiredNumber() {
       if(requiredNumber == 0){
       requiredNumber = Random.Range(dailyMissionSC.randomRequiredNumber.x,dailyMissionSC.randomRequiredNumber.y);
       }
    }

}
