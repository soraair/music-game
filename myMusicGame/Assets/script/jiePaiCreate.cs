using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class jiePaiCreate : MonoBehaviour {
   
    public GameObject jiepai;
    private GameObject jiePaiOn;
    public float timer = 1f;
    private float timing;

    List<float> music1Time = new List<float>();
    List<float> music2Time = new List<float>();
    List<float> music3Time = new List<float>();

   // List<float> timingList = new List<float>();
    List<float> jiepaiTimeList = new List<float>();//用于承载节拍时间点的集合
    private int timeIndex;

    private bool isCreate = true;

    private float randomX = 0, randomY = 0, tempX = 0, tempY = 0;
    private float AreaWidth = 1750f, AreaHeight = 800f;
    private float offsetY = -70f;

    public float interalX = 120f, interalY = 120;

    private AudioSource music;  // 播放音乐的组件

    private int sortNum = 0;

    public static bool isEnd = false;

    private string musicName;
     

    // Use this for initialization
    private void Awake()
    {

        LoadMusic();


    }
    void Start () {
        music = this.GetComponent<AudioSource>();
        musicOn();//设置加载的音乐开启

        //ClickChoose getchoose = new ClickChoose();
        //string str = getchoose.clickChoose();
        //print(str);

        timing = jiepaiTimeList[0];
        timeIndex = 0;
    }
	
	// Update is called once per frame
	void Update () {
       
        //计时器计时
            timer += Time.deltaTime;
        
        //调用方法生成节拍  
            if (timeIndex < jiepaiTimeList.Count )
             create(); 
  
    }

    public void create() //生成节拍 和 判断音乐结束并生成重新开始界面 的方法
    {
        while (Mathf.Abs(randomX - tempX) < interalX || Mathf.Abs(randomY - tempY) < interalY)
        {
            randomX = Random.Range(-AreaWidth/2, AreaWidth/2);
            randomY = Random.Range(-AreaHeight / 2 + offsetY, AreaHeight / 2 + offsetY);//音符出现位置
        }
        //Debug.Log("X " + randomX + "  Y " + randomY);
        if(timer>= timing)//到了相应的时间点就生成一个 节拍
      
        {
            jiePaiOn = Instantiate(jiepai);
            jiePaiOn.transform.SetParent(this.transform);
            jiePaiOn.transform.localPosition = new Vector3(randomX,randomY,0);
            //jiePaiOn.transform.localScale = new Vector3(1.5f,1.5f,1.5f);//音符大小
            jiePaiOn.transform.Find("sortText").GetComponent<Text>().text = "" + (++sortNum);
            if (sortNum == 10) sortNum = 0;
            if (timeIndex + 1 < jiepaiTimeList.Count)
            {
                timing = jiepaiTimeList[timeIndex + 1];
            }
            timeIndex++;
            jiePaiOn.transform.SetAsFirstSibling();//设置层级，防止 后来出现的 遮挡 先前出现的
        }


        if (timeIndex == jiepaiTimeList.Count)
        {
            isEnd = true;
        };//返回音乐结束判断

        tempX = randomX;
        tempY = randomY;
    }

    private void LoadMusic()
    {
        //获取所选择的歌曲名
        musicName = ClickChoose.chooseName;
        //print(musicName);

        //添加对应的音乐
        this.transform.GetComponent<AudioSource>().clip = Resources.Load("music/" + musicName) as AudioClip;

        //设置背景为对应的图片
        this.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("bg/" + musicName);

        //从对应歌曲名的txt获取节拍时间点string
        //string[] jiepaiInfo = File.ReadAllLines(musicName + ".txt");

        switch (musicName)
        {
            case "EveonPiano":
                {
                    LoadMusic1();
                    jiepaiTimeList = music1Time;
                    break;
                }

            case "WeightoftheWorld":
                {
                    LoadMusic2();
                    jiepaiTimeList = music2Time;
                    break;
                }
            case "GuiltyCrown":
                {
                    LoadMusic3();
                    jiepaiTimeList = music3Time;
                    break;
                }
        }
        //foreach (string temp in jiepaiInfo)  //将获取到的string 转成float
        //{
        //    jiepaiTimeList.Add(float.Parse(temp));
        //}
    }


    private void musicOn()
    {
        if(musicName == "GuiltyCrown" || musicName == "WeightoftheWorld"){
            this.music.volume = 0.13f;
        }
        else
        {
            this.music.volume = 0.23f;
        }
        music.Play();
    }

    
    private void LoadMusic3()
    {
        music3Time.Add(0.703f);
        music3Time.Add(1.430f);
        music3Time.Add(2.140f);
        music3Time.Add(2.836f);
        music3Time.Add(3.579f);
        music3Time.Add(4.284f);
        music3Time.Add(4.980f);
        music3Time.Add(5.724f);
        music3Time.Add(6.443f);
        music3Time.Add(7.108f);
        music3Time.Add(7.771f);
        music3Time.Add(8.435f);
        music3Time.Add(9.123f);
        music3Time.Add(9.861f);
        music3Time.Add(10.555f);
        music3Time.Add(11.236f);
        music3Time.Add(11.915f);
        music3Time.Add(12.603f);
        music3Time.Add(13.341f);
        music3Time.Add(14.037f);
        music3Time.Add(14.700f);
        music3Time.Add(15.397f);
        music3Time.Add(16.151f);
        music3Time.Add(16.835f);
        music3Time.Add(17.500f);
        music3Time.Add(18.205f);
        music3Time.Add(18.957f);
        music3Time.Add(19.627f);
        music3Time.Add(20.307f);
        music3Time.Add(21.003f);
        music3Time.Add(21.739f);
        music3Time.Add(22.444f);
        music3Time.Add(23.116f);
        music3Time.Add(23.779f);
        music3Time.Add(24.523f);
        music3Time.Add(25.195f);
        music3Time.Add(25.883f);
        music3Time.Add(26.563f);
        music3Time.Add(27.275f);
        music3Time.Add(27.963f);
        music3Time.Add(28.766f);
        music3Time.Add(30.214f);
        music3Time.Add(30.926f);
        music3Time.Add(31.598f);
        music3Time.Add(32.301f);
//        33.014
//33.718
//34.398
//35.085
//35.774
//36.510
//37.150
//37.502
//37.902
//38.270
//38.598
//38.942
//39.278
//39.622
//40.286
//41.022
//41.750
//42.438
//43.126
//43.774
//44.478
//45.198
//45.910
//46.590
//47.310
//47.982
//48.686
//49.382
//50.039
//50.798
//51.454
//52.198
//52.846
//53.590
//54.262
//54.918
//55.686
//56.382
//57.054
//57.702
//58.422
//59.150
//59.798
//60.558
//61.998
//62.678
//63.358
//64.022
//64.718
//65.406
//66.118
//66.814
//67.518
//68.222
//68.918
//69.566
//70.286
//71.006
//71.678
//72.350
//73.054
//73.414
//73.782
//74.142
//74.518
//74.878
//75.230
//75.614
//76.262
//76.598
//76.934
//77.286
//77.670
//78.030
//78.381
//78.726
//79.422
//80.062
//80.766
//81.470
//82.110
//82.830
//83.534
//84.254
//84.598
//84.958
//85.294
//85.726
//86.038
//86.374
//86.701
//87.046
//87.365
//87.670
//88.038
//88.406
//88.774
//89.118
//89.438
//89.805
//90.518
//91.205
//91.942
//92.654
//93.270
//93.998
//94.550
//95.110
//95.790
//96.438
//97.166
//97.830

    }

    private void LoadMusic1()
    {
        music1Time.Add(1.175f);

        music1Time.Add(1.317f);
        music1Time.Add(1.712f);
        music1Time.Add(1.978f);
        music1Time.Add(2.843f);
    }

    private void LoadMusic2()
    {
        music2Time.Add(1.175f);

        music2Time.Add(1.317f);
        music2Time.Add(1.712f);
        music2Time.Add(1.978f);
        music2Time.Add(2.843f);
    }
}
