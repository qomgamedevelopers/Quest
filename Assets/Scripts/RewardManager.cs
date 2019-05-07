using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class RewardManager : MonoBehaviour
{
    public GameObject rewardObj;
    [System.Serializable]
    public class RequireItem{
    public ItemSC ItemSC;
    public int Score;
    }

    [ReorderableList]
    public List<RequireItem> requireItem;

    private void Start() {
     foreach (var item in requireItem)
     {
    var reward = Instantiate(rewardObj,transform);    
     reward.GetComponent<Reward>().ItemSprite.sprite = item.ItemSC.Sprite;
     reward.GetComponent<Reward>().RequiredItem = item.Score;

     }
    }
}
