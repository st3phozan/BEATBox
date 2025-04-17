using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GloveCalibration : MonoBehaviour
{
    public FistScript fsTreble, fsBass; 
    public float delay = 10f; 
    public TMP_Text instructions; 
    public bool finishCalib = false;
    public ScoreManager sm; 


    public FistScript trebleScript, bassScript;
    public Image fistBump;
    public Sprite preBump, postBump;
    public GameObject readyStart;
    public GameObject treble, bass;
    public GameObject cameraM;
    public GameObject HUD, CalibMenu;


    public float distance;


    // Start is called before the first frame update
    void Start()
    {
        finishCalib = false;
        CalibMenu.SetActive(true);
        HUD.SetActive(false);
        fistBump.sprite = preBump;
        readyStart.SetActive(false);
        StartCoroutine(RunCalibration());
    }
    IEnumerator RunCalibration(){
        instructions.text = "Get Ready to Calibrate";
        yield return new WaitForSeconds(delay);
	instructions.text = "Resting Positions";
	
        yield return new WaitForSeconds(delay);

	
        fsTreble.RestPos();
        fsBass.RestPos();
	float xMidpt = (treble.transform.position.x + bass.transform.position.x)/2;
	cameraM.transform.position = new Vector3(xMidpt, (treble.transform.position.y + .53f), treble.transform.position.z + 1.63f);
        instructions.text = "Forward Punch";

        yield return new WaitForSeconds(delay);

        fsTreble.ForwardPunch();
        fsBass.ForwardPunch();
        instructions.text = "Upper Left";

        yield return new WaitForSeconds(delay);

        fsTreble.UpperLeft();
        fsBass.UpperLeft();
        instructions.text = "Upper Right";

        yield return new WaitForSeconds(delay);

        fsTreble.UpperRight();
        fsBass.UpperRight();
        instructions.text = "Lower Left";

        yield return new WaitForSeconds(delay);

        fsTreble.LowerLeft();
        fsBass.LowerLeft();
        instructions.text = "Lower Right";

        yield return new WaitForSeconds(delay);

        fsTreble.LowerRight();
        fsBass.LowerRight();
        instructions.text = "DONE!";
        yield return new WaitForSeconds(delay);

        instructions.text = "DONE!";
        finishCalib = true;
        readyStart.SetActive(true);
        trebleScript.isCalibrate = true;
        bassScript.isCalibrate = true;

    }

    // Update is called once per frame
    void Update()
    {
	distance = Vector3.Distance(treble.transform.position, bass.transform.position);
        if (finishCalib){
            if (distance <=.2f && distance!=0){
                StartGame();
            }
        }
    }
     public void StartGame(){
        fistBump.sprite = postBump;
        StartCoroutine(BeginGameplay());

    }
    IEnumerator BeginGameplay(){
        
        yield return new WaitForSeconds(3);
        
        HUD.SetActive(true);
        sm.LevelBegin();
        CalibMenu.SetActive(false);
    }
}
