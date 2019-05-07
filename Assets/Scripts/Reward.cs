using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTLTMPro;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
public Image ItemSprite;
public RTLTextMeshPro Text;
public int RequiredItem;

private void Start() {
    Text.text = RequiredItem.ToString();
}
}
