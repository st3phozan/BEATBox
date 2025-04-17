using UnityEngine;
using OscJack;

public class OSCJackTestSender : MonoBehaviour
{
    OscClient client;

    void Start()
    {
        // Set up the OSC client with IP and port
        client = new OscClient("127.0.0.1", 7500);
        Debug.Log("📡 OSCJack client ready to send to 127.0.0.1:8000");
    }

    void Update()
    {
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
        client.Send("/hit");  // Send OSC message with no arguments
        Debug.Log("🔥 Sent OSC /hit");
    }
    void OnDestroy()
    {
        client.Dispose(); // Proper cleanup
    }
}
