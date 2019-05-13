using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeEditorItem : MonoBehaviour
{
public ItemSC Item;

private void Start() {
    GetComponent<Button>().onClick.AddListener(()=> UpgradeEditorWindowManager.Instance.SetItemSelection(Item));
}
}
