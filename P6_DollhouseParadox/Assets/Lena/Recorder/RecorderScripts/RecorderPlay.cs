using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecorderPlay : MonoBehaviour
{

    public RecorderRec recorderRec;
    private Collider triggerCollider;
    void Start()
    {
        SpeechManager.OnMessageReadComplete += HandleMessageReadComplete;
        triggerCollider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (triggerCollider != other && triggerCollider != null)
        {
            // StartCoroutine(recordingRoutine());
            SpeechManager.StartSpeechRecording();
            triggerCollider.enabled = false;
            recorderRec.EnableTrigger();
        }
    }

    public void EnableTrigger()
    {
        triggerCollider.enabled = true;
    }

    private void HandleMessageReadComplete(string text)
    {
        // Access and use the completed _returnText
        Debug.Log("Received completed text: " + text);

        // Perform further actions with the text as needed
    }

    private void OnDestroy()
    {
        SpeechManager.OnMessageReadComplete -= HandleMessageReadComplete;
    }
}
