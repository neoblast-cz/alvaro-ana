using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSize : MonoBehaviour
{
    bool shouldIncreaseSize;
    public Vector3 initialSize;
    float tempSize = 0f;

    void Start() {
        initialSize = transform.localScale;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.E))
            StartGettingBigger();

        if (shouldIncreaseSize)
            GettingBigger();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Mushroom") {
        }
    }

    void StartGettingBigger() {
        shouldIncreaseSize = true;
        Debug.Log("test");
    }

    void GettingBigger()
    {
        if (transform.localScale.x <= 4f) {
            tempSize++;
            Debug.Log(tempSize);
            transform.localScale = new Vector3 (tempSize, tempSize, tempSize);
        } else {
            shouldIncreaseSize = false;
        }
    }
}
