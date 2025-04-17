using UnityEngine;
using extOSC;

public class SimpleOSCSender : MonoBehaviour
{
    private OSCTransmitter transmitter;

    void Start()
    {
        transmitter = gameObject.AddComponent<OSCTransmitter>();
        transmitter.RemoteHost = "127.0.0.1";  // local test
        transmitter.RemotePort = 7500;

        SendTestMessage();
    }

    void SendTestMessage()
    {
        var message = new OSCMessage("/startSong");
        transmitter.Send(message);
        Debug.Log("🔥 Sent /startSong to 127.0.0.1:8000");
    }
}
