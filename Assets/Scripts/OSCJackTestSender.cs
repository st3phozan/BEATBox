using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OscJack;

public class OSCJackTestSender : MonoBehaviour
{
    OscClient client;
public float msgNum = 0;

    void Start()
    {
        // Set up the OSC client with IP and port
        client = new OscClient("127.0.0.1", 7500);
        Debug.Log("📡 OSCJack client ready to send to 127.0.0.1:8000");
    }

    void Update()
    {
	client.Send("/hit", msgNum);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            client.Send("/startSong");  // Send OSC message with no arguments
            Debug.Log("🔥 Sent OSC /startSong");
        }
    }
    public void StartSong(){
        client.Send("/startSong");  // Send OSC message with no arguments
        Debug.Log("🔥 Sent OSC /startSong");
    }
     public void Hit(){
        //client.Send("/hit", 1.0f);  // Send OSC message with no arguments
msgNum = 1.0f;
        Debug.Log("🔥 Sent OSC /hit");
StartCoroutine(ResetLight());
    }
	IEnumerator ResetLight(){
yield return new WaitForSeconds(1f);
msgNum = 0.0f;
}
    void OnDestroy()
    {
        client.Dispose(); // Proper cleanup
    }
}
