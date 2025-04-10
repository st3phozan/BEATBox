using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public ScoreManager sm;
    public bool isTreble = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "note")
        {
            Destroy(other.gameObject);
            Debug.Log("missed punch");
            if (isTreble){
                sm.MissTreble();
            }
            else{
                sm.MissBass();
            }
            
        }
    }
    
}
