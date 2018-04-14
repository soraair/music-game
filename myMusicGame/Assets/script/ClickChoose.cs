using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickChoose : MonoBehaviour
{
    
    public static string chooseName= "EveonPiano";
    public void click()
    {
        Transform music = this.transform.GetChild(1);
        chooseName= music.GetComponent<Text >().text;//获取所选音乐的名字
        //print(chooseName);
        
    }

}
