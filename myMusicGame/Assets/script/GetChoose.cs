using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class GetChoose : MonoBehaviour {

    public GameObject chooseMusic;//挂载的选项
    private GameObject chooseMusicIns;//实例化出的选项
    private string chooseName;//选择的音乐的名字

    Vector3 temp;
    private float dx = 0;

    private float dy = 0;
   public static  Dictionary<string, int> level = new Dictionary<string, int>();

    void Start ()
	{
	    
	    Transform musicImage;//承载音乐对应图片的载体
	    Transform musicName;//承载音乐对应的名字的载体

        string[] musicInfo = new string[6];                         //File.ReadAllLines("musicData1.txt");//获得所有音乐的名字
        musicInfo[0] = "EveonPiano";
        musicInfo[1] = "6";
        musicInfo[2] = "WeightoftheWorld";
        musicInfo[3] = "7";
        musicInfo[4] = "GuiltyCrown";
        musicInfo[5] = "8";

        List<string> name=new List<string>();
	    for (int i = 0; i < musicInfo.Length; i=i+2)
	    {
	       
	        name.Add(musicInfo[i]) ;
	    }

	    

        for (int i = 1; i < musicInfo.Length; i=i+2)
	    {
            level.Add(musicInfo[i-1],Int32.Parse(musicInfo[i]));
	    }
       

        //foreach (var temp in musicInfo)//遍历所有音乐名
        //{
        //    print(temp);

        //}
        int musicNumber = 0;
	    int musicNumMax = name.Count;
	    while (true)//生成所有音乐选项
	    {
	        chooseMusicIns = Instantiate(chooseMusic);
	        chooseMusicIns.transform.SetParent(this.transform);
   
            musicImage = chooseMusicIns.transform.GetChild(0);
	        musicName = chooseMusicIns.transform.GetChild(1);
            //print(Resources.Load<Sprite>("bg/" + name[musicNumber]));

            musicImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("bg/" + name[musicNumber]) as Sprite;
            musicName.GetComponent<Text>().text = name[musicNumber];
            musicNumber++;
            if (musicNumber == musicNumMax) break;
	    }

    }

    


}
