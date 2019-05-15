using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : Singleton<Items> {

public List<ItemSC> ItemSCList;

public string[] ItemNames(){
	var _names = new List<string>();
	foreach (var item in ItemSCList)
	{
	_names.Add(item.Name);
	}
	return _names.ToArray();
}


}
