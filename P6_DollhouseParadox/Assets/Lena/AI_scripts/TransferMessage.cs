using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Voice;

public class TransferMessage : MonoBehaviour
{
    //Attach this script to the same object that has Photonview attached to it!!!
    public RecorderManager RecordingManager;
   

    private void Start()
    {
        
    }

    void SendString(string message)
   {
        PhotonView.RPC("ReceiveString", RpcTarget.Others, message);  //remote reciever call... everyone call the function and rpc.target all other players should do this. message is string(hand over with function)
    }
    [PunRPC]
    private void ReceiveString(string receivedString)
    {
        RecordingManager.saveString(receivedString);
        Debug.Log("Received string: " + receivedString);
    }

    
}
