using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecorderRec : MonoBehaviour
{

    public RecorderPlay recorderPlay;
    private Collider triggerCollider;

    private bool isTriggerEnabled = true;
   
    void Start()
    {
        triggerCollider = GetComponent<Collider>();
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggerEnabled && triggerCollider != other && triggerCollider != null)
        {
           // StartCoroutine(recordingRoutine());
            SpeechManager.StartSpeechRecording();
            triggerCollider.enabled = false;
            recorderPlay.EnableTrigger();
        }
    }

    private IEnumerator recordingRoutine()
    {
        SpeechManager.StartSpeechRecording();
        Debug.Log("RecorderRec script, recording started");

        yield return new WaitForSeconds(10f);

        Debug.Log("RecorderRec script, recording stopped");

        SpeechManager.StopSpeechRecording();
    }

    public void EnableTrigger()
    {
        isTriggerEnabled = true;
        triggerCollider.enabled = true;
    }

    public void DisableTrigger()
    {
        isTriggerEnabled = false;
        triggerCollider.enabled = false;    
    }
}
