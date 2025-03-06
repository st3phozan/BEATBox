using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNoteShooter : MonoBehaviour
{
    public GameObject testNote;
    public Transform down, up, forward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)){
            Instantiate(testNote, forward.position, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.W)){
            Instantiate(testNote, down.position, Quaternion.Euler(new Vector3(90, 0, 0)));
        }
        else if (Input.GetKeyDown(KeyCode.S)){
            Instantiate(testNote, up.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        }
    }
    public void ShootNote(){
        
    }
}
