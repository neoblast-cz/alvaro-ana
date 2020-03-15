using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    public ContentOfBox content;
    bool isUsed;
    void OnTriggerEnter2D(Collider2D collision) {
        if (!isUsed) {
            isUsed = true;
            switch (content)
            {
                case (ContentOfBox.Mushroom):
                    Instantiate(GameAssets.instance.mushroomPf, new Vector3(transform.position.x, transform.position.y + 1.6f, transform.position.z), Quaternion.identity);
                    break;
                case (ContentOfBox.Coin):
                    Instantiate(GameAssets.instance.coinPf, new Vector3(transform.position.x, transform.position.y + 1.4f, transform.position.z), Quaternion.identity);
                    break;
                default:
                    break;
            }
        }
    }
}

public enum ContentOfBox
{
    Mushroom,
    Coin,
}