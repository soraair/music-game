using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public GameObject restartbutton; //get button in pause
    public GameObject rechoosebutton;
    public GameObject resumebutton;

    public GameObject bg;  //get background

    private bool isPause = false;

    void Update()
    {
        if (jiePaiCreate.isEnd == true)
        {
            
          Invoke("endEvent",2);

            jiePaiCreate.isEnd = false;
        }
    }

    public void pause()
    {
        if (isPause) return;
        else isPause = !isPause;
        Time.timeScale = 0;
        musicOff();
        btnSwitch();
       
    }

    private void endEvent()
    {   
        rechoosebutton.active = !rechoosebutton.active;
        restartbutton.active = !restartbutton.active;
    }

    public void restart() //点击重新开始
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("playing");
    }

    public void rechoose()  //点击重新选择歌曲
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Choose");
    }

    public void resume()
    {
        isPause = !isPause;
        Time.timeScale = 1;
        musicOn();
        btnSwitch();
    }
    public void musicOn()
    {
        bg.transform.GetComponent<AudioSource>().UnPause();
    }

    public void musicOff()
    {
        bg.transform.GetComponent<AudioSource>().Pause();
    }

    private void btnSwitch()
    {
        rechoosebutton.active = !rechoosebutton.active;
        restartbutton.active = !restartbutton.active;
        resumebutton.active = !resumebutton.active;
    }

   
}
