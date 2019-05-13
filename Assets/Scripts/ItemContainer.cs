using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemContainer : MonoBehaviour
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
if(item.gameObject.GetComponent<EditorBox>() != null && item.gameObject.GetComponent<EditorBox>().ItemInfo != null){
Items.Add(item.gameObject.GetComponent<EditorBox>().ItemInfo);    
}
}
}

public void AddToUsedItems(){
    EditorItemWindow.Instance.SetUsedItems(this);
}
}
