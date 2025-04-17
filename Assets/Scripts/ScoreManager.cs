using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public float score = 0;
public float trebleScore = 0, bassScore = 0;
    public float animHitTrigger = 4, hurtResetter;
    public float total = 20; 
    public bool thresholdMet = false, gameOver = false;
    public Slider caesuraHealth; 
public GameObject caesura, scoreScreen, failScreen;

    public BossAnimationController bAC;

    public Image feedbackTreble, feedbackBass;
    public Sprite great, yikes;
    public Animator feedbackAnimTreble, feedbackAnimBass;
    public AnimationTriggers triggers;

public TMP_Text trebleScoreT, bassScoreT;
    //public AbletonTrigger aT;

    public OSCJackTestSender oscCtrl;

    public float LevelTime = 180f;
    public float LevelStartTime = 0;
    public float distance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       //score tracker and Caesura healthbar
        if (score/total >= .95){
            thresholdMet = true;     
        }
        caesuraHealth.value = score/total;

        //music timer
        float timerDuration = Time.time - LevelStartTime;
         if (timerDuration >= LevelTime){
            if (thresholdMet){
                if(!gameOver){
                EndSuccess();
                gameOver = true;
                bAC.PlayerWin();
                }
            }
            else{
                if(!gameOver){
                EndFail();
                gameOver = true;
                bAC.PlayerLoose();
                }
            }
        }
        if (hurtResetter % 4 == 0 && hurtResetter != 0){
            bAC.TriggerAngry();
            hurtResetter = 0;
        }
        
    }
    public void LevelBegin(){
        LevelStartTime = Time.time;
        StartCoroutine(LvlStart());
        oscCtrl.StartSong();
    }
    IEnumerator LvlStart(){
yield return new WaitForSeconds(2);
bAC.ActivateBoss();
	caesura.SetActive(true);
	bAC.JumpAttack();
}
    public void HitTreble(){
        score += 1;
	trebleScore +=1;
        hurtResetter += 1;
        //feedback.sprite = great;
        oscCtrl.Hit();
       feedbackAnimTreble.SetTrigger("great");
    }
    public void MissTreble(){
        //feedback.sprite = yikes;
        feedbackAnimTreble.SetTrigger("yikes");
    }
    public void HitBass(){
        score += 1;
	bassScore +=1;
        hurtResetter += 1;
        //feedback.sprite = great;
        oscCtrl.Hit();
        feedbackAnimBass.SetTrigger("great");
    }
    public void MissBass(){
        //feedback.sprite = yikes;
        feedbackAnimBass.SetTrigger("yikes");
    }
    public void EndSuccess(){
	scoreScreen.SetActive(true);
trebleScoreT.text = trebleScore.ToString();
bassScoreT.text = bassScore.ToString();
    }
    public void EndFail(){
failScreen.SetActive(true);

    }
}
