using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EditorItem : MonoBehaviour
{
public ItemSC Item;

private void Start() {
    GetComponent<Button>().onClick.AddListener(()=> EditorWindowManager.Instance.SetItemSelection(Item));
}
}
