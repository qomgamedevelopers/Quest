using UnityEditor;
using UnityEngine;

namespace NaughtyAttributes.Editor
{
    //[FoldOutGrouper(typeof(BoxGroupAttribute))]
    public class FoldOutGrouperPropertyGrouper : FoldOutGrouper
    {
    public override void BeginGroup(string label)
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);

            if (!string.IsNullOrEmpty(label))
            {
                EditorGUILayout.LabelField(label, EditorStyles.boldLabel);
            }
        }

        public override void EndGroup()
        {
            EditorGUILayout.EndVertical();
        }
    }
}
