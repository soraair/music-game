using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;
using Image = UnityEngine.UI.Image;

public class jiePaiWaitClick : MonoBehaviour ,IPointerClickHandler,IPointerEnterHandler{
    public float clickTime = 1;
    private float timer = 0;
    private bool isClick = false;
    private Image coldImage;
    public GameObject judgement;
    private GameObject judgementIns;
    private string judgeText;
    private bool isComb = false;
    private static int combHit = 0;
  
   
   

    // Use this for initialization
    void Start ()
    {
        coldImage = transform.Find("onClick").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
       // Debug.Log( this.transform.parent.transform.parent);
        timer += Time.deltaTime;
       
        coldImage.fillAmount = (clickTime - timer) / clickTime;
       if(isClick)
        {
           
            if (coldImage.fillAmount < 0.07)
            {
               
                isComb = true;
                judgeText = "perfect";
                updateScore.scoreIns.AddScore(1000);
                judgementCreate();
               
            }
                
            else if (coldImage.fillAmount < 0.25)
            {
              
                isComb = true;
                updateScore.scoreIns.AddScore(500);
                judgeText = "great";
                judgementCreate();
               
            }
              
            else
            {
               
                isComb = false;
                judgeText = "bad";
                judgementCreate();
               
            }
           
            Destroy(this.gameObject);

            isClick = false;
        }
        if (clickTime+0.15 < timer)
        {
            isComb = false;
            judgeText = "miss";
            judgementCreate();
          

            Destroy(this.gameObject);
     
        }

       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       
        if (eventData.pointerPress==this.gameObject)   
         isClick = true; 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {   
            
            if (Input.GetKeyDown("z"))
                isClick = true;
            
    }

    public void judgementCreate()
    {
        judgement.transform.Find("judgementText").GetComponent<Text>().text = judgeText;
        judgementIns = Instantiate(judgement);
        judgementIns.transform.localPosition = new Vector3(transform.position.x, transform.position.y, 0);
        judgementIns.transform.localScale =  new Vector3(2.5f,2.5f,2.5f);
        judgementIns.transform.SetParent(transform.parent);
       
        if (isComb == true)
        {
            judgementIns.transform.Find("combText").GetComponent<Text>().text = "Comb" + (++combHit );
        }
        else
        {
            judgementIns.transform.Find("combText").GetComponent<Text>().text = "";
            combHit = 0;
        }
           

        judgementIns.transform.SetAsFirstSibling();
        Destroy(judgementIns, 1f);
    }

 
}
