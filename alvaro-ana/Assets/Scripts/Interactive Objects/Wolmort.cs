using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolmort : MonoBehaviour
{
    private Transform inventory;

    private SpriteRenderer spriteRenderer;
    private Sprite shopClosedSprite;
    public Sprite shopOpenedSprite;
    public GameObject shopOptions;
    private GameObject shopOptionsInstantiated; // will be instantiated
    private Vector3 offset = new Vector3(0f, 1.3f, 0f);
    private bool shopActive;

    public int priceOfItem1 = 1;
    public int priceOfItem2 = 5;
    public int priceOfItem3 = 10;
    public int priceOfItem4 = 15;

    private bool purchased1;
    private bool purchased2;
    private bool purchased3;
    private bool purchased4;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shopClosedSprite = spriteRenderer.sprite;
        inventory = GameObject.Find("Content_DoNotRename").transform;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (!shopActive) {
            spriteRenderer.sprite = shopOpenedSprite;
            CreateUIWindow();
            shopActive = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        spriteRenderer.sprite = shopClosedSprite;
        DestroyUIWindow();
        shopActive = false;
    }

    void Update() {
        if (Input.anyKeyDown && shopActive) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                if (!purchased1) {
                    if (GameManager.instance.ReturnNumberOfRings() >= priceOfItem1) {
                        purchased1 = true;
                        GameManager.instance.RemoveCoins(priceOfItem1);
                        PurchasedObjectAddedToInventory(GameAssets.instance.shopZelda);
                    }
                    else
                        UIController.instance.UpdateMessageWithFadeOut("Not enough coins.");
                }
                else {
                    AudioManager.instance.PlaySound(AudioManager.Sound.UI_Error);
                    UIController.instance.UpdateMessageWithFadeOut("You've already bought this useless item.");
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                if (!purchased2) {
                    if (GameManager.instance.ReturnNumberOfRings() >= priceOfItem2) {
                        purchased2 = true;
                        GameManager.instance.RemoveCoins(priceOfItem2);
                        PurchasedObjectAddedToInventory(GameAssets.instance.shopRingSilver);
                    }
                    else
                        UIController.instance.UpdateMessageWithFadeOut("Not enough coins");
                }
                else {
                    AudioManager.instance.PlaySound(AudioManager.Sound.UI_Error);
                    UIController.instance.UpdateMessageWithFadeOut("You've already bought this");
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha3)) {
                if (!purchased3) {
                    if (GameManager.instance.ReturnNumberOfRings() >= priceOfItem3) {
                        purchased3 = true;
                        GameManager.instance.RemoveCoins(priceOfItem3);
                        PurchasedObjectAddedToInventory(GameAssets.instance.shopRingGolden);
                    }
                    else
                        UIController.instance.UpdateMessageWithFadeOut("Not enough coins");
                }
                else {
                    AudioManager.instance.PlaySound(AudioManager.Sound.UI_Error);
                    UIController.instance.UpdateMessageWithFadeOut("You've already bought this");
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha4)) {
                if (!purchased4) {
                    if (GameManager.instance.ReturnNumberOfRings() >= priceOfItem4) {
                        purchased4 = true;
                        GameManager.instance.RemoveCoins(priceOfItem4);
                        PurchasedObjectAddedToInventory(GameAssets.instance.shopRingDiamond);
                    }
                    else
                        UIController.instance.UpdateMessageWithFadeOut("Not enough coins");
                }
                else {
                    AudioManager.instance.PlaySound(AudioManager.Sound.UI_Error);
                    UIController.instance.UpdateMessageWithFadeOut("You've already bought this");
                }
            }
        }
    }


    private void CreateUIWindow() {
        AudioManager.instance.PlaySound(AudioManager.Sound.ShopDoorBell);

        shopOptionsInstantiated = Instantiate(shopOptions, transform.position + offset, transform.rotation);
        shopOptionsInstantiated.transform.parent = gameObject.transform;
        //UIDialogueWindowTexts = wolmortShopOptions.GetComponentsInChildren<TMP_Text>();
        UIController.instance.UpdateMessageWithFadeOut("You should get the best ring you can afford. You know... for the lady");
        CameraController.instance.StartZoomIn(2.5f, 4f);
        UIController.instance.AddBackgroundOverlay();
    }

    private void DestroyUIWindow() {
        Destroy(shopOptionsInstantiated);
        UIController.instance.UpdateMessageSticky("", false);
        CameraController.instance.StartZoomOut(2.5f, 4f);
        UIController.instance.RemoveBackgroundOverlay();
    }

    public void PurchasedObjectAddedToInventory(GameObject shopItem) {
        GameObject memoryPF = (GameObject)Instantiate(shopItem, inventory.position, Quaternion.identity);
        memoryPF.transform.localScale = new Vector3(1, 1, 1);
        memoryPF.transform.parent = inventory;
        memoryPF.name = shopItem.name;
        UIController.instance.UpdateMessageWithFadeOut("Added to inventory");
        AudioManager.instance.PlaySound(AudioManager.Sound.CashRegister);
    }
}
