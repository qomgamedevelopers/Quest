using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EditorItemWindow : Singleton<EditorItemWindow>
{
private Items Items;
public GameObject ItemPrefab;
public Transform editorWindow;
public ItemContainer currentItemContainer;
public List<ItemSC> UsedItems;
public List<GameObject> InventoryItems;

private void Start() {
    Items = GetComponent<Items>();
    InitializeItems();
}

/// <summary>
/// اعمال کردن آیتم های استفاده شده
/// </summary>
/// <param name="ItemContainer"></param>
public void SetUsedItems(ItemContainer ItemContainer){
currentItemContainer = ItemContainer;
UsedItems = ItemContainer.Items;
}

/// <summary>
/// پاک کردن محتویات لیست آیتم های استفاده شده
/// </summary>
public void ResetUsedItemsList(){
UsedItems.Clear();
currentItemContainer.Items.Clear();
}

/// <summary>
/// اضافه کردن آیتم ها به لیست
/// </summary>
public void InitializeItems(){

		
	foreach (var item in Items.ItemSCList)
	{

	var newItem = Instantiate(ItemPrefab,editorWindow.transform);
    newItem.GetComponent<Image>().sprite = item.Sprite;
	newItem.GetComponent<Image>().SetNativeSize();
	newItem.GetComponent<EditorItem>().Item = item;
	InventoryItems.Add(newItem);
	}
	}

private void Update() {
	FilterUnselectedItems();
}
public void FilterUnselectedItems(){
foreach (var item in InventoryItems)
{
item.SetActive(true);	
}

foreach (var InventoryItem in InventoryItems)
{
foreach (var usedItem in UsedItems)
{
	if(usedItem == InventoryItem.GetComponent<EditorItem>().Item){
	InventoryItem.SetActive(false);
	}
}
}
	// foreach (var item in InventoryItems)
	// {
	// foreach (var selectedItem in EditorWindowManager.Instance.currentItemContainer.Items)
	// {
	// 		if(item.GetComponent<EditorItem>().Item == selectedItem){
	// 			item.gameObject.SetActive(false);
	// 		}
	// 	}
	// }
	//var CommonList = InventoryItems.Intersect(EditorWindowManager.Instance.currentItemContainer.Items);
}
}

