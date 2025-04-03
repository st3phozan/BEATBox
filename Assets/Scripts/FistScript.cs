using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistScript : MonoBehaviour
{
    public GameObject hitbox;
    public List<Transform> positions = new List<Transform>(); 
    public float zpos = -1.12f;
    public int points = 0;
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
       
    }
	void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "note")
        {
            points +=1;
            Debug.Log(points);
        }
    }
}
