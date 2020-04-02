using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController instance;

    private Animator animator;
    bool inventory;
    [SerializeField] private GameObject[] memories;

    void Start() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        animator = GameObject.Find("UI_DoNotRename").GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            InventorySwitch();
        }   
    }
    public void InventorySwitch()
    {
        animator.SetBool("inventory", !inventory);
        inventory = !inventory;
    }
}
