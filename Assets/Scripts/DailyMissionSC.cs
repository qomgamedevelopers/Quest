using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "DailyMission", menuName = "DailyMission", order = 0)]
public class DailyMissionSC : ScriptableObject {

    public int Level;


    [DropDownAttribute]
    [OnValueChanged("OnValueChanged")]
    public int selectIndex;
    public ItemSC Item;

    public string Description;


    // public bool IsRandom;
    //[ShowIf("IsnRandom")]

    // [ShowIf("IsRandom")]
    public Vector2Int randomRequiredNumber;
    public string Id;


    /// <summary>
    /// تولید میزان مورد نیاز به صورت رندوم
    /// </summary>

    // public void GenerateRequiredNumber() {
    //    if(IsRandom && requiredNumber == 0){
    //    requiredNumber = Random.Range(randomRequiredNumber.x,randomRequiredNumber.y);
    //    }
    // }


    public void OnValueChanged(){
    Item = Items.Instance.ItemSCList[selectIndex]; 
    }

    // public bool IsnRandom(){
    //     return !IsRandom;
    // }

    public DailyMissionSC(){
        Id = GUIDManager.GUID;

    }
}