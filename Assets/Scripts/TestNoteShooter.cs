using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class TestNoteShooter : MonoBehaviour
{
    public GameObject testNote;
    public Transform ldown, lup, rdown, rup, forward;
    public int currMidi;
    public List<Transform> positions = new List<Transform>(); 
    public List<int> midiNotes = new List<int>(); 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         for (int note = 0; note < 128; note++)
        {
            if (MidiMaster.GetKeyDown(note))
            {
                if (MidiMaster.GetKeyDown(note) && note== midiNotes[0]){
            GameObject NewNote = Instantiate(testNote, forward.position, Quaternion.identity);
            NewNote.GetComponent<TestNote>().target = positions[0];
        }
        else if (MidiMaster.GetKeyDown(note) && note== midiNotes[1]){
            GameObject NewNote =Instantiate(testNote, ldown.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            NewNote.GetComponent<TestNote>().target = positions[1];
        }
        else if (MidiMaster.GetKeyDown(note) && note== midiNotes[2]){
            GameObject NewNote =Instantiate(testNote, rdown.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            NewNote.GetComponent<TestNote>().target = positions[2];
        }
        else if (MidiMaster.GetKeyDown(note)&&note == midiNotes[3]){
            GameObject NewNote =Instantiate(testNote, lup.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            NewNote.GetComponent<TestNote>().target = positions[3];
    }
    else if (MidiMaster.GetKeyDown(note)&&note == midiNotes[4]){
            GameObject NewNote =Instantiate(testNote, rup.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            NewNote.GetComponent<TestNote>().target = positions[4];
    }
                //Debug.Log($"MIDI Note Received: {note}");
            }
        }
        
        if (Input.GetKeyDown(KeyCode.A)){
            GameObject NewNote = Instantiate(testNote, forward.position, Quaternion.identity);
            NewNote.GetComponent<TestNote>().target = positions[0];
        }
        else if (Input.GetKeyDown(KeyCode.W)){
            GameObject NewNote =Instantiate(testNote, ldown.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            NewNote.GetComponent<TestNote>().target = positions[1];
        }
        else if (Input.GetKeyDown(KeyCode.S)){
            GameObject NewNote =Instantiate(testNote, rup.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            NewNote.GetComponent<TestNote>().target = positions[2];
        }
        
    }
    public void ShootNote(){
        
    }
}
