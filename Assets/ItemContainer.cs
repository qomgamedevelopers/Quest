using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemContainer : MonoBehaviour
{
    // TODO optimising
public List<ItemSC> Items;

private void Update() {
FindUsedItem();
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
    EditorItemWindow.Instance.UsedItems = Items;
}
}
