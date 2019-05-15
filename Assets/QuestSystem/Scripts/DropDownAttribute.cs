using System;
using UnityEngine;
 
[AttributeUsage (AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public sealed class DropDownAttribute : PropertyAttribute
{
    public string[] options;


 
    public DropDownAttribute ()
    {
	options = Items.Instance.ItemNames();
    }
}