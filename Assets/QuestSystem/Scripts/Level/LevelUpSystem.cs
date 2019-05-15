using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using RTLTMPro;
public class LevelUpSystem : MonoBehaviour
{
public UpgradeInfoSC upgradeInfoSC;
public RTLTextMeshPro descriptionText;
public RTLTextMeshPro levelText;
public GameObject upgradeRewardsPrefab;
public Transform rewardPos;
public int Level;

private void Start() {
    descriptionText.text = upgradeInfoSC.questList[Level].Description;
    levelText.text = string.Format(" سطح {0}",Level);
    foreach (var reward in upgradeInfoSC.questList[Level].Rewards)
    {
        var rewardSpawn = Instantiate(upgradeRewardsPrefab,rewardPos.transform);
        rewardSpawn.GetComponent<Reward>().ItemSC = reward.ItemSC;
        rewardSpawn.GetComponent<Reward>().Score = reward.Score;
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
    }

}
