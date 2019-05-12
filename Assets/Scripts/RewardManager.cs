using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using RTLTMPro;
using UnityEngine.UI;
using UnityEngine.Events;
// TODO Change the name of this class
public class RewardManager : Singleton<RewardManager>
{
    [BoxGroup("Level")]
    public int Level;
    [BoxGroup("Level")]
    public List<MissionInfoSC> levelList;
    //[BoxGroup("Level")]
    //public MissionInfoSC missionInfoSC;
    [BoxGroup("QuestWindow")]
    public GameObject questWindow;
    [BoxGroup("QuestWindow")]
    public Button claimRewardButton;
    [BoxGroup("Prefab")]
    public GameObject rewardPrefab,missionPrefab;
    [BoxGroup("Position")]
    public Transform rewardPos,missionPos;
    [BoxGroup("Information")]
    public RTLTextMeshPro TitleText,DescriptionText;
    public int questNumber;
    public bool ClaimReward;
    public UnityEvent OnCompleteMission,OnClaimReward;
    

private void Start() {
    LoadMission(0);
}

    public void LoadNextMission(){
    Level++;
    LoadMission(0);     
    }

    public MissionInfoSC currentMissionInfoSC(){
    return levelList[Level];
    }

    public void LoadMission(int index) {
    RemoveAllMissions();
    questNumber = index;
     foreach (var item in currentMissionInfoSC().questList[questNumber].Rewards)
     {
    var reward = Instantiate(rewardPrefab,rewardPos.transform);    
     reward.GetComponent<Reward>().ItemSC = item.ItemSC;
     reward.GetComponent<Reward>().Score = item.Score;
     }

    foreach (var item in currentMissionInfoSC().questList[questNumber].Missions)
     {
    var mission = Instantiate(missionPrefab,missionPos.transform);    
     mission.GetComponent<DailyMissionUI>().ItemImage.sprite = item.ItemSC.Sprite;
    //  mission.GetComponent<DailyMissionUI>().RequiredText.text = string.Format("{0}/{1}",PlayerResources.Instance.GetItemByName(item.ItemSC.Name).Number,item.requiredNumber.ToString());
     mission.GetComponent<DailyMissionUI>().ItemNameText.text = item.ItemSC.persianName;
     }
     TitleText.text = currentMissionInfoSC().questList[questNumber].Title;
     DescriptionText.text = currentMissionInfoSC().questList[questNumber].Description;

    // RequiredText.text = string.Format("{0}/{1}",PlayerResources.Instance.GetItemByName(missionInfoSC.Item.Name).Number,dailyMissionSC.requiredNumber.ToString());
	// var _IsFinishedMission = PlayerResources.Instance.IsFinishRequired(dailyMissionSC.Item.Name,dailyMissionSC.requiredNumber);
    questWindow.SetActive(true);
    }

    private void Update() {

    for (int i = 0; i < missionPos.transform.childCount; i++)
    {
    missionPos.GetChild(i).GetComponent<DailyMissionUI>().SetItemInfo(currentMissionInfoSC().questList[questNumber],currentMissionInfoSC().questList[questNumber].Missions[i]);
    }

    if(IsCompleteMission() && !ClaimReward){
    Debug.Log("<color=yellow>Mission OComplete</color>");
    ClaimReward = true;
    OnCompleteMission.Invoke();
    }
    claimRewardButton.gameObject.SetActive(IsCompleteMission());


    }

    public void RemoveAllMissions(){
        foreach (Transform missionObj in missionPos.transform)
        {
            Destroy(missionObj.gameObject);
        }
        foreach (Transform rewardPos in rewardPos.transform)
        {
            Destroy(rewardPos.gameObject);
        }
    }

    /// <summary>
    /// گرفتن تمام جوایز
    /// </summary>
    public void ClaimAllRewards(){
    foreach (Transform reward in rewardPos.transform)
    {
    reward.GetComponent<Reward>().ClaimReward();
    }
    ClaimReward = false;
    OnClaimReward.Invoke();
    MissionQueueManager.Instance.SetCompleteMission(questNumber);
    // RemoveAllMissions();
    // questNumber++;
    // LoadMission();
    }



    public bool IsCompleteMission(){
    foreach (Transform mission in missionPos.transform)
    {
    if(!mission.gameObject.GetComponent<DailyMissionUI>().IsDone){
    return false;
    }
    }
    return true;    
    }
}
