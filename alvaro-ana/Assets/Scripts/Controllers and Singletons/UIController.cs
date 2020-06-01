using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text memories;

    [SerializeField] RectTransform inventoryTransform;
    [SerializeField] CanvasGroup inventoryCanvasGroup;

    [SerializeField] GameObject addToInventoryAnimItem;
    [SerializeField] RectTransform addToInventoryTo;
    [SerializeField] RectTransform addToCoins;

    SpriteRenderer blackBackground;
    Animator blackBackgroundAnimator;

    GameObject messageParent;
    GameObject messageSticky;
    GameObject uI;

    bool inventoryIsOpened;

    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        //activate intro screen
        GameAssets.instance.introMenu.SetActive(true);

        messageParent = GameObject.Find("UI_Message_DoNotRename");
        uI = GameObject.Find("UI_DoNotRename");
        LeanTween.moveY(inventoryTransform, 200f, .5f);
        inventoryIsOpened = false;
        addToInventoryAnimItem.GetComponent<TrailRenderer>().enabled = false;
        LeanTween.alphaCanvas(inventoryCanvasGroup, 0f, 0.5f);

        GameObject blackBackgroundGO = GameObject.Find("BlackBackground_DoNotRename");

        blackBackground = blackBackgroundGO.GetComponent<SpriteRenderer>();
        blackBackground.enabled = true;
        blackBackgroundAnimator = blackBackgroundGO.GetComponent<Animator>();
        RemoveBackgroundOverlay();
    }

    public void AddToInventoryAnimation(GameObject GOfrom, bool isCoin) {
        addToInventoryAnimItem.gameObject.transform.position = GOfrom.transform.position;
        RectTransform destinationTransform;

        if (!isCoin) {
            addToInventoryAnimItem.GetComponent<Image>().sprite = GameAssets.instance.flyingMemory;
            destinationTransform = addToInventoryTo;
        }
        else {
            addToInventoryAnimItem.GetComponent<Image>().sprite = GameAssets.instance.flyingCoin;
            destinationTransform = addToCoins;
        }

        addToInventoryAnimItem.GetComponent<TrailRenderer>().enabled = true;

        LeanTween.alpha(addToInventoryAnimItem, 1f, 0.2f);

        LeanTween.scale(addToInventoryAnimItem, new Vector3(1.1f, 1.1f, 1.1f), .5f);

        LeanTween.move(addToInventoryAnimItem, destinationTransform, 0.5f).setDelay(0.5f);

        LeanTween.scale(addToInventoryAnimItem, new Vector3(0.01f, 0.01f, 0.01f), .1f).setDelay(1f);
        LeanTween.alpha(addToInventoryAnimItem, 1f, 0.2f).setDelay(1.1f).setOnComplete(() => { addToInventoryAnimItem.GetComponent<TrailRenderer>().enabled = false; } );
        
    }

    public void UpdateRingsScore(int newScore, int totalNumberOfRigngs) {
        score.text = newScore.ToString() + "/" + totalNumberOfRigngs;
        score.color = Color.white;
    }

    public void UpdateMemoriesCount(int newAmount, int totalAmountOfMemories) {
        memories.text = newAmount.ToString() + "/" + totalAmountOfMemories + " | press [i] to open";
        memories.color = Color.white;
    }

    public void AddBackgroundOverlay() {
        blackBackgroundAnimator.SetTrigger("FadeIn");
    }

    public void RemoveBackgroundOverlay() {
        blackBackgroundAnimator.SetTrigger("FadeOut");
    }

    public void InventorySwitch() {
        if (!inventoryIsOpened) {
            // open inventory
            inventoryIsOpened = !inventoryIsOpened;
            LeanTween.moveY(inventoryTransform, 0f, .5f);
            //LeanTween.alphaCanvas(inventoryCanvasGroup, 0f, 0.5f);
        } else {
            // close inventory
            inventoryIsOpened = !inventoryIsOpened;
            LeanTween.moveY(inventoryTransform, 200f, .2f);
            //LeanTween.alphaCanvas(inventoryCanvasGroup, 1f, 0.2f); ;
        }
    }

    public void UpdateMessageWithFadeOut(string actualMessage) {
        GameObject message = Instantiate(GameAssets.instance.messagingSystemWithFadeOutPF, messageParent.transform, messageParent.transform);
        message.transform.parent = messageParent.transform;
        message.GetComponent<TMP_Text>().text = actualMessage.ToString();

        Destroy(message, 6f);
    }

    public void UpdateMessageSticky(string actualMessage, bool initiate) {
        if (initiate) {
            messageSticky = Instantiate(GameAssets.instance.messagingSystemPF, messageParent.transform, messageParent.transform);
            messageSticky.transform.parent = messageParent.transform;
            messageSticky.GetComponent<TMP_Text>().text = actualMessage.ToString();
            messageSticky.GetComponent<TMP_Text>().color = Color.white;
        }
        else {
            Destroy(messageSticky);
        }
    }

    public void HideUI() {
        uI.SetActive(false);
    }

    public void ShowUI() {
        uI.SetActive(true);
    }
}