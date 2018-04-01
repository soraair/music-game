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

    
	
	void Start ()
	{

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

        this.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("try/" + select);
        Invoke("tryOn",1);
    }

    public void startSound()
    {
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
        this.GetComponent<AudioSource>().Play();
    }
}
