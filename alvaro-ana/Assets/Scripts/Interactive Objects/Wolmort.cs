using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolmort : MonoBehaviour
{
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
                PurchaseItem(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                PurchaseItem(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3)) {
                PurchaseItem(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4)) {
                PurchaseItem(4);
            }
        }
    }

    private void PurchaseItem(float itemPurchased) {
        if (itemPurchased == 1) {
            if (!purchased1) {
                if (GameManager.instance.ReturnNumberOfRings() >= priceOfItem1) {
                    purchased1 = true;
                    GameManager.instance.RemoveCoins(priceOfItem1);
                    PlayerInventory.instance.GetItem(GameAssets.instance.shopZelda, true);
                }
                else
                    UIController.instance.UpdateMessageWithFadeOut("Not enough coins.");
            }
            else {
                AudioManager.instance.PlaySound(AudioManager.Sound.UI_Error);
                UIController.instance.UpdateMessageWithFadeOut("You've already bought this useless item.");
            }
        }
        if (itemPurchased == 2) {
            if (!purchased2) {
                if (GameManager.instance.ReturnNumberOfRings() >= priceOfItem2) {
                    purchased2 = true;
                    GameManager.instance.RemoveCoins(priceOfItem2);
                    PlayerInventory.instance.GetItem(GameAssets.instance.shopRingSilver, true);
                }
                else
                    UIController.instance.UpdateMessageWithFadeOut("Not enough coins");
            }
            else {
                AudioManager.instance.PlaySound(AudioManager.Sound.UI_Error);
                UIController.instance.UpdateMessageWithFadeOut("You've already bought this");
            }
        }
        if (itemPurchased == 3) {
            if (!purchased3) {
                if (GameManager.instance.ReturnNumberOfRings() >= priceOfItem3) {
                    purchased3 = true;
                    GameManager.instance.RemoveCoins(priceOfItem3);
                    PlayerInventory.instance.GetItem(GameAssets.instance.shopRingGolden, true);
                }
                else
                    UIController.instance.UpdateMessageWithFadeOut("Not enough coins");
            }
            else {
                AudioManager.instance.PlaySound(AudioManager.Sound.UI_Error);
                UIController.instance.UpdateMessageWithFadeOut("You've already bought this");
            }
        }
        if (itemPurchased == 4) {
            if (!purchased4) {
                if (GameManager.instance.ReturnNumberOfRings() >= priceOfItem4) {
                    purchased4 = true;
                    GameManager.instance.RemoveCoins(priceOfItem4);
                    PlayerInventory.instance.GetItem(GameAssets.instance.shopRingDiamond, true);
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

        private void CreateUIWindow() {
            AudioManager.instance.PlaySound(AudioManager.Sound.ShopDoorBell);

            shopOptionsInstantiated = Instantiate(shopOptions, transform.position + offset, transform.rotation);
            shopOptionsInstantiated.transform.parent = gameObject.transform;
            CameraController.instance.StartZoomIn(2.5f, 4f);
            UIController.instance.AddBackgroundOverlay();
        }

        private void DestroyUIWindow() {
            Destroy(shopOptionsInstantiated);
            UIController.instance.UpdateMessageSticky("", false);
            CameraController.instance.StartZoomOut(2.5f, 4f);
            UIController.instance.RemoveBackgroundOverlay();
        }
    }