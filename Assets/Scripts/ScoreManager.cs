using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float score = 0;
    public float total = 20; 
    public bool thresholdMet = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score/total >= .8){
            thresholdMet = true;
        }
        
    }
    public void EndGame(){

    }
}
