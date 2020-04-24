using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    private string[] cheatCode;
    private int index;

    private bool used;
    public List<NPC> listOfPeople;

    void Start() {
        cheatCode = new string[] { "a", "l", "v", "a", "r", "o"};
        index = 0;
        listOfPeople = new List<NPC>();
        listOfPeople.AddRange(GameObject.FindObjectsOfType<NPC>());
    }

    void Update() {
        if (Input.anyKeyDown && !used) {
            if (Input.GetKeyDown(cheatCode[index])) {
                index++;
            }
            else {
                index = 0;
            }
        }
        if (index == cheatCode.Length) {
            if (!used) {
                CheatActivated();
                used = true;
            }
        }
    }

    void CheatActivated() {
        Debug.Log("cheat activated");
        foreach (NPC men in listOfPeople) {
            men.GiveObject();
        }
    }
}
