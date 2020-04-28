using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Transform inventory;

    void Awake()
    {
        inventory = GameObject.Find("Content_DoNotRename").transform;
    }

    public void GetItem(GameObject objectGO, bool shop)
    {
        GameObject memoryPF = (GameObject)Instantiate(objectGO, inventory.position, Quaternion.identity);
        memoryPF.transform.localScale = new Vector3(1, 1, 1);
        memoryPF.transform.parent = inventory;
        memoryPF.name = objectGO.name;

        if (inventory.transform.childCount > 9)
            inventory.gameObject.GetComponent<RectTransform>().sizeDelta = inventory.gameObject.GetComponent<RectTransform>().sizeDelta + new Vector2(150, 0);

        if (shop) {
            UIController.instance.UpdateMessageWithFadeOut("Added to inventory");
            AudioManager.instance.PlaySound(AudioManager.Sound.CashRegister);
        } else {
            UIController.instance.UpdateMessageWithFadeOut("Memory added");
            AudioManager.instance.PlaySound(AudioManager.Sound.UI_Click);
        }
        
    }
}
