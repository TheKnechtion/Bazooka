using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGame : MonoBehaviour
{

    GameObject GameManager;

    GameObject Player;

    GameObject Main_Camera;

    private void Awake()
    {
        
        if(GameObject.Find("GameManager") == null) 
        {
            SetGameObjectName(Instantiate(LoadPrefabFromString("GameManager")), "GameManager");

            SetGameObjectName(Instantiate(LoadPrefabFromString("Player")), "Player");

            SetGameObjectName(Instantiate(LoadPrefabFromString("Main Camera")), "Main Camera");

        }
    }

    GameObject LoadPrefabFromString(string prefabName)
    {
        return Resources.Load(prefabName) as GameObject;
    }

    void SetGameObjectName(GameObject gameObject, string nameToChangeTo)
    {
        gameObject.name = nameToChangeTo;
    }


}
