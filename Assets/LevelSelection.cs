using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelSelection : MonoBehaviour
{
    List<string> DropOptions = new List<string>();
    public List<MissionInfoSC> Missions;
    Dropdown Dropdown;

    void Start()
    {
        Dropdown = GetComponent<Dropdown>();

        //GetCorrespondingMission();
    }
    private void Update() {
        var levels = Resources.LoadAll<MissionInfoSC>("Missions");
        DropOptions.Clear();
        Missions.Clear();
        foreach (var level in levels)
        {
            DropOptions.Add(level.name);
            Missions.Add(level);
        }
        Dropdown.ClearOptions();
        Dropdown.AddOptions(DropOptions);
    }
    public void GetCorrespondingMission(){
        foreach (var mission in Missions)
        {
            if(mission.name == Dropdown.captionText.text){
            EditorWindowManager.Instance.SetLevel(Dropdown.value);
            }
        }
    }
}
