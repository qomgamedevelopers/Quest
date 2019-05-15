using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class PersonList : MonoBehaviour
{
    public Image personImage;
    public Dropdown personDropDown;
    public List<string> personNames = new List<string>();
    public PersonSC currentPerson;
private void Awake() {
    personDropDown = GetComponent<Dropdown>();
 foreach (var person in EditorWindowManager.Instance.personList)
 {
    personNames.Add(person.Name.ToString());
 }
 personDropDown.AddOptions(personNames);
 OnChangedValue();
}


public void OnChangedValue(){
string currentOption = personDropDown.options[personDropDown.value].text;
var persons = EditorWindowManager.Instance.personList.Where(x => x.Name == currentOption);
currentPerson = persons.FirstOrDefault();
personImage.sprite = currentPerson.Sprite;
}

public void SetSelection(PersonSC personSC){
if(personSC != null){
var listAvailableStrings = personDropDown.options.Select(option => option.text).ToList();

personDropDown.value = listAvailableStrings.IndexOf(personSC.Name);
}else{
    Debug.LogError("personSC is Null");
}
}
}
