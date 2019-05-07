using UnityEngine;
using UnityEditor;
 
[CustomPropertyDrawer (typeof(DropDownAttribute))]
internal sealed class DropDownEditor : PropertyDrawer
{
    public int MyProperty { get; set; }
    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
    {
        
        var MyTarget = (DropDownAttribute)base.attribute;

        property.intValue = EditorGUI.Popup(position,"Label", property.intValue, MyTarget.options);
		EditorGUI.Popup(position,"Label", property.intValue, MyTarget.options); 
    }
}