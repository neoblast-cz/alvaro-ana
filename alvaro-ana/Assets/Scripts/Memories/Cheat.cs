using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Cheat : MonoBehaviour
{
    private string[] cheatCode;
    private int index;

    private bool used;
    public List<Interactable> listOfPeople;

    void Start() {
        cheatCode = new string[] { "d", "e", "n", "v", "e", "r"};
        index = 0;
        listOfPeople = new List<Interactable>();
        listOfPeople.AddRange(GameObject.FindObjectsOfType<Interactable>());
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
        foreach (Interactable carryingMemory in listOfPeople) {
            carryingMemory.GiveObject();
            listOfPeople.Remove(carryingMemory);
        }
    }

    [MenuItem("Cheats/Get 10 coins")]
    public static void TenCoins()
    {
        GameManager.instance.AddCoins(10);
    }

    [MenuItem("Cheats/Move to the end")]
    public static void MoveToTheEnd()
    {
        GameManager.instance.MovePlayer(GameObject.Find("CheatTeleport_DoNotRename").transform);
    }
}
