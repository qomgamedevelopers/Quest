using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTLTMPro;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
public ItemSC ItemSC;
public Image ItemSprite;
public RTLTextMeshPro Text;
public RTLTextMeshPro lossText;
public GameObject lossObj;
public int Score;

private void Start() {
    Text.text = Score.ToString();
    ItemSprite.sprite = ItemSC.Sprite;
}

public void ReduceReward(){
    Score = (int)(Score*0.2f);
    lossObj.SetActive(true);
    lossText.text = Score.ToString();
}
public void ClaimReward(){
PlayerResources.Instance.AddItemNumber(ItemSC.Name,Score);
}
}
