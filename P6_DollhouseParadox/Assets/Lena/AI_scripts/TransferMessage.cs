using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Voice;

public class TransferMessage : MonoBehaviourPun
{
    private string _recognizedSpeechFromOtherPlayer = "";   // If you want to do things further with the string, you can save it here or elsewhere

    private void Start()
    {
        SpeechManager.OnNewRecognizedText += SendStringToOtherPlayers;  // Subscribe to the SpeechManager to receive the recorded text
    }

    // When you receive a new recorded text, send it to the other players immediately via the photonView component.
    public void SendStringToOtherPlayers(string message)
    {
        photonView.RPC("ReceiveString", RpcTarget.Others, message); // Calls the "ReceiveString" function only on other players and hands over "message".
        // Note: you can hand over more variables if needed. Just add another set of ", *variable here*" to the brackets. Ofc the function you defined
        // has to also take these kinds of variables (like mine takes a string only, so I only have ", *myString*" and nothing more.)
    }

    // This function can be called via the network by other players (needs a photonView component on this object to do so) 
    [PunRPC]
    private void ReceiveString(string receivedString)
    {
        _recognizedSpeechFromOtherPlayer = receivedString;  // Saves the string received from the other player
        SpeechManager.StartReadMessage(receivedString); // Tells the speech manager to start converting to chatGPT and reading out the message.
        // Replace the above line with what you want to once the other players receive the string.

        Debug.Log("Received string: " + receivedString);
    }


}
