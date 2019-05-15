using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PersonSC", menuName = "Quest/Person", order = 3)]
public class PersonSC : ScriptableObject {
	public string Name;
	public Sprite Sprite;
	public string persianName;
	public string Id;
	
	/// <summary>
	/// سازنده
	/// </summary>
	public PersonSC(){
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