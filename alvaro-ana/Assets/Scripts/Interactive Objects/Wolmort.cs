using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolmort : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Sprite wolmortClosed;
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
        wolmortClosed = spriteRenderer.sprite;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (!shopActive) {
            spriteRenderer.sprite = GameAssets.instance.walmortOpened;
            CreateUIWindow();
            shopActive = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        spriteRenderer.sprite = wolmortClosed;
        DestroyUIWindow();
        shopActive = false;
    }

    void Update() {
        if (Input.anyKeyDown && shopActive) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                if (!purchased1) {
                    if (GameManager.instance.ReturnNumberOfRings() >= priceOfItem1) {
                        purchased1 = true;
                        UIController.instance.UpdateMessageWithFadeOut("Why did you buy this?");
                        AudioManager.instance.PlaySound(AudioManager.Sound.CashRegister);
                    }
                    else
                        UIController.instance.UpdateMessageWithFadeOut("You don't have enough rings.");
                }
                else
                    AudioManager.instance.PlaySound(AudioManager.Sound.UI_Error);
                    UIController.instance.UpdateMessageWithFadeOut("You've already bought this useless item.");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && !purchased2) {
                purchased2 = true;
                Debug.Log("option 2");
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && !purchased3) {
                purchased3 = true;
                Debug.Log("option 3");
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && !purchased4) {
                purchased4 = true;
                Debug.Log("option 4");
            }
        }
    }


    private void CreateUIWindow() {
        AudioManager.instance.PlaySound(AudioManager.Sound.ShopDoorBell);

        shopOptionsInstantiated = Instantiate(shopOptions, transform.position + offset, transform.rotation);
        shopOptionsInstantiated.transform.parent = gameObject.transform;
        //UIDialogueWindowTexts = wolmortShopOptions.GetComponentsInChildren<TMP_Text>();
        UIController.instance.UpdateMessageWithFadeOut("You should get the best ring you can afford. You know... for the lady.");
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
