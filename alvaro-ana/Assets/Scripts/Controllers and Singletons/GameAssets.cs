using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instance;

    void Awake()
    {
        if (instance != null) //Singleton Pattern
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [Header("UI")]
    public GameObject backgroundOverlayPf;
    public GameObject dialoguePf;
    

    [Header("Objects")]
    public GameObject mushroomPf;
    public GameObject coinPf;
}
