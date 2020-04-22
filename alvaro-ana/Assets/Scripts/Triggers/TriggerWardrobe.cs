using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWardrobe : MonoBehaviour
{
    public GameObject leftSide;
    public GameObject openedDoor;

    void Start(){        
        openedDoor.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        leftSide.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.openDoor;
        openedDoor.SetActive(true);

        GameObject puff = (GameObject)Instantiate(GameAssets.instance.smokePF, transform.position, transform.rotation);
        puff.transform.localScale = new Vector3(2f, 2f, 2f);
        Destroy(puff, 2f);
    }
}