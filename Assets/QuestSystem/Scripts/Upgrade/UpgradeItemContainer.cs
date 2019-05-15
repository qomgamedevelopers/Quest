using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeItemContainer : MonoBehaviour
{
    // TODO optimising
public List<ItemSC> Items;
//public bool shouldFindUsedItem;

private void Update() {
// if(shouldFindUsedItem){
FindUsedItem();
// }else{
// Items.Clear();    
// }
}

public void FindUsedItem(){
Items.Clear();
foreach (Transform item in transform.parent)
{
if(item.gameObject.GetComponent<UpgradeEditorBox>() != null && item.gameObject.GetComponent<UpgradeEditorBox>().ItemInfo != null){
Items.Add(item.gameObject.GetComponent<UpgradeEditorBox>().ItemInfo);    
}
}
}

public void AddToUsedItems(){
    UpgradeEditorItemWindow.Instance.SetUsedItems(this);
}
}
