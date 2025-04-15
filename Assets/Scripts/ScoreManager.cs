using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float score = 0;
    public float total = 20; 
    public bool thresholdMet = false;
    public Slider caesuraHealth; 

    public Image feedbackTreble, feedbackBass;
    public Sprite great, yikes;
    public Animator feedbackAnimTreble, feedbackAnimBass;

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
        if (score/total >= .8){
            thresholdMet = true;     
        }
        caesuraHealth.value = score/total;

        //music timer
        float timerDuration = Time.time - LevelStartTime;
         if (timerDuration >= LevelTime){
            if (thresholdMet){
                EndSuccess();
            }
            else{
                EndFail();
            }
        }
        
    }
    public void LevelBegin(){
        LevelStartTime = Time.time;
    }
    public void HitTreble(){
        score += 1;
        //feedback.sprite = great;
        feedbackAnimTreble.SetTrigger("great");
    }
    public void MissTreble(){
        //feedback.sprite = yikes;
        feedbackAnimTreble.SetTrigger("yikes");
    }
    public void HitBass(){
        score += 1;
        //feedback.sprite = great;
        feedbackAnimBass.SetTrigger("great");
    }
    public void MissBass(){
        //feedback.sprite = yikes;
        feedbackAnimBass.SetTrigger("yikes");
    }
    public void EndSuccess(){

    }
    public void EndFail(){

    }
}
