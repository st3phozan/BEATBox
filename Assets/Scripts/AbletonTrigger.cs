using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class AbletonTrigger : MonoBehaviour
{public string remoteIP = "127.0.0.1";
    public int remotePort = 7500;

    private OSCTransmitter transmitter;

    void Start()
    {
        transmitter = gameObject.AddComponent<OSCTransmitter>();
        transmitter.RemoteHost = remoteIP;
        transmitter.RemotePort = remotePort;

        // Check if the transmitter is properly configured
        if (transmitter == null)
        {
            Debug.LogError("OSCTransmitter not initialized.");
        }
        else
        {
            Debug.Log($"Transmitter configured to send to {remoteIP}:{remotePort}");
        }
    }

    public void SendStartSong()
    {
        if (transmitter == null)
        {
            Debug.LogError("OSCTransmitter is null. Message not sent.");
            return;
        }

        var message = new OSCMessage("/startSong"); // No arguments
        transmitter.Send(message);

        
    }
}