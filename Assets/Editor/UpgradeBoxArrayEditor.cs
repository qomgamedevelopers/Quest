using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UpgradeInfoSC))]
public class UpgradeBoxArrayEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
var myTarget = (UpgradeInfoSC)target;

for (int i = 0; i < myTarget.questList.Count; i++)
{
    GUILayout.BeginVertical();
    GUILayout.Label("Level " + i.ToString(),EditorStyles.boldLabel);
    GUILayout.EndVertical();


    GUILayout.BeginVertical();

    var rewards = myTarget.questList[i].Rewards;

    GUILayout.BeginVertical();
    GUILayout.Label("Rewards " + i.ToString(),EditorStyles.boldLabel);
    GUILayout.EndVertical();
    GUILayout.BeginHorizontal();

    foreach (var reward in rewards)
    {
    reward.ItemSC.Sprite = (Sprite)EditorGUILayout.ObjectField(GUIContent.none, reward.ItemSC.Sprite, typeof(Sprite), allowSceneObjects: false, options:GUILayout.Width(55));
           GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();     
    reward.ItemSC.Name = EditorGUILayout.TextField(reward.ItemSC.Name.ToString());
        GUILayout.EndHorizontal();
    reward.Score = EditorGUILayout.IntField(reward.Score);
    GUILayout.EndVertical();
    
    }
    GUILayout.EndHorizontal();

}
GUILayout.EndVertical();

EditorGUILayout.Space ();
}
    
}
