using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    
    #region//开始场景
    public void startSound()
    {
        transform.GetComponent<AudioSource>().Play();
    }

    public void sceneTurn()
    {
        Application.LoadLevel("Choose");
    }
    public void OnStart(string sceneName)
    {
        //Debug.LogWarning("asd");

        Invoke("sceneTurn", 2);
        // startButton.transform.GetComponent<AudioSource>().Play();
    }
    #endregion

   

}



