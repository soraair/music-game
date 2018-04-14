using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class getInfo : MonoBehaviour
{

    private Transform image;

    private Transform name;

    private Transform level;
    public GameObject levelLogo;
    private GameObject levelLogoIns;

    private int levelNum = 0;

    private Transform startbutton;
    
    private string select;

    [HideInInspector]
    public AudioSource tryMusic;
	
	void Start ()
	{
        tryMusic = this.GetComponent<AudioSource>();
	    select = ClickChoose.chooseName;
	    name = this.transform.GetChild(0);
	    image = this.transform.GetChild(1);
	    level = this.transform.GetChild(2);
	    startbutton = this.transform.GetChild(3);
	  
	    infoUpdate();

	}
	
	
	void Update () {
	    if (select != ClickChoose.chooseName)
	    {
	        select = ClickChoose.chooseName;
            infoUpdate();
	       
	    }
	}

    public void infoUpdate()
    {
        foreach (Transform child in level)
        {
            Destroy(child.gameObject);
        }
        name.GetComponent<Text>().text = select;
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>("bg/" + select);

        levelNum = GetChoose.level[select];
        while (levelNum>0)
        {
            levelLogoIns = Instantiate(levelLogo);
            levelLogoIns.transform.SetParent(level);
            levelNum--;
        }

        tryMusic.clip = Resources.Load<AudioClip>("try/" + select);
        if (select == "GuiltyCrown" || select == "WeightoftheWorld")
        {
            tryMusic.volume = 0.13f;
        }
        else{
            tryMusic.volume = 0.23f;
        }
        Invoke("tryOn",1);  //循环播放试听
    }

    public void startSound()
    {
        tryMusic.Stop();
        startbutton.GetComponent<AudioSource>().Play();
        GetChoose.level.Clear();
        Invoke("loadScene",1);
    }

    private void loadScene()
    {
        Application.LoadLevel("playing");
    }

    private void tryOn()
    {
        tryMusic.Play();
    }
}
