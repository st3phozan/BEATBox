using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistScript : MonoBehaviour
{
    public GameObject hitbox;
    public List<Transform> positions = new List<Transform>(); 
    public float zpos = -1.12f;
    public int points = 0;
    public ScoreManager sm;
    public bool isTitle = false, isCalibrate = false, startGame = false;
    public bool isTreble = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)){
            hitbox.transform.position = new Vector3(transform.position.x, transform.position.y, zpos);
        }
        if (Input.GetKeyDown(KeyCode.P)){
            hitbox.transform.position = new Vector3(hitbox.transform.position.x, hitbox.transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            positions[0].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            positions[1].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)){
            positions[2].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)){
            positions[3].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }



        if (Input.GetKeyDown(KeyCode.H)){
            sm.HitBass();
        }
        if (Input.GetKeyDown(KeyCode.M)){
            sm.MissTreble();
        }

       
    }
    public void RestPos(){
        hitbox.transform.position = new Vector3(transform.position.x, transform.position.y, zpos);
        Debug.Log("CalibrateRest");
    }
    public void ForwardPunch(){
        hitbox.transform.position = new Vector3(hitbox.transform.position.x, hitbox.transform.position.y, transform.position.z);
        Debug.Log("CalibrateForward");
    }
    public void UpperLeft(){
        positions[0].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Debug.Log("CalibrateUL");
    }
    public void UpperRight(){
        positions[1].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Debug.Log("CalibrateUR");
    }

    public void LowerLeft(){
        positions[2].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Debug.Log("CalibrateLL");
    }
    public void LowerRight(){
       positions[3].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Debug.Log("CalibrateLR");
    }
	void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "note")
        {
            if (isTreble){
            sm.HitTreble();
            }
            else{
            sm.HitBass();
            }
            //Debug.Log(points);
        }
        if (other.gameObject.tag == "fist")
        {
            if (isTitle){
                startGame = true;
                isTitle = false;
            }
            else if (isCalibrate){
                startGame = true;
                isCalibrate = false;
            }
        }
    }
}
