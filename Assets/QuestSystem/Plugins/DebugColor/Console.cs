using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : Debug
{
public static void Log(string _message,Color _color){
ColorUtility.ToHtmlStringRGB(_color);
Debug.Log(string.Format("<color=#{0}>{1}</color>",ColorUtility.ToHtmlStringRGB(_color),_message));
}
}
