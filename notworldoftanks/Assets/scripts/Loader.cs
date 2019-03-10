﻿using UnityEngine;


public class Loader : MonoBehaviour
{
    public GameManager GameManager;          //GameManager prefab to instantiate.


    void Awake()
    {
        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (GameManager.instance == null)
            Instantiate(GameManager);
    }
}
