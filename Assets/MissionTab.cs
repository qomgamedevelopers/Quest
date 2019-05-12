using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionTab : MonoBehaviour
{
public bool IsComplete;
private int missionIndex;
private void Start() {
    missionIndex = transform.GetSiblingIndex();
    GetComponent<Button>().onClick.AddListener(()=>RewardManager.Instance.LoadMission(missionIndex));
}

private void Update() {
    if(IsComplete){
    GetComponent<Image>().color = Color.green;
    GetComponent<Button>().interactable = false;
    }
}
}
