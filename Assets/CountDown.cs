using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RTLTMPro;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
private float lastTime;
public float Timer;

public bool IsFinishedTimer;
// public GameObject fastUpgradeButton;

// private void OnDisable() {
//    upgradeTimeShowPanel.gameObject.SetActive(false);
//    // fastUpgradeButton.gameObject.SetActive(false);
// }

// private void OnEnable() {
//    upgradeTimeShowPanel.gameObject.SetActive(true);
//    // fastUpgradeButton.gameObject.SetActive(true);
// }


private void Update()
{

   CheckTime();
   }

   public virtual void CheckTime(){
      if(Timer >= 1){
      Timer -= Time.deltaTime;
      }else{
      Timer = 0;
      if(!IsFinishedTimer){
      IsFinishedTimer = true;
      }
      }
   }

   public virtual void OnFinishTimer(){

   }  
}
