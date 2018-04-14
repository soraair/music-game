using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateScore : MonoBehaviour {

    //public static updateScore scoreIns =null ;
    public Text scoreNum;
    private int score = 0;
    public Text comb;
    private int combHit = 0;

    private void Awake()
    {
        //scoreIns = this;
        comb = GameObject.Find("Comb/CombNum").GetComponent<Text>();
    }
   
    public void AddScore(int score)
    {
        //Debug.Log(this.score);
        this.score += score;
        //Debug.Log(scoreNum);
        scoreNum.text = this.score.ToString();
        comb.text = (++combHit).ToString(); 
    }

    public void CleanComb()
    {
        combHit = 0;
        comb.text = combHit.ToString();
    }

}
