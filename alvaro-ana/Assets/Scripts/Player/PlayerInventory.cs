using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance { get; private set; }

    private Transform inventory;

    void Awake(){
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        inventory = GameObject.Find("Content_DoNotRename").transform;
    }

    public void GetItem(GameObject whoGives, GameObject givenObject, bool shop){
        GameManager.instance.AddMemoriesCount();
        GameObject memoryPF = (GameObject)Instantiate(givenObject, inventory.position, Quaternion.identity);
        memoryPF.transform.localScale = new Vector3(1, 1, 1);
        memoryPF.transform.parent = inventory;
        memoryPF.name = givenObject.name;

        if (inventory.transform.childCount > 9)
            inventory.gameObject.GetComponent<RectTransform>().sizeDelta = inventory.gameObject.GetComponent<RectTransform>().sizeDelta + new Vector2(75, 0);

        if (shop) {
            UIController.instance.UpdateMessageWithFadeOut("Added to inventory");
            AudioManager.instance.PlaySound(AudioManager.Sound.CashRegister);
        } else {
            //UIController.instance.UpdateMessageWithFadeOut("Memory added");
            AudioManager.instance.PlaySound(AudioManager.Sound.UI_Click);
        }
        UIController.instance.AddToInventoryAnimation(whoGives, false);
    }
}
