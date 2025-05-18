using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    private static PlayerManager _instance;
    public static PlayerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerManager();
            }
            return _instance;
        }
    }

    public GameObject NearGameObject
    {
        get;
        private set;
    }

    public void NearGameObjectSet(GameObject nearGameObject)
    {
        NearGameObject = nearGameObject;
    }



}
