using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTLTMPro;
using NaughtyAttributes;
public class UpgradeEditorBox : MonoBehaviour
{
public RTLTextMeshPro Text;
public Image Image;
// [OnValueChanged("UpdateTextValue")]

public UpgradeRewardDesign upgradeRewardDesign;
public int Index;

public int Number;
public ItemSC ItemInfo;

public string Type;

public bool IsChangeItem;


private void Start() {
    GetComponent<Button>().onClick.AddListener(()=>{UpgradeEditorWindowManager.Instance.SetSelection(gameObject);UpgradeEditorItemWindow.Instance.ResetUsedItemsList(); IsChangeItem = true;});
    

    if(ItemInfo != null){
    Number = UpgradeEditorWindowManager.Instance.upgradeInfoSC.GetRewardInfo(upgradeRewardDesign.upgradeIndex,Index);

    UpdateTextValue();
}
}

/// <summary>
/// اعمال کردن اطلاعات آیتم
/// </summary>
/// <param name="ItemInfo"></param>
public void SetItemInfo(ItemSC ItemSC){
    ItemInfo = ItemSC;
    Image.sprite = ItemInfo.Sprite;
    Image.SetNativeSize();
    if(IsChangeItem){
        IsChangeItem = false;
        return;
    }
    UpgradeInfoSC.Reward _reward = new UpgradeInfoSC.Reward(ItemInfo,Number);
    UpgradeEditorWindowManager.Instance.upgradeInfoSC.AddReward(upgradeRewardDesign.upgradeIndex,_reward);
    Image.SetNativeSize();
}


public void LoadItemInfo(ItemSC ItemSC){
    ItemInfo = ItemSC;
    Image.sprite = ItemInfo.Sprite;
    Image.SetNativeSize();
    }
private void Update() {
    if(ItemInfo != null){
    UpgradeEditorWindowManager.Instance.upgradeInfoSC.UpdateRewardInfo(upgradeRewardDesign.upgradeIndex,Index,Number,ItemInfo);
    }
}
public void AddNumber(int _number){
Number += _number;
UpdateTextValue();

}
public void SubNumber(int _number){
Number -= _number;
UpdateTextValue();
}

public void UpdateTextValue(){
Number = Mathf.Max(0,Number);
Text.text = Number.ToString();
}
}
