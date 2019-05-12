using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTLTMPro;
public class Number : MonoBehaviour
{
public RTLTextMeshPro Text;
public int number;

private void Update() {
    Text.text = number.ToString();
}

public void AddNumber(int value){
number += value;
}
public void SubNumber(int value){
number -= value;   
}
}
