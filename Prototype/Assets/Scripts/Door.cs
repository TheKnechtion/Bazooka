using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    bool roomCleared = false;

    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {


        if(collision.gameObject.tag == "Player" && roomCleared) { SceneManager.LoadSceneAsync(this.name); }
    }
}
