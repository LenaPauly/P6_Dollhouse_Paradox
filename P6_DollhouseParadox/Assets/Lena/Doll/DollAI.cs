using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;
using UnityEngine.InputSystem.Controls;

public class DollAI : MonoBehaviour
{
    
    private Collider triggerCollider;
    //private Interactable interactable;

    private void Awake()
    {
        // interactable = GetComponent<Interactable>();
       // trigger = new InputFeatureUsage<float>("Trigger");
    }
    void Start()
    {
        
        triggerCollider = GetComponent<Collider>();
    }

    public void OnGripPerformed()
    {
        if (triggerCollider != null)
        {
            StartCoroutine(recordingRoutine());
            Debug.Log("Grip button pressed on Vive controller inside trigger collider!");
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

 

    private void HandleMessageReadComplete(string text)
    {
        Debug.Log("Received completed text: " + text);
    }

}

//public static InputFeatureUsage<1> trigger;