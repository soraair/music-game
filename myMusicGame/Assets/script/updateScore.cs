using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateScore : MonoBehaviour {

    public static updateScore scoreIns =null ;
    public Text scoreNum;
    private int score = 0;

    private void Awake()
    {
        scoreIns = this;
    }
   
    public void AddScore(int score)
    {
        this.score += score;
        scoreNum.text = this.score.ToString();
    }

}
