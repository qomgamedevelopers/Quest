using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
public class ItemSC : ScriptableObject {
	public string Name;
	public Sprite Sprite;
	public string persianName;
	public float sellPrice;
	public string Id;
	
	/// <summary>
	/// سازنده
	/// </summary>
	public ItemSC(){
	Id = GUIDManager.GUID;
	}
	private void Update() {
	#if UNITY_EDITOR
	UnityEditor.EditorUtility.SetDirty(this);
	#endif
	}

	public virtual void ItemAction(){

	}

}