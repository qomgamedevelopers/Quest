using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class PlayerResources : Singleton<PlayerResources>
{
[System.Serializable]
public class Resource{
public ItemSC Item;
public int Number;

}

public List<Resource> ResourceList;
public bool IsFinishRequired(string _name,int _requiredNumber){
foreach (var item in ResourceList)
{
if(item.Item.Name == _name && item.Number >= _requiredNumber){
return true;
}
}
return false;
}

/// <summary>
/// برگرداندن آیتم با اسم
/// </summary>
/// <param name="_name"></param>
/// <returns></returns>
public Resource GetItemByName(string _name){
foreach (var item in ResourceList)
{
if(_name == item.Item.Name){
return item;
}
}
return null;
}
}
