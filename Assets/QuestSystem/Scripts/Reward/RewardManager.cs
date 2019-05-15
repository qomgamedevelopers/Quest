using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using RTLTMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using QuestSystem;
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
    [BoxGroup("CustomerProfile")]
    public Image customerPhoto;
    [BoxGroup("Information")]
    public RTLTextMeshPro TitleText,DescriptionText;

    public RTLTextMeshPro countDownPreview;

    public int questNumber;
    public bool ClaimReward;
    public UnityEvent OnCompleteMission,OnClaimReward;

    [BoxGroup("CountDown")]
    public bool IsCountDown;
    [BoxGroup("CountDown")]
    public int requiredTime;

    [BoxGroup("CountDown")]
    public GameObject missionTabPos,missionInfonWindow,startMissionPanel;
    [BoxGroup("CountDown")]
    public RTLTextMeshPro countDownText;

    

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

    public MissionCountDown currentMissionCountDown(){
    return missionTabPos.transform.GetChild(questNumber).GetComponent<MissionCountDown>();
    }
    /// <summary>
    /// وقتی روی شروع مأموریت کلیک کرد
    /// </summary>
    public void SetCountDownTime(){
    currentMissionCountDown().IsPreesedButton = true;
    }
    public void LoadMission(int index) {
    RemoveAllMissions();
    questNumber = index;
    IsCountDown = currentMissionInfoSC().questList[questNumber].IsCountDown;
    // if(!countDown.IsFinishedTimer && countDown.Timer == 0){
  
    SetRewardInfo();
    SetMissionInfo();
    CheckIsCountDown();



    // RequiredText.text = string.Format("{0}/{1}",PlayerResources.Instance.GetItemByName(missionInfoSC.Item.Name).Number,dailyMissionSC.requiredNumber.ToString());
	// var _IsFinishedMission = PlayerResources.Instance.IsFinishRequired(dailyMissionSC.Item.Name,dailyMissionSC.requiredNumber);
    questWindow.SetActive(true);
    }

    /// <summary>
    /// اعمال کردن اطلاعات جایزه ها
    /// </summary>
    public void SetRewardInfo(){
     foreach (var item in currentMissionInfoSC().questList[questNumber].Rewards)
     {
    var reward = Instantiate(rewardPrefab,rewardPos.transform);    
     reward.GetComponent<Reward>().ItemSC = item.ItemSC;
     reward.GetComponent<Reward>().Score = item.Score;
     }
    }
    /// <summary>
    /// اعمال کردن اطلاعات مأموریت ها
    /// </summary>
    public void SetMissionInfo(){
    foreach (var item in currentMissionInfoSC().questList[questNumber].Missions)
     {
    var mission = Instantiate(missionPrefab,missionPos.transform);    
     mission.GetComponent<DailyMissionUI>().ItemImage.sprite = item.ItemSC.Sprite;
    //  mission.GetComponent<DailyMissionUI>().RequiredText.text = string.Format("{0}/{1}",PlayerResources.Instance.GetItemByName(item.ItemSC.Name).Number,item.requiredNumber.ToString());
     mission.GetComponent<DailyMissionUI>().ItemNameText.text = item.ItemSC.persianName;

     }
     TitleText.text = currentMissionInfoSC().questList[questNumber].Title;
     DescriptionText.text = currentMissionInfoSC().questList[questNumber].Description;
     customerPhoto.sprite = currentMissionInfoSC().questList[questNumber].personSC.Sprite;
     var requiredTime = currentMissionInfoSC().questList[questNumber].requiredTime;
     if(!currentMissionCountDown().IsPreesedButton){
    currentMissionCountDown().Timer = requiredTime;
     }
    countDownPreview.text = TimeConverter.GetClockTime(requiredTime);


     customerPhoto.SetNativeSize();
    }
    /// <summary>
    /// چک کن ببین تایمر هست یا نه
    /// </summary>
    public void CheckIsCountDown(){

    if(IsCountDown && !currentMissionCountDown().IsPreesedButton){
    startMissionPanel.SetActive(true);   
    missionInfonWindow.SetActive(false);
    } 
    else{
    missionInfonWindow.SetActive(true);
    startMissionPanel.SetActive(false);
    }

    if(IsCountDown){
     countDownText.gameObject.SetActive(true);
    }else{
     countDownText.gameObject.SetActive(false);
    }
    }
    private void Update() {
    for (int i = 0; i < missionPos.transform.childCount; i++)
    {
    missionPos.GetChild(i).GetComponent<DailyMissionUI>().SetItemInfo(currentMissionInfoSC().questList[questNumber],currentMissionInfoSC().questList[questNumber].Missions[i]);
    }

    if(IsCompleteMission() && !ClaimReward){
    Console.Log("Mission OComplete",Color.yellow);


    ClaimReward = true;
    OnCompleteMission.Invoke();
    }
    if(IsCompleteMission()){
    countDownText.gameObject.SetActive(false);
    currentMissionCountDown().StopTimer();
    claimRewardButton.gameObject.SetActive(true);
    }else{
    claimRewardButton.gameObject.SetActive(false);
    }

    displayCountDown();
    }

    /// <summary>
    /// نشون دادن زمان
    /// </summary>
    private void displayCountDown()
    {
    if(currentMissionCountDown().IsPreesedButton){
    countDownText.text = TimeConverter.GetClockTime(currentMissionCountDown().Timer);
    }    
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

    /// <summary>
    /// جریمه کردن تمام جایزه ها
    /// </summary>
    public void ReduceAllRewards(){
    foreach (Transform reward in rewardPos.transform)
    {
    reward.GetComponent<Reward>().ReduceReward();
    }   
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
