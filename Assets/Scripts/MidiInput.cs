using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class MidiInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
void Update()
    {
        for (int note = 0; note < 128; note++)
        {
            if (MidiMaster.GetKeyDown(note))
            {
                //Debug.Log($"MIDI Note Received: {note}");
            }
        }
    }
}
    // Update is called once per frame